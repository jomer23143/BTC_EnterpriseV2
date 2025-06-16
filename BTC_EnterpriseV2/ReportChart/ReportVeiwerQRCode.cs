using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BTC_EnterpriseV2.ReportChart
{
    public partial class ReportVeiwerQRCode : Form
    {
        public ReportVeiwerQRCode()
        {
            InitializeComponent();
        }

        private void ReportVeiwerQRCode_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.EnableExternalImages = true;

            QRCoder.QRCodeGenerator qrCodeGenerator = new QRCoder. QRCodeGenerator();
            QRCoder.QRCodeData qrData = qrCodeGenerator.CreateQrCode("JOMER", QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qRCode = new QRCoder.QRCode(qrData);
            Bitmap bmp = qRCode.GetGraphic(2);
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Bmp);
                //Dataset.DataSet1 reportdata = new Dataset.DataSet1();
                //Dataset.DataSet1.qrcodeRow qrcodeRow = reportdata.qrcode.NewqrcodeRow();
                //Byte[] bytes = ms.ToArray();
                //qrcodeRow.image = qRCode.GetGraphic(2);
                //reportdata.qrcode.AddqrcodeRow(qrcodeRow);

                //ReportDataSource ds = new ReportDataSource();
                //ds.Name = "DataSet1";
                //ds.Value = reportdata.qrcode;
                //reportViewer1.LocalReport.DataSources.Add(ds);
                //reportViewer1.LocalReport.DataSources.Clear();
                //reportViewer1.RefreshReport();
                //reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                //reportViewer1.ZoomMode = ZoomMode.PageWidth;
            }
           
        }
    }
}
