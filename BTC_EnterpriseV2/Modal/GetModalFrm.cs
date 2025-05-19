using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class GetModalFrm : Form
    {
        public event Action<string?> SerialScanned = delegate { }; // Initialize with an empty delegate to avoid nullability issues.

        public GetModalFrm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedButton(button1, 8, Color.Tomato);
            txt_serial.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetModalFrm_Load(object sender, EventArgs e)
        {

        }

        private void txt_serial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SerialScanned?.Invoke(txt_serial.Text);
                this.Close();
            }
        }
    }
}
