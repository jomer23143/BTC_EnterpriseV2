namespace BTC_EnterpriseV2.Modal
{
    partial class EndProcessScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndProcessScanner));
            pictureBox1 = new PictureBox();
            txt_rfid = new TextBox();
            button1 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(93, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(247, 259);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txt_rfid
            // 
            txt_rfid.BackColor = Color.White;
            txt_rfid.BorderStyle = BorderStyle.None;
            txt_rfid.Location = new Point(110, 96);
            txt_rfid.Name = "txt_rfid";
            txt_rfid.Size = new Size(215, 20);
            txt_rfid.TabIndex = 1;
            txt_rfid.KeyDown += txt_rfid_KeyDown;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 128);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(93, 383);
            button1.Name = "button1";
            button1.Size = new Size(247, 43);
            button1.TabIndex = 2;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(47, 306);
            label1.Name = "label1";
            label1.Size = new Size(335, 56);
            label1.TabIndex = 3;
            label1.Text = "Please tap your ID to RFID Scanner \r\nto end the process.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EndProcessScanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(425, 459);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(txt_rfid);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EndProcessScanner";
            Text = "EndProcessScanner";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txt_rfid;
        private Button button1;
        private Label label1;
    }
}