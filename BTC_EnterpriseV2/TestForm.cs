using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;
namespace BTC_EnterpriseV2
{
    public partial class TestForm : Form
    {
        public static TestForm instance;
        public DataGridView dgv1;///jomer
        private DateTime _startTime;
        public string? toplvlipn;
        public string? psegment;
        public string? station;
        public string? _MoID;
        public string? serialnumber;
        public string? generatedcode;
        public string _serial;
        private string processname;
        private int _segmentID;
        private int is_kit_list;
        public DataTable dtserials = new DataTable("tbname");
        public DataTable response_list = new DataTable("response_list");
        private string ApiUrl = GlobalApi.GetScanSerialUrl();
        private string ScanUrl = GlobalApi.GetScanUrl();
        private string GetSubPUrl = GlobalApi.GetGetSubPUrl();
        private TimeFormat timeFormat = new TimeFormat();
        public TestForm(string scangeneratedSerial, DataTable response_list, int segmentid, string processname)
        //   public TestForm()
        {
            InitializeComponent();

            QrController();
            instance = this;//jomer
                            //dgv1 = sfDataGrid1;//jomer
            this._serial = scangeneratedSerial;
            ////  pb_loader.Visible = false;
            //this.response_list = response_list;
            this._segmentID = segmentid;
            this.processname = processname;
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            _ = InitializeFormAsync();
        }

        private void QrController()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.FormBorderStyle = FormBorderStyle.None;

            // PB_qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
            //  lbl_qrinfo.Visible = false;
            //  PB_qrcode.Visible = false;
        }
        public void QRBehaviorController()
        {
            //btn_scan.Visible = true;
            //PB_qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
            //lbl_qrinfo.Visible = false;
            //PB_qrcode.Visible = false;
        }
        private async Task InitializeFormAsync()
        {
            //lbl_toplvlipn.Text = toplvlipn;
            //lbl_station.Text = station;
            //lbl_generatedserial.Text = generatedcode;
            //pb_loader.Visible = true;
            bool response = _segmentID == 1 ? true : false;
            switch (response)
            {
                case true:
                    // lbl_segment.Text = processname;
                    await LoadSegmentProcessAsync(_serial, _segmentID); // No segment ID
                    break;

                case false:
                    // lbl_segment.Text = processname;
                    await LoadSegmentProcessAsync(_serial, _segmentID); // With segment ID
                    break;


                default:
                    //  lbl_segment.Text = "Unknown Segment";
                    break;
            }
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

                var token = await ApiHelper.PostJsonAsync(ApiUrl, postData);
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
                    //lbl_toplvlipn.Text = data.mo_id;
                    //lbl_segment.Text = processname;
                    //lbl_station.Text = data.name;
                    //lbl_generatedserial.Text = data.serial_number;

                    var durationItem = data.duration?.FirstOrDefault();
                    var rawStartTime = data.duration?.FirstOrDefault()?.start_time;
                    var rawEndTime = data.duration?.FirstOrDefault()?.end_time;

                    if (durationItem == null)
                    {
                        MessageBox.Show("No duration data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //  int reqValidator = durationItem.manufacturing_order_station_status_id;

                    //switch (reqValidator)
                    //{
                    //    case 1:
                    //        lbl_processStatus.Text = "In Progress";
                    //        lbl_processStatus.ForeColor = Color.FromArgb(7, 222, 151);
                    //        break;

                    //    case 2:
                    //        lbl_processStatus.Text = "Pending";
                    //        lbl_processStatus.ForeColor = Color.OrangeRed;
                    //        break;

                    //    case 3:
                    //        lbl_processStatus.Text = "Done";
                    //        lbl_processStatus.ForeColor = Color.Red;
                    //        btn_scan.Text = "This Process is already Done";
                    //        btn_scan.Enabled = false;

                    //        using (var dialog = new ProcessDoneModal(lbl_station.Text))
                    //        {
                    //            dialog.StartPosition = FormStartPosition.CenterScreen;
                    //            dialog.ShowDialog();
                    //            if (dialog.Result == DialogResult.OK)
                    //            {
                    //                // Handle OK result if needed
                    //            }
                    //            else if (dialog.Result == DialogResult.Cancel)
                    //            {
                    //                // Handle Cancel result if needed
                    //            }
                    //        }
                    //        break;

                    //    default:
                    //        lbl_processStatus.Text = "Unknown Status";
                    //        lbl_processStatus.ForeColor = Color.Gray;
                    //        break;
                    //}

                    //    if (data.duration != null && data.duration.Count > 0)
                    //    {
                    //        var firstDuration = data.duration.First();
                    //        var lastDuration = data.duration.Last();

                    //        if (!string.IsNullOrWhiteSpace(firstDuration.start_time) &&
                    //            DateTime.TryParse(firstDuration.start_time, out var parsedStart))
                    //        {
                    //            lbl_timestart.Text = parsedStart.ToString("HH:mm:ss");
                    //            lbl_date.Text = parsedStart.ToString("dddd, MMMM dd, yyyy");
                    //            _startTime = parsedStart;

                    //            if (!string.IsNullOrWhiteSpace(lastDuration.end_time) &&
                    //                DateTime.TryParse(lastDuration.end_time, out var parsedEnd))
                    //            {
                    //                lbl_timeEnd.Text = parsedEnd.ToString("HH:mm:ss");
                    //                lbl_date_end.Text = parsedEnd.ToString("dddd, MMMM dd, yyyy");
                    //                lbl_duration.Text = timeFormat.FormatDuration(parsedEnd - parsedStart);
                    //            }
                    //            else
                    //            {
                    //                lbl_timeEnd.Text = "-:-:-";
                    //                lbl_date_end.Text = "-:-:-";
                    //                lbl_duration.Text = timeFormat.FormatDuration(DateTime.Now - parsedStart);
                    //                timer1.Start();
                    //            }
                    //        }

                    //        else
                    //        {
                    //            lbl_timestart.Text = "-";
                    //            lbl_date.Text = "-";
                    //            lbl_timeEnd.Text = "-:-:-";
                    //            lbl_duration.Text = "0 Days : 00 : 00 : 00";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lbl_timestart.Text = "-";
                    //        lbl_date.Text = "-";
                    //        lbl_timeEnd.Text = "-";
                    //        lbl_date_end.Text = "-";
                    //        lbl_duration.Text = "0 Days : 00 : 00 : 00";
                    //    }

                    bool isSubAssembly = segmentId == 1;
                    await LoadProcessDataMerged_Sf(data.process, isSubAssembly, anyIsKitList);


                    //    pb_loader.Visible = false;
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

        private async Task LoadProcessDataMerged_Sf(List<Sub_Asy_Process_Model.Process> processes, bool isSubAssembly, bool isKitlist)
        {
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Clear();
            CellStyleInfo cellstyle = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.FromArgb(0, 0, 0),
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
            sfDataGrid1.Style.HeaderStyle.BackColor = Color.FromArgb(7, 222, 151);
            sfDataGrid1.Style.HeaderStyle.TextColor = Color.White;
            // --- Parent Columns ---
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Index", HeaderText = "#", Width = 50, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Process", Width = 450, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "StartTime", HeaderText = "Time Start", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "EndTime", HeaderText = "Time End", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Duration", HeaderText = "Duration", CellStyle = cellstyle1 });

            if (!isSubAssembly)
                sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "IsKitList", HeaderText = "KitList", Visible = false });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", HeaderText = "ID", Visible = false });

            // Button Columns
            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "StartButton", HeaderText = "Start", CellStyle = cellstyle });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "HoldButton", HeaderText = "Hold", CellStyle = cellstyle });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "BreakButton", HeaderText = "Break", CellStyle = cellstyle });

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
            var viewModels = new List<ProcessViewModel>();
            int index = 1;

            foreach (var process in processes)
            {
                var childDurations = new List<ChildProcessViewModel>();

                if (process.duration != null)
                {
                    foreach (var d in process.duration)
                    {
                        childDurations.Add(new ChildProcessViewModel
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
                string durationDisplay = "0 Days : 00 : 00 : 00";

                if (process.duration != null && process.duration.Count > 0)
                {
                    var firstDuration = process.duration.First();
                    var lastDuration = process.duration.Last();

                    if (!string.IsNullOrWhiteSpace(firstDuration.start_time) &&
                        DateTime.TryParse(firstDuration.start_time, out var parsedStart))
                    {
                        startTimeDisplay = $"{parsedStart:HH:mm:ss} {parsedStart:dddd, MMMM dd, yyyy}";
                        _startTime = parsedStart;

                        if (!string.IsNullOrWhiteSpace(lastDuration.end_time) &&
                            DateTime.TryParse(lastDuration.end_time, out var parsedEnd))
                        {
                            endTimeDisplay = $"{parsedEnd:HH:mm:ss} {parsedEnd:dddd, MMMM dd, yyyy}";
                            durationDisplay = timeFormat.FormatDuration(parsedEnd - parsedStart);
                        }
                        else
                        {
                            endTimeDisplay = "-:-:-";
                            durationDisplay = timeFormat.FormatDuration(DateTime.Now - parsedStart);
                            // timer1.Start();
                        }
                    }
                    else
                    {
                        startTimeDisplay = "-";
                        endTimeDisplay = "-";
                        durationDisplay = "0 Days : 00 : 00 : 00";
                    }
                }

                viewModels.Add(new ProcessViewModel
                {
                    Index = index++,
                    ProcessId = process.id,
                    Name = process.name,
                    StartTime = startTimeDisplay,
                    EndTime = endTimeDisplay,
                    Duration = durationDisplay,
                    StartButton = "▶",
                    HoldButton = "⏸",
                    BreakButton = "☕",
                    SubProcesses = childDurations
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
            //pb_loader.Visible = false;
        }

        // --- ViewModel for SfDataGrid Binding ---


        private GridViewDefinition GetChildViewDefinition()
        {
            var childGrid = new SfDataGrid
            {
                AutoGenerateColumns = false
            };
            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.FromArgb(0, 0, 0),
                BackColor = Color.PaleGreen
            };
            childGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            childGrid.HeaderRowHeight = 45;
            childGrid.RowHeight = 60;
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Id", HeaderText = "#", CellStyle = cellstyle1 });
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

        public class ProcessViewModel
        {
            public int Index { get; set; }
            public string? ProcessId { get; set; }
            public string Name { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string Duration { get; set; }

            public string StartButton { get; set; }
            public string HoldButton { get; set; }
            public string BreakButton { get; set; }

            // For child rows
            public List<ChildProcessViewModel> SubProcesses { get; set; } = new List<ChildProcessViewModel>();
        }


        public class ChildProcessViewModel
        {
            public int Id { get; set; }
            public string ProcessId { get; set; }
            public string TimeStart { get; set; }
            public string TimeEnd { get; set; }
            public string Remarks { get; set; }
        }


        private async Task LoadSubProcessData(int processID)
        {
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

            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Index", HeaderText = "#", Width = 50 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Material" });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Ipn", HeaderText = "IPN Number" });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Serial_qty", HeaderText = "Serial Qty", Visible = false });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Serial_count", HeaderText = "Scanned Serial", Visible = false });

            sfDataGrid2.Columns.Add(new GridImageColumn()
            {
                MappingName = "image",
                HeaderText = "Scan Item Serial",
                ImageLayout = ImageLayout.Zoom
            });

            // Load Images
            string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "qrcode.gif");
            Image resizedDefaultImage = ResizeImage(Image.FromFile(defaultImagePath), 60, 60);

            // --- Map Processes to ViewModel ---
            var viewModels = new List<SubProcessView>();
            int index = 1;

            // 🔑 Fix: Make sure you are iterating over `data.sub_process`
            if (data.sub_process != null && data.sub_process.Any())
            {
                foreach (var subprocess in data.sub_process)
                {
                    viewModels.Add(new SubProcessView
                    {
                        Index = index++,
                        Name = subprocess.name,
                        Ipn = subprocess.ipn_number ?? "N/A",
                        Serial_qty = subprocess.serial_quantity.ToString(),
                        Serial_count = subprocess.serial_count.ToString(),
                        image = resizedDefaultImage != null
                            ? (byte[])new ImageConverter().ConvertTo(resizedDefaultImage, typeof(byte[]))
                            : null
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
        }



        public class SubProcessView
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Ipn { get; set; }
            public string? Serial_qty { get; set; }
            public string? Serial_count { get; set; }
            public byte[] image { get; set; }
        }

        private async void sfDataGrid1_CurrentCellActivated(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatedEventArgs e)
        {
            if (e.DataRow?.RowData is ProcessViewModel record)
            {
                int selectedId = Convert.ToInt32(record.ProcessId);
                string selecttedName = record.Name;

                label1.Text = $"Process Name : {selecttedName}";
                await LoadSubProcessData(selectedId);

            }
        }
    }
}