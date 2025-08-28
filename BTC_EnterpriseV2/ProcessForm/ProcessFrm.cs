using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.Class;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;
using JsonReaderException = Newtonsoft.Json.JsonReaderException;

namespace BTC_EnterpriseV2.ProcessForm
{
    public partial class ProcessFrm : Form
    {
        public static ProcessFrm instance;
        private DateTime _startTime;
        private string ScanUrl = GlobalApi.GetScanSerialUrl();
        private string GetSubPUrl = GlobalApi.GetGetSubPUrl();
        private string Postprocess = GlobalApi.GetPostProcessUrl();
        private TimeFormat timeFormat = new TimeFormat();

        public DataTable dtserials = new DataTable("tbname");

        public string? _MoID;
        public string _serial;
        private int _segmentID;
        private string processname;
        private string processstatus;
        private string durationDisplay;

        private Boolean _started = false;
        private int _processStrtID;
        private bool IsScanItem = true;
        private FormManager formManager;
        private System.Windows.Forms.Timer fadeTimer;

        private ProcessScanner _processScanner;
        private scantorque _scanTorque;

        public ProcessFrm(string scangeneratedSerial, int segmentid, string processname)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            QrController();
            instance = this;
            this._serial = scangeneratedSerial;
            pb_child.Visible = false;
            this._segmentID = segmentid;
            this.processname = processname;
            formManager = new FormManager(panel_top, panel_parent_tab_subprocess);
            YUI yaoui = new YUI();
            yaoui.RoundedButton(btn_material, 8, Color.FromArgb(27, 86, 253));
            yaoui.RoundedButton(btn_torque, 8, Color.FromArgb(7, 222, 151));
            checkBoxAdv2.Checked = true;
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
            await LoadSegmentProcessAsync(_serial, _segmentID);
        }

        public async Task LoadSegmentProcessAsync(string serial, int segmentId)
        {
            try
            {
                DictionaryBuilder Dbuilder = new DictionaryBuilder();
                //var postData = segmentId != 1 ? Dbuilder.BuildPostData(serial, segmentId) : Dbuilder.BuildPostData(serial);
                var postData = Dbuilder.BuildPostSubAssy(serial, segmentId);
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                var token = await ApiHelper.PostJsonAsync(ScanUrl, postData);
                if (token == null) return;

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        //pb_loader.Visible = false;
                        return;
                    }
                    dtserials.Rows.Clear();
                    dtserials.Columns.Clear();
                    dtserials.Columns.Add("id");
                    dtserials.Columns.Add("process_id");
                    dtserials.Columns.Add("serial_number");

                    foreach (var data_process in data.name)
                    {
                        //foreach (var data_serial in data_process.serial_number)
                        //{
                        //    dtserials.Rows.Add(data_serial.name, data_serial.manufacturing_order_process_id, data_serial.serial_number);
                        //}
                        //is_kit_list = data_process.is_kit_list;
                    }
                    bool anyIsKitList = data.process.Any(p => p.is_kit_list == 1);


                    _MoID = data.mo_id;
                    lbl_mo.Text = data.mo_id;
                    lbl_segment.Text = processname;
                    lbl_parentname.Text = data.name;
                    lbl_generatedSerial.Text = data.serial_number;

                    var durationItem = data.duration?.FirstOrDefault();
                    var rawStartTime = data.duration?.FirstOrDefault()?.start_time;
                    var rawEndTime = data.duration?.FirstOrDefault()?.end_time;

                    if (durationItem == null)
                    {
                        MessageBox.Show("No duration data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool isSubAssembly = segmentId == 1;
                    await LoadProcessDataMerged_Sf(data.process, isSubAssembly, anyIsKitList);

                }
                else
                {
                    MessageBox.Show("Unexpected response format.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
            }
        }

        //Start of bullshitness 
        Image ResizeImage(Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _startTime;
            durationDisplay = timeFormat.FormatDuration(duration);
        }


        private async Task LoadProcessDataMerged_Sf(List<Sub_Asy_Process_Model.Process> processes, bool isSubAssembly, bool isKitlist)
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


            CellStyleInfo cellstyle = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,

            };
            cellstyle.Font = new GridFontInfo(new Font("Segoe UI", 18, FontStyle.Bold));


            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.FromArgb(0, 0, 0),
            };
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            sfDataGrid1.HeaderRowHeight = 45;
            sfDataGrid1.Style.HeaderStyle.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Bold));
            sfDataGrid1.Style.HeaderStyle.BackColor = Color.Gray;
            sfDataGrid1.Style.HeaderStyle.TextColor = Color.Black;
            sfDataGrid1.Style.SelectionStyle.BackColor = Color.PaleGreen;
            sfDataGrid1.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGrid1.AllowEditing = true;
            sfDataGrid1.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            sfDataGrid1.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            // --- Parent Columns ---
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Index", HeaderText = "#", Width = 50, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Process", Width = 450, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "StartTime", HeaderText = "Time Start", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "EndTime", HeaderText = "Time End", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Duration", HeaderText = "Duration", CellStyle = cellstyle1, AllowTextWrapping = true });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Status", HeaderText = "Status", Visible = true, CellStyle = cellstyle1, AllowTextWrapping = true });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Color", HeaderText = "Color", Visible = false });

            if (!isSubAssembly)
                sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "IsKitList", HeaderText = "KitList", Visible = false });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", HeaderText = "ID", Visible = false });



            // Button Columns
            sfDataGrid1.Columns.Add(new GridButtonColumn()
            {
                MappingName = "StartButton",
                HeaderText = "Start",
                CellStyle = cellstyle
            });
            sfDataGrid1.Columns.Add(new GridButtonColumn()
            {
                MappingName = "EndButton",
                HeaderText = "End",
                CellStyle = cellstyle
            });
            sfDataGrid1.Columns.Add(new GridButtonColumn()
            {
                MappingName = "HoldButton",
                HeaderText = "Hold",
                CellStyle = cellstyle,
            });

            // --- Preload Track Data if Kit List ---
            List<dynamic> response_list = null;
            if (isKitlist)
            {
                var ipnList = processes
                    .SelectMany(p => (p.ipn_number ?? "").Split('/'))
                    .Where(ipn => !string.IsNullOrWhiteSpace(ipn))
                    .Distinct()
                    .ToList();


            }

            // --- Map Processes to ViewModel ---
            var viewModels = new List<ViewModel.ProcessViewModel>();
            int index = 1;

            foreach (var process in processes)
            {
                var childDurations = new List<ViewModel.ChildProcessViewModel>();

                if (process.duration != null)
                {
                    foreach (var d in process.duration)
                    {
                        childDurations.Add(new ViewModel.ChildProcessViewModel
                        {
                            Id = d.id,
                            ProcessId = process.id,
                            TimeStart = d.start_time ?? "",
                            TimeEnd = d.end_time ?? "",
                            Remarks = d.remarks ?? "N/A"
                        });
                    }
                }

                string startTimeDisplay = "N/A";
                string endTimeDisplay = "N/A";
                durationDisplay = "0 Days : 00 : 00 : 00";

                if (process.duration != null && process.duration.Count > 0)
                {
                    var firstDuration = process.duration.First();
                    var lastDuration = process.duration.Last();

                    if (!string.IsNullOrWhiteSpace(firstDuration.start_time) &&
                        DateTime.TryParse(firstDuration.start_time, out var parsedStart))
                    {
                        startTimeDisplay = $"Time: {parsedStart:HH:mm:ss} Date: {parsedStart:MM-dd-yyyy}";

                        _startTime = parsedStart;

                        if (!string.IsNullOrWhiteSpace(lastDuration.end_time) &&
                            DateTime.TryParse(lastDuration.end_time, out var parsedEnd))
                        {
                            endTimeDisplay = $"Time: {parsedEnd:HH:mm:ss} Date: {parsedEnd:MM-dd-yyyy}";
                            durationDisplay = timeFormat.FormatDuration(parsedEnd - parsedStart);
                        }
                        else
                        {
                            endTimeDisplay = "-:-:-";
                            durationDisplay = timeFormat.FormatDuration(DateTime.Now - parsedStart);
                            timer1.Start();
                        }
                    }
                    else
                    {
                        startTimeDisplay = "-";
                        endTimeDisplay = "-";
                        durationDisplay = "0 Days : 00 : 00 : 00";
                    }
                }

                viewModels.Add(new ViewModel.ProcessViewModel
                {
                    Index = index++,
                    ProcessId = process.id,
                    Name = process.name,
                    StartTime = startTimeDisplay,
                    EndTime = endTimeDisplay,
                    Duration = durationDisplay,
                    Status = process.status?.Name ?? "Unknown",
                    Color = process.status?.Color ?? "White",
                    StartButton = "▶",
                    EndButton = "⏹",
                    HoldButton = "⏸",
                    // SubProcesses = childDurations
                    // 🔑 Convert List → BindingList
                    SubProcesses = new BindingList<ViewModel.ChildProcessViewModel>(childDurations)
                });
            }



            // Assign parent data
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.DataSource = viewModels;

            // Add details view (child grid)
            sfDataGrid1.DetailsViewDefinitions.Clear();
            sfDataGrid1.DetailsViewDefinitions.Add(GetChildViewDefinition());
            // --- Assign DataSource ---
            sfDataGrid1.DataSource = viewModels;
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
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Remarks", HeaderText = "Remarks", CellStyle = cellstyle1, AllowTextWrapping = true });

            return new GridViewDefinition
            {
                RelationalColumn = "SubProcesses", // matches property in ProcessViewModel
                DataGrid = childGrid
            };
        }


        private async Task LoadSubProcessData(int processID)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            DictionaryBuilder Dbuilder = new DictionaryBuilder();
            var postData = Dbuilder.Build_PostSubP(processID);

            var token = await ApiHelper.PostJsonAsync(GetSubPUrl, postData);
            if (token == null) return;

            // Deserialize to dynamic Root model
            var data = token.ToObject<SubProcessViewModel.Root>();
            if (data == null)
            {
                MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            // --- Map Processes to ViewModel ---
            var viewModels = new List<ViewModel.SubProcessView>();
            int index = 1;

            // 🔑 Fix: Make sure you are iterating over `data.sub_process`
            if (data.sub_process != null && data.sub_process.Any())
            {
                foreach (var subprocess in data.sub_process)
                {
                    // string test = string.Format("({0}) {1}", subprocess.machine_tool_torque_name, subprocess.machine_tool_torque_value);

                    viewModels.Add(new ViewModel.SubProcessView
                    {
                        Torque_count = subprocess.is_torque == 1 ? "1" : "0",
                        Serial_count = subprocess.is_serial == 1 ? subprocess.serial_count.ToString() : "0",

                        Index = index++,
                        MaterialID = subprocess.id,
                        Name = subprocess.name,
                        Ipn = subprocess.ipn_number ?? "N/A",
                        Torque = string.Format("({0}) {1}", subprocess.machine_tool_torque_name, subprocess.machine_tool_torque_value),
                        Serial_qty = subprocess.serial_quantity.ToString(),
                        IsSerialized = subprocess.is_serial,
                        IsTorque = subprocess.is_torque,
                    });
                }
            }
            else
            {
                MessageBox.Show("No sub-process data found.", "API Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // --- Assign DataSource ---
            sfDataGrid2.DataSource = viewModels;
            pb_child.Visible = false;
        }





        // Disable for now, as it is not used
        private void sfDataGrid1_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            //// Skip if not a data column

            if (e.Column == null) return;

            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;

            // ✅ Only apply style to the "Status" column
            if (e.Column.MappingName == "Status")
            {
                // Default to LightGray
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

                // ✅ Apply to text only
                e.Style.TextColor = textColor;
                e.Style.Font = new GridFontInfo(new Font("Segoe UI", 10, FontStyle.Bold));
            }

            // find the first row that is NOT completed
            var firstPendingRow = sfDataGrid1.View.Records
                .Select(r => r.Data as ViewModel.ProcessViewModel)
                .FirstOrDefault(r => r.Status != "Completed");

            // if this is NOT the first pending row, gray it out
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

            // 🔥 Rule: Only enable row if it's the first "pending" row (previous row is Completed or this is row 0)
            bool isRowEnabled = false;

            if (recordIndex == 0)
            {
                // First row is always enabled if it's not Completed
                isRowEnabled = record.Status != "Completed";
            }
            else
            {
                // Check if the previous row is Completed
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
            }
        }




        private async void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            if (sfDataGrid1.SelectedItem is ViewModel.ProcessViewModel record)
            {
                int selectedId = Convert.ToInt32(record.ProcessId);
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
                await LoadSubProcessData(selectedId);
            }
        }
        private async void sfDataGrid1_CellButtonClick_1(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;

            var processid = 0;
            var status = "";
            switch (e.Column.MappingName)
            {

                case "StartButton":
                    record.IsStarted = true;
                    record.IsOnHold = false;
                    record.IsEnded = false;
                    record.Status = "Processing";   // ✅ update status
                    processid = Convert.ToInt32(record.ProcessId);
                    status = "START_TIME";

                    record.SubProcesses.Add(new ViewModel.ChildProcessViewModel
                    {
                        Id = record.SubProcesses.Count + 1,
                        ProcessId = record.ProcessId,
                        TimeStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Remarks = "Processing"
                    });

                    // force grid to rebind because List<T> doesn’t notify
                    sfDataGrid1.Refresh();
                    var rifd = "";
                    await PostProcessWithDictionary(processid, "Start remarks", status, rifd);

                    break;

                case "HoldButton":

                    record.IsStarted = false;
                    record.IsEnded = false;
                    processid = Convert.ToInt32(record.ProcessId);
                    var processName = record.Name;
                    var moid = lbl_mo.Text;
                    var generatedSerial = lbl_generatedSerial.Text;
                    TabFrm tabFrm = new TabFrm(this, processid, processName, moid, generatedSerial);

                    if (tabFrm.ShowDialog() == DialogResult.Yes)
                    {
                        record.IsCancelled = true; // ✅ update status
                        record.Status = "Processing";
                    }
                    else
                    {
                        // ✅ instead of adding new row, update last subprocess
                        var lastSubProcess = record.SubProcesses.LastOrDefault();
                        if (lastSubProcess != null && string.IsNullOrEmpty(lastSubProcess.TimeEnd))
                        {
                            lastSubProcess.TimeEnd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            lastSubProcess.Remarks = lbl_public_event.Text;
                        }
                        else
                        {
                            // fallback: if no subprocess found, create new one (optional)
                            record.SubProcesses.Add(new ViewModel.ChildProcessViewModel
                            {
                                Id = record.SubProcesses.Count + 1,
                                ProcessId = record.ProcessId,
                                TimeStart = record.StartTime,
                                TimeEnd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                Remarks = lbl_public_event.Text
                            });
                        }

                        record.IsOnHold = true;
                        record.Status = "Pause";
                    }

                    sfDataGrid1.Refresh();
                    break;


                case "EndButton":
                    record.IsStarted = false;
                    record.IsOnHold = false;

                    processid = Convert.ToInt32(record.ProcessId);

                    // ✅ Check if Serial_count = 0 in sfDataGrid2
                    bool hasZeroSerialCount = false;
                    if (sfDataGrid2.RowCount == 0)
                    {
                        MessageBox.Show(
                            "Please Select the Process.",
                            "Validation Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                    foreach (var row in sfDataGrid2.View.Records)
                    {
                        var material = row.Data as ViewModel.SubProcessView;
                        if (material != null && material.Serial_count == "1")
                        {
                            hasZeroSerialCount = true;
                            break;
                        }
                    }

                    if (hasZeroSerialCount)
                    {
                        MessageBox.Show(
                            "You cannot end this process because one or more materials have not scanned yet.",
                            "Validation Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                    using (var endProcess = new EndProcessScanner())
                    {
                        endProcess.rfidScaned += async (rfid) =>
                        {
                            if (!string.IsNullOrEmpty(rfid))
                            {
                                record.Status = "Completed";
                                record.IsEnded = true;
                                status = "END_TIME";


                                // ✅ instead of adding new row, update last subprocess
                                var lastSubProcess = record.SubProcesses.LastOrDefault();
                                if (lastSubProcess != null && string.IsNullOrEmpty(lastSubProcess.TimeEnd))
                                {
                                    lastSubProcess.TimeEnd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    lastSubProcess.Remarks = "Process Completed";
                                }
                                else
                                {
                                    // fallback: if no subprocess found, create new one (optional)
                                    record.SubProcesses.Add(new ViewModel.ChildProcessViewModel
                                    {
                                        Id = record.SubProcesses.Count + 1,
                                        ProcessId = record.ProcessId,
                                        TimeStart = record.StartTime,
                                        TimeEnd = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                        Remarks = "Process Completed"
                                    });
                                }
                                var Rmarks = "Process Completed";

                                await PostProcessWithDictionary(processid, Rmarks, status, rfid);
                            }
                            else
                            {
                                record.IsEnded = false;
                                record.Status = "Processing";
                                MessageBox.Show("Process End Cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        };

                        endProcess.ShowDialog();
                    }
                    break;
            }

            sfDataGrid1.Refresh();
        }


        public async Task PostProcessWithDictionary(int processid, string remark, string status, string rfid)
        {
            try
            {
                DictionaryBuilder Dbuilder = new DictionaryBuilder();
                var postData = Dbuilder.BuilderPost_Process(processid, remark, status, rfid);


                var token = await ApiHelper.PostJsonAsync(Postprocess, postData);
                if (token == null) return;

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();
                    if (data == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }

            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
            }
        }

        private void sfDataGrid2_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {

            // Guard: only act on real data rows
            if (e.DataRow == null || e.DataRow.RowType != RowType.DefaultRow)
                return;

            // Get your bound object
            var record = e.DataRow.RowData as ViewModel.SubProcessView;
            if (record == null) return;

            string selectedName = record.Name;
            var rowindex = 0;
            var processid = Convert.ToString(record.MaterialID);
            var qty = record.Serial_qty;
            var count = Convert.ToInt32(record.Serial_count) > 0 ? 0 : 1;
            var iskitlist = 0;
            var buffcount = Convert.ToString(count);

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
                // both torque and serial
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
                lbl_subprocessInfo.Text = "This material is neither serialized nor requires torque.";
                return;
            }

            if (IsScanItem == true && processstatus == "Processing")
            {
                var scanner = new ProcessScanner(rowindex, processid, selectedName, lbl_generatedSerial.Text, qty, buffcount, iskitlist, dtserials);
                formManager.OpenChildForm(scanner, sender);

                scanner.Shown += (s, args) => scanner.txt_serialnumber.Focus();
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
            else if (IsScanItem == false && processstatus == "Processing")
            {
                var Tscanner = new scantorque(processid, selectedName);
                formManager.OpenChildForm(Tscanner, sender);
                Tscanner.Shown += (s, args) => Tscanner.txt_torque.Focus();

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

        private async void ProcessFrm_Shown(object sender, EventArgs e)
        {
            this.Opacity = 0;
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 30; // speed of fade (ms per step)
            fadeTimer.Tick += FadeIn;
            fadeTimer.Start();
        }
        private void FadeIn(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05; // fade step
            }
            else
            {
                fadeTimer.Stop();
            }
        }
    }
}
