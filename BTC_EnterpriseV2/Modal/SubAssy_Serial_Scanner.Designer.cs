namespace BTC_EnterpriseV2.Modal
{
    partial class SubAssy_Serial_Scanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubAssy_Serial_Scanner));
            button1 = new Button();
            label1 = new Label();
            txt_serialnumber = new TextBox();
            pbimage = new PictureBox();
            panel_UI = new Panel();
            pictureBox1 = new PictureBox();
            label_progress = new Label();
            ((System.ComponentModel.ISupportInitialize)pbimage).BeginInit();
            panel_UI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(365, 17);
            button1.Name = "button1";
            button1.Size = new Size(39, 31);
            button1.TabIndex = 10;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(70, 185);
            label1.Name = "label1";
            label1.Size = new Size(266, 20);
            label1.TabIndex = 6;
            label1.Text = "Please Scan Generated Serial Number";
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(19, 153);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(369, 27);
            txt_serialnumber.TabIndex = 5;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // pbimage
            // 
            pbimage.Image = (Image)resources.GetObject("pbimage.Image");
            pbimage.Location = new Point(139, 66);
            pbimage.Name = "pbimage";
            pbimage.Size = new Size(121, 80);
            pbimage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbimage.TabIndex = 4;
            pbimage.TabStop = false;
            // 
            // panel_UI
            // 
            panel_UI.Controls.Add(pbimage);
            panel_UI.Controls.Add(button1);
            panel_UI.Controls.Add(label1);
            panel_UI.Controls.Add(txt_serialnumber);
            panel_UI.Location = new Point(11, 10);
            panel_UI.Name = "panel_UI";
            panel_UI.Size = new Size(413, 243);
            panel_UI.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(52, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(297, 195);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label_progress
            // 
            label_progress.ForeColor = Color.White;
            label_progress.Location = new Point(52, 228);
            label_progress.Name = "label_progress";
            label_progress.Size = new Size(295, 25);
            label_progress.TabIndex = 13;
            label_progress.Text = "Prepairing data ....";
            label_progress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SubAssy_Serial_Scanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(432, 265);
            Controls.Add(panel_UI);
            Controls.Add(pictureBox1);
            Controls.Add(label_progress);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SubAssy_Serial_Scanner";
            Text = "SubAssy_Serial_Scanner";
            Load += SubAssy_Serial_Scanner_Load_1;
            ((System.ComponentModel.ISupportInitialize)pbimage).EndInit();
            panel_UI.ResumeLayout(false);
            panel_UI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txt_serialnumber;
        private PictureBox pbimage;
        private Panel panel_UI;
        private PictureBox pictureBox1;
        private Label label_progress;
    }
}