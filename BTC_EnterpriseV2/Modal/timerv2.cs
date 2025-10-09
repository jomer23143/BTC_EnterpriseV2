using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTC_EnterpriseV2.Modal
{
    public partial class timerv2 : Form
    {
        private System.Windows.Forms.Timer mainTimer;
        private Dictionary<int, TimeSpan> elapsedTimes = new Dictionary<int, TimeSpan>();
        private HashSet<int> runningTimers = new HashSet<int>();

        private List<TaskItem> taskList = new List<TaskItem>();
        public timerv2()
        {
            InitializeComponent();
            taskList = new List<TaskItem>()
                {
                    new TaskItem(){ TaskName="Task 1",TimeDisplay = "00:23:04"},
                    new TaskItem(){ TaskName="Task 2",TimeDisplay = "00:03:30"},
                    new TaskItem(){ TaskName ="Task 3" , TimeDisplay = "00:05:08"}
                };

            sfDataGrid1.DataSource = taskList;
            //this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "TaskName", HeaderText = "TaskName", Width = 200 });
            //this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "TimeDisplay", HeaderText = "TimeDisplay", MinimumWidth = 150 });
            CellStyleInfo cellStyleInfo = new CellStyleInfo();
            cellStyleInfo.HorizontalAlignment = HorizontalAlignment.Center;
            List<CellButton> button_add = new List<CellButton>();
            button_add.Add(new CellButton() { Text = "Start", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
            List<CellButton> button_scan = new List<CellButton>();
            button_scan.Add(new CellButton() { Text = "Pause", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
            List<CellButton> button_stop = new List<CellButton>();
            button_stop.Add(new CellButton() { Text = "Stop", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
            this.sfDataGrid1.Columns.Add(new GridButtonColumn() { Buttons = button_add, MappingName = "start", AllowDefaultButtonText = true, Width = 100, CellStyle = cellStyleInfo, Orientation = Orientation.Vertical });
            this.sfDataGrid1.Columns.Add(new GridButtonColumn() { Buttons = button_scan, MappingName = "pause", AllowDefaultButtonText = true, Width = 100, CellStyle = cellStyleInfo, Orientation = Orientation.Vertical });
            this.sfDataGrid1.Columns.Add(new GridButtonColumn() { Buttons = button_stop, MappingName = "stop", AllowDefaultButtonText = true, Width = 100, CellStyle = cellStyleInfo, Orientation = Orientation.Vertical });



        }

        public class TaskItem
        {
            public string TaskName { get; set; }
            public string TimeDisplay { get; set; } = "00:00:00";
            public bool IsRunning { get; set; }

            // Internal fields (not bound)
            [System.ComponentModel.Browsable(false)]
            public DateTime StartTime { get; set; }

            [System.ComponentModel.Browsable(false)]
            public TimeSpan Elapsed { get; set; } = TimeSpan.Zero;

            [System.ComponentModel.Browsable(false)]
            public System.Windows.Forms.Timer Timer { get; set; }
        }
        private void timerv2_Load(object sender, EventArgs e)
        {


        }


        private void sfDataGrid1_CellButtonClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            var rowData = sfDataGrid1.SelectedItem as TaskItem;
            //var okb = rowData[] as TaskItem;
            if (rowData == null) return;

            if (e.Column.MappingName == "start")
                StartTimer(rowData);
            else if (e.Column.MappingName == "pause")
                PauseTimer(rowData);
            else if (e.Column.MappingName == "stop")
                StopTimer(rowData);
        }
        private void StartTimer(TaskItem task)
        {
            if (task.Timer == null)
            {
                task.Timer = new System.Windows.Forms.Timer();
                task.Timer.Interval = 1000; // 1 second
                task.Timer.Tick += (s, e) =>
                {
                    var timestart = TimeSpan.Parse(task.TimeDisplay);
                    var totalElapsed = timestart + task.Elapsed + TimeSpan.FromSeconds(1);
                    task.TimeDisplay = totalElapsed.ToString(@"hh\:mm\:ss");
                    //task.Elapsed = task.Elapsed.Add(TimeSpan.FromSeconds(1));
                    //task.TimeDisplay = task.Elapsed.ToString(@"hh\:mm\:ss");
                    sfDataGrid1.Refresh(); // Update grid display
                };
            }

            if (!task.IsRunning)
            {
                task.IsRunning = true;
                task.Timer.Start();
            }
        }

        private void PauseTimer(TaskItem task)
        {
            if (task.IsRunning && task.Timer != null)
            {
                task.Timer.Stop();
                task.IsRunning = false;
            }
        }

        private void StopTimer(TaskItem task)
        {
            if (task.Timer != null)
            {
                task.Timer.Stop();
            }
            task.IsRunning = false;
            task.Elapsed = TimeSpan.Zero;
            task.TimeDisplay = "00:00:00";
            sfDataGrid1.Refresh();
            //BTC_EnterpriseV2.Modal.timer frm = new Modal.timer();
            //frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BTC_EnterpriseV2.Modal.timer frm = new Modal.timer();
            frm.Show();
        }
    }
}
