using BTC_EnterpriseV2.Dataset;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BTC_EnterpriseV2.Model.Sub_Asy_Process_Model;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ViewStationGeneratedSerials : Form
    {
        public string station;
        public DataTable dt_station_generated_serials;
        public DataTable stationdt;
        public ViewStationGeneratedSerials(string station, DataTable dt_station_serials)
        {
            InitializeComponent();
            this.station = station;
            this.dt_station_generated_serials = dt_station_serials;
            reportViewer1.Visible = false;
        }

        private void ViewStationGeneratedSerials_Load(object sender, EventArgs e)
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
            foreach (DataRow drow in dt_station_generated_serials.Rows)
            {
                if (drow["station"].ToString() == station)
                {
                    dataGridView1.Rows.Add(drow["manufacturing_order_id"].ToString(), drow["station"].ToString(), drow["serial_number"].ToString(), resizedImage);
                    dataTable.Rows.Add(drow["manufacturing_order_id"].ToString(), drow["station"].ToString(), drow["serial_number"].ToString());
                }
            }
            stationdt = dataTable;
           // PreviewAllGeneratedSerial(dataTable);
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
        List<PictureBox> pictureboxes = new List<PictureBox>();
        PictureBox pictureBox = new PictureBox();
        private List<Bitmap> panelBitmaps = new List<Bitmap>();
        private void btn_print_Click(object sender, EventArgs e)
        {

            int qrSize = 110; // ~30mm
            Bitmap qrImage = null;
            Bitmap resizedQR = null;
            foreach (DataRow dr in stationdt.Rows)
            {
                QRCodeGenerator qrGen = new QRCodeGenerator();
                QRCodeData qrData = qrGen.CreateQrCode(dr["serial_number"].ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrData);
                qrImage = qrCode.GetGraphic(7); // higher detail
                resizedQR = new Bitmap(qrImage, new Size(qrSize + 10, qrSize));
                resizedQR.SetResolution(240, 240);
                panelBitmap2.Add(resizedQR);

            }

            PrintDialog pd = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintPreview;
            pd.Document = printDocument;
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
            //printDocument.Print();

            #region
            //foreach (Control ctrl in flowLayoutPanel.Controls)
            //{
            //    if (ctrl is Panel panel)
            //    {
            //        Bitmap bmp = new Bitmap(panel.Width, panel.Height);
            //        bmp.SetResolution(200, 200); // Zebra default DPI
            //        panel.DrawToBitmap(bmp, new Rectangle(0, 0, panel.Width, panel.Height));
            //        panelBitmaps.Add(bmp);

            //    }
            //}
            //if (panelBitmaps.Count > 0)
            //{
            //    PrintDialog pd = new PrintDialog();
            //    PrintDocument printDocument = new PrintDocument();
            //    // Set up printer settings for 4x2 inch label (400 x 200 hundredths of inch)
            //    printDocument = new PrintDocument
            //    {
            //        DefaultPageSettings = new PageSettings
            //        {
            //            PaperSize = new PaperSize("Label4x2", 200, 40), // 4"x2"
            //            Margins = new Margins(1, 1, 1, 1),
            //            Landscape = false,
            //        }
            //    };

            //    printDocument.PrintPage += PrintDoc_PrintPage;
            //    PrintPreviewDialog previewDialog = new PrintPreviewDialog
            //    {
            //        Document = printDocument,
            //        Width = 800,
            //        Height = 600
            //    };
            //    pd.Document = printDocument;
            //   if (previewDialog.ShowDialog() == DialogResult.OK)
            //        printDocument.Print();
            //    try
            //    {
            //        printDocument.Print(); // Sends directly to default printer
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Print failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {
            //        printDocument.PrintPage -= PrintDoc_PrintPage;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Nothing to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}



            //printDocument.PrintPage += PrintPicture;
            //pd.Document = printDocument;

            //if (pd.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}
            #endregion
            #region
            //foreach (DataRow drow in dt_station_generated_serials.Rows)
            //{
            //    if (drow["station"].ToString() == station)
            //    {
            //        QRCoder.QRCodeGenerator qRCodeGenerator = new QRCoder.QRCodeGenerator();
            //        QRCoder.QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(drow["serial_number"].ToString(), QRCoder.QRCodeGenerator.ECCLevel.Q);
            //        pictureBox.Image = qRCodeGenerator.CreateQrCode(drow["serial_number"].ToString(), QRCoder.QRCodeGenerator.ECCLevel.Q);
            //        QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
            //        Bitmap bmp = qRCode.GetGraphic(7);
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            bmp.Save(ms, ImageFormat.Bmp);
            //            ReportData reportData = new ReportData();
            //            ReportData.QRCodeRow qrcoderow = reportData.QRCode.NewQRCodeRow();
            //            qrcoderow.serial_number = ms.ToArray();
            //            reportData.QRCode.AddQRCodeRow(qrcoderow);

            //            reportDataSource.Name = "DataSet1";
            //            reportDataSource.Value = reportData.QRCode;



            //        }
            //    }
            //}
            // var localreport = reportViewer1.LocalReport;
            // ReportDataSource rds = new ReportDataSource("DataSet1", dt_station_generated_serials);
            // localreport.DataSources.Add(rds);
            // //string res = $"{Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace}.Report.Report1.rdlc";
            //// reportViewer1.LocalReport.ReportEmbeddedResource = res;
            // reportViewer1.LocalReport.ReportPath = "C:\\Users\\JomerAlo\\source\\repos\\BTC_EnterpriseV2\\BTC_EnterpriseV2\\Report\\Report1.rdlc";
            // reportViewer1.RefreshReport();
            // //reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //reportViewer1.ZoomMode = ZoomMode.PageWidth;
            #endregion
        }
        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        private void PreviewAllGeneratedSerial(DataTable station)
        {
            foreach (DataRow drow in station.Rows)
            {
                Panel stationPanel = new Panel
                {
                    Width = 180,
                    Height = 75,
                    BorderStyle = BorderStyle.FixedSingle,
                    // Margin = new Padding(2),
                    BackColor = Color.White
                };

                PictureBox qrBox = new PictureBox
                {
                    Top = 2,
                    Left = 2,
                    Width = 50,
                    Height = 75,
                    SizeMode = PictureBoxSizeMode.Zoom,
                };

                if (!string.IsNullOrEmpty(drow["serial_number"].ToString()))
                {
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(drow["serial_number"].ToString(), QRCodeGenerator.ECCLevel.Q))
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        qrBox.Image = qrCode.GetGraphic(2);
                    }
                }

                Font labelFont = new Font("Tahoma", 7, FontStyle.Bold);
                Color textColor = Color.Black;

                int labelLeft = qrBox.Right + 10;
                int topStart = 2;
                int labelHeight = 30;
                int spacing = 3; // vertical gap between labels

                //Label nameLabel = new Label
                //{
                //    Text = "Name: " + station.name,
                //    Font = labelFont,
                //    AutoSize = false,
                //    Width = stationPanel.Width - labelLeft - 5,
                //    Height = labelHeight,
                //    Top = topStart,
                //    Left = labelLeft,
                //    ForeColor = textColor
                //};

                Label moidLabel = new Label
                {
                    Text = drow["serial_number"].ToString(),
                    Font = labelFont,
                    AutoSize = false,
                    Width = stationPanel.Width - labelLeft - 5,
                    Height = labelHeight,
                    Top = topStart + labelHeight + spacing,
                    Left = labelLeft,
                    ForeColor = textColor
                };

                //Label serialLabel = new Label
                //{
                //    Text = "SN: " + station.serial_number,
                //    Font = labelFont,
                //    AutoSize = false,
                //    Width = nameLabel.Width,
                //    Height = labelHeight,
                //    Top = moidLabel.Top + moidLabel.Height + spacing,
                //    Left = labelLeft,
                //    ForeColor = textColor
                //};

                stationPanel.Controls.Add(qrBox);
                //stationPanel.Controls.Add(nameLabel);
                stationPanel.Controls.Add(moidLabel);
                //stationPanel.Controls.Add(serialLabel);

                flowLayoutPanel.Controls.Add(stationPanel);
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

            // Center image on label
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

            // Set DPI for reference (for 300 DPI printer: 1mm ≈ 11.81px)
            float labelWidthPx = 531; // 45mm x 11.81
            float labelHeightPx = 531;

            // Fonts and brushes
            Font font = new Font("Tahoma", 7, FontStyle.Bold); // small font for label
            Brush brush = Brushes.Black;

            int qrSize = 110; // ~30mm
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrData = qrGen.CreateQrCode(serial_number, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);
            Bitmap qrImage = qrCode.GetGraphic(7); // higher detail

            Bitmap resizedQR = new Bitmap(qrImage, new Size(qrSize + 10, qrSize));
            resizedQR.SetResolution(240, 240);
            e.Graphics.DrawImage(resizedQR, new PointF(10, 2));

            // Offset text beside QR code
            float textStartX = 5 + qrSize + 5;
            float textStartY = 5;
            float lineHeight = font.GetHeight(g) + 2;

            //e.Graphics.DrawString($"Name: {name}", font, brush, textStartX + 10, textStartY);
            //e.Graphics.DrawString($"MOID: {themoid}", font, brush, textStartX + 10, textStartY + lineHeight);
            e.Graphics.DrawString($"{serial_number}", font, brush, textStartX - 50, textStartY + 8 * 2);
            //e.Graphics.DrawString($"Segment: {segments}", font, brush, textStartX + 10, textStartY + lineHeight * 3);
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
            }
        }
        private List<Bitmap> panelBitmap2 = new List<Bitmap>();
        private void PrintPreview(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Set DPI for reference (for 300 DPI printer: 1mm ≈ 11.81px)
            float labelWidthPx = 531; // 45mm x 11.81
            float labelHeightPx = 531;

            // Fonts and brushes
            Font font = new Font("Tahoma", 7, FontStyle.Bold); // small font for label
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

            //e.Graphics.DrawString($"Name: {name}", font, brush, textStartX + 10, textStartY);
            //e.Graphics.DrawString($"MOID: {themoid}", font, brush, textStartX + 10, textStartY + lineHeight);
            e.Graphics.DrawString($"{stationdt.Rows[printPageIndex]["serial_number"].ToString()}", font, brush, textStartX - 50, textStartY + 8 * 2);
            // Offset text beside QR code

            //e.Graphics.DrawString($"Segment: {segments}", font, brush, textStartX + 10, textStartY + lineHeight * 3);
            printPageIndex++;
            e.HasMorePages = (printPageIndex < panelBitmap2.Count);
        }
        int print_index = 0;
        private void PrintAll(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Set DPI for reference (for 300 DPI printer: 1mm ≈ 11.81px)
            float labelWidthPx = 531; // 45mm x 11.81
            float labelHeightPx = 531;

            // Fonts and brushes
            Font font = new Font("Tahoma", 7, FontStyle.Bold); // small font for label
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

            //e.Graphics.DrawString($"Name: {name}", font, brush, textStartX + 10, textStartY);
            //e.Graphics.DrawString($"MOID: {themoid}", font, brush, textStartX + 10, textStartY + lineHeight);
            e.Graphics.DrawString($"{stationdt.Rows[print_index]["serial_number"].ToString()}", font, brush, textStartX - 50, textStartY + 8 * 2);
            // Offset text beside QR code

            //e.Graphics.DrawString($"Segment: {segments}", font, brush, textStartX + 10, textStartY + lineHeight * 3);
            print_index++;
            e.HasMorePages = (print_index < panelBitmap3.Count);
        }
        private List<Bitmap> panelBitmap3 = new List<Bitmap>();
        private void btn_print_all_Click(object sender, EventArgs e)
        {
            int qrSize = 110; // ~30mm
            Bitmap qrImage = null;
            Bitmap resizedQR = null;
            foreach (DataRow dr in stationdt.Rows)
            {
                QRCodeGenerator qrGen = new QRCodeGenerator();
                QRCodeData qrData = qrGen.CreateQrCode(dr["serial_number"].ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrData);
                qrImage = qrCode.GetGraphic(7); // higher detail
                resizedQR = new Bitmap(qrImage, new Size(qrSize + 10, qrSize));
                resizedQR.SetResolution(240, 240);
                panelBitmap3.Add(resizedQR);

            }

            PrintDialog pd = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintAll;
            pd.Document = printDocument;
            printPageIndex = 0;
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };
            printDocument.Print();
        }
    }
}
