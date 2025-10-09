using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Services.CircuitBreaker;
using Org.BouncyCastle.Asn1.X509;
using Syncfusion.WinForms.SmithChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static BTC_EnterpriseV2.Class.GetBoomItemID_Class;

namespace BTC_EnterpriseV2.Modal
{
    public partial class timer : Form
    {
        private System.Windows.Forms.Timer mainTimer;
        private Dictionary<int, TimeSpan> elapsedTimes = new Dictionary<int, TimeSpan>();
        private HashSet<int> runningTimers = new HashSet<int>();

        public timer()
        {
            InitializeComponent();
            SetupDataGridView();

        }
        private void SetupDataGridView()
        {
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("time", "Time");

            DataGridViewButtonColumn startBtn = new DataGridViewButtonColumn();
            startBtn.Name = "start";
            startBtn.HeaderText = "Start";
            startBtn.Text = "Start";
            startBtn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(startBtn);

            DataGridViewButtonColumn pauseBtn = new DataGridViewButtonColumn();
            pauseBtn.Name = "pause";
            pauseBtn.HeaderText = "Pause";
            pauseBtn.Text = "Pause";
            pauseBtn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(pauseBtn);

            DataGridViewButtonColumn resetBtn = new DataGridViewButtonColumn();
            resetBtn.Name = "reset";
            resetBtn.HeaderText = "Reset";
            resetBtn.Text = "Reset";
            resetBtn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(resetBtn);

            // Add some sample rows
            dataGridView1.Rows.Add("Timer 1", "00:00:00");
            dataGridView1.Rows.Add("Timer 2", "00:00:00");
            dataGridView1.Rows.Add("Timer 3", "00:00:00");

        }
        private void timer_Load(object sender, EventArgs e)
        {
            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 1000; // 1 second
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();

            // Initialize timers for each row
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                elapsedTimes[i] = TimeSpan.Zero;
            }

        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            foreach (int rowIndex in runningTimers.ToList())
            {
                elapsedTimes[rowIndex] = elapsedTimes[rowIndex].Add(TimeSpan.FromSeconds(1));
                dataGridView1.Rows[rowIndex].Cells["time"].Value = elapsedTimes[rowIndex].ToString(@"hh\:mm\:ss");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnName == "start")
            {
                runningTimers.Add(e.RowIndex);
            }
            else if (columnName == "pause")
            {
                runningTimers.Remove(e.RowIndex);
            }
            else if (columnName == "reset")
            {
                runningTimers.Remove(e.RowIndex);
                elapsedTimes[e.RowIndex] = TimeSpan.Zero;
                dataGridView1.Rows[e.RowIndex].Cells["time"].Value = "00:00:00";
            }
        }
    }
}
