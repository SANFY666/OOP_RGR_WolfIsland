using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace WolfIsland
{
    public partial class Form1 : Form
    {
        private SimulationEngine engine;
        private int stepCounter = 0;
        private Point hoveredCell = new Point(-1, -1);
        private StatsForm statsWindow;
        private IslandRenderer renderer = new IslandRenderer();
        private Random rand = new Random();

        private int CellSize
        {
            get
            {
                int offset = 20; // відступ для координат
                int minSize = Math.Min(pbIsland.Width, pbIsland.Height); // квадратна карта
                return Math.Max(5, (minSize - offset - 10) / 20);
            }
        }

        public Form1()
        {
            InitializeComponent();

            engine = new SimulationEngine(20);
            this.DoubleBuffered = true;

            // малювання та кліки по сітці
            pbIsland.Paint += PbIsland_Paint;
            pbIsland.MouseClick += PbIsland_MouseClick;
            pbIsland.MouseMove += PbIsland_MouseMove;

            // повзунок до швидкості таймера 
            if (speedSlider != null)
            {
                speedSlider.Scroll += (s, e) =>
                {
                    // зміна швидкості повзунком
                    mainTimer.Interval = 1000 / speedSlider.Value;

                    // оновлення тексту
                    if (lblSpeedValue != null)
                    {
                        lblSpeedValue.Text = $"Швидкість: x{speedSlider.Value}";
                    }
                };
            }

            engine.InitializePopulation();
            WriteLogsToBox(); // стартові події
            UpdateUI();
        }

        // наведення мишки на карту
        private void PbIsland_MouseMove(object sender, MouseEventArgs e)
        {
            int offset = 20;
            if (e.X >= offset && e.Y >= offset)
            {
                int gridX = (e.X - offset) / CellSize;
                int gridY = (e.Y - offset) / CellSize;

                if (gridX >= 0 && gridX < engine.GridSize && gridY >= 0 && gridY < engine.GridSize)
                {
                    if (gridX != hoveredCell.X || gridY != hoveredCell.Y)
                    {
                        hoveredCell = new Point(gridX, gridY);
                        pbIsland.Invalidate(); // оновлення карти
                    }
                    return;
                }
            }

            // прибрали мишку з карти
            if (hoveredCell.X != -1)
            {
                hoveredCell = new Point(-1, -1);
                pbIsland.Invalidate();
            }
        }

        // клік по карті для додавання тварин
        private void PbIsland_MouseClick(object sender, MouseEventArgs e)
        {
            int offset = 20;
            if (e.X < offset || e.Y < offset) return;

            int gridX = (e.X - offset) / CellSize;
            int gridY = (e.Y - offset) / CellSize;

            if (gridX < 0 || gridX >= engine.GridSize || gridY < 0 || gridY >= engine.GridSize) return;

            if (e.Button == MouseButtons.Left)
            {
                engine.Rabbits.Add(new Rabbit(gridX, gridY));
                AddLogMessage($"👆 +Кролик [{(char)('A' + gridX)}{gridY + 1}]");
            }
            else if (e.Button == MouseButtons.Right)
            {
                bool isFemale = rand.NextDouble() > 0.5;
                engine.Predators.Add(new Predator(gridX, gridY, isFemale) { Energy = 1.0 });
                AddLogMessage($"👆 +{(isFemale ? "Вч" : "В")} [{(char)('A' + gridX)}{gridY + 1}]");
            }

            UpdateUI();
        }

        // метод для виконання кроку симуляції
        private void RunStep()
        {
            int prevRabbits = engine.Rabbits.Count;
            int prevPredators = engine.Predators.Count;

            stepCounter++;
            engine.PerformStep(stepCounter);

            WriteLogsToBox();

            // вимирання кроликів
            if (prevRabbits > 0 && engine.Rabbits.Count == 0)
            {
                AddLogMessage("☠️ Кролики вимерли.");
                mainTimer.Enabled = false; // Зупиняємо таймер
            }

            // вимирання хижаків
            if (prevPredators > 0 && engine.Predators.Count == 0)
            {
                AddLogMessage("☠️ Хижаки вимерли.");
                mainTimer.Enabled = false; // Зупиняємо таймер
            }

            // острів пустий
            if (engine.Rabbits.Count == 0 && engine.Predators.Count == 0 && (prevRabbits > 0 || prevPredators > 0))
            {
                AddLogMessage("🌍 Острів пустий.");
                mainTimer.Enabled = false;
            }

            UpdateUI();
        }

        // додавання повідомлення в лог
        private void AddLogMessage(string message)
        {
            if (statsWindow != null && !statsWindow.IsDisposed)
            {
                statsWindow.AddLogMessage(message);
            }
        }

        // запис всіх логів з движка в лог-бокс
        private void WriteLogsToBox()
        {
            foreach (var log in engine.EventLog)
            {
                AddLogMessage(log);
            }
        }

        // оновлення UI: карта, статистика та графік
        private void UpdateUI()
        {
            pbIsland.Invalidate(); // перемальовка карти

            // кількість тварин
            int maleCount = engine.Predators.Count(p => !p.IsFemale);
            int femaleCount = engine.Predators.Count(p => p.IsFemale);

            // оновлення статистики в lblStats
            if (lblStats != null)
            {
                lblStats.Text = $"🐰 Кролики: {engine.Rabbits.Count}\n" +
                                $"🐺 Вовки (♂): {maleCount}\n" +
                                $"🦊 Вовчиці (♀): {femaleCount}\n" +
                                $"⏳ Крок:    {stepCounter}";
            }

            // оновлення графіка в StatsForm
            if (statsWindow != null && !statsWindow.IsDisposed)
            {
                statsWindow.UpdateChart(stepCounter, engine.Rabbits.Count, maleCount, femaleCount);
            }
        }

        // малювання карти
        private void PbIsland_Paint(object sender, PaintEventArgs e)
        {
            renderer.Draw(e.Graphics, engine, CellSize, hoveredCell, pbIsland.Width, pbIsland.Height);
        }

        // кнопка для запуску/паузи симуляції
        private void btnStart_Click(object sender, EventArgs e) => mainTimer.Enabled = !mainTimer.Enabled;

        // кнопка для виконання одного кроку
        private void btnStep_Click(object sender, EventArgs e) => RunStep();

        // кнопка для скидання симуляції
        private void btnReset_Click(object sender, EventArgs e)
        {
            mainTimer.Enabled = false;
            stepCounter = 0;

            // очищення логів в StatsForm
            if (statsWindow != null && !statsWindow.IsDisposed)
            {
                statsWindow.ClearData();
            }

            engine.InitializePopulation();
            WriteLogsToBox();

            UpdateUI();
        }

        // таймер для автоматичного виконання кроків
        private void mainTimer_Tick(object sender, EventArgs e) => RunStep();

        // кнопка для виклику катастрофи (епідемії)
        private void btnDisaster_Click(object sender, EventArgs e)
        {
            if (engine.Rabbits.Count > 1)
            {
                int initialCount = engine.Rabbits.Count;
                Random rand = new Random();

                for (int i = engine.Rabbits.Count - 1; i >= 0; i--)
                {
                    // 50% шанс померти від епідемії для кожної окремої особини
                    if (rand.NextDouble() < 0.5)
                    {
                        engine.Rabbits.RemoveAt(i);
                    }
                }

                int killed = initialCount - engine.Rabbits.Count;

                if (killed > 0)
                {
                    AddLogMessage($"Епідемія: загинуло {killed} кроликів");
                    UpdateUI();
                }
            }
        }

        // відкрити аналітику
        private void btnShowStats_Click(object sender, EventArgs e)
        {
            if (statsWindow == null || statsWindow.IsDisposed)
            {
                statsWindow = new StatsForm();
                statsWindow.Show();
            }
            else
            {
                if (!statsWindow.Visible)
                {
                    statsWindow.Show();
                }
                statsWindow.BringToFront(); 
            }
        }
    }
}
    
