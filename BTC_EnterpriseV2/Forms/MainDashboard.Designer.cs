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
            btn_productionprocess = new Button();
            btn_subasemble = new Button();
            BTN_Warehouse = new Button();
            panel3 = new Panel();
            lbl_currentdate = new Label();
            lbl_time = new Label();
            settingimage = new PictureBox();
            panel_sidebar = new Panel();
            panel_main_display = new Panel();
            panel_chart = new Panel();
            pictureBox1 = new PictureBox();
            panel_Subassy_Display = new Panel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            warehouseRecievingToolStripMenuItem = new ToolStripMenuItem();
            kitlistRecievingToolStripMenuItem = new ToolStripMenuItem();
            panel_menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingimage).BeginInit();
            panel_main_display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            panel_menubar.Controls.Add(btn_productionprocess);
            panel_menubar.Controls.Add(btn_subasemble);
            panel_menubar.Controls.Add(BTN_Warehouse);
            panel_menubar.Controls.Add(panel3);
            panel_menubar.Controls.Add(lbl_currentdate);
            panel_menubar.Controls.Add(lbl_time);
            panel_menubar.Controls.Add(settingimage);
            panel_menubar.Dock = DockStyle.Top;
            panel_menubar.Location = new Point(0, 0);
            panel_menubar.Name = "panel_menubar";
            panel_menubar.Size = new Size(1614, 66);
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
            btn_home.Location = new Point(12, 11);
            btn_home.Name = "btn_home";
            btn_home.Size = new Size(301, 46);
            btn_home.TabIndex = 6;
            btn_home.UseVisualStyleBackColor = true;
            btn_home.Click += btn_home_Click;
            // 
            // btn_productionprocess
            // 
            btn_productionprocess.Cursor = Cursors.Hand;
            btn_productionprocess.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btn_productionprocess.FlatAppearance.BorderSize = 0;
            btn_productionprocess.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_productionprocess.FlatStyle = FlatStyle.Flat;
            btn_productionprocess.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_productionprocess.ForeColor = SystemColors.ControlLightLight;
            btn_productionprocess.Location = new Point(942, 12);
            btn_productionprocess.Name = "btn_productionprocess";
            btn_productionprocess.Size = new Size(263, 42);
            btn_productionprocess.TabIndex = 5;
            btn_productionprocess.Text = "Production Process";
            btn_productionprocess.UseVisualStyleBackColor = true;
            btn_productionprocess.Click += btn_productionprocess_Click;
            // 
            // btn_subasemble
            // 
            btn_subasemble.Cursor = Cursors.Hand;
            btn_subasemble.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btn_subasemble.FlatAppearance.BorderSize = 0;
            btn_subasemble.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_subasemble.FlatStyle = FlatStyle.Flat;
            btn_subasemble.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_subasemble.ForeColor = SystemColors.ControlLightLight;
            btn_subasemble.Location = new Point(671, 12);
            btn_subasemble.Name = "btn_subasemble";
            btn_subasemble.Size = new Size(263, 42);
            btn_subasemble.TabIndex = 5;
            btn_subasemble.Text = "Sub Assymble";
            btn_subasemble.UseVisualStyleBackColor = true;
            btn_subasemble.Click += button2_Click;
            // 
            // BTN_Warehouse
            // 
            BTN_Warehouse.Cursor = Cursors.Hand;
            BTN_Warehouse.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            BTN_Warehouse.FlatAppearance.BorderSize = 0;
            BTN_Warehouse.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BTN_Warehouse.FlatStyle = FlatStyle.Flat;
            BTN_Warehouse.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BTN_Warehouse.ForeColor = SystemColors.ControlLightLight;
            BTN_Warehouse.Location = new Point(400, 12);
            BTN_Warehouse.Name = "BTN_Warehouse";
            BTN_Warehouse.Size = new Size(263, 42);
            BTN_Warehouse.TabIndex = 5;
            BTN_Warehouse.Text = "Warehouse";
            BTN_Warehouse.UseVisualStyleBackColor = true;
            BTN_Warehouse.Click += BTN_Warehouse_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(380, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 49);
            panel3.TabIndex = 4;
            // 
            // lbl_currentdate
            // 
            lbl_currentdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_currentdate.ForeColor = Color.White;
            lbl_currentdate.Location = new Point(1386, 39);
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
            lbl_time.Location = new Point(1385, 8);
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
            settingimage.Location = new Point(319, 10);
            settingimage.Name = "settingimage";
            settingimage.Size = new Size(55, 51);
            settingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            settingimage.TabIndex = 1;
            settingimage.TabStop = false;
            // 
            // panel_sidebar
            // 
            panel_sidebar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel_sidebar.BackColor = Color.Transparent;
            panel_sidebar.Location = new Point(3, 19);
            panel_sidebar.Name = "panel_sidebar";
            panel_sidebar.Size = new Size(298, 836);
            panel_sidebar.TabIndex = 1;
            // 
            // panel_main_display
            // 
            panel_main_display.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_main_display.BackColor = Color.Transparent;
            panel_main_display.Controls.Add(panel_chart);
            panel_main_display.Controls.Add(pictureBox1);
            panel_main_display.Location = new Point(320, 19);
            panel_main_display.Name = "panel_main_display";
            panel_main_display.Size = new Size(1244, 836);
            panel_main_display.TabIndex = 2;
            panel_main_display.SizeChanged += panel_main_display_SizeChanged;
            // 
            // panel_chart
            // 
            panel_chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_chart.BackColor = Color.White;
            panel_chart.Location = new Point(33, 233);
            panel_chart.Name = "panel_chart";
            panel_chart.Size = new Size(1186, 585);
            panel_chart.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-21, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1137, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel_Subassy_Display
            // 
            panel_Subassy_Display.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_Subassy_Display.Controls.Add(panel_sidebar);
            panel_Subassy_Display.Controls.Add(panel_main_display);
            panel_Subassy_Display.Location = new Point(12, 72);
            panel_Subassy_Display.Name = "panel_Subassy_Display";
            panel_Subassy_Display.Size = new Size(1589, 858);
            panel_Subassy_Display.TabIndex = 3;
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
            panel_main_display.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_Subassy_Display.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_menubar;
        private Panel panel3;
        private Button BTN_Warehouse;
        private Button btn_productionprocess;
        private Button btn_subasemble;
        public Label lbl_currentdate;
        public Label lbl_time;
        public System.Windows.Forms.Timer timer1;
        public PictureBox settingimage;
        public Panel panel_sidebar;
        public Panel panel_main_display;
        private PictureBox pictureBox1;
        public Panel panel_chart;
        private Button btn_home;
        private Panel panel_Subassy_Display;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem warehouseRecievingToolStripMenuItem;
        private ToolStripMenuItem kitlistRecievingToolStripMenuItem;
    }
}