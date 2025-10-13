using BTCP_EnterpriseV2.YaoUI;
using QRCoder;

namespace BTC_EnterpriseV2.Modal
{
    public partial class QC_Checklist_QR : Form
    {
        public QC_Checklist_QR(string gencode, int segment)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            GenerateQR_Code(gencode, segment);
        }



        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QC_Checklist_QR_Load(object sender, EventArgs e)
        {

        }

        private void GenerateQR_Code(string generatedcode, int segment)
        {
            string jsonData = $"{segment}|{generatedcode}";

            if (string.IsNullOrEmpty(jsonData))
            {
                MessageBox.Show("Please enter data to generate QR code.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(jsonData, QRCodeGenerator.ECCLevel.Q))
            using (var qrCode = new QRCode(qrCodeData))
            {
                var qrCodeImage = qrCode.GetGraphic(20);
                Pb_qr.Image = qrCodeImage;
            }
        }

    }
}
