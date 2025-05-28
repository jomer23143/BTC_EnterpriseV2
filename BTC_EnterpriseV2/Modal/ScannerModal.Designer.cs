namespace BTC_EnterpriseV2.Modal
{
    partial class ScannerModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerModal));
            pbimage = new PictureBox();
            txt_serialnumber = new TextBox();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pbimage).BeginInit();
            SuspendLayout();
            // 
            // pbimage
            // 
            pbimage.Image = (Image)resources.GetObject("pbimage.Image");
            pbimage.Location = new Point(151, 12);
            pbimage.Name = "pbimage";
            pbimage.Size = new Size(121, 80);
            pbimage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbimage.TabIndex = 0;
            pbimage.TabStop = false;
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(31, 99);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(369, 27);
            txt_serialnumber.TabIndex = 1;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(82, 131);
            label1.Name = "label1";
            label1.Size = new Size(266, 20);
            label1.TabIndex = 2;
            label1.Text = "Please Scan Generated Serial Number";
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Salmon;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(296, 161);
            button1.Name = "button1";
            button1.Size = new Size(104, 31);
            button1.TabIndex = 3;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ScannerModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
            ClientSize = new Size(425, 205);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txt_serialnumber);
            Controls.Add(pbimage);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ScannerModal";
            Text = "ScannerModal";
            ((System.ComponentModel.ISupportInitialize)pbimage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbimage;
        private TextBox txt_serialnumber;
        private Label label1;
        private Button button1;
    }
}