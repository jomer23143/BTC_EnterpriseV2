using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.Modal
{
    public partial class Printqrcodeform : Form
    {
        public string ApiUrl;
        public string theid;
        public string themoid;
        public Printqrcodeform(string api, string id, string moid, string serial)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            this.ApiUrl = api;
            this.theid = id;
            this.themoid = moid;
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
            processes = await Get_PrintQR(themoid);
            LoadStationsToFlowPanel(processes);
        }
        public async Task<List<PrintQR_Model.Main>> Get_PrintQR(string moid)
        {
            try
            {
                var apiUrl = $"{ApiUrl}&mo_id={moid}";
                string jsonResponse = await WebRequestApi.GetData_httpclient(apiUrl);
                Debug.WriteLine("Response: " + jsonResponse);

                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<PrintQR_Model.Main>(); // return empty list
                }

                var token = JToken.Parse(jsonResponse);

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return new List<PrintQR_Model.Main>(); // return empty list
                }

                if (token.Type == JTokenType.Object && token["data"] != null)
                {
                    var rootObj = token.ToObject<PrintQR_Model.RootWrapper>();
                    var dataList = rootObj?.data;

                    if (dataList == null || dataList.Count == 0)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return new List<PrintQR_Model.Main>(); // return empty list
                    }

                    pb_loader.Visible = false;

                    return dataList;
                }
                else
                {
                    MessageBox.Show("Unexpected response format.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<PrintQR_Model.Main>(); // return empty list
                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PrintQR_Model.Main>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
                return new List<PrintQR_Model.Main>();
            }
        }

        private void LoadStationsToFlowPanel(List<PrintQR_Model.Main> processes)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var process in processes)
            {
                foreach (var segment in process.segment)
                {
                    if (segment.manufacturing_order_id == theid)
                    {
                        foreach (var station in segment.station)
                        {
                            Panel stationPanel = new Panel
                            {
                                Width = 200,
                                Height = 50,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(2),
                                BackColor = Color.White
                            };

                            PictureBox qrBox = new PictureBox
                            {
                                Top = 2,
                                Left = 2,
                                Width = 45,
                                Height = 45,
                                SizeMode = PictureBoxSizeMode.Zoom
                            };

                            if (!string.IsNullOrEmpty(station.serial_number))
                            {
                                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(station.serial_number, QRCodeGenerator.ECCLevel.Q))
                                using (QRCode qrCode = new QRCode(qrCodeData))
                                {
                                    qrBox.Image = qrCode.GetGraphic(2);
                                }
                            }

                            Font labelFont = new Font("Arial", 4.5f, FontStyle.Regular);
                            Color textColor = Color.Black;

                            int labelLeft = qrBox.Right + 5;
                            int topStart = 2;
                            int labelHeight = 10;
                            int spacing = 3; // vertical gap between labels

                            Label nameLabel = new Label
                            {
                                Text = "Name: " + station.name,
                                Font = labelFont,
                                AutoSize = false,
                                Width = stationPanel.Width - labelLeft - 5,
                                Height = labelHeight,
                                Top = topStart,
                                Left = labelLeft,
                                ForeColor = textColor
                            };

                            Label moidLabel = new Label
                            {
                                Text = "MOID: " + themoid,
                                Font = labelFont,
                                AutoSize = false,
                                Width = nameLabel.Width,
                                Height = labelHeight,
                                Top = nameLabel.Top + nameLabel.Height + spacing,
                                Left = labelLeft,
                                ForeColor = textColor
                            };

                            Label serialLabel = new Label
                            {
                                Text = "SN: " + station.serial_number,
                                Font = labelFont,
                                AutoSize = false,
                                Width = nameLabel.Width,
                                Height = labelHeight,
                                Top = moidLabel.Top + moidLabel.Height + spacing,
                                Left = labelLeft,
                                ForeColor = textColor
                            };

                            stationPanel.Controls.Add(qrBox);
                            stationPanel.Controls.Add(nameLabel);
                            stationPanel.Controls.Add(moidLabel);
                            stationPanel.Controls.Add(serialLabel);

                            flowLayoutPanel1.Controls.Add(stationPanel);
                        }
                    }
                }
            }
        }


        int series_count = 0;
        int segment_count = 0;
        string name = "";
        string serial = "";
        string segments = "";
        private void btn_print_Click(object sender, EventArgs e)
        {
            //ReportChart.ReportVeiwerQRCode rp = new ReportChart.ReportVeiwerQRCode();
            //rp.ShowDialog();

            // PrintStationsAsZPL(processes); // Assume 'processes' is stored after Load
            //PrintDocument pd = new PrintDocument();
            ////pd.PrinterSettings.PrinterName = "ZDesigner ZD421CN-300dpi ZPL"; // or use your default printer
            //pd.PrintPage += Pd_PrintPage;

            ////Optionally preview before print
            //PrintPreviewDialog previewDialog = new PrintPreviewDialog
            //{
            //    Document = pd,
            //    Width = 800,
            //    Height = 600
            //};
            //previewDialog.ShowDialog(); // comment this if you want to print directly

            // Or print directly:
            // pd.Print();
            //panelBitmaps.Clear();
            //printPageIndex = 0;

            // Render each panel as an image
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Panel panel)
                {
                    Bitmap bmp = new Bitmap(panel.Width, panel.Height);
                    bmp.SetResolution(203, 203); // Zebra default DPI
                    panel.DrawToBitmap(bmp, new Rectangle(0, 0, panel.Width, panel.Height));
                    panelBitmaps.Add(bmp);

                }
            }

            if (panelBitmaps.Count > 0)
            {
                // Set up printer settings for 4x2 inch label (400 x 200 hundredths of inch)
                printDoc = new PrintDocument
                {
                    DefaultPageSettings = new PageSettings
                    {
                        PaperSize = new PaperSize("Label4x2", 200, 50), // 4"x2"
                        Margins = new Margins(1, 1, 1, 1),
                        Landscape = false
                    }
                };

                printDoc.PrintPage += PrintDoc_PrintPage;

                try
                {
                    printDoc.Print(); // Sends directly to default printer
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Print failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    printDoc.PrintPage -= PrintDoc_PrintPage;
                }
            }
            else
            {
                MessageBox.Show("Nothing to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PrintStationsAsZPL(List<PrintQR_Model.Main> processes)
        {
            string printerName = "ZDesigner ZD421CN-300dpi ZPL"; // Replace with your actual printer name

            foreach (var process in processes)
            {
                foreach (var segment in process.segment)
                {
                    if (segment.manufacturing_order_id == theid)
                    {
                        foreach (var station in segment.station)
                        {
                            if (string.IsNullOrWhiteSpace(station.serial_number))
                                continue;

                            string name = TruncateZplText(station.name, 25);
                            string moid = TruncateZplText(themoid, 25);
                            string serial = TruncateZplText(station.serial_number, 25);

                            string zpl = $@"
                                            ^XA
                                            ^PW812
                                            ^LL406
                                            ^A0N,40,40

                                            ^FO30,30^BQN,2,10^FDLA,{serial}^FS
                                            ^FO200,30^FDName: {name}^FS
                                            ^FO200,70^FDMOID: {moid}^FS
                                            ^FO200,110^FDSN: {serial}^FS
                                            ^FO200,150^FDSegment: Sub-Assembly^FS
                                            ^XZ";

                            RawPrinterHelper.SendStringToPrinter(printerName, zpl);
                        }
                    }
                }
            }

            MessageBox.Show("ZPL print job sent to Zebra.", "Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string TruncateZplText(string input, int maxLength)
        {
            return string.IsNullOrEmpty(input) ? "" : (input.Length > maxLength ? input.Substring(0, maxLength) : input);
        }







        private PrintDocument printDoc = new PrintDocument();
        private List<Bitmap> panelBitmaps = new List<Bitmap>();
        private int printPageIndex = 0;

        //private void btn_print_Click(object sender, EventArgs e)
        //{


            //panelBitmaps.Clear();
            //printPageIndex = 0;

            //// Render each panel as an image
            //foreach (Control ctrl in flowLayoutPanel1.Controls)
            //{
            //    if (ctrl is Panel panel)
            //    {
            //        Bitmap bmp = new Bitmap(panel.Width, panel.Height);
            //        bmp.SetResolution(203, 203); // Zebra default DPI
            //        panel.DrawToBitmap(bmp, new Rectangle(0, 0, panel.Width, panel.Height));
            //        panelBitmaps.Add(bmp);

            //    }
            //}

            //if (panelBitmaps.Count > 0)
            //{
            //    // Set up printer settings for 4x2 inch label (400 x 200 hundredths of inch)
            //    printDoc = new PrintDocument
            //    {
            //        DefaultPageSettings = new PageSettings
            //        {
            //            PaperSize = new PaperSize("Label4x2", 200, 50), // 4"x2"
            //            Margins = new Margins(1, 1, 1, 1),
            //            Landscape = false
            //        }
            //    };

            //    printDoc.PrintPage += PrintDoc_PrintPage;

            //    try
            //    {
            //        printDoc.Print(); // Sends directly to default printer
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Print failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {
            //        printDoc.PrintPage -= PrintDoc_PrintPage;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Nothing to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        //}

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

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            e.Graphics.DrawImage(bmp, x, y, bmp.Width, bmp.Height);
            printPageIndex++;
            e.HasMorePages = (printPageIndex < panelBitmaps.Count);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //foreach (var process in processes)
            //{
            //    foreach (var segment in process.segment)
            //    {
            //        if (segment.manufacturing_order_id == theid)
            //        {
            //            int series_count = 0;
            //            int segment_count = segment.station.Count;
                        
            //            foreach (var station in segment.station)
            //            {
            //                if (string.IsNullOrWhiteSpace(station.serial_number))
            //                    continue;
                            Graphics g = e.Graphics;

                            // Set DPI for reference (for 300 DPI printer: 1mm ≈ 11.81px)
                            float labelWidthPx = 531; // 45mm x 11.81
                            float labelHeightPx = 531;

                            // Fonts and brushes
                            Font font = new Font("Calibre", 10, FontStyle.Bold); // small font for label
                            Brush brush = Brushes.Black;

                            string serial = "1234567890";
                            //string moid = "MO123456";
                            //string name = "Station XYZ";

                            // Generate QR Code (make it ~30mm or 354px in size)
                            int qrSize = 240; // ~30mm
                            using (QRCodeGenerator qrGen = new QRCodeGenerator())
                            using (QRCodeData qrData = qrGen.CreateQrCode(serial, QRCodeGenerator.ECCLevel.Q))
                            using (QRCode qrCode = new QRCode(qrData))
                            using (Bitmap qrImage = qrCode.GetGraphic(7)) // higher detail
                            {
                                Bitmap resizedQR = new Bitmap(qrImage, new Size(qrSize, qrSize));
                                resizedQR.SetResolution(240,240);
                                e.Graphics.DrawImage(resizedQR, new PointF(10, 2));

                                // Offset text beside QR code
                                float textStartX = 5 + qrSize + 5;
                                float textStartY = 5;
                                float lineHeight = font.GetHeight(g) + 2;

                                //e.Graphics.DrawString($"Name: {name}", font, brush, textStartX + 10, textStartY);
                                //e.Graphics.DrawString($"MOID: {themoid}", font, brush, textStartX + 10, textStartY + lineHeight);
                                e.Graphics.DrawString($"{serial}", font, brush, textStartX + 10, textStartY + 5 * 2);
                                //e.Graphics.DrawString($"Segment: {segments}", font, brush, textStartX + 10, textStartY + lineHeight * 3);
                                series_count++;
                            }
                           
            //            }
            //        }
            //    }
            //}
        }
    }
}
