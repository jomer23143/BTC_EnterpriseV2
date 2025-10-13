using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.Class;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json.Linq;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;
using Timer = System.Windows.Forms.Timer;

namespace BTC_EnterpriseV2.ProcessForm
{
    public partial class ProcessFrm : Form
    {
        private Timer timer;
        private int timer_durration;

        public static ProcessFrm instance;
        private DateTime _startTime;

        private string Postprocess = GlobalApi.GetPostProcessUrl();
        private TimeFormat timeFormat = new TimeFormat();
        public DataTable tbl_process = new DataTable("tblp");
        public DataTable tbl_subprocess = new DataTable("tblsp");
        public bool _IsTScanSuccess = false;
        public bool _IsMScanSuccess = false;
        public string _returnTorqueName = "";
        public string _returnTorqueValue = "";
        public string? _MoID;
        public string _serial;
        private int _segmentID;
        private string processname;
        private string segmentname;
        private string processstatus;
        private string durationDisplay;
        private int _selectedProcessID;
        private bool _started = false;
        private int _processStrtID;
        private bool IsScanItem = true;
        private bool _IscanOK = false;
        private FormManager formManager;
        private System.Windows.Forms.Timer fadeTimer;
        private string Token;
        private ProcessScanner _processScanner;
        private scantorque _scanTorque;
        private ShowCustomizeAlert ShowCustomizeAlert;
        //Final Test
        private Timer processTimer;
        private DateTime startTime;
        private bool isRunning = false;
        private Dictionary<int, DateTime> activeProcesses = new Dictionary<int, DateTime>();
        private string _storedDuration;
        private bool durationUpdated;

        private DataTable parentDurationDatatable = new DataTable("p");
        private DataTable ChildrowDataTable = new DataTable("Cr");

        public ProcessFrm(string scangeneratedSerial, int segmentid, string moid, string segmentname, string processname, string operatorfullname, string thetoken, DataTable plist, DataTable subplist)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            durationUpdated = false;
            QrController();
            instance = this;
            this._serial = scangeneratedSerial;
            pb_child.Visible = false;
            this._MoID = moid;
            this._segmentID = segmentid;
            this.processname = processname;
            this.segmentname = segmentname;
            this.tbl_process = plist;
            this.tbl_subprocess = subplist;
            this.lbl_operatorname.Text = operatorfullname;
            this.Token = thetoken;
            formManager = new FormManager(panel_top, panel_parent_tab_subprocess);
            YUI yaoui = new YUI();
            yaoui.RoundedButton(btn_material, 8, Color.FromArgb(27, 86, 253));
            yaoui.RoundedButton(btn_torque, 8, Color.FromArgb(7, 222, 151));
            yaoui.RoundedButton(btn_chemical, 8, Color.FromArgb(255, 128, 0));
            yaoui.RoundedButton(btn_qcChecklist, 8, Color.Tomato);
            checkBoxAdv2.Checked = true;

            // Timers
            processTimer = new Timer();
            processTimer.Interval = 1000;
            processTimer.Tick += timer_duration_Tick;

        }
        private void QrController()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.FormBorderStyle = FormBorderStyle.None;


        }
        private async void ProcessFrm_Load(object sender, EventArgs e)
        {
            lbl_mo.Text = _MoID;
            lbl_segment.Text = segmentname;
            lbl_parentname.Text = processname;
            lbl_generatedSerial.Text = _serial;
            pb_parent.Visible = true;

            await LoadProcessDataMerged_Sf(tbl_process);


        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _startTime;
            durationDisplay = timeFormat.FormatDuration(duration);
        }


        private async Task LoadProcessDataMerged_Sf(DataTable processlist)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });

            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Clear();
            sfDataGrid1.RowHeight = 90;
            sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            sfDataGrid1.AllowEditing = false;
            sfDataGrid1.RowHeaderWidth = 70;

            CellStyleInfo cellstyle = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,
                Font = new GridFontInfo(new Font("Segoe UI", 18, FontStyle.Bold))
            };

            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,
                Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular))
            };

            sfDataGrid1.HeaderRowHeight = 45;
            sfDataGrid1.Style.HeaderStyle.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Bold));
            sfDataGrid1.Style.HeaderStyle.BackColor = Color.Gray;
            sfDataGrid1.Style.HeaderStyle.TextColor = Color.Black;
            sfDataGrid1.Style.SelectionStyle.BackColor = Color.PaleGreen;
            sfDataGrid1.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGrid1.AllowEditing = true;
            sfDataGrid1.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            sfDataGrid1.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;

            // --- Columns ---
            sfDataGrid1.Columns.Add(new GridButtonColumn()
            {
                MappingName = "ExpandCollapse",
                HeaderText = "",
                CellStyle = cellstyle,
                Width = 50,
                Visible = false,
                AllowDefaultButtonText = true
            });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Index", HeaderText = "#", Width = 50, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Process", Width = 450, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "StartTime", HeaderText = "Time Start", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "EndTime", HeaderText = "Time End", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Duration", HeaderText = "Duration", CellStyle = cellstyle1, AllowTextWrapping = true });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Status", HeaderText = "Status", Visible = true, CellStyle = cellstyle1, AllowTextWrapping = true });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Color", HeaderText = "Color", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", HeaderText = "ID", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CycleTime", HeaderText = "CycleTime", Visible = false });

            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "StartButton", HeaderText = "Start", CellStyle = cellstyle });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "EndButton", HeaderText = "End", CellStyle = cellstyle });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "HoldButton", HeaderText = "Hold", CellStyle = cellstyle });


            var groupedProcesses = processlist.AsEnumerable()
                .GroupBy(row => row.Field<int>("id"))
                .Select(group => new
                {
                    ProcessId = group.Key,
                    AllDurationRows = group.OrderBy(r => DateTime.TryParse(r.Field<string>("end_time"), out var dt) ? dt : DateTime.MinValue).ToList()
                })
                .ToList();


            var viewModels = new List<ViewModel.ProcessViewModel>();
            int index = 1;

            foreach (var group in groupedProcesses)
            {
                TimeSpan totalDuration = TimeSpan.Zero;

                System.Data.DataRow lastDurationRow = group.AllDurationRows.Last();

                string processId = Convert.ToString(lastDurationRow["id"]);
                string processName = lastDurationRow["name"]?.ToString() ?? "Unknown";
                string statusName = lastDurationRow["status"]?.ToString() ?? "Unknown";
                string statusColor = lastDurationRow["color"]?.ToString() ?? "White";
                string cycleTime = lastDurationRow["cycle_time"]?.ToString() ?? "N/A";

                string startTimeDisplay = "-";
                string endTimeDisplay = "-";

                DateTime parsedStart;
                DateTime parsedEnd;
                if (lastDurationRow["start_time"] != DBNull.Value && DateTime.TryParse(lastDurationRow["start_time"].ToString(), out parsedStart))
                {
                    startTimeDisplay = $"Time: {parsedStart:HH:mm:ss} Date: {parsedStart:MM-dd-yyyy}";

                    if (lastDurationRow["end_time"] != DBNull.Value && DateTime.TryParse(lastDurationRow["end_time"].ToString(), out parsedEnd))
                    {
                        endTimeDisplay = $"Time: {parsedEnd:HH:mm:ss} Date: {parsedEnd:MM-dd-yyyy}";

                    }
                    else
                    {
                        endTimeDisplay = "-:-:-";

                        timer1.Start();
                    }
                }

                var childProcesses = new BindingList<ViewModel.ChildProcessViewModel>();

                foreach (System.Data.DataRow durationRow in group.AllDurationRows)
                {
                    string childStartTime = durationRow["start_time"]?.ToString() ?? "-";
                    string childEndTime = durationRow["end_time"]?.ToString() ?? "-";
                    string theStatus = durationRow["status"]?.ToString() ?? "";

                    if (string.IsNullOrEmpty(childEndTime))
                    {
                        continue;
                    }

                    string childdurationDisplay = "0 Days : 00 : 00 : 00";
                    DateTime childparsedStart;
                    DateTime childparsedEnd;
                    TimeSpan currentDuration = TimeSpan.Zero;

                    if (DateTime.TryParse(childStartTime, out childparsedStart))
                    {
                        if (DateTime.TryParse(childEndTime, out childparsedEnd))
                        {

                            currentDuration = childparsedEnd - childparsedStart;
                            childdurationDisplay = timeFormat.FormatDuration(currentDuration);
                        }
                        else
                        {

                            currentDuration = DateTime.Now - childparsedStart;
                            childdurationDisplay = timeFormat.FormatDuration(currentDuration);
                        }

                        totalDuration = totalDuration.Add(currentDuration);
                    }

                    childProcesses.Add(new ViewModel.ChildProcessViewModel
                    {
                        Id = Convert.ToInt32(durationRow["id"]),
                        ProcessId = processId,
                        TimeStart = childStartTime,
                        TimeEnd = childEndTime,
                        Duration = childdurationDisplay,
                        Remarks = durationRow["remark"]?.ToString() ?? "",
                        StatusName = durationRow["status"]?.ToString() ?? "Unknown"
                    });
                }

                string finalTotalDurationDisplay = timeFormat.FormatDuration(totalDuration);

                viewModels.Add(new ViewModel.ProcessViewModel
                {
                    Index = index++,
                    expandIcon = "+",
                    ProcessId = processId,
                    Name = processName,

                    StartTime = startTimeDisplay,
                    EndTime = endTimeDisplay,

                    Duration = finalTotalDurationDisplay,

                    Status = statusName,
                    Color = statusColor,
                    CycleTime = cycleTime,

                    StartButton = "▶",
                    EndButton = "⏹",
                    HoldButton = "⏸",

                    SubProcesses = childProcesses
                });
            }

            sfDataGrid1.DataSource = viewModels;
            sfDataGrid1.DetailsViewDefinitions.Clear();
            sfDataGrid1.DetailsViewDefinitions.Add(GetChildViewDefinition());

            pb_parent.Visible = false;
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
            childGrid.Style.HeaderStyle.BackColor = Color.Gray;
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Id", HeaderText = "#", Visible = false, CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ProcessId", HeaderText = "Process ID", CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "TimeStart", HeaderText = "Start Time", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "TimeEnd", HeaderText = "End Time", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Duration", HeaderText = "Duration", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Remarks", HeaderText = "Remarks", CellStyle = cellstyle1, AllowTextWrapping = true });

            return new GridViewDefinition
            {
                RelationalColumn = "SubProcesses",
                DataGrid = childGrid
            };
        }

        private async Task LoadSubProcessData(int processID, DataTable subprocess)
        {

            // --- Setup Grid ---
            sfDataGrid2.AutoGenerateColumns = false;
            sfDataGrid2.Columns.Clear();
            sfDataGrid2.RowHeight = 90;
            sfDataGrid2.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            sfDataGrid2.AllowEditing = true;
            sfDataGrid2.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            sfDataGrid2.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.FromArgb(0, 0, 0),
            };
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            sfDataGrid2.HeaderRowHeight = 45;
            sfDataGrid2.Style.HeaderStyle.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Bold));
            sfDataGrid2.Style.HeaderStyle.BackColor = Color.Gray;
            sfDataGrid2.Style.HeaderStyle.TextColor = Color.Black;
            sfDataGrid2.Style.SelectionStyle.BackColor = Color.LimeGreen;
            sfDataGrid2.Style.SelectionStyle.TextColor = Color.White;

            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Index", HeaderText = "#", Width = 50, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "MaterialID", HeaderText = "ID", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Material", Width = 300, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Ipn", HeaderText = "ipn", AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Torque", HeaderText = "Torque", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Serial_qty", HeaderText = "Qty", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Serial_count", HeaderText = "s", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "IsSerialized", HeaderText = "IsSerialized", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "IsTorque", HeaderText = "IsTorque", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Torque_count", HeaderText = "tc", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "IsChemical", HeaderText = "ischemical", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });

            // --- Map Processes to ViewModel ---

            // --- Filter rows by processID ---
            var filteredRows = subprocess.AsEnumerable()
                .Where(r => r.Field<int>("manufacturing_order_process_id") == processID);

            // --- Map Processes to ViewModel ---
            var viewModels = new List<ViewModel.SubProcessView>();
            int index = 1;

            foreach (var row in filteredRows)
            {
                viewModels.Add(new ViewModel.SubProcessView
                {
                    Torque_count = !string.IsNullOrEmpty(row.Field<string>("machine_tool_torque_value")) ? "1" : "0",

                    Serial_count = row.Field<int>("is_serial") == 1 ? row["serial_count"]?.ToString() ?? "0" : "0",


                    Index = index++,
                    MaterialID = row.Field<int>("id"),
                    Name = row["name"]?.ToString() ?? "N/A",
                    Ipn = row["ipn_number"]?.ToString() ?? "N/A",

                    Torque = string.Format("({0}) {1}",
                             string.IsNullOrEmpty(row["machine_tool_torque_name"]?.ToString()) ? "N/A" : row["machine_tool_torque_name"].ToString(),
                             string.IsNullOrEmpty(row["machine_tool_torque_value"]?.ToString()) ? "N/A" : row["machine_tool_torque_value"].ToString()),

                    Serial_qty = row["serial_quantity"]?.ToString() ?? "0",
                    IsSerialized = row.Field<int>("is_serial"),
                    IsTorque = row.Field<int>("is_torque"),
                    IsChemical = row.Field<string>("is_chemical"),

                });
            }


            sfDataGrid2.DataSource = viewModels;
            sfDataGrid2.DetailsViewDefinitions.Clear();

            pb_child.Visible = false;
        }

        //child of subprocess
        private GridViewDefinition GetChildSubPviewDefinition()
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
            childGrid.Style.HeaderStyle.BackColor = Color.Gray;
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Id", HeaderText = "#", Visible = false, CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "SerialNumber", HeaderText = "Serial Number", CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ChemicalName", HeaderText = "Chemical Name", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ChemicalExpiry", HeaderText = "Chemical Expiry", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });

            return new GridViewDefinition
            {
                RelationalColumn = "ChildSubProcessView",
                DataGrid = childGrid
            };
        }


        private void sfDataGrid1_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {

            if (e.Column == null) return;

            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;


            if (e.Column.MappingName == "ExpandCollapse")
            {
                e.Style.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Bold));
                e.Style.TextColor = Color.Red;

            }


            if (e.Column.MappingName == "Status")
            {
                Color textColor = Color.LightGray;

                if (!string.IsNullOrWhiteSpace(record.Color))
                {
                    try
                    {
                        string hex = record.Color.Replace("#", "");

                        if (hex.Length == 6)
                        {
                            textColor = ColorTranslator.FromHtml("#" + hex);
                        }
                        else if (hex.Length == 8) // ARGB
                        {
                            byte a = Convert.ToByte(hex.Substring(0, 2), 16);
                            byte r = Convert.ToByte(hex.Substring(2, 2), 16);
                            byte g = Convert.ToByte(hex.Substring(4, 2), 16);
                            byte b = Convert.ToByte(hex.Substring(6, 2), 16);
                            textColor = Color.FromArgb(a, r, g, b);
                        }
                    }
                    catch
                    {
                        textColor = Color.LightGray;
                    }
                }


                e.Style.TextColor = textColor;
                e.Style.Font = new GridFontInfo(new Font("Segoe UI", 10, FontStyle.Bold));
            }


            var firstPendingRow = sfDataGrid1.View.Records
                .Select(r => r.Data as ViewModel.ProcessViewModel)
                .FirstOrDefault(r => r.Status != "Completed");

            if (record != firstPendingRow)
            {
                e.Style.BackColor = Color.LightGray;
                e.Style.TextColor = Color.DarkGray;
            }



        }

        private void sfDataGrid1_QueryButtonCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryButtonCellStyleEventArgs e)
        {
            if (e.RowIndex < 0 || e.Column == null) return;

            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;

            if (_IscanOK == true)
            {
                e.Style.TextColor = Color.Green;
            }

            bool isRowEnabled = false;

            if (recordIndex == 0)
            {

                isRowEnabled = record.Status != "Completed";
            }
            else
            {

                var prevRecord = sfDataGrid1.View.Records.GetItemAt(recordIndex - 1) as ViewModel.ProcessViewModel;
                if (prevRecord != null && prevRecord.Status == "Completed" && record.Status != "Completed")
                {
                    isRowEnabled = true;
                }
            }

            switch (e.Column.MappingName)
            {
                case "StartButton":
                    if (!isRowEnabled || record.Status == "Completed" || record.IsCancelled || record.Status == "Processing")
                    {
                        e.Style.BackColor = Color.LightGray;
                        e.Style.TextColor = Color.DarkGray;
                        e.Style.Enabled = false;
                    }
                    else
                    {
                        e.Style.BackColor = Color.ForestGreen;
                        e.Style.TextColor = Color.White;
                        e.Style.Enabled = true;
                    }
                    break;

                case "HoldButton":
                    if (!isRowEnabled || record.Status == "Open" || record.Status == "Completed" || record.IsCancelled)
                    {
                        e.Style.BackColor = Color.LightGray;
                        e.Style.TextColor = Color.DarkGray;
                        e.Style.Enabled = false;
                    }
                    else
                    {
                        e.Style.BackColor = Color.Goldenrod;
                        e.Style.TextColor = Color.White;
                        e.Style.Enabled = true;
                    }
                    break;

                case "EndButton":
                    if (!isRowEnabled || record.Status == "Open" || record.Status == "Completed" || record.IsCancelled)
                    {
                        e.Style.BackColor = Color.LightGray;
                        e.Style.TextColor = Color.DarkGray;
                        e.Style.Enabled = false;
                    }
                    else
                    {
                        e.Style.BackColor = Color.Salmon;
                        e.Style.TextColor = Color.White;
                        e.Style.Enabled = true;
                    }
                    break;

                case "ExpandCollapse":
                    if (record.IsExpanded)
                    {
                        e.Style.TextColor = Color.Red;
                        e.Style.Enabled = true;
                        e.Style.BackColor = Color.SeaGreen;
                        record.expandIcon = "➖";

                    }
                    else
                    {
                        e.Style.TextColor = Color.Green;
                        e.Style.Enabled = true;
                        e.Style.BackColor = Color.LimeGreen;
                        record.expandIcon = "➕";

                    }
                    break;
            }
        }




        private async void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            if (sfDataGrid1.SelectedItem is ViewModel.ProcessViewModel record)
            {
                int selectedId = Convert.ToInt32(record.ProcessId);
                _selectedProcessID = selectedId;
                string selectedName = record.Name;

                processstatus = record.Status;
                if (record.Status != "Processing")
                {
                    formManager.closeAForm();
                }
                lbl_processname.Text = $"Process Name : {selectedName}";
                sfDataGrid2.Columns.Clear();
                pb_child.Visible = true;
                lbl_subprocessInfo.Text = "";
                await LoadSubProcessData(selectedId, tbl_subprocess);
            }
        }





        private async void sfDataGrid1_CellButtonClick_1(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            // --- Initial Checks ---
            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;

            int processid = Convert.ToInt32(record.ProcessId);
            string timeEndString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime segmentEndTime = DateTime.Now;
            string status = "";
            TimeSpan segmentDuration = TimeSpan.Zero;


            switch (e.Column.MappingName)
            {
                // ─────────────── START ───────────────
                case "StartButton":
                    status = "START_TIME";

                    bool canStart = await PostProcessWithDictionary(processid, "Start remarks", status, "");
                    if (!canStart) return;

                    record.IsStarted = true;
                    if (record.Status == "Pause" || record.Status == "Cancelled")
                    {
                        record.IsOnHold = true;
                    }
                    record.Status = "Processing";
                    processstatus = "Processing";

                    DateTime startTime = DateTime.Now;
                    activeProcesses[processid] = startTime;

                    record.StartTime = $"Time: {startTime:HH:mm:ss} Date: {startTime:MM-dd-yyyy}";

                    _storedDuration = record.Duration;
                    record.Duration = timeFormat.FormatDuration(record.AccumulatedDuration);

                    StartProcessTimers(record);

                    if (record.IsOnHold || record.SubProcesses.Count == 0)
                    {

                        LogSubProcess(
                            record,
                            lastSubProcess: null,
                            "Processing",
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            null,
                            TimeSpan.Zero
                        );
                    }
                    record.IsOnHold = false;
                    record.IsEnded = false;

                    break;



                // ─────────────── HOLD ───────────────
                case "HoldButton":
                    string processName = record.Name;
                    if (record.Status == "Pause")
                    {
                        ShowCustomizeAlert.ShowMsg("Pause Process Validation.", "You already Pause the current Process. Please Start the process.", CustomeAlert.Alertype.Warning);
                        return;
                    }
                    TabFrm tabFrm = new TabFrm(this, processid, processName, lbl_mo.Text, lbl_generatedSerial.Text, Token);

                    if (tabFrm.ShowDialog() == DialogResult.Yes)
                    {
                        UpdateStatus(record, true, false, false, "Cancelled");
                        activeProcesses.Remove(processid);
                    }

                    else
                    {
                        if (activeProcesses.TryGetValue(processid, out DateTime segmentStartTime))
                        {
                            segmentDuration = segmentEndTime - segmentStartTime;
                            activeProcesses.Remove(processid);
                            record.AccumulatedDuration += segmentDuration;
                        }
                        StopProcessTimersIfInactive();

                        var lastSubProcess = record.SubProcesses.LastOrDefault();

                        LogSubProcess(
                            record,
                            lastSubProcess,
                            "Paused: " + lbl_public_event.Text,
                            record.StartTime,
                            timeEndString,
                            segmentDuration
                        );
                        record.Duration = timeFormat.FormatDuration(record.AccumulatedDuration);
                        record.StartTime = timeEndString;
                        UpdateStatus(record, true, true, true, "Pause");
                    }
                    break;



                // ─────────────── END ───────────────
                case "EndButton":
                    if (record.Status == "Pause")
                    {
                        ShowCustomizeAlert.ShowMsg("Validation Error.", "You cannot end this process because the process is on Pause. Please Start the process again.", CustomeAlert.Alertype.Warning);
                        return;
                    }
                    if (sfDataGrid2.RowCount == 0)
                    {
                        ShowCustomizeAlert.ShowMsg("Validation Error.", "Select the process first.", CustomeAlert.Alertype.Warning);
                        return;
                    }

                    if (HasUnscannedMaterial() || HasUnscannedTorque())
                    {
                        ShowCustomizeAlert.ShowMsg("Validation Error.", "You cannot end this process because one or more required items have not been scanned or torqued yet.", CustomeAlert.Alertype.Warning);
                        return;
                    }

                    if (!string.IsNullOrEmpty(Token))
                    {
                        status = "END_TIME";


                        if (activeProcesses.TryGetValue(processid, out DateTime segmentStartTime))
                        {
                            segmentDuration = segmentEndTime - segmentStartTime;
                            record.AccumulatedDuration += segmentDuration;
                            activeProcesses.Remove(processid);
                        }

                        LogSubProcess(record, lastSubProcess: null, "Process Completed", record.StartTime, timeEndString, segmentDuration);

                        TimeSpan totalAccumulatedDuration = TimeFormat.ParseCustomDuration(record.Duration);
                        record.Duration = timeFormat.FormatDuration(totalAccumulatedDuration);
                        record.EndTime = $"Time: {segmentEndTime:HH:mm:ss} Date: {segmentEndTime:MM-dd-yyyy}";
                        UpdateStatus(record, true, false, true, "Completed");
                        await PostProcessWithDictionary(processid, "Process Completed", status, Token);
                        StopProcessTimersIfInactive();
                    }
                    else
                    {

                        UpdateStatus(record, true, false, false, "Processing");
                        MessageBox.Show("Process End Cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                // ─────────────── EXPAND / COLLAPSE ───────────────
                case "ExpandCollapse":
                    record.IsExpanded = !record.IsExpanded;

                    if (record.IsExpanded)
                    {
                        sfDataGrid1.ExpandDetailsViewAt(e.RowIndex);
                        record.expandIcon = "➖";
                    }
                    else
                    {
                        sfDataGrid1.CollapseDetailsViewAt(e.RowIndex);
                        record.expandIcon = "➕";
                    }
                    break;
            }

            sfDataGrid1.View.Refresh();
        }


        private void UpdateStatus(ViewModel.ProcessViewModel record, bool isStarted, bool isOnHold, bool isEnded, string statusText)
        {
            record.IsStarted = isStarted;
            record.IsOnHold = isOnHold;
            record.IsEnded = isEnded;
            record.Status = statusText;
            processstatus = statusText;
        }



        private void StartProcessTimers(ViewModel.ProcessViewModel record)
        {
            if (!processTimer.Enabled)
            {
                processTimer.Start();
                isRunning = true;
            }

            if (record.CycleTime != "N/A" && int.TryParse(record.CycleTime, out int timer_duration))
            {
                process_duration_timer.Interval = timer_duration;
                process_duration_timer.Start();
            }
        }

        private void StopProcessTimersIfInactive()
        {
            if (activeProcesses.Count == 0 && processTimer.Enabled)
            {
                processTimer.Stop();
                isRunning = false;
            }
        }

        private void LogSubProcess(
    ViewModel.ProcessViewModel record,
    ViewModel.ChildProcessViewModel lastSubProcess,
    string remarks,
    string timeStart,
    string timeEnd,
    TimeSpan duration)
        {

            if (lastSubProcess != null && string.IsNullOrEmpty(lastSubProcess.TimeEnd))
            {

                lastSubProcess.TimeEnd = timeEnd;
                lastSubProcess.Remarks = remarks;
                lastSubProcess.Duration = timeFormat.FormatDuration(duration);
            }
            else
            {
                record.SubProcesses.Add(new ViewModel.ChildProcessViewModel
                {
                    Id = record.SubProcesses.Count + 1,
                    ProcessId = record.ProcessId,
                    TimeStart = timeStart,
                    TimeEnd = string.IsNullOrEmpty(timeEnd) ? null : timeEnd,
                    Duration = timeFormat.FormatDuration(duration),
                    Remarks = remarks
                });
            }
        }


        private bool HasUnscannedMaterial()
        {
            return sfDataGrid2.View.Records
                .Select(r => r.Data as ViewModel.SubProcessView)
                .Any(m => m?.Serial_count == "1");
        }

        private bool HasUnscannedTorque()
        {
            return sfDataGrid2.View.Records
                .Select(r => r.Data as ViewModel.SubProcessView)
                .Any(t => t?.IsTorque == 1 && t.Torque_count == "0");
        }



        public async Task<bool> PostProcessWithDictionary(int processid, string remark, string status, string rfid)
        {
            try
            {
                DictionaryBuilder Dbuilder = new DictionaryBuilder();
                var postData = Dbuilder.BuilderPost_Process(processid, remark, status, rfid);

                var (isSuccess, token) = await ApiHelper.PostTokenJsonAsync_response(Postprocess, postData, Token);

                if (!isSuccess)
                    return false;

                if (token?.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    if (result?.FirstOrDefault() == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
                return false;
            }
        }
        //SubProcvess
        private void sfDataGrid2_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.Column == null) return;

            int recordIndex = sfDataGrid2.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid2.View.Records.GetItemAt(recordIndex) as ViewModel.SubProcessView;
            if (record == null) return;


            Color newTextColor = Color.Black;
            FontStyle newFontStyle = FontStyle.Regular;


            if (record.IsSerialized == 1 && record.Serial_count == "0")
            {
                newTextColor = Color.FromArgb(27, 86, 253);
            }

            else if (record.IsTorque == 1 && record.Torque_count == "0")
            {
                newTextColor = Color.FromArgb(7, 222, 151);

            }

            else if (record.IsChemical == "1")
            {
                newTextColor = Color.FromArgb(255, 128, 0);
            }


            else if (record.IsSerialized == 1 && record.Serial_count == "1")
            {
                newTextColor = Color.Green;
            }

            else if (record.IsTorque == 1 && record.Torque_count == "1")
            {
                newTextColor = Color.Green;
            }


            e.Style.TextColor = newTextColor;
            e.Style.Font = new GridFontInfo(new Font("Segoe UI", 10, newFontStyle));


        }

        private async void sfDataGrid2_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow == null || e.DataRow.RowType != RowType.DefaultRow)
                return;

            var record = e.DataRow.RowData as ViewModel.SubProcessView;
            if (record == null) return;

            string selectedName = record.Name;
            var rowindex = 0;
            var processid = Convert.ToString(record.MaterialID);
            var qty = record.Serial_qty;
            var tqty = record.Torque_count;
            var count = Convert.ToInt32(record.Serial_count) > 0 ? 0 : 1;
            var tcount = Convert.ToInt32(record.Torque_count) > 0 ? 0 : 1;
            var iskitlist = 0;
            var buffcount = Convert.ToString(count);
            var bufftcount = Convert.ToString(tcount);



            if (record.IsTorque == 0 && record.IsSerialized == 1)
            {
                IsScanItem = true;
                checkBoxAdv1.Checked = false;
                checkBoxAdv2.Checked = true;
            }
            else if (record.IsTorque == 1 && record.IsSerialized == 0)
            {
                IsScanItem = false;
                checkBoxAdv1.Checked = true;
                checkBoxAdv2.Checked = false;
            }
            else if (record.IsTorque == 1 && record.IsSerialized == 1)
            {
                if (IsScanItem == true)
                {
                    IsScanItem = true;
                    checkBoxAdv1.Checked = false;
                    checkBoxAdv2.Checked = true;
                }
                else
                {
                    IsScanItem = false;
                    checkBoxAdv1.Checked = true;
                    checkBoxAdv2.Checked = false;
                }
            }
            else
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "This material is neither serialized nor requires torque.";
                return;
            }

            if (IsScanItem == true && processstatus == "Processing" && record.Serial_count == "1")
            {
                if (record.IsSerialized == 0)
                {
                    formManager.closeAForm();
                    lbl_subprocessInfo.Text = "This material is not serialized, cannot scan item.";
                    return;
                }
                else
                {
                    var scanner = new ProcessScanner(this, rowindex, processid, selectedName, lbl_generatedSerial.Text, qty, buffcount, iskitlist, tbl_subprocess);
                    formManager.OpenChildForm(scanner, sender);
                    scanner.Shown += (s, args) => scanner.txt_serialnumber.Focus();

                    scanner.ItemScanSuccess += async (serial, processid) =>
                    {
                        UpdateSerialQuantity(tbl_subprocess, Convert.ToInt32(processid), 0);
                        await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                    };

                }


            }
            else if (IsScanItem == true && processstatus == "Processing" && record.Serial_count == "0")
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "The item was already scanned successfully. Please do not scan it again.";
            }

            else if (IsScanItem == true && processstatus == "Pause")
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "Process is on Hold, cannot scan item.";
            }
            else if (IsScanItem == true && processstatus == "Completed")
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "Process is Completed, cannot scan item.";
            }
            else if (IsScanItem == true && processstatus == "Open")
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "Process is not started, cannot scan Item.";
            }
            else if (IsScanItem == false && processstatus == "Pause")
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "Process is on Hold, cannot scan torque.";
            }
            else if (IsScanItem == false && processstatus == "Completed")
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "Process is Completed, cannot scan torque.";

            }
            else if (IsScanItem == false && processstatus == "Open")

            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "Process is not started, cannot scan torque.";
            }
            else if (IsScanItem == false && processstatus == "Processing" && record.Torque_count == "1")
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "You have already Scan Torque for this Material, cannot scan torque.";
            }
            else if (IsScanItem == false && processstatus == "Processing")
            {
                if (record.IsTorque == 0)
                {
                    formManager.closeAForm();
                    lbl_subprocessInfo.Text = "This is not have Torque, cannot scan Torque.";
                    return;
                }
                else
                {
                    var Tscanner = new scantorque(this, processid, selectedName, tqty, bufftcount);
                    formManager.OpenChildForm(Tscanner, sender);
                    Tscanner.Shown += (s, args) => Tscanner.txt_torque.Focus();
                    // Subscribe to event
                    Tscanner.TorqueScanSuccess += async (torqueName, torqueValue) =>
                    {
                        _IscanOK = true;
                        UpdateTorqueQuantity(tbl_subprocess, Convert.ToInt32(processid), 1, torqueName, torqueValue);
                        await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                    };

                }


            }

        }

        private void sfDataGrid2_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            //if (sfDataGrid2.SelectedItem is ViewModel.SubProcessView record)
            //{
            //    string selectedName = record.Name;
            //    var rowindex = 0;
            //    var processid = Convert.ToString(record.MaterialID);
            //    var qty = record.Serial_qty;
            //    var count = Convert.ToInt32(record.Serial_count) > 0 ? 0 : 1;
            //    var iskitlist = 0;
            //    var buffcount = Convert.ToString(count);

            //    //if (record.IsTorque == 0 && record.IsSerialized == 1)
            //    //{
            //    //    IsScanItem = true;
            //    //    checkBoxAdv1.Checked = false;
            //    //    checkBoxAdv2.Checked = true;
            //    //}
            //    //else if (record.IsTorque == 1 && record.IsSerialized == 0)
            //    //{
            //    //    IsScanItem = false;
            //    //    checkBoxAdv1.Checked = true;
            //    //    checkBoxAdv2.Checked = false;
            //    //}
            //    //else if (record.IsTorque == 1 && record.IsSerialized == 1)
            //    //{
            //    //    // both torque and serial
            //    //    if (IsScanItem == true)
            //    //    {
            //    //        IsScanItem = true;
            //    //        checkBoxAdv1.Checked = false;
            //    //        checkBoxAdv2.Checked = true;
            //    //    }
            //    //    else
            //    //    {
            //    //        IsScanItem = false;
            //    //        checkBoxAdv1.Checked = true;
            //    //        checkBoxAdv2.Checked = false;
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    lbl_subprocessInfo.Text = "This material is neither serialized nor requires torque.";
            //    //    return;
            //    //}




            //    if (IsScanItem == true && processstatus == "Completed")
            //    {
            //        formManager.OpenChildForm(new ProcessScanner(rowindex, processid, selectedName, lbl_generatedSerial.Text, qty, buffcount, iskitlist, dtserials), sender);
            //    }
            //    else if (IsScanItem == true && processstatus == "Pause")
            //    {
            //        lbl_subprocessInfo.Text = "Process is on Hold, cannot scan item.";
            //    }
            //    else if (IsScanItem == true && processstatus == "Completed")
            //    {

            //        lbl_subprocessInfo.Text = "Process is Completed, cannot scan item.";
            //    }
            //    else if (IsScanItem == true && processstatus == "Open")
            //    {
            //        lbl_subprocessInfo.Text = "Process is not started, cannot scan Item.";
            //    }
            //    else if (IsScanItem == false && processstatus == "Pause")
            //    {
            //        lbl_subprocessInfo.Text = "Process is on Hold, cannot scan torque.";
            //    }
            //    else if (IsScanItem == false && processstatus == "Completed")
            //    {
            //        lbl_subprocessInfo.Text = "Process is Completed, cannot scan torque.";
            //    }
            //    else if (IsScanItem == false && processstatus == "Open")
            //    {
            //        lbl_subprocessInfo.Text = "Process is not started, cannot scan torque.";
            //    }
            //    else if (IsScanItem == false && processstatus == "Completed")
            //    {
            //        formManager.OpenChildForm(new scantorque(processid, selectedName), sender);
            //    }


            //}

        }

        private void btn_torque_Click(object sender, EventArgs e)
        {
            checkBoxAdv1.Checked = true;
            checkBoxAdv2.Checked = false;
            IsScanItem = false;
        }

        private void btn_material_Click(object sender, EventArgs e)
        {
            checkBoxAdv1.Checked = false;
            checkBoxAdv2.Checked = true;
            IsScanItem = true;

        }
        private void btn_chemical_Click(object sender, EventArgs e)
        {

        }
        private async void ProcessFrm_Shown(object sender, EventArgs e)
        {
            this.Opacity = 0;
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeIn;
            fadeTimer.Start();
        }
        private void FadeIn(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            else
            {
                fadeTimer.Stop();
            }
        }

        private void UpdateSerialQuantity(DataTable subprocess, int materialID, int newQuantity)
        {

            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                if (Convert.ToInt32(row["id"]) == materialID)
                {
                    row["serial_count"] = newQuantity;
                    break;
                }
            }
        }
        private void UpdateTorqueQuantity(DataTable subprocess, int materialID, int newQuantity, string Tname, string Tvalue)
        {
            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                if (Convert.ToInt32(row["id"]) == materialID)
                {
                    row["torque_count"] = newQuantity;
                    row["machine_tool_torque_name"] = Tname;
                    row["machine_tool_torque_value"] = Tvalue;
                    break;
                }
            }
        }

        private void process_duration_timer_Tick(object sender, EventArgs e)
        {
            new ToastForm("Attention! You have exceeded the process time duration.").Show();
        }

        private void btn_qcChecklist_Click(object sender, EventArgs e)
        {
            var qcform = new QC_Checklist_QR(lbl_generatedSerial.Text, _segmentID);
            qcform.ShowDialog();
        }

        private void timer_duration_Tick(object sender, EventArgs e)
        {
            if (sfDataGrid1.InvokeRequired)
            {
                sfDataGrid1.Invoke(new Action(() => timer_duration_Tick(sender, e)));
                return;
            }
            if (sfDataGrid1.View == null || sfDataGrid1.View.Records == null)
            {
                return;
            }


            TimeSpan accumulatedTimeBase = TimeFormat.ParseCustomDuration(_storedDuration);

            foreach (var record in sfDataGrid1.View.Records.Select(r => r.Data as ViewModel.ProcessViewModel))
            {
                if (record == null) continue;

                if (activeProcesses.TryGetValue(Convert.ToInt32(record.ProcessId), out DateTime currentStartTime))
                {
                    TimeSpan currentSegmentDuration = DateTime.Now - currentStartTime;

                    TimeSpan totalRunningDuration = accumulatedTimeBase + currentSegmentDuration;


                    string durationDisplay = timeFormat.FormatDuration(totalRunningDuration);
                    record.Duration = durationDisplay;
                    durationUpdated = true;
                }
            }


            if (durationUpdated)
            {
                sfDataGrid1.Refresh();
            }
        }


    }
}
