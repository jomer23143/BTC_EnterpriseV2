using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.ABI;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.ProcessForm
{
    public partial class Pre_AssyFrm : Form
    {
        private DateTime _startTime;
        private TimeFormat timeFormat = new TimeFormat();
        private int is_kit_list;
        public DataTable dtserials = new DataTable("tbname");
        public DataTable response_list = new DataTable("response_list");
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        private int _stationID;
        private string _serial;
        public Pre_AssyFrm(int stationID, string serial)
        {
            InitializeComponent();
            this._stationID = stationID;
            this._serial = serial;

            YUI yUI = new YUI();
            yUI.RoundedPanelDocker(panel_info1, 10);
            yUI.RoundedPanelDocker(panel_info2, 10);
            yUI.RoundedPanelDocker(panel_start, 10);
            yUI.RoundedPanelDocker(panel_dateend, 10);
            yUI.RoundedPanelDocker(panel_operator, 10);
            yUI.RoundedPanelDocker(panel_end, 10);
            yUI.RoundedPanelDocker(panel_duration, 10);
            yUI.RoundedPanelDocker(panel_date, 10);
            yUI.RoundedPanelDocker(panel_statusprocess, 10);
            yUI.RoundedPanelDocker(panel_processname, 8);
            yUI.RoundedPanelDocker(panel_segment, 8);
            yUI.RoundedPanelDocker(panel_moid, 8);
            yUI.RoundedPanelDocker(panel_generatedserial, 8);
            yUI.RoundedButton(btn_scan, 10, Color.FromArgb(7, 222, 151));
            // yUI.RoundedButton(btn_scan, 10, Color.Lime);
            QrController();
            //   this.generatedSerial = scangeneratedSerial;
            pb_loader.Visible = false;
            this.response_list = response_list;
        }

        private void Pre_AssyFrm_SizeChanged(object sender, EventArgs e)
        {

            YUI yUI = new YUI();
            yUI.RoundedPanelDocker(panel_info1, 10);
            yUI.RoundedPanelDocker(panel_info2, 10);
            yUI.RoundedPanelDocker(panel_start, 10);
            yUI.RoundedPanelDocker(panel_dateend, 10);
            yUI.RoundedPanelDocker(panel_operator, 10);
            yUI.RoundedPanelDocker(panel_end, 10);
            yUI.RoundedPanelDocker(panel_duration, 10);
            yUI.RoundedPanelDocker(panel_date, 10);
            yUI.RoundedPanelDocker(panel_statusprocess, 10);
            yUI.RoundedPanelDocker(panel_processname, 8);
            yUI.RoundedPanelDocker(panel_segment, 8);
            yUI.RoundedPanelDocker(panel_moid, 8);
            yUI.RoundedPanelDocker(panel_generatedserial, 8);
            yUI.RoundedButton(btn_scan, 10, Color.FromArgb(7, 222, 151));
            // yUI.RoundedButton(btn_scan, 10, Color.Lime);
            QrController();
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


        private void Pre_AssyFrm_Load(object sender, EventArgs e)
        {
            _ = InitializeFormAsync();
        }
        private async Task InitializeFormAsync()
        {

            await Get_PreAssy_Process(_serial, _stationID);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _startTime;
            lbl_duration.Text = timeFormat.FormatDuration(duration);
        }
        public async Task Get_PreAssy_Process(string serial, int id)
        {
            try
            {
                pb_loader.Visible = true;
                var serialClean = serial.Trim();
                var postData = new { serial_number = serialClean, station_id = id };
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
                    lbl_segment.Text = "Pre Assembly";
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
                                lbl_duration.Text = timeFormat.FormatDuration(parsedEnd - parsedStart);
                            }
                            else
                            {
                                lbl_timeEnd.Text = "-:-:-";
                                lbl_date_end.Text = "-:-:-";
                                lbl_duration.Text = timeFormat.FormatDuration(DateTime.Now - parsedStart);
                                timer1.Start();
                            }
                        }

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

                //if (process.serial_count == process.serial_quantity)
                //{
                //    process.serial_count = 0;
                //}
                //else
                //{
                //    process.serial_count = process.serial_quantity - process.serial_count;
                //}


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ScanItemSerial"].Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["serial_count"].Value.ToString() == "1")
                {
                    MessageBox.Show("This process is already done.", "Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int processId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                string ipnNumber = dataGridView1.Rows[e.RowIndex].Cells["ipn_number"].Value.ToString();
                string processName = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                using (var dialog = new PreAssy_ProcessScanner(_stationID, processId, processName, _serial))
                {
                    dialog.ShowDialog();

                }
            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            btn_scan.Visible = false;
            PB_qrcode.Visible = true;
            lbl_qrinfo.Visible = true;
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
            var processname = string.Empty;

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
                            ABI_Frm aBI_Frm = new ABI_Frm(lbl_segment.Text, lbl_toplvlipn.Text, _serial, processname);
                            aBI_Frm.ShowDialog();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }

                }

                //  Debug.WriteLine($"Serial Quantity: {serialQty}, Serial Count: {serialCount}");

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
                        ABI_Frm aBI_Frm = new ABI_Frm(lbl_segment.Text, lbl_toplvlipn.Text, _serial, processname);
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
                endProcess.rfidScaned += async (rfid) =>
                {
                    if (!string.IsNullOrEmpty(rfid))
                    {
                        var status = 3;
                        var serialnumber = lbl_generatedserial.Text;
                        var remark = "Process Completed";
                        await End_Process(serialnumber, status, remark, rfid);
                    }
                };

                endProcess.ShowDialog();
            }

        }
        // Method for End the processs 
        public async Task End_Process(string serial, int status, string remark, string rfid)
        {
            try
            {

                var serialClean = serial.Trim();
                var statusClean = status;
                var rfidClean = rfid.Trim();
                var postData = new
                {
                    serial_number = serialClean,
                    status_id = statusClean,
                    remarks = remark,
                    employee_rfid = rfidClean
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
                            lbl_duration.Text = timeFormat.FormatDuration(duration);
                            timer1.Stop();
                        }
                        else
                        {
                            lbl_timeEnd.Text = "-:-:-";
                            lbl_date_end.Text = "-:-:-";
                            TimeSpan duration = DateTime.Now - parsedStart;
                            lbl_duration.Text = timeFormat.FormatDuration(duration);
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


    }
}
