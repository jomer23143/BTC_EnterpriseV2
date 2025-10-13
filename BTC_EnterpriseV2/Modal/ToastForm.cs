using Timer = System.Windows.Forms.Timer;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ToastForm : Form
    {
        private Timer timer;
        private int duration = 5000;
        public ToastForm(string message)
        {
            InitializeComponent();
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.Tomato;
            this.Size = new Size(450, 100);

            //// Position bottom-right
            //this.Location = new Point(
            //    Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10,
            //    Screen.PrimaryScreen.WorkingArea.Height - this.Height - 10
            //);

            // Position top-center
            this.Location = new Point(
             (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, 10);

            Label lbl = new Label()
            {
                Text = message,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White

            };

            this.Controls.Add(lbl);

            // Timer for auto-close
            timer = new Timer();
            timer.Interval = duration;
            timer.Tick += (s, e) => { this.Close(); };
            timer.Start();

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Opacity = 0;
            var fadeIn = new Timer { Interval = 20 };
            fadeIn.Tick += (s, ev) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                else fadeIn.Stop();
            };
            fadeIn.Start();
        }

    }
}
