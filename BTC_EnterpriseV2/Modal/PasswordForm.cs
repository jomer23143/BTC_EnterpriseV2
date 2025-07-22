using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            txt1.Select();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            txt1.TextChanged += TxtBox_TextChanged;
            txt2.TextChanged += TxtBox_TextChanged;
            txt3.TextChanged += TxtBox_TextChanged;
            txt4.TextChanged += TxtBox_TextChanged;
            txt5.TextChanged += TxtBox_TextChanged;
            txt6.TextChanged += TxtBox_TextChanged;

            txt1.KeyDown += TxtBox_KeyDown;
            txt2.KeyDown += TxtBox_KeyDown;
            txt3.KeyDown += TxtBox_KeyDown;
            txt4.KeyDown += TxtBox_KeyDown;
            txt5.KeyDown += TxtBox_KeyDown;
            txt6.KeyDown += TxtBox_KeyDown;

            txt1.KeyPress += TxtBox_KeyPress;
            txt2.KeyPress += TxtBox_KeyPress;
            txt3.KeyPress += TxtBox_KeyPress;
            txt4.KeyPress += TxtBox_KeyPress;
            txt5.KeyPress += TxtBox_KeyPress;
            txt6.KeyPress += TxtBox_KeyPress;


            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox current = sender as TextBox;

            if (current == null) return;

            if (current.Text.Length > 1)
            {
                current.Text = current.Text.Substring(0, 1);
                current.SelectionStart = 1;
            }

            if (current.Text.Length == 1)
            {
                // Delay the focus move to allow the TextBox to visually update
                this.BeginInvoke(new Action(() =>
                {
                    this.SelectNextControl(current, false, true, true, true);
                }));
            }

            UpdatePasswordIfComplete();
        }


        private void UpdatePasswordIfComplete()
        {
            if (txt1.Text.Length == 1 &&
                txt2.Text.Length == 1 &&
                txt3.Text.Length == 1 &&
                txt4.Text.Length == 1 &&
                txt5.Text.Length == 1 &&
                txt6.Text.Length == 1)
            {
                string fullPassword = txt1.Text + txt2.Text + txt3.Text + txt4.Text + txt5.Text + txt6.Text;

                if (fullPassword == "202503")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password is incorrect. Please enter the correct password.",
                        "Password Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txt1.Text = txt2.Text = txt3.Text = txt4.Text = txt5.Text = txt6.Text = string.Empty;
                    txt1.Focus();
                }
            }
        }


        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox current = sender as TextBox;

            if (e.KeyCode == Keys.Back && current.Text == "")
            {
                this.SelectNextControl(current, false, true, true, true); // go to previous
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
