using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WolfIsland
{
    public class IslandRenderer
    {
        // стиль та шрифти
        private readonly Font labelFont = new Font("Arial", 8, FontStyle.Bold);
        private readonly Font emojiFont = new Font("Segoe UI Emoji", 14);
        private readonly Font countFont = new Font("Arial", 9, FontStyle.Bold);
        private readonly Font cleanFont = new Font("Arial", 9, FontStyle.Bold);
        private readonly Font miniFont = new Font("Arial", 8, FontStyle.Bold);

        private readonly StringFormat centerSf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        private readonly Pen gridPen = new Pen(Color.FromArgb(60, 60, 60), 1);
        private readonly Pen radarPen = new Pen(Color.Yellow, 2);

        private readonly Brush huntBrush = new SolidBrush(Color.FromArgb(80, 255, 50, 50));
        private readonly Brush breedBrush = new SolidBrush(Color.FromArgb(80, 150, 50, 255));
        private readonly Brush radarBgBrush = new SolidBrush(Color.FromArgb(230, 20, 20, 20));

        public void Draw(Graphics g, SimulationEngine engine, int cellSize, Point hoveredCell, int pbWidth, int pbHeight)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int offset = 20;

            // малюємо сітку та позначки
            for (int i = 0; i < engine.GridSize; i++)
            {
                char letter = (char)('A' + i);
                g.DrawString(letter.ToString(), labelFont, Brushes.DarkGray, new RectangleF(offset + i * cellSize, 0, cellSize, offset), centerSf);
                g.DrawString((i + 1).ToString(), labelFont, Brushes.DarkGray, new RectangleF(0, offset + i * cellSize, offset, cellSize), centerSf);
            }

            for (int i = 0; i <= engine.GridSize; i++)
            {
                g.DrawLine(gridPen, offset + i * cellSize, offset, offset + i * cellSize, offset + engine.GridSize * cellSize);
                g.DrawLine(gridPen, offset, offset + i * cellSize, offset + engine.GridSize * cellSize, offset + i * cellSize);
            }

            // аналізую дані для кожної клітинки
            var cellData = new Dictionary<Point, (int r, int m, int f)>();

            foreach (var r in engine.Rabbits)
            {
                var pt = new Point(r.X, r.Y);
                if (!cellData.ContainsKey(pt)) cellData[pt] = (0, 0, 0);
                cellData[pt] = (cellData[pt].r + 1, cellData[pt].m, cellData[pt].f);
            }
            foreach (var p in engine.Predators)
            {
                var pt = new Point(p.X, p.Y);
                if (!cellData.ContainsKey(pt)) cellData[pt] = (0, 0, 0);
                if (p.IsFemale) cellData[pt] = (cellData[pt].r, cellData[pt].m, cellData[pt].f + 1);
                else cellData[pt] = (cellData[pt].r, cellData[pt].m + 1, cellData[pt].f);
            }

            // малювання тварин у клітинках
            foreach (var kvp in cellData)
            {
                int x = kvp.Key.X;
                int y = kvp.Key.Y;
                int rCount = kvp.Value.r;
                int mCount = kvp.Value.m;
                int fCount = kvp.Value.f;

                float drawX = offset + x * cellSize;
                float drawY = offset + y * cellSize;
                RectangleF rect = new RectangleF(drawX, drawY, cellSize, cellSize);

                // візуальні підказки для конфліктів
                if (rCount > 0 && (mCount > 0 || fCount > 0)) g.FillRectangle(huntBrush, rect);      // червона: полювання
                else if (mCount > 0 && fCount > 0) g.FillRectangle(breedBrush, rect);                // фіолетова: розмноження

                int types = (rCount > 0 ? 1 : 0) + (mCount > 0 ? 1 : 0) + (fCount > 0 ? 1 : 0);

                if (types == 1)
                {
                    // у клітинці лише один вид
                    if (rCount > 0)
                    {
                        g.DrawString("🐰", emojiFont, Brushes.White, rect, centerSf);
                        if (rCount > 1) g.DrawString(rCount.ToString(), countFont, Brushes.LightGreen, drawX + cellSize - 12, drawY + cellSize - 14);
                    }
                    else if (mCount > 0)
                    {
                        g.FillEllipse(Brushes.CadetBlue, drawX + 4, drawY + 4, cellSize - 8, cellSize - 8);
                        g.DrawString("🐺", emojiFont, Brushes.White, rect, centerSf);
                        if (mCount > 1) g.DrawString(mCount.ToString(), countFont, Brushes.Yellow, drawX + cellSize - 12, drawY + cellSize - 14);
                    }
                    else if (fCount > 0)
                    {
                        g.FillEllipse(Brushes.HotPink, drawX + 4, drawY + 4, cellSize - 8, cellSize - 8);
                        g.DrawString("🦊", emojiFont, Brushes.White, rect, centerSf);
                        if (fCount > 1) g.DrawString(fCount.ToString(), countFont, Brushes.Yellow, drawX + cellSize - 12, drawY + cellSize - 14);
                    }
                }
                else
                {
                    // конфлікт: кілька видів у клітинці
                    int rows = types;
                    float dotSize = 6;
                    float rowHeight = 12;
                    float totalHeight = rows * rowHeight;

                    float startY = drawY + (cellSize - totalHeight) / 2f;
                    float startX = drawX + (cellSize - 20) / 2f;
                    float currentY = startY;

                    if (rCount > 0)
                    {
                        g.FillEllipse(Brushes.White, startX, currentY + 3, dotSize, dotSize);
                        g.DrawString(rCount.ToString(), miniFont, Brushes.White, startX + dotSize + 3, currentY);
                        currentY += rowHeight;
                    }
                    if (mCount > 0)
                    {
                        g.FillEllipse(Brushes.LightSkyBlue, startX, currentY + 3, dotSize, dotSize);
                        g.DrawString(mCount.ToString(), miniFont, Brushes.LightSkyBlue, startX + dotSize + 3, currentY);
                        currentY += rowHeight;
                    }
                    if (fCount > 0)
                    {
                        g.FillEllipse(Brushes.HotPink, startX, currentY + 3, dotSize, dotSize);
                        g.DrawString(fCount.ToString(), miniFont, Brushes.HotPink, startX + dotSize + 3, currentY);
                    }
                }
            }

            // підсвічування наведеної клітинки та показ інформації
            if (hoveredCell.X >= 0 && hoveredCell.Y >= 0)
            {
                g.DrawRectangle(radarPen, offset + hoveredCell.X * cellSize, offset + hoveredCell.Y * cellSize, cellSize, cellSize);

                var pt = new Point(hoveredCell.X, hoveredCell.Y);
                if (cellData.ContainsKey(pt))
                {
                    string info = $"Клітинка [{(char)('A' + hoveredCell.X)}{hoveredCell.Y + 1}]\n";
                    info += "------------------\n";
                    if (cellData[pt].r > 0) info += $"Кроликів: {cellData[pt].r}\n";
                    if (cellData[pt].m > 0) info += $"Вовків: {cellData[pt].m}\n";
                    if (cellData[pt].f > 0) info += $"Вовчиць: {cellData[pt].f}";

                    info = info.TrimEnd('\n');

                    SizeF txtSize = g.MeasureString(info, cleanFont);

                    float tX = offset + hoveredCell.X * cellSize + cellSize;
                    float tY = offset + hoveredCell.Y * cellSize + cellSize;

                    if (tX + txtSize.Width + 10 > pbWidth) tX = pbWidth - txtSize.Width - 10;
                    if (tY + txtSize.Height + 10 > pbHeight) tY = pbHeight - txtSize.Height - 10;

                    g.FillRectangle(radarBgBrush, tX, tY, txtSize.Width + 10, txtSize.Height + 10);
                    g.DrawRectangle(Pens.White, tX, tY, txtSize.Width + 10, txtSize.Height + 10);
                    g.DrawString(info, cleanFont, Brushes.White, tX + 5, tY + 5);
                }
            }
        }
    }
}