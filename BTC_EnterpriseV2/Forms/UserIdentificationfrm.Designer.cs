namespace BTC_EnterpriseV2.Forms
{
    partial class UserIdentificationfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserIdentificationfrm));
            label1 = new Label();
            pb_rfid = new PictureBox();
            lbl_userinfo = new Label();
            lbl_position = new Label();
            txt_scanid = new TextBox();
            txt_id = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_rfid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(45, 24);
            label1.Name = "label1";
            label1.Size = new Size(306, 38);
            label1.TabIndex = 0;
            label1.Text = "BTC POWER CEBU INC.";
            // 
            // pb_rfid
            // 
            pb_rfid.Image = (Image)resources.GetObject("pb_rfid.Image");
            pb_rfid.Location = new Point(90, 90);
            pb_rfid.Name = "pb_rfid";
            pb_rfid.Size = new Size(214, 203);
            pb_rfid.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_rfid.TabIndex = 1;
            pb_rfid.TabStop = false;
            // 
            // lbl_userinfo
            // 
            lbl_userinfo.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_userinfo.ForeColor = Color.White;
            lbl_userinfo.Location = new Point(33, 311);
            lbl_userinfo.Name = "lbl_userinfo";
            lbl_userinfo.Size = new Size(318, 40);
            lbl_userinfo.TabIndex = 2;
            lbl_userinfo.Text = "Operation Name";
            lbl_userinfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_position
            // 
            lbl_position.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_position.ForeColor = Color.White;
            lbl_position.Location = new Point(34, 351);
            lbl_position.Name = "lbl_position";
            lbl_position.Size = new Size(318, 40);
            lbl_position.TabIndex = 2;
            lbl_position.Text = "Position ";
            lbl_position.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_scanid
            // 
            txt_scanid.Location = new Point(137, 396);
            txt_scanid.Name = "txt_scanid";
            txt_scanid.Size = new Size(112, 27);
            txt_scanid.TabIndex = 3;
            txt_scanid.KeyDown += txt_scanid_KeyDown;
            // 
            // txt_id
            // 
            txt_id.BackColor = Color.SeaGreen;
            txt_id.BorderStyle = BorderStyle.None;
            txt_id.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_id.ForeColor = Color.White;
            txt_id.Location = new Point(44, 394);
            txt_id.Name = "txt_id";
            txt_id.Size = new Size(307, 36);
            txt_id.TabIndex = 4;
            txt_id.TextAlign = HorizontalAlignment.Center;
            txt_id.KeyDown += txt_id_KeyDown;
            // 
            // button1
            // 
            button1.BackColor = Color.Tomato;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(90, 448);
            button1.Name = "button1";
            button1.Size = new Size(214, 47);
            button1.TabIndex = 5;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // UserIdentificationfrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSeaGreen;
            ClientSize = new Size(391, 507);
            Controls.Add(button1);
            Controls.Add(txt_id);
            Controls.Add(txt_scanid);
            Controls.Add(lbl_position);
            Controls.Add(lbl_userinfo);
            Controls.Add(pb_rfid);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserIdentificationfrm";
            Text = "UserIdentificationfrm";
            ((System.ComponentModel.ISupportInitialize)pb_rfid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pb_rfid;
        private Label lbl_userinfo;
        private Label lbl_position;
        private TextBox txt_scanid;
        private TextBox txt_id;
        private Button button1;
    }
}