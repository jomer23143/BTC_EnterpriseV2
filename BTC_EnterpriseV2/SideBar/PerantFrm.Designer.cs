namespace BTC_EnterpriseV2.SideBar
{
    partial class PerantFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerantFrm));
            panel_sidebarHolder = new Panel();
            btn_logout = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            btn_printqr = new Button();
            button1 = new Button();
            panel2 = new Panel();
            btn_toggle_right = new Button();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel_display_holder = new Panel();
            panel_chart = new Panel();
            pictureBox1 = new PictureBox();
            panel_sidebarHolder.SuspendLayout();
            panel2.SuspendLayout();
            panel_display_holder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel_sidebarHolder
            // 
            panel_sidebarHolder.BackColor = Color.FromArgb(22, 27, 45);
            panel_sidebarHolder.Controls.Add(btn_logout);
            panel_sidebarHolder.Controls.Add(button6);
            panel_sidebarHolder.Controls.Add(button5);
            panel_sidebarHolder.Controls.Add(button4);
            panel_sidebarHolder.Controls.Add(button3);
            panel_sidebarHolder.Controls.Add(btn_printqr);
            panel_sidebarHolder.Controls.Add(button1);
            panel_sidebarHolder.Controls.Add(panel2);
            panel_sidebarHolder.Dock = DockStyle.Left;
            panel_sidebarHolder.Location = new Point(0, 0);
            panel_sidebarHolder.Name = "panel_sidebarHolder";
            panel_sidebarHolder.Size = new Size(295, 762);
            panel_sidebarHolder.TabIndex = 0;
            // 
            // btn_logout
            // 
            btn_logout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_logout.FlatAppearance.BorderSize = 0;
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_logout.ForeColor = Color.SpringGreen;
            btn_logout.Image = (Image)resources.GetObject("btn_logout.Image");
            btn_logout.ImageAlign = ContentAlignment.MiddleLeft;
            btn_logout.Location = new Point(7, 694);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(283, 56);
            btn_logout.TabIndex = 1;
            btn_logout.Text = "Logout";
            btn_logout.UseVisualStyleBackColor = true;
            btn_logout.Click += btn_logout_Click;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(7, 381);
            button6.Name = "button6";
            button6.Size = new Size(283, 56);
            button6.TabIndex = 1;
            button6.Text = "Process";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(7, 316);
            button5.Name = "button5";
            button5.Size = new Size(283, 56);
            button5.TabIndex = 1;
            button5.Text = "Chart";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(7, 251);
            button4.Name = "button4";
            button4.Size = new Size(283, 56);
            button4.TabIndex = 1;
            button4.Text = "Kitlist Recieving";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(7, 186);
            button3.Name = "button3";
            button3.Size = new Size(283, 56);
            button3.TabIndex = 1;
            button3.Text = "Warehouse Kitting";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btn_printqr
            // 
            btn_printqr.FlatAppearance.BorderSize = 0;
            btn_printqr.FlatStyle = FlatStyle.Flat;
            btn_printqr.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_printqr.ForeColor = Color.White;
            btn_printqr.Image = (Image)resources.GetObject("btn_printqr.Image");
            btn_printqr.ImageAlign = ContentAlignment.MiddleLeft;
            btn_printqr.Location = new Point(7, 121);
            btn_printqr.Name = "btn_printqr";
            btn_printqr.Size = new Size(283, 56);
            btn_printqr.TabIndex = 1;
            btn_printqr.Text = "Print QR Code";
            btn_printqr.UseVisualStyleBackColor = true;
            btn_printqr.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(7, 56);
            button1.Name = "button1";
            button1.Size = new Size(283, 56);
            button1.TabIndex = 1;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_toggle_right);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 50);
            panel2.TabIndex = 0;
            // 
            // btn_toggle_right
            // 
            btn_toggle_right.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_toggle_right.BackgroundImage = (Image)resources.GetObject("btn_toggle_right.BackgroundImage");
            btn_toggle_right.BackgroundImageLayout = ImageLayout.Center;
            btn_toggle_right.Cursor = Cursors.Hand;
            btn_toggle_right.FlatAppearance.BorderSize = 0;
            btn_toggle_right.FlatStyle = FlatStyle.Flat;
            btn_toggle_right.Location = new Point(244, 6);
            btn_toggle_right.Name = "btn_toggle_right";
            btn_toggle_right.Size = new Size(44, 37);
            btn_toggle_right.TabIndex = 0;
            btn_toggle_right.UseVisualStyleBackColor = true;
            btn_toggle_right.Click += btn_toggle_right_Click;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(295, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1130, 10);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(295, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 752);
            panel4.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(305, 754);
            panel5.Name = "panel5";
            panel5.Size = new Size(1120, 8);
            panel5.TabIndex = 3;
            // 
            // panel_display_holder
            // 
            panel_display_holder.BackColor = Color.FromArgb(22, 27, 45);
            panel_display_holder.Controls.Add(panel_chart);
            panel_display_holder.Controls.Add(pictureBox1);
            panel_display_holder.Dock = DockStyle.Fill;
            panel_display_holder.Location = new Point(305, 10);
            panel_display_holder.Name = "panel_display_holder";
            panel_display_holder.Size = new Size(1120, 744);
            panel_display_holder.TabIndex = 5;
            // 
            // panel_chart
            // 
            panel_chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_chart.BackColor = Color.White;
            panel_chart.Location = new Point(107, 195);
            panel_chart.Name = "panel_chart";
            panel_chart.Size = new Size(927, 500);
            panel_chart.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(107, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(927, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PerantFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(1425, 762);
            Controls.Add(panel_display_holder);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel_sidebarHolder);
            Name = "PerantFrm";
            Text = "PerantFrm";
            Load += PerantFrm_Load;
            SizeChanged += PerantFrm_SizeChanged;
            panel_sidebarHolder.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel_display_holder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_sidebarHolder;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel_display_holder;
        private Button button1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button btn_printqr;
        private Button button6;
        private Button btn_toggle_right;
        private PictureBox pictureBox1;
        private Panel panel_chart;
        private Button btn_logout;
    }
}