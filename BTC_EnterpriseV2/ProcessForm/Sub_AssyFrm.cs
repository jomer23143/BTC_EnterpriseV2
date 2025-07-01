using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.ABI;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;

namespace BTC_EnterpriseV2.ProcessForm
{
    public partial class Sub_AssyFrm : Form
    {
        private DateTime _startTime;
        public string? toplvlipn;
        public string? psegment;
        public string? station;
        public string? mo;
        public string? serialnumber;
        public string? generatedcode;
        public string generatedSerial;
        private string processname;
        private int is_kit_list;
        public DataTable dtserials = new DataTable("tbname");
        public DataTable response_list = new DataTable("response_list");
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        public Sub_AssyFrm(string scangeneratedSerial, DataTable response_list)
        {
            InitializeComponent();
            YUI yUI = new YUI();
            yUI.RoundedPanelDocker(panel_info1, 12);
            yUI.RoundedPanelDocker(panel_info2, 12);
            yUI.RoundedPanelDocker(panel_start, 12);
            yUI.RoundedPanelDocker(panel_dateend, 12);
            yUI.RoundedPanelDocker(panel_operator, 12);
            yUI.RoundedPanelDocker(panel_end, 12);
            yUI.RoundedPanelDocker(panel_duration, 12);
            yUI.RoundedPanelDocker(panel_date, 12);
            yUI.RoundedPanelDocker(panel_statusprocess, 12);
            yUI.RoundedPanelDocker(panel_processname, 10);
            yUI.RoundedPanelDocker(panel_segment, 10);
            yUI.RoundedPanelDocker(panel_moid, 10);
            yUI.RoundedButton(btn_scan, 10, Color.FromArgb(17, 40, 86));
            QrController();
            this.generatedSerial = scangeneratedSerial;
            pb_loader.Visible = false;
            this.response_list = response_list;
        }

        private void QrController()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.FormBorderStyle = FormBorderStyle.None;

            PB_qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
            lbl_qrinfo.Visible = false;
            PB_qrcode.Visible = false;
        }
        public void QRBehaviorController()
        {
            btn_scan.Visible = true;
            PB_qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
            lbl_qrinfo.Visible = false;
            PB_qrcode.Visible = false;
        }



        public void response()
        {
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - _startTime;

            lbl_timeEnd.Text = endTime.ToString("HH:mm:ss");
            lbl_duration.Text = duration.ToString(@"hh\:mm\:ss");
        }

        private void Sub_AssyFrm_Load(object sender, EventArgs e)
        {
            _ = InitializeFormAsync();
        }
        private async Task InitializeFormAsync()
        {
            lbl_segment.Text = psegment;
            lbl_toplvlipn.Text = toplvlipn;
            lbl_station.Text = station;
            lbl_generatedserial.Text = generatedcode;
            pb_loader.Visible = true;
            await Get_SubAsy_Process(generatedSerial);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _startTime;
            lbl_duration.Text = FormatDuration(duration);
        }


        private string FormatDuration(TimeSpan duration)
        {
            return $"{duration.Days} Day{(duration.Days != 1 ? "s" : "")} : " +
                   $"{duration.Hours} hr{(duration.Hours != 1 ? "s" : "")} : " +
                   $"{duration.Minutes} min{(duration.Minutes != 1 ? "s" : "")} : " +
                   $"{duration.Seconds} Second{(duration.Seconds != 1 ? "s" : "")}";
        }


        public class ApiErrorResponse
        {
            public string? message { get; set; }
        }


        public async Task Get_SubAsy_Process(string serial)
        {
            try
            {
                // Clean and prepare serial
                var serialClean = serial.Trim();
                var postData = new { serial_number = serialClean };
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                // API call
                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
                Debug.WriteLine("Response: " + jsonResponse);

                // Basic validation
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse response
                var token = JToken.Parse(jsonResponse);

                // Handle error object
                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Handle valid array response
                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dtserials.Rows.Clear();
                    dtserials.Columns.Clear();
                    dtserials.Columns.Add("id");
                    dtserials.Columns.Add("process_id");
                    dtserials.Columns.Add("serial_number");
                    ///From master jomer
                    foreach (var data_process in data.process)
                    {
                        foreach (var data_serial in data_process.serial)
                        {
                            dtserials.Rows.Add(data_serial.id, data_serial.manufacturing_order_process_id, data_serial.serial_number);
                        }
                        is_kit_list = data_process.is_kit_list;
                    }


                    // Populate labels
                    lbl_toplvlipn.Text = data.mo_id;
                    lbl_segment.Text = "Sub Assembly";
                    lbl_station.Text = data.name;
                    lbl_generatedserial.Text = data.serial_number;

                    var durationItem = data.duration?.FirstOrDefault();
                    var rawStartTime = data.duration?.FirstOrDefault()?.start_time;
                    var rawEndTime = data.duration?.FirstOrDefault()?.end_time;

                    if (durationItem == null)
                    {
                        MessageBox.Show("No duration data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int reqValidator = durationItem.manufacturing_order_station_status_id;

                    switch (reqValidator)
                    {
                        case 1:
                            lbl_processStatus.Text = "In Progress";
                            lbl_processStatus.ForeColor = Color.FromArgb(7, 222, 151);
                            break;

                        case 2:
                            lbl_processStatus.Text = "Pending";
                            lbl_processStatus.ForeColor = Color.OrangeRed;
                            break;

                        case 3:
                            lbl_processStatus.Text = "Done";
                            lbl_processStatus.ForeColor = Color.Red;
                            btn_scan.Text = "This Process is already Done";
                            btn_scan.Enabled = false;

                            using (var dialog = new ProcessDoneModal(lbl_station.Text))
                            {
                                dialog.StartPosition = FormStartPosition.CenterScreen;
                                dialog.ShowDialog();
                                if (dialog.Result == DialogResult.OK)
                                {
                                    // Handle OK result if needed
                                }
                                else if (dialog.Result == DialogResult.Cancel)
                                {
                                    // Handle Cancel result if needed
                                }
                            }
                            break;

                        default:
                            lbl_processStatus.Text = "Unknown Status";
                            lbl_processStatus.ForeColor = Color.Gray;
                            break;
                    }

                    if (data.duration != null && data.duration.Count > 0)
                    {
                        var firstDuration = data.duration.First();
                        var lastDuration = data.duration.Last();

                        if (!string.IsNullOrWhiteSpace(firstDuration.start_time) &&
                            DateTime.TryParse(firstDuration.start_time, out var parsedStart))
                        {
                            lbl_timestart.Text = parsedStart.ToString("HH:mm:ss");
                            lbl_date.Text = parsedStart.ToString("dddd, MMMM dd, yyyy");
                            _startTime = parsedStart;

                            if (!string.IsNullOrWhiteSpace(lastDuration.end_time) &&
                                DateTime.TryParse(lastDuration.end_time, out var parsedEnd))
                            {
                                lbl_timeEnd.Text = parsedEnd.ToString("HH:mm:ss");
                                lbl_date_end.Text = parsedEnd.ToString("dddd, MMMM dd, yyyy");
                                lbl_duration.Text = FormatDuration(parsedEnd - parsedStart);
                            }
                            else
                            {
                                lbl_timeEnd.Text = "-:-:-";
                                lbl_date_end.Text = "-:-:-";
                                lbl_duration.Text = FormatDuration(DateTime.Now - parsedStart);
                                timer1.Start();
                            }
                        }
                        //var firstDuration = data.duration.FirstOrDefault();
                        //var lastDuration = data.duration.Last();
                        //var lastWithEndTime = data.duration.LastOrDefault(x =>
                        //    !string.IsNullOrWhiteSpace(x.end_time) &&
                        //    DateTime.TryParse(x.end_time, out _));

                        //if (firstDuration != null &&
                        //!string.IsNullOrWhiteSpace(firstDuration.start_time) &&
                        //DateTime.TryParse(firstDuration.start_time, out var parsedStart))
                        //{
                        //    lbl_timestart.Text = parsedStart.ToString("HH:mm:ss");
                        //    lbl_date.Text = parsedStart.ToString("dddd, MMMM dd, yyyy");
                        //    _startTime = parsedStart;

                        //    if (lastWithEndTime != null &&
                        //        DateTime.TryParse(lastWithEndTime.end_time, out var parsedEnd))
                        //    {
                        //        lbl_timeEnd.Text = parsedEnd.ToString("HH:mm:ss");
                        //        lbl_date_end.Text = parsedEnd.ToString("dddd, MMMM dd, yyyy");
                        //        lbl_duration.Text = FormatDuration(parsedEnd - parsedStart);
                        //    }
                        //    else
                        //    {
                        //        lbl_timeEnd.Text = "-:-:-";
                        //        lbl_date_end.Text = "-:-:-";
                        //        lbl_duration.Text = FormatDuration(DateTime.Now - parsedStart);
                        //        timer1.Start();
                        //    }
                        //}



                        else
                        {
                            lbl_timestart.Text = "-";
                            lbl_date.Text = "-";
                            lbl_timeEnd.Text = "-:-:-";
                            lbl_duration.Text = "0 Days : 00 : 00 : 00";
                        }
                    }
                    else
                    {
                        lbl_timestart.Text = "-";
                        lbl_date.Text = "-";
                        lbl_timeEnd.Text = "-";
                        lbl_date_end.Text = "-";
                        lbl_duration.Text = "0 Days : 00 : 00 : 00";
                    }

                    LoadProcessData(data.process);
                    pb_loader.Visible = false;
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


        private void LoadProcessData(List<Sub_Asy_Process_Model.Process> processes)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("NoProcess", "No. Process");
            dataGridView1.Columns.Add("name", "Process");
            dataGridView1.Columns.Add("ipn_number", "IPN");
            dataGridView1.Columns.Add("serial_quantity", "Serial Quantity");
            dataGridView1.Columns.Add("serial_count", "Scaned");

            var idColumn = dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns["id"].Visible = false;

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            {
                Name = "ScanItemSerial",
                HeaderText = "Scan Item Serial",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView1.Columns.Add(imgColumn);

            string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "qrcode.gif");
            Image originalImage = Image.FromFile(defaultImagePath);
            Image resizedImage = ResizeImage(originalImage, 60, 60);

            string viewImagePath = Path.Combine(Application.StartupPath, "Assets", "viewsacn.png");
            Image viewImage = Image.FromFile(viewImagePath);
            Image resizedImage2 = ResizeImage(viewImage, 60, 60);


            int index = 1;
            foreach (var process in processes)
            {

                if (process.serial_count == process.serial_quantity)
                {
                    process.serial_count = 0;
                }
                else
                {
                    process.serial_count = process.serial_quantity - process.serial_count;
                }


                bool isCompleted = process.serial_count >= process.serial_quantity;

                int remaining = process.serial_quantity - process.serial_count;
                if (remaining < 0) remaining = 0;

                Image iconToShow = isCompleted ? resizedImage2 : resizedImage;

                dataGridView1.Rows.Add(index++, process.name, process.ipn_number, process.serial_quantity, process.serial_count, process.id, iconToShow);


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
        }






        private void Sub_AssyFrm_SizeChanged(object sender, EventArgs e)
        {
            YUI yUI = new YUI();
            yUI.RoundedPanelDocker(panel_info1, 12);
            yUI.RoundedPanelDocker(panel_info2, 12);
            yUI.RoundedPanelDocker(panel_start, 12);
            yUI.RoundedPanelDocker(panel_end, 12);
            yUI.RoundedPanelDocker(panel_duration, 12);
            yUI.RoundedPanelDocker(panel_date, 12);
            yUI.RoundedButton(btn_scan, 10, Color.FromArgb(17, 40, 86));
        }


        private void btn_scan_Click(object sender, EventArgs e)
        {
            btn_scan.Visible = false;
            PB_qrcode.Visible = true;
            lbl_qrinfo.Visible = true;
            string id = string.Empty;
            string processname = "Sub Assembly";
            string moid = mo;
            string segment = psegment;
            GenerateQRCode(lbl_generatedserial.Text);
            EndProcessValidation();
            QRBehaviorController();
        }
        private void GenerateQRCode(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            PB_qrcode.Image = qrCodeImage;
        }


        private void EndProcessValidation()
        {
            bool hasMismatch = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var serialQtyStr = row.Cells["serial_quantity"].Value?.ToString();
                var serialCountStr = row.Cells["serial_count"].Value?.ToString();
                processname = row.Cells["name"].Value?.ToString();
                if (!int.TryParse(serialQtyStr, out int serialQty) || !int.TryParse(serialCountStr, out int serialCount))
                {
                    using (var dialog = new CustomDialog("ABI", "Invalid quantity or count value., would you like to proceed for ABI?"))
                    {
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.ShowDialog();
                        if (dialog.Result == DialogResult.OK)
                        {
                            ABI_Frm aBI_Frm = new ABI_Frm(lbl_segment.Text, lbl_toplvlipn.Text, generatedSerial, processname);
                            aBI_Frm.ShowDialog();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }

                }

                Debug.WriteLine($"Serial Quantity: {serialQty}, Serial Count: {serialCount}");

                if (serialCount != serialQty)
                {
                    hasMismatch = true;
                    break;
                }
            }

            if (hasMismatch)
            {
                using (var dialog = new CustomDialog("ABI", "Invalid quantity or count value., would you like to proceed for ABI?"))
                {
                    dialog.StartPosition = FormStartPosition.CenterScreen;
                    dialog.ShowDialog();
                    if (dialog.Result == DialogResult.OK)
                    {
                        ABI_Frm aBI_Frm = new ABI_Frm(lbl_segment.Text, lbl_toplvlipn.Text, generatedSerial, processname);
                        aBI_Frm.ShowDialog();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            using (var endProcess = new EndProcessScanner())
            {
                endProcess.SerialScanned += async (serial) =>
                {
                    if (!string.IsNullOrEmpty(serial))
                    {
                        var status = 3;
                        await End_Process(serial, status);
                    }
                };

                endProcess.ShowDialog();
            }

        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                e.ColumnIndex == dataGridView1.Columns["ScanItemSerial"].Index)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Get quantity and count values
                var serialQtyStr = row.Cells["serial_quantity"].Value?.ToString();
                var serialCountStr = row.Cells["serial_count"].Value?.ToString();

                var processname = row.Cells["name"].Value?.ToString();
                // Start scanning
                var processId = row.Cells["id"].Value?.ToString();

                // Try to parse to integers
                bool qtyParsed = int.TryParse(serialQtyStr, out int serialQty);
                bool countParsed = int.TryParse(serialCountStr, out int serialCount);

                if (!qtyParsed || !countParsed)
                {
                    MessageBox.Show("Invalid quantity or count value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (serialCount == serialQty)
                {
                    DialogResult = MessageBox.Show("This process is already Done, do you want to view more details?.", "Process Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (DialogResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {

                        ViewScanedDetails view = new ViewScanedDetails(e.RowIndex, processId, processname, lbl_generatedserial.Text, dtserials);
                        view.ShowDialog();
                        return;
                    }

                }

                ProcessScanner scan = new ProcessScanner(e.RowIndex, processId, processname, lbl_generatedserial.Text, serialQtyStr, serialCountStr, is_kit_list, dtserials);
                scan.ShowDialog();
                await Get_SubAsy_Process(lbl_generatedserial.Text);

            }
        }

        // mao ni ako method sa pag kuha sa response 

        public async Task Get_Process_response(string serial, string processid, string kitserial)
        {
            try
            {
                var processidClean = processid.Trim();
                var kitserialClean = kitserial.Trim();
                var serialClean = serial.Trim();
                var postData = new
                {
                    process_id = processidClean,
                    kit_serial = kitserialClean,
                    serial_number = serialClean
                };
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
                Debug.WriteLine("Response: " + jsonResponse);

                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var token = JToken.Parse(jsonResponse);

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    lbl_processStatus.Text = "Processing";
                    lbl_processStatus.ForeColor = Color.Green;

                    lbl_toplvlipn.Text = data.mo_id;
                    lbl_segment.Text = "Sub Assembly";
                    lbl_station.Text = data.name;
                    lbl_generatedserial.Text = data.serial_number;
                    LoadProcessData(data.process);

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


        // Method for End the processs 
        public async Task End_Process(string serial, int status)
        {
            try
            {

                var serialClean = serial.Trim();
                var statusClean = status;
                var postData = new
                {
                    serial_number = serialClean,
                    status_id = statusClean
                };
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
                Debug.WriteLine("Response: " + jsonResponse);

                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var token = JToken.Parse(jsonResponse);

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var rawStartTime = data.duration?.FirstOrDefault()?.start_time;
                    var rawEndTime = data.duration?.FirstOrDefault()?.end_time;

                    if (!string.IsNullOrWhiteSpace(rawStartTime) && DateTime.TryParse(rawStartTime, out var parsedStart))
                    {
                        lbl_timestart.Text = parsedStart.ToString("HH:mm:ss");
                        lbl_date.Text = parsedStart.ToString("dddd, MMMM-dd-yyyy");
                        _startTime = parsedStart;

                        if (!string.IsNullOrWhiteSpace(rawEndTime) && DateTime.TryParse(rawEndTime, out var parsedEnd))
                        {
                            lbl_timeEnd.Text = parsedEnd.ToString("HH:mm:ss");
                            lbl_date_end.Text = parsedEnd.ToString("dddd, MMMM-dd-yyyy");
                            lbl_processStatus.Text = "Done";
                            lbl_processStatus.ForeColor = Color.Red;

                            btn_scan.Text = "This  Process is already Done";
                            btn_scan.Enabled = false;
                            TimeSpan duration = parsedEnd - parsedStart;
                            lbl_duration.Text = FormatDuration(duration);
                            timer1.Stop();
                        }
                        else
                        {
                            lbl_timeEnd.Text = "-:-:-";
                            lbl_date_end.Text = "-:-:-";
                            TimeSpan duration = DateTime.Now - parsedStart;
                            lbl_duration.Text = FormatDuration(duration);
                            timer1.Start();
                        }
                    }
                    else
                    {
                        lbl_timestart.Text = "-";
                        lbl_date.Text = "-";
                        lbl_timeEnd.Text = "-:-:-";
                        lbl_date_end.Text = "-:-:-";
                        lbl_duration.Text = "0 Days : 00: 00  :00 ";
                    }


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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
