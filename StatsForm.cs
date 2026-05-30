using System;
using System.Drawing;
using System.Windows.Forms;

namespace WolfIsland
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
            SetupChart();
        }

        // налаштування графіка
        private void SetupChart()
        {
            if (chartStats != null && chartStats.ChartAreas.Count > 0)
            {
                chartStats.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
                chartStats.ChartAreas[0].AxisX.Interval = 100;
                chartStats.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
                chartStats.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            }
        }

        // графік буде викликати цей метод, щоб додати нові точки
        public void UpdateChart(int step, int rabbits, int males, int females)
        {
            if (chartStats != null)
            {
                chartStats.Series[0].Points.AddXY(step, rabbits);
                chartStats.Series[1].Points.AddXY(step, males);
                chartStats.Series[2].Points.AddXY(step, females);
            }
        }

        // лог буде викликати цей метод, щоб додати нові повідомлення
        public void AddLogMessage(string message)
        {
            if (logBox != null)
            {
                logBox.Items.Add(message);
                logBox.TopIndex = logBox.Items.Count - 1; // авто-прокрутка
            }
        }

        // очищення при скиданні симуляції
        public void ClearData()
        {
            if (chartStats != null)
            {
                chartStats.Series[0].Points.Clear();
                chartStats.Series[1].Points.Clear();
                chartStats.Series[2].Points.Clear();
            }
            if (logBox != null) logBox.Items.Clear();
        }

        // кнопка для ручного очищення логів
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            if (logBox != null) logBox.Items.Clear();
        }

        // при закритті форми просто ховаю її, щоб не втрачати дані
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            base.OnFormClosing(e);
        }
    }
}