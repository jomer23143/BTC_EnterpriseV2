using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class SubAssy_Serial_Scanner : Form
    {
        public event Action<string?> SerialScanned = delegate { };
        public string segmentname;
        public SubAssy_Serial_Scanner(string segmentname)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedTextBox(txt_serialnumber, 8, Color.White);
            txt_serialnumber.Focus();
            lbl_segmentname.Text = segmentname;
        }

        private void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SerialScanned?.Invoke(txt_serialnumber.Text);
                this.Close();
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txt_serialnumber.Focus();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubAssy_Serial_Scanner_Load(object sender, EventArgs e)
        {

            txt_serialnumber.Focus();
        }
    }
}
