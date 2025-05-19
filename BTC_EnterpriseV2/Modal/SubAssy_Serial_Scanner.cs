using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class SubAssy_Serial_Scanner : Form
    {
        public event Action<string?> SerialScanned = delegate { };
        public SubAssy_Serial_Scanner()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            yUI.RoundedButton(button1, 8, Color.SteelBlue);
            yUI.RoundedTextBox(txt_serialnumber, 8, Color.White);
            txt_serialnumber.Focus();
        }

        private void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SerialScanned?.Invoke(txt_serialnumber.Text);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
