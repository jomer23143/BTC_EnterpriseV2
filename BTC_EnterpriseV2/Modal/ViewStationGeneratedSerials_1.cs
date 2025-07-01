using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using BTCP_EnterpriseV2.YaoUI;
using QRCoder;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ViewStationGeneratedSerials_1 : Form
    {
        public string station;
        public DataTable dt_station_generated_serials;
        public DataTable stationdt;
        private string moid;
        List<PictureBox> pictureboxes = new List<PictureBox>();
        PictureBox pictureBox = new PictureBox();
        private List<Bitmap> panelBitmaps = new List<Bitmap>();
        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        public ViewStationGeneratedSerials_1(string themoid, string station, DataTable dt_station_serials)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            this.station = station;
            this.moid = themoid;
            this.dt_station_generated_serials = dt_station_serials;
            this.stationdt = new DataTable();
            reportViewer1.Visible = false;
        }

        private void ViewStationGeneratedSerials_1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("Station", "Station Name");
            dataGridView1.Columns.Add("serial_number", "Generated Serial Number");

            DataTable dataTable = new DataTable("Station");
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("Station");
            dataTable.Columns.Add("serial_number");

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            {
                Name = "Printing",
                HeaderText = "Print QR",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView1.Columns.Add(imgColumn);
            string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "printer.png");
            Image originalImage = Image.FromFile(defaultImagePath);
            Image resizedImage = ResizeImage(originalImage, 60, 60);
            dataGridView1.Rows.Clear();
            int rownum = 1;
            foreach (DataRow drow in dt_station_generated_serials.Rows)
            {

                if (drow["station"].ToString() == station)
                {
                    dataGridView1.Rows.Add(rownum++,
                        drow["station"].ToString(),
                        drow["serial_number"].ToString(),
                        resizedImage);
                    dataTable.Rows.Add(drow["manufacturing_order_id"].ToString(),
                        drow["station"].ToString(),
                        drow["serial_number"].ToString());
                }
            }
            stationdt = dataTable;

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

        private int printPageIndex = 0;
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

            // Fonts and brushes
            Font font = new Font("Tahoma", 7, FontStyle.Bold);
            Brush brush = Brushes.Black;

            int qrSize = 110; // ~30mm
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrData = qrGen.CreateQrCode(serial_number, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);
            Bitmap qrImage = qrCode.GetGraphic(7); // higher detail

            Bitmap resizedQR = new Bitmap(qrImage, new Size(qrSize + 10, qrSize));
            resizedQR.SetResolution(240, 240);
            e.Graphics.DrawImage(resizedQR, new PointF(10, 2));

            float textStartX = 5 + qrSize + 5;
            float textStartY = 5;
            float lineHeight = font.GetHeight(g) + 2;


            e.Graphics.DrawString($"{serial_number}", font, brush, textStartX - 50, textStartY + 8 * 2);

        }
        string serial_number = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
             e.ColumnIndex == dataGridView1.Columns["Printing"].Index)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                serial_number = row.Cells["serial_number"].Value?.ToString();

                PrintDialog pd = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();

                printDocument.PrintPage += PrintPicture;
                pd.Document = printDocument;
                PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDocument,
                    Width = 800,
                    Height = 600
                };
                if (previewDialog.ShowDialog() == DialogResult.OK)
                    printDocument.Print();
                panelBitmap2.Clear();
            }
        }
        private List<Bitmap> panelBitmap2 = new List<Bitmap>();
        private void PrintPreview(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float labelWidthPx = 531;
            float labelHeightPx = 531;

            Font font = new Font("Tahoma", 9, FontStyle.Bold);
            Brush brush = Brushes.Black;


            if (printPageIndex >= panelBitmap2.Count)
            {
                e.HasMorePages = false;
                return;
            }
            Bitmap bmp = panelBitmap2[printPageIndex];
            e.Graphics.DrawImage(bmp, new PointF(10, 2));
            float textStartX = 5 + 110 + 5;
            float textStartY = 5;
            float lineHeight = font.GetHeight(g) + 2;


            e.Graphics.DrawString($"{stationdt.Rows[printPageIndex]["serial_number"].ToString()}", font, brush, textStartX - 50, textStartY + 8 * 2);

            printPageIndex++;
            e.HasMorePages = (printPageIndex < panelBitmap2.Count);
        }
        int print_index = 0;
        private void PrintAll(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float labelWidthPx = 531;
            float labelHeightPx = 531;

            Font font = new Font("Tahoma", 7, FontStyle.Bold);
            Brush brush = Brushes.Black;


            if (print_index >= panelBitmap3.Count)
            {
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
        private List<Bitmap> panelBitmap3 = new List<Bitmap>();

        private void btn_print_all_Click(object sender, EventArgs e)
        {
            this.Hide();
            Printqrcodeform printqrcodeform = new Printqrcodeform(stationdt, moid);
            printqrcodeform.ShowDialog();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
