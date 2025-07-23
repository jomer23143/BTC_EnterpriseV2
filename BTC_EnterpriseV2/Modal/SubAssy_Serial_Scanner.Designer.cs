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
            btn_close2 = new Button();
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
            button1.Location = new Point(333, 9);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(34, 23);
            button1.TabIndex = 10;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(74, 139);
            label1.Name = "label1";
            label1.Size = new Size(205, 15);
            label1.TabIndex = 6;
            label1.Text = "Please Scan Generated Serial Number";
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(30, 115);
            txt_serialnumber.Margin = new Padding(3, 2, 3, 2);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(323, 22);
            txt_serialnumber.TabIndex = 5;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // pbimage
            // 
            pbimage.Image = (Image)resources.GetObject("pbimage.Image");
            pbimage.Location = new Point(135, 22);
            pbimage.Margin = new Padding(3, 2, 3, 2);
            pbimage.Name = "pbimage";
            pbimage.Size = new Size(106, 88);
            pbimage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbimage.TabIndex = 4;
            pbimage.TabStop = false;
            // 
            // panel_UI
            // 
            panel_UI.Controls.Add(btn_close2);
            panel_UI.Controls.Add(pbimage);
            panel_UI.Controls.Add(label1);
            panel_UI.Controls.Add(txt_serialnumber);
            panel_UI.Dock = DockStyle.Fill;
            panel_UI.Location = new Point(0, 0);
            panel_UI.Margin = new Padding(3, 2, 3, 2);
            panel_UI.Name = "panel_UI";
            panel_UI.Size = new Size(378, 199);
            panel_UI.TabIndex = 11;
            // 
            // btn_close2
            // 
            btn_close2.BackgroundImage = (Image)resources.GetObject("btn_close2.BackgroundImage");
            btn_close2.BackgroundImageLayout = ImageLayout.Center;
            btn_close2.FlatAppearance.BorderSize = 0;
            btn_close2.FlatStyle = FlatStyle.Flat;
            btn_close2.Location = new Point(332, 0);
            btn_close2.Margin = new Padding(3, 2, 3, 2);
            btn_close2.Name = "btn_close2";
            btn_close2.Size = new Size(43, 39);
            btn_close2.TabIndex = 7;
            btn_close2.UseVisualStyleBackColor = true;
            btn_close2.Click += btn_close2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(46, 22);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label_progress
            // 
            label_progress.ForeColor = Color.White;
            label_progress.Location = new Point(46, 171);
            label_progress.Name = "label_progress";
            label_progress.Size = new Size(258, 19);
            label_progress.TabIndex = 13;
            label_progress.Text = "Prepairing data ....";
            label_progress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SubAssy_Serial_Scanner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(378, 199);
            Controls.Add(panel_UI);
            Controls.Add(pictureBox1);
            Controls.Add(label_progress);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
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
        private Button btn_close2;
    }
}