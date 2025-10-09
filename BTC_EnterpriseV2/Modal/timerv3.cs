using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
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
    public partial class timerv3 : Form
    {
        private List<TaskTimer> taskList;
        private Dictionary<TaskTimer, System.Windows.Forms.Timer> timers;
        public timerv3()
        {
            InitializeComponent();
            taskList = new List<TaskTimer>
        {
            new TaskTimer { TaskName = "Task A",StartTime = "00:03:03", Elapsed = TimeSpan.Zero },
            new TaskTimer { TaskName = "Task B",StartTime = "00:10:29", Elapsed = TimeSpan.Zero },
            new TaskTimer { TaskName = "Task C",StartTime = "00:14:54", Elapsed = TimeSpan.Zero }
        };

            timers = new Dictionary<TaskTimer, System.Windows.Forms.Timer>();

            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.DataSource = taskList;

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "TaskName", HeaderText = "Task" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "StartTime", HeaderText = "Duration" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Elapsed", HeaderText = "Elapsed Time" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Status", HeaderText = "Status" });
            CellStyleInfo cellStyleInfo = new CellStyleInfo();
            cellStyleInfo.HorizontalAlignment = HorizontalAlignment.Center;
            List<CellButton> button_add = new List<CellButton>();
            button_add.Add(new CellButton() { Text = "Start", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
            List<CellButton> button_scan = new List<CellButton>();
            button_scan.Add(new CellButton() { Text = "Pause", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
            List<CellButton> button_stop = new List<CellButton>();
            button_stop.Add(new CellButton() { Text = "Stop", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { Buttons = button_add, HeaderText = "Start", MappingName = "Start" });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { Buttons = button_scan, HeaderText = "Pause", MappingName = "Pause" });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { Buttons = button_stop, HeaderText = "Stop", MappingName = "Stop" });

            sfDataGrid1.CellButtonClick += SfDataGrid1_CellButtonClick;

            // Optional: Enable row collapse
            sfDataGrid1.DetailsViewDefinitions.Add(GetChildViewDefinition());
            //{
            //    RelationalColumn = "TaskName",
            //    DataGrid = new SfDataGrid() { AutoGenerateColumns = true }
            //});
        }
        private GridViewDefinition GetChildViewDefinition()
        {
            var childGrid = new SfDataGrid
            {
                AutoGenerateColumns = false
            };
            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,
                BackColor = Color.LightSkyBlue
            };
            childGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            childGrid.HeaderRowHeight = 45;
            childGrid.RowHeight = 80;
            childGrid.Style.HeaderStyle.BackColor = Color.White;
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ProcessId", HeaderText = "Process ID", CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "TimeStart", HeaderText = "Start Time", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "TimeEnd", HeaderText = "End Time", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Remarks", HeaderText = "Remarks", CellStyle = cellstyle1, AllowTextWrapping = true });
            return new GridViewDefinition
            {
                RelationalColumn = "SubProcesses", // matches property in ProcessViewModel
                DataGrid = childGrid
            };
        }
        public class TaskTimer
        {
            public string TaskName { get; set; }
            public string StartTime { get; set; }
            public TimeSpan Elapsed { get; set; }
            public bool IsRunning { get; set; }
            public string Status { get; set; }
            public BindingList<ChildProcessViewModel> SubProcesses { get; set; } = new BindingList<ChildProcessViewModel>();
        }
        public class ChildProcessViewModel
        {
            public string ProcessId { get; set; }
            public string TimeStart { get; set; }
            public string TimeEnd { get; set; }
            public string Remarks { get; set; }
        }
        private void SfDataGrid1_CellButtonClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            var rowData = sfDataGrid1.SelectedItem as TaskTimer;
            if (rowData == null) return;

            switch (e.Column.MappingName)
            {
                case "Start":
                    StartTimer(rowData);
                    break;
                case "Pause":
                    PauseTimer(rowData);
                    break;
                case "Stop":
                    StopTimer(rowData);

                    break;
            }
        }
        private void StartTimer(TaskTimer task)
        {
            if (task.IsRunning)
            {
                MessageBox.Show("Already Started");
                return;
            }
            task.SubProcesses.Add(new ChildProcessViewModel
            {
                ProcessId = task.TaskName,
                TimeStart = DateTime.Now.ToString(@"hh\:mm\:ss"),
                TimeEnd = "",
                Remarks = "Started"
            });
            if (!timers.ContainsKey(task))
            {
                var timer = new System.Windows.Forms.Timer { Interval = 1000 };
                timer.Tick += (s, e) =>
                {
                    task.Status = "Running";
                    var timestart = TimeSpan.Parse(task.StartTime);
                    var totalElapsed = timestart + task.Elapsed + TimeSpan.FromSeconds(1);
                    task.StartTime = totalElapsed.ToString(@"hh\:mm\:ss");
                    task.Elapsed = task.Elapsed.Add(TimeSpan.FromSeconds(1));
                    sfDataGrid1.Refresh();
                };
                timers[task] = timer;
            }
            timers[task].Start();
            task.IsRunning = true;


        }

        private void PauseTimer(TaskTimer task)
        {
            if (!task.IsRunning)
            {
                MessageBox.Show("Already Pause");
                return;
            }
            if (timers.ContainsKey(task))
            {
                task.Status = "Paused";
                var lastSubProcess = task.SubProcesses.LastOrDefault();
                if (lastSubProcess != null && string.IsNullOrEmpty(lastSubProcess.TimeEnd))
                {
                    lastSubProcess.TimeEnd = DateTime.Now.ToString(@"hh\:mm\:ss");
                    lastSubProcess.Remarks = "Paused";
                }
                sfDataGrid1.Refresh();
                timers[task].Stop();
                task.IsRunning = false;
            }
        }

        private void StopTimer(TaskTimer task)
        {
            if (task.Status == "Pause")
            {
                MessageBox.Show("Status is Pause");
                return;
            }
            else if (task.Status == "") 
            {
                MessageBox.Show("Status is not running");
                return;
            }
            else if (task.Status == null)
            {
                MessageBox.Show("Status is not running");
                return;
            }
            if (!task.IsRunning)
            {
                MessageBox.Show("Already Stop");
                return;
            }
          
            if (timers.ContainsKey(task))
            {
                task.Status = "Done";
                var lastSubProcess = task.SubProcesses.LastOrDefault();
                if (lastSubProcess != null && string.IsNullOrEmpty(lastSubProcess.TimeEnd))
                {
                    lastSubProcess.TimeEnd = DateTime.Now.ToString(@"hh\:mm\:ss");
                    lastSubProcess.Remarks = "Done";
                }
                timers[task].Stop();
                //task.StartTime = "00:00:00";
                task.Elapsed = TimeSpan.Zero;
                sfDataGrid1.Refresh();
                task.IsRunning = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Modal.timerv2();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Modal.timer();
            frm.Show();
        }

        private void sfDataGrid1_QueryButtonCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryButtonCellStyleEventArgs e)
        {
            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;
            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as TaskTimer;
            if (record == null) return;

            if (record.Status == "Done")
            {
                e.Style.BackColor = Color.LightGray;
                e.Style.TextColor = Color.DarkGray;
                e.Style.Enabled = false;
            }
            else
            {
                e.Style.BackColor = Color.CornflowerBlue;
                e.Style.TextColor = Color.White;
                e.Style.Enabled = true;
            }
        }
    }
}
