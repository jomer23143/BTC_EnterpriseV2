namespace BTCP_EnterpriseV2.Forms
{
    partial class MainDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            timer1 = new System.Windows.Forms.Timer(components);
            panel_last = new Panel();
            panel_Subassy_Display = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            panel2 = new Panel();
            panel6 = new Panel();
            settingimage = new PictureBox();
            lbl_time = new Label();
            lbl_currentdate = new Label();
            panel3 = new Panel();
            btn_subasemble = new Button();
            btn_home = new Button();
            Btn_maximixe = new Button();
            lbl_departmemnt = new Label();
            lbl_operatorlogin = new Label();
            panel_menubar = new Panel();
            panel4 = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            panel_Subassy_Display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingimage).BeginInit();
            panel_menubar.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel_last
            // 
            panel_last.BackColor = Color.Transparent;
            panel_last.Dock = DockStyle.Left;
            panel_last.Location = new Point(0, 0);
            panel_last.Name = "panel_last";
            panel_last.Size = new Size(10, 863);
            panel_last.TabIndex = 1;
            // 
            // panel_Subassy_Display
            // 
            panel_Subassy_Display.BackColor = Color.FromArgb(37, 45, 55);
            panel_Subassy_Display.Controls.Add(label1);
            panel_Subassy_Display.Controls.Add(pictureBox2);
            panel_Subassy_Display.Controls.Add(pictureBox1);
            panel_Subassy_Display.Controls.Add(panel5);
            panel_Subassy_Display.Controls.Add(panel2);
            panel_Subassy_Display.Controls.Add(panel_last);
            panel_Subassy_Display.Controls.Add(panel6);
            panel_Subassy_Display.Dock = DockStyle.Fill;
            panel_Subassy_Display.Location = new Point(0, 79);
            panel_Subassy_Display.Name = "panel_Subassy_Display";
            panel_Subassy_Display.Size = new Size(1614, 863);
            panel_Subassy_Display.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(478, 47);
            label1.Name = "label1";
            label1.Size = new Size(648, 97);
            label1.TabIndex = 11;
            label1.Text = "Production System";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(288, 721);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1045, 82);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(288, 147);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1045, 568);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(10, 853);
            panel5.Name = "panel5";
            panel5.Size = new Size(1594, 10);
            panel5.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(10, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1594, 5);
            panel2.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(37, 45, 55);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(1604, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(10, 863);
            panel6.TabIndex = 8;
            // 
            // settingimage
            // 
            settingimage.BackgroundImage = (Image)resources.GetObject("settingimage.BackgroundImage");
            settingimage.BackgroundImageLayout = ImageLayout.Center;
            settingimage.Location = new Point(319, 7);
            settingimage.Name = "settingimage";
            settingimage.Size = new Size(55, 51);
            settingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            settingimage.TabIndex = 1;
            settingimage.TabStop = false;
            settingimage.Click += settingimage_Click;
            // 
            // lbl_time
            // 
            lbl_time.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_time.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_time.ForeColor = Color.FromArgb(100, 180, 45);
            lbl_time.Location = new Point(1385, 11);
            lbl_time.Name = "lbl_time";
            lbl_time.Size = new Size(216, 28);
            lbl_time.TabIndex = 2;
            lbl_time.Text = "10:10 AM";
            lbl_time.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_currentdate
            // 
            lbl_currentdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_currentdate.ForeColor = Color.White;
            lbl_currentdate.Location = new Point(1386, 42);
            lbl_currentdate.Name = "lbl_currentdate";
            lbl_currentdate.Size = new Size(216, 20);
            lbl_currentdate.TabIndex = 3;
            lbl_currentdate.Text = "Monday, October 07 2025";
            lbl_currentdate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(380, 14);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 52);
            panel3.TabIndex = 4;
            // 
            // btn_subasemble
            // 
            btn_subasemble.Cursor = Cursors.Hand;
            btn_subasemble.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btn_subasemble.FlatAppearance.BorderSize = 0;
            btn_subasemble.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_subasemble.FlatStyle = FlatStyle.Flat;
            btn_subasemble.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_subasemble.ForeColor = SystemColors.ControlLightLight;
            btn_subasemble.Location = new Point(447, 16);
            btn_subasemble.Name = "btn_subasemble";
            btn_subasemble.Size = new Size(320, 50);
            btn_subasemble.TabIndex = 5;
            btn_subasemble.Text = "Production Process";
            btn_subasemble.UseVisualStyleBackColor = true;
            btn_subasemble.Click += button2_Click;
            // 
            // btn_home
            // 
            btn_home.BackgroundImage = (Image)resources.GetObject("btn_home.BackgroundImage");
            btn_home.BackgroundImageLayout = ImageLayout.Stretch;
            btn_home.Cursor = Cursors.Hand;
            btn_home.FlatAppearance.BorderSize = 0;
            btn_home.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_home.FlatStyle = FlatStyle.Flat;
            btn_home.Location = new Point(12, 9);
            btn_home.Name = "btn_home";
            btn_home.Size = new Size(301, 40);
            btn_home.TabIndex = 6;
            btn_home.UseVisualStyleBackColor = true;
            btn_home.Click += btn_home_Click;
            // 
            // Btn_maximixe
            // 
            Btn_maximixe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_maximixe.Location = new Point(773, 23);
            Btn_maximixe.Name = "Btn_maximixe";
            Btn_maximixe.Size = new Size(94, 39);
            Btn_maximixe.TabIndex = 7;
            Btn_maximixe.Text = "button2";
            Btn_maximixe.UseVisualStyleBackColor = true;
            Btn_maximixe.Visible = false;
            Btn_maximixe.Click += Btn_maximixe_Click;
            // 
            // lbl_departmemnt
            // 
            lbl_departmemnt.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_departmemnt.ForeColor = Color.White;
            lbl_departmemnt.Location = new Point(16, 52);
            lbl_departmemnt.Name = "lbl_departmemnt";
            lbl_departmemnt.Size = new Size(297, 27);
            lbl_departmemnt.TabIndex = 8;
            lbl_departmemnt.Text = "label1";
            lbl_departmemnt.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_operatorlogin
            // 
            lbl_operatorlogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_operatorlogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_operatorlogin.ForeColor = Color.SpringGreen;
            lbl_operatorlogin.Location = new Point(1105, 44);
            lbl_operatorlogin.Name = "lbl_operatorlogin";
            lbl_operatorlogin.Size = new Size(275, 29);
            lbl_operatorlogin.TabIndex = 9;
            lbl_operatorlogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_menubar
            // 
            panel_menubar.BackColor = Color.FromArgb(22, 27, 45);
            panel_menubar.Controls.Add(panel4);
            panel_menubar.Controls.Add(panel1);
            panel_menubar.Controls.Add(label2);
            panel_menubar.Controls.Add(lbl_operatorlogin);
            panel_menubar.Controls.Add(lbl_departmemnt);
            panel_menubar.Controls.Add(Btn_maximixe);
            panel_menubar.Controls.Add(btn_home);
            panel_menubar.Controls.Add(btn_subasemble);
            panel_menubar.Controls.Add(panel3);
            panel_menubar.Controls.Add(lbl_currentdate);
            panel_menubar.Controls.Add(lbl_time);
            panel_menubar.Controls.Add(settingimage);
            panel_menubar.Dock = DockStyle.Top;
            panel_menubar.Location = new Point(0, 0);
            panel_menubar.Name = "panel_menubar";
            panel_menubar.Size = new Size(1614, 79);
            panel_menubar.TabIndex = 0;
            panel_menubar.MouseDown += panel_menubar_MouseDown;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.BackColor = Color.White;
            panel4.ForeColor = SystemColors.ControlLight;
            panel4.Location = new Point(1094, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(5, 73);
            panel4.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.ForeColor = SystemColors.ControlLight;
            panel1.Location = new Point(1385, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 73);
            panel1.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1105, 10);
            label2.Name = "label2";
            label2.Size = new Size(275, 32);
            label2.TabIndex = 9;
            label2.Text = "Login Operator";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(1614, 942);
            Controls.Add(panel_Subassy_Display);
            Controls.Add(panel_menubar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainDashboard";
            Text = "MainDashboard";
            Load += MainDashboard_Load;
            SizeChanged += MainDashboard_SizeChanged;
            panel_Subassy_Display.ResumeLayout(false);
            panel_Subassy_Display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingimage).EndInit();
            panel_menubar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        public Panel panel_last;
        private Panel panel_Subassy_Display;
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        public PictureBox settingimage;
        public Label lbl_time;
        public Label lbl_currentdate;
        private Panel panel3;
        private Button btn_subasemble;
        private Button btn_home;
        private Button Btn_maximixe;
        public Label lbl_departmemnt;
        private Panel panel_menubar;
        private Panel panel1;
        private Label label2;
        private Panel panel4;
        public Label lbl_operatorlogin;
    }
}