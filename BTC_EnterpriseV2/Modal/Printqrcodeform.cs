using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using BTC_EnterpriseV2.Model;
using QRCoder;

namespace BTC_EnterpriseV2.Modal
{
    public partial class Printqrcodeform : Form
    {
        public string ApiUrl;
        public string theid;
        public string themoid;
        public string station;
        string serial_number = "";
        public DataTable dt_station_generated_serials;
        public DataTable stationdt;
        List<PictureBox> pictureboxes = new List<PictureBox>();
        PictureBox pictureBox = new PictureBox();
        private List<Bitmap> panelBitmap3 = new List<Bitmap>();
        private List<Bitmap> panelBitmaps = new List<Bitmap>();
        private int printPageIndex = 0;
        int print_index = 0;

        public Printqrcodeform(DataTable station, string moid)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.stationdt = station;
            this.themoid = moid;
        }
        private void Printqrcodeform_Load(object sender, EventArgs e)
        {
            lbl_moid.Text = $"MOID : {themoid}";
            _ = InitializePrintAsync();
        }
        private List<PrintQR_Model.Main> processes;

        private async Task InitializePrintAsync()
        {

            LoadStationsToFlowPanel(stationdt);
        }


        private void LoadStationsToFlowPanel(DataTable station_data)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in station_data.Rows)
            {
                string serial = row["serial_number"]?.ToString();

                Panel stationPanel = new Panel
                {
                    Width = 380,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(20),
                    BackColor = Color.White
                };

                PictureBox qrBox = new PictureBox
                {
                    Top = 2,
                    Left = 2,
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                if (!string.IsNullOrEmpty(serial))
                {
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(serial, QRCodeGenerator.ECCLevel.Q))
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        qrBox.Image = qrCode.GetGraphic(2);
                    }
                }

                Font labelFont = new Font("Tahoma", 12, FontStyle.Bold);
                Color textColor = Color.Black;

                Label serialLabel = new Label
                {
                    Text = serial,
                    Font = labelFont,
                    AutoSize = false,
                    Width = stationPanel.Width - (qrBox.Width + 10),
                    Height = 100,
                    Top = 2,
                    Left = qrBox.Right + 5,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ForeColor = textColor
                };

                stationPanel.Controls.Add(qrBox);
                stationPanel.Controls.Add(serialLabel);

                stationPanel.Controls.Add(qrBox);
                stationPanel.Controls.Add(serialLabel);

                // Make panel & controls clickable
                stationPanel.Tag = serial;
                stationPanel.Cursor = Cursors.Hand;
                stationPanel.Click += PrintSingleSerialOnClick;
                serialLabel.Click += PrintSingleSerialOnClick;
                qrBox.Click += PrintSingleSerialOnClick;

                flowLayoutPanel1.Controls.Add(stationPanel);



                flowLayoutPanel1.Controls.Add(stationPanel);
            }
        }

        //for single serial print
        private void PrintSingleSerialOnClick(object sender, EventArgs e)
        {
            string serial = "";

            if (sender is Control ctrl && ctrl.Parent is Panel panel && panel.Tag is string)
            {
                serial = panel.Tag.ToString();
            }
            else if (sender is Panel clickedPanel && clickedPanel.Tag is string)
            {
                serial = clickedPanel.Tag.ToString();
            }

            if (string.IsNullOrWhiteSpace(serial))
            {
                MessageBox.Show("No serial found to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            serial_number = serial;

            PrintDialog pd = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPicture;
            pd.Document = printDoc;

            // Optional: show preview dialog
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };

            if (preview.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }
        //====================================


        private void btn_print_Click(object sender, EventArgs e)
        {
            QR_Code_Print();
        }



        private void QR_Code_Print()
        {
            int qrSize = 110;
            Bitmap qrImage = null;
            Bitmap resizedQR = null;

            panelBitmap3.Clear();

            foreach (DataRow dr in stationdt.Rows)
            {
                QRCodeGenerator qrGen = new QRCodeGenerator();
                QRCodeData qrData = qrGen.CreateQrCode(dr["serial_number"].ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrData);
                qrImage = qrCode.GetGraphic(7);
                resizedQR = new Bitmap(qrImage, new Size(qrSize + 10, qrSize));
                resizedQR.SetResolution(240, 240);
                panelBitmap3.Add(resizedQR);
            }

            if (panelBitmap3.Count == 0)
            {
                MessageBox.Show("No serials to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDialog pd = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintAll;
            pd.Document = printDocument;

            print_index = 0;


            printDocument.Print();
            label_printcount.Text = $"Printed : {panelBitmap3.Count} / {stationdt.Rows.Count}";
            panelBitmap3.Clear();
        }

        private void PrintAll(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;


            float labelWidthPx = 531;
            float labelHeightPx = 531;


            Font font = new Font("Tahoma", 7, FontStyle.Bold);
            Brush brush = Brushes.Black;


            if (print_index >= panelBitmap3.Count)
            {
                print_index = 0;
                e.HasMorePages = false;
                return;
            }
            Bitmap bmp = panelBitmap3[print_index];
            e.Graphics.DrawImage(bmp, new PointF(10, 2));
            float textStartX = 5 + 110 + 5;
            float textStartY = 5;
            float lineHeight = font.GetHeight(g) + 2;


            e.Graphics.DrawString($"{stationdt.Rows[print_index]["serial_number"].ToString()}", font, brush, textStartX - 50, textStartY + 8 * 2);

            print_index++;
            e.HasMorePages = (print_index < panelBitmap3.Count);
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (printPageIndex >= panelBitmaps.Count)
            {
                e.HasMorePages = false;
                return;
            }

            Bitmap bmp = panelBitmaps[printPageIndex];


            int x = (e.MarginBounds.Width - bmp.Width) / 2;
            int y = (e.MarginBounds.Height - bmp.Height) / 2;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            e.Graphics.DrawImage(bmp, x, y, bmp.Width, bmp.Height);
            printPageIndex++;
            e.HasMorePages = (printPageIndex < panelBitmaps.Count);
        }

        private void PrintPicture(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float labelWidthPx = 531;
            float labelHeightPx = 531;

            Font font = new Font("Tahoma", 7, FontStyle.Bold);
            Brush brush = Brushes.Black;

            int qrSize = 110;
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrData = qrGen.CreateQrCode(serial_number, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);
            Bitmap qrImage = qrCode.GetGraphic(7);

            Bitmap resizedQR = new Bitmap(qrImage, new Size(qrSize + 10, qrSize));
            resizedQR.SetResolution(240, 240);
            e.Graphics.DrawImage(resizedQR, new PointF(10, 2));

            float textStartX = 5 + qrSize + 5;
            float textStartY = 5;
            float lineHeight = font.GetHeight(g) + 2;


            e.Graphics.DrawString($"{serial_number}", font, brush, textStartX - 50, textStartY + 8 * 2);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
