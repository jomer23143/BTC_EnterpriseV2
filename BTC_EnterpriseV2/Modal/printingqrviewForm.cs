using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using QRCoder;

namespace BTC_EnterpriseV2.Modal
{
    public partial class printingqrviewForm : Form
    {
        public string ApiUrl;
        public string theid;
        public string themoid;
        private DataTable SelectedPrintList = new DataTable("thetable");


        PictureBox pictureBox = new PictureBox();
        private List<Bitmap> panelBitmap3 = new List<Bitmap>();
        private List<Bitmap> panelBitmaps = new List<Bitmap>();
        private int printPageIndex = 0;
        int print_index = 0;
        string serial_number = "";

        public printingqrviewForm(DataTable printlist)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.SelectedPrintList = printlist;
        }
        private void printingqrviewForm_Load(object sender, EventArgs e)
        {

            _ = InitializeViewAsync();
        }

        private async Task InitializeViewAsync()
        {

            LoadProcessData(SelectedPrintList);

        }

        private void LoadProcessData(DataTable forprint)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Setup columns
            dataGridView1.Columns.Add("No", "#");
            dataGridView1.Columns.Add("name", "Station Name");
            dataGridView1.Columns.Add("serial_number", "Serial Number");


            int index = 1;

            foreach (DataRow serial in forprint.Rows)
            {
                string stationName = serial["Station"].ToString();
                string serialNum = serial["serial_number"].ToString();

                dataGridView1.Rows.Add(index++, stationName, serialNum);
            }
            pb_loader.Visible = false;
        }
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

            foreach (DataRow dr in SelectedPrintList.Rows)
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
            label_printcount.Text = $"Printed : {panelBitmap3.Count} / {SelectedPrintList.Rows.Count}";
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


            e.Graphics.DrawString($"{SelectedPrintList.Rows[print_index]["serial_number"].ToString()}", font, brush, textStartX - 50, textStartY + 8 * 2);

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

