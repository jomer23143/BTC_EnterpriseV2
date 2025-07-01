using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class CustomeAlert : Form
    {

        public enum Alertype
        {
            Success,
            Warning,
            confirm,
            Error,
            Logout
        }

        public CustomeAlert(string Atitle, string message, Alertype type)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            yUI.RoundedButton(button1, 8, Color.FromArgb(22, 27, 45));
            lbl_alertTitle.Text = Atitle;
            lblMessage.Text = message;
            CustomizeAlert(type);
        }
        private void CustomizeAlert(Alertype type)
        {
            switch (type)
            {
                case Alertype.Success:
                    // this.BackColor = Color.FromArgb(72, 201, 176); // Green
                    this.BackColor = Color.White;
                    string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "success_icon.png");
                    string imagePath = defaultImagePath;  // No image found in response
                    picIcon.Image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;
                    break;
                case Alertype.Warning:
                    // this.BackColor = Color.FromArgb(241, 196, 15); // Yellow
                    this.BackColor = Color.FromArgb(22, 27, 45);
                    string wariningIcon = Path.Combine(Application.StartupPath, "Assets", "warning_icon.png");
                    string IconPath = wariningIcon;  // No image found in response
                    picIcon.Image = File.Exists(IconPath) ? Image.FromFile(IconPath) : null;
                    break;

                case Alertype.confirm:
                    // this.BackColor = Color.FromArgb(231, 76, 60); // Red
                    this.BackColor = Color.White;
                    string confirmIcon = Path.Combine(Application.StartupPath, "Assets", "confirm_icon.png");
                    string CiconPath = confirmIcon;  // No image found in response
                    picIcon.Image = File.Exists(CiconPath) ? Image.FromFile(CiconPath) : null;
                    break;

                case Alertype.Error:
                    this.BackColor = Color.LightGray;
                    string errorIcon = Path.Combine(Application.StartupPath, "Assets", "error.png");
                    string errorPath = errorIcon;  // No image found in response
                    picIcon.Image = File.Exists(errorPath) ? Image.FromFile(errorPath) : null;
                    break;
                case Alertype.Logout:
                    // this.BackColor = Color.FromArgb(231, 76, 60); // Red
                    this.BackColor = Color.White;
                    string LogoutIcon = Path.Combine(Application.StartupPath, "Assets", "logout_icon.png");
                    string LiconPath = LogoutIcon;  // No image found in response
                    picIcon.Image = File.Exists(LiconPath) ? Image.FromFile(LiconPath) : null;

                    break;
            }
            this.Opacity = 0;
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            else timer1.Stop();
        }
    }
}
