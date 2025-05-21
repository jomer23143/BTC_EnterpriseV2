using System.Diagnostics;
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
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        public Sub_AssyFrm(string scangeneratedSerial)
        {
            InitializeComponent();
            YUI yUI = new YUI();
            yUI.RoundedPanelDocker(panel_info1, 12);
            yUI.RoundedPanelDocker(panel_info2, 12);
            yUI.RoundedPanelDocker(panel_start, 12);
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

            await Get_SubAsy_Process(generatedSerial);

            _startTime = DateTime.Now;
            lbl_timestart.Text = _startTime.ToString("HH:mm:ss");
            lbl_duration.Text = "00:00:00";
            lbl_date.Text = _startTime.ToString("dddd, MMMM-dd-yyyy");
            timer1.Start();
        }


        public class ApiErrorResponse
        {
            public string? message { get; set; }
        }

        public async Task Get_SubAsy_Process(string serial)
        {
            try
            {
                var serialClean = serial.Trim();
                var postData = new { serial_number = serialClean };
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

                    lbl_processStatus.Text = "In Progress";
                    lbl_processStatus.ForeColor = Color.FromArgb(7, 222, 151);

                    lbl_toplvlipn.Text = data.mo_id;
                    lbl_segment.Text = "Sub Assymbly";
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

                dataGridView1.Rows.Add(index++, process.name, process.ipn_number, process.serial_quantity, process.serial_count, process.id, resizedImage);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _startTime;
            lbl_duration.Text = duration.ToString(@"hh\:mm\:ss");
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            btn_scan.Visible = false;
            PB_qrcode.Visible = true;
            lbl_qrinfo.Visible = true;
            string id = string.Empty;
            string processname = "Sub Assy";
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
            bool allScanned = true;
            bool hasZeroCount = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var serialqty = row.Cells["serial_quantity"].Value?.ToString();
                var serialcount = row.Cells["serial_count"].Value?.ToString();
                var status = row.Cells["ScanItemSerial"].Value?.ToString();

                // Check if serial count is 0
                if (serialcount != serialqty)
                {
                    hasZeroCount = true;
                    break;
                }

                // If quantity equals count, check if scanned
                if (serialqty == serialcount)
                {
                    if (!string.Equals(status, "Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        allScanned = false;
                        break;
                    }
                }
            }

            if (hasZeroCount)
            {
                MessageBox.Show("One or more processes have serials not scanned. Please complete scanning before ending the process.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (allScanned)
            {
                EndProcessScanner endProcess = new EndProcessScanner();
                endProcess.SerialScanned += (serial) =>
                {
                    if (!string.IsNullOrEmpty(serial))
                    {
                        SaveProcess();
                    }
                };

                endProcess.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please scan all item serial numbers for each process to proceed.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }



        private void SaveProcess()
        {
            MessageBox.Show("The Process is Sucessfully saved.");
            lbl_processStatus.Text = "Done";
            lbl_processStatus.ForeColor = Color.Red;
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
                    MessageBox.Show("This process is already fully scanned.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var processname = row.Cells["name"].Value?.ToString();
                // Start scanning
                ProcessScanner scan = new ProcessScanner(e.RowIndex, processname, lbl_generatedserial.Text, serialQtyStr, serialCountStr);
                scan.SerialScanned += async (serial) =>
                {
                    if (!string.IsNullOrWhiteSpace(serial))
                    {
                        var processId = row.Cells["id"].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(processId))
                        {
                            await Get_Process_response(
                                lbl_generatedserial.Text,
                                processId,
                                serial
                            );
                        }
                    }
                };

                scan.ShowDialog();
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

                    lbl_processStatus.Text = "In Progress";
                    lbl_processStatus.ForeColor = Color.Green;

                    lbl_toplvlipn.Text = data.mo_id;
                    lbl_segment.Text = "Sub Assymbly";
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



    }
}
