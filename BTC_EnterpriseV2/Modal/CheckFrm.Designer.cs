namespace BTC_EnterpriseV2.Modal
{
    partial class CheckFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckFrm));
            panel1 = new Panel();
            btn_close = new Button();
            panel2 = new Panel();
            panel_rfid = new Panel();
            panel_scangeneratedserial = new Panel();
            panel_generatedcodeform = new Panel();
            txt_scangeneratedserial = new TextBox();
            pictureBox2 = new PictureBox();
            label_scaninfo = new Label();
            pictureBox1 = new PictureBox();
            panel_rfidtextholder = new Panel();
            txt_scan = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            btn_viewlicense = new Button();
            panel_positionHolder = new Panel();
            lbl_position = new Label();
            panel_nameHolder = new Panel();
            lbl_userinfo = new Label();
            panel_idholder = new Panel();
            txt_id = new Label();
            pb_rfid = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel_rfid.SuspendLayout();
            panel_scangeneratedserial.SuspendLayout();
            panel_generatedcodeform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_rfidtextholder.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel_positionHolder.SuspendLayout();
            panel_nameHolder.SuspendLayout();
            panel_idholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_rfid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(865, 38);
            panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            btn_close.BackgroundImage = (Image)resources.GetObject("btn_close.BackgroundImage");
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Location = new Point(817, 3);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(37, 32);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(panel_rfid);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(12, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(842, 543);
            panel2.TabIndex = 1;
            // 
            // panel_rfid
            // 
            panel_rfid.BackColor = Color.FromArgb(22, 27, 45);
            panel_rfid.BackgroundImage = (Image)resources.GetObject("panel_rfid.BackgroundImage");
            panel_rfid.BackgroundImageLayout = ImageLayout.Stretch;
            panel_rfid.Controls.Add(panel_scangeneratedserial);
            panel_rfid.Controls.Add(pictureBox1);
            panel_rfid.Controls.Add(panel_rfidtextholder);
            panel_rfid.Controls.Add(label2);
            panel_rfid.Controls.Add(label1);
            panel_rfid.Location = new Point(487, 24);
            panel_rfid.Name = "panel_rfid";
            panel_rfid.Size = new Size(343, 496);
            panel_rfid.TabIndex = 3;
            // 
            // panel_scangeneratedserial
            // 
            panel_scangeneratedserial.Controls.Add(panel_generatedcodeform);
            panel_scangeneratedserial.Controls.Add(pictureBox2);
            panel_scangeneratedserial.Controls.Add(label_scaninfo);
            panel_scangeneratedserial.Location = new Point(0, -5);
            panel_scangeneratedserial.Name = "panel_scangeneratedserial";
            panel_scangeneratedserial.Size = new Size(343, 501);
            panel_scangeneratedserial.TabIndex = 4;
            // 
            // panel_generatedcodeform
            // 
            panel_generatedcodeform.BackColor = Color.FromArgb(37, 45, 55);
            panel_generatedcodeform.Controls.Add(txt_scangeneratedserial);
            panel_generatedcodeform.Location = new Point(24, 249);
            panel_generatedcodeform.Name = "panel_generatedcodeform";
            panel_generatedcodeform.Size = new Size(300, 54);
            panel_generatedcodeform.TabIndex = 1;
            // 
            // txt_scangeneratedserial
            // 
            txt_scangeneratedserial.BorderStyle = BorderStyle.None;
            txt_scangeneratedserial.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_scangeneratedserial.Location = new Point(11, 11);
            txt_scangeneratedserial.Name = "txt_scangeneratedserial";
            txt_scangeneratedserial.Size = new Size(277, 31);
            txt_scangeneratedserial.TabIndex = 0;
            txt_scangeneratedserial.TextAlign = HorizontalAlignment.Center;
            txt_scangeneratedserial.KeyDown += txt_scangeneratedserial_KeyDown;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(24, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(300, 182);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label_scaninfo
            // 
            label_scaninfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_scaninfo.ForeColor = Color.White;
            label_scaninfo.Location = new Point(38, 325);
            label_scaninfo.Name = "label_scaninfo";
            label_scaninfo.Size = new Size(272, 63);
            label_scaninfo.TabIndex = 1;
            label_scaninfo.Text = "Please Scan Generated Serial Here.";
            label_scaninfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(274, 198);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel_rfidtextholder
            // 
            panel_rfidtextholder.BackColor = Color.FromArgb(7, 222, 151);
            panel_rfidtextholder.Controls.Add(txt_scan);
            panel_rfidtextholder.Location = new Point(33, 272);
            panel_rfidtextholder.Name = "panel_rfidtextholder";
            panel_rfidtextholder.Size = new Size(274, 45);
            panel_rfidtextholder.TabIndex = 1;
            // 
            // txt_scan
            // 
            txt_scan.BorderStyle = BorderStyle.None;
            txt_scan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_scan.Location = new Point(5, 6);
            txt_scan.Name = "txt_scan";
            txt_scan.Size = new Size(265, 31);
            txt_scan.TabIndex = 0;
            txt_scan.KeyDown += txt_scan_KeyDown;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 6);
            label2.Name = "label2";
            label2.Size = new Size(275, 33);
            label2.TabIndex = 1;
            label2.Text = "BTC POWER CEBU INC.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(33, 325);
            label1.Name = "label1";
            label1.Size = new Size(274, 66);
            label1.TabIndex = 2;
            label1.Text = "Please tap your ID to RFID Scanner";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(22, 27, 45);
            panel3.Controls.Add(groupBox1);
            panel3.Location = new Point(13, 19);
            panel3.Name = "panel3";
            panel3.Size = new Size(468, 501);
            panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_viewlicense);
            groupBox1.Controls.Add(panel_positionHolder);
            groupBox1.Controls.Add(panel_nameHolder);
            groupBox1.Controls.Add(panel_idholder);
            groupBox1.Controls.Add(pb_rfid);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Lime;
            groupBox1.Location = new Point(10, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(437, 476);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Operator Information";
            // 
            // btn_viewlicense
            // 
            btn_viewlicense.FlatAppearance.BorderColor = Color.FromArgb(22, 27, 45);
            btn_viewlicense.FlatStyle = FlatStyle.Flat;
            btn_viewlicense.Location = new Point(40, 405);
            btn_viewlicense.Name = "btn_viewlicense";
            btn_viewlicense.Size = new Size(358, 59);
            btn_viewlicense.TabIndex = 3;
            btn_viewlicense.Text = "View License";
            btn_viewlicense.UseVisualStyleBackColor = true;
            btn_viewlicense.Click += button1_Click;
            // 
            // panel_positionHolder
            // 
            panel_positionHolder.BackColor = Color.FromArgb(37, 45, 55);
            panel_positionHolder.Controls.Add(lbl_position);
            panel_positionHolder.Location = new Point(40, 334);
            panel_positionHolder.Name = "panel_positionHolder";
            panel_positionHolder.Size = new Size(361, 52);
            panel_positionHolder.TabIndex = 2;
            // 
            // lbl_position
            // 
            lbl_position.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_position.ForeColor = Color.White;
            lbl_position.Location = new Point(3, 5);
            lbl_position.Name = "lbl_position";
            lbl_position.Size = new Size(355, 40);
            lbl_position.TabIndex = 1;
            lbl_position.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_nameHolder
            // 
            panel_nameHolder.BackColor = Color.FromArgb(37, 45, 55);
            panel_nameHolder.Controls.Add(lbl_userinfo);
            panel_nameHolder.Location = new Point(40, 266);
            panel_nameHolder.Name = "panel_nameHolder";
            panel_nameHolder.Size = new Size(361, 52);
            panel_nameHolder.TabIndex = 2;
            // 
            // lbl_userinfo
            // 
            lbl_userinfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_userinfo.ForeColor = Color.White;
            lbl_userinfo.Location = new Point(3, 7);
            lbl_userinfo.Name = "lbl_userinfo";
            lbl_userinfo.Size = new Size(344, 39);
            lbl_userinfo.TabIndex = 1;
            lbl_userinfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_idholder
            // 
            panel_idholder.BackColor = Color.FromArgb(37, 45, 55);
            panel_idholder.Controls.Add(txt_id);
            panel_idholder.Location = new Point(131, 198);
            panel_idholder.Name = "panel_idholder";
            panel_idholder.Size = new Size(199, 52);
            panel_idholder.TabIndex = 2;
            // 
            // txt_id
            // 
            txt_id.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_id.ForeColor = Color.White;
            txt_id.Location = new Point(5, 0);
            txt_id.Name = "txt_id";
            txt_id.Size = new Size(191, 52);
            txt_id.TabIndex = 1;
            txt_id.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pb_rfid
            // 
            pb_rfid.Image = (Image)resources.GetObject("pb_rfid.Image");
            pb_rfid.Location = new Point(136, 36);
            pb_rfid.Name = "pb_rfid";
            pb_rfid.Size = new Size(191, 156);
            pb_rfid.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_rfid.TabIndex = 0;
            pb_rfid.TabStop = false;
            // 
            // CheckFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(865, 599);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CheckFrm";
            Text = "CheckFrm";
            Load += CheckFrm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel_rfid.ResumeLayout(false);
            panel_scangeneratedserial.ResumeLayout(false);
            panel_generatedcodeform.ResumeLayout(false);
            panel_generatedcodeform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_rfidtextholder.ResumeLayout(false);
            panel_rfidtextholder.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel_positionHolder.ResumeLayout(false);
            panel_nameHolder.ResumeLayout(false);
            panel_idholder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_rfid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_close;
        private Panel panel2;
        private Label label1;
        private Panel panel_rfidtextholder;
        private Panel panel3;
        private GroupBox groupBox1;
        private PictureBox pb_rfid;
        private Label lbl_position;
        private Label lbl_userinfo;
        private Label txt_id;
        private TextBox txt_scan;
        private Panel panel_rfid;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel_generatedcodeform;
        private TextBox txt_scangeneratedserial;
        private PictureBox pictureBox2;
        private Label label_scaninfo;
        private Panel panel_positionHolder;
        private Panel panel_nameHolder;
        private Panel panel_idholder;
        private Button btn_viewlicense;
        public Panel panel_scangeneratedserial;
    }
}