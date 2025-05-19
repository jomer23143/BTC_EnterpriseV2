using BTC_EnterpriseV2.Modal;
using BTCP_EnterpriseV2.YaoUI;
using QRCoder;

namespace BTC_EnterpriseV2.ProcessForm
{
    public partial class Sub_AssyFrm : Form
    {
        private DateTime _startTime;
        public string toplvlipn;
        public string psegment;
        public string station;
        public string mo;
        public string serialnumber;
        public string generatedcode;
        public Sub_AssyFrm(string mo, string serialno, string toplvlipn, string psegment, string station, string code)
        {
            InitializeComponent();
            YUI yUI = new YUI();
            yUI.RoundedPanelDocker(panel_info1, 12);
            yUI.RoundedPanelDocker(panel_info2, 12);
            yUI.RoundedPanelDocker(panel_start, 12);
            yUI.RoundedPanelDocker(panel_end, 12);
            yUI.RoundedPanelDocker(panel_duration, 12);
            yUI.RoundedPanelDocker(panel_date, 12);
            yUI.RoundedButton(btn_scan, 10, Color.FromArgb(17, 40, 86));
            QrController();
            this.mo = mo;
            this.serialnumber = serialno;
            this.toplvlipn = toplvlipn;
            this.psegment = psegment;
            this.station = station;
            this.generatedcode = code;
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
            lbl_segment.Text = psegment;
            lbl_toplvlipn.Text = toplvlipn;
            lbl_station.Text = station;
            lbl_generatedserial.Text = generatedcode;
            DGV_SampleData();
            _startTime = DateTime.Now;
            lbl_timestart.Text = _startTime.ToString("HH:mm:ss");
            lbl_duration.Text = "00:00:00";
            lbl_date.Text = DateTime.Now.ToString("dddd, MMMM-dd-yyyy");
            timer1.Start();
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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;
                var material = row.Cells["SerializedMaterial"].Value?.ToString();
                var status = row.Cells["Scan Status"].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(material))
                {
                    if (!string.Equals(status, "Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        allScanned = false;
                        break;
                    }
                }
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



        private void DGV_SampleData()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("NoProcess", "No. Process");
            dataGridView1.Columns.Add("Process", "Process");
            dataGridView1.Columns.Add("SerializedMaterial", "Serialized Material");
            dataGridView1.Columns.Add("SerialQuantity", "Serial Quantity");
            dataGridView1.Columns.Add("Scan Status", "status");

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "ScanItemSerial";
            imgColumn.HeaderText = "Scan Item Serial";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgColumn);
            string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "qrcode.gif");
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


            Image originalImage = Image.FromFile(defaultImagePath);
            Image resizedImage = ResizeImage(originalImage, 60, 60);

            dataGridView1.Rows.Add("P001", "Process1", "Material A", "1", "No", resizedImage);
            dataGridView1.Rows.Add("P002", "Process2", "Material B", "1", "No", resizedImage);
            dataGridView1.Rows.Add("P003", "Process3", "Material C", "1", "No", resizedImage);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ScanItemSerial"].Index && e.RowIndex >= 0)
            {
                ProcessScanner scan = new ProcessScanner(e.RowIndex);
                scan.SerialScanned += (serial) =>
                {
                    if (!string.IsNullOrEmpty(serial))
                    {

                        dataGridView1.Rows[e.RowIndex].Cells["Scan Status"].Value = "Yes";

                    }
                };

                scan.ShowDialog();
            }
        }


    }
}
