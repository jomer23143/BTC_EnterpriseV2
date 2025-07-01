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
            panel_menubar = new Panel();
            btn_home = new Button();
            btn_subasemble = new Button();
            panel3 = new Panel();
            lbl_currentdate = new Label();
            lbl_time = new Label();
            settingimage = new PictureBox();
            panel_last = new Panel();
            panel_Subassy_Display = new Panel();
            panel5 = new Panel();
            panel2 = new Panel();
            panel6 = new Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            warehouseRecievingToolStripMenuItem = new ToolStripMenuItem();
            kitlistRecievingToolStripMenuItem = new ToolStripMenuItem();
            panel_menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingimage).BeginInit();
            panel_Subassy_Display.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel_menubar
            // 
            panel_menubar.BackColor = Color.FromArgb(22, 27, 45);
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
            // btn_home
            // 
            btn_home.BackgroundImage = (Image)resources.GetObject("btn_home.BackgroundImage");
            btn_home.BackgroundImageLayout = ImageLayout.Stretch;
            btn_home.Cursor = Cursors.Hand;
            btn_home.FlatAppearance.BorderSize = 0;
            btn_home.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_home.FlatStyle = FlatStyle.Flat;
            btn_home.Location = new Point(12, 15);
            btn_home.Name = "btn_home";
            btn_home.Size = new Size(301, 50);
            btn_home.TabIndex = 6;
            btn_home.UseVisualStyleBackColor = true;
            btn_home.Click += btn_home_Click;
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
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(380, 14);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 52);
            panel3.TabIndex = 4;
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
            // settingimage
            // 
            settingimage.BackgroundImage = (Image)resources.GetObject("settingimage.BackgroundImage");
            settingimage.BackgroundImageLayout = ImageLayout.Center;
            settingimage.Location = new Point(319, 13);
            settingimage.Name = "settingimage";
            settingimage.Size = new Size(55, 51);
            settingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            settingimage.TabIndex = 1;
            settingimage.TabStop = false;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.BackColor = Color.SeaGreen;
            contextMenuStrip1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { warehouseRecievingToolStripMenuItem, kitlistRecievingToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(284, 76);
            // 
            // warehouseRecievingToolStripMenuItem
            // 
            warehouseRecievingToolStripMenuItem.BackColor = Color.White;
            warehouseRecievingToolStripMenuItem.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            warehouseRecievingToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark;
            warehouseRecievingToolStripMenuItem.Image = (Image)resources.GetObject("warehouseRecievingToolStripMenuItem.Image");
            warehouseRecievingToolStripMenuItem.Name = "warehouseRecievingToolStripMenuItem";
            warehouseRecievingToolStripMenuItem.Size = new Size(283, 36);
            warehouseRecievingToolStripMenuItem.Text = "Warehouse Kitting";
            warehouseRecievingToolStripMenuItem.Click += warehouseRecievingToolStripMenuItem_Click;
            // 
            // kitlistRecievingToolStripMenuItem
            // 
            kitlistRecievingToolStripMenuItem.BackColor = Color.White;
            kitlistRecievingToolStripMenuItem.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kitlistRecievingToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark;
            kitlistRecievingToolStripMenuItem.Image = (Image)resources.GetObject("kitlistRecievingToolStripMenuItem.Image");
            kitlistRecievingToolStripMenuItem.Name = "kitlistRecievingToolStripMenuItem";
            kitlistRecievingToolStripMenuItem.Size = new Size(283, 36);
            kitlistRecievingToolStripMenuItem.Text = "Kitlist Recieving";
            kitlistRecievingToolStripMenuItem.Click += kitlistRecievingToolStripMenuItem_Click;
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
            panel_menubar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)settingimage).EndInit();
            panel_Subassy_Display.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_menubar;
        private Panel panel3;
        private Button btn_subasemble;
        public Label lbl_currentdate;
        public Label lbl_time;
        public System.Windows.Forms.Timer timer1;
        public PictureBox settingimage;
        public Panel panel_last;
        private Button btn_home;
        private Panel panel_Subassy_Display;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem warehouseRecievingToolStripMenuItem;
        private ToolStripMenuItem kitlistRecievingToolStripMenuItem;
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
    }
}