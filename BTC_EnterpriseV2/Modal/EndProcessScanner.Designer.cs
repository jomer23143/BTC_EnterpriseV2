﻿namespace BTC_EnterpriseV2.Modal
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
            button1 = new Button();
            label1 = new Label();
            txt_serialnumber = new TextBox();
            pbimage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbimage).BeginInit();
            SuspendLayout();
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
            button1.Location = new Point(293, 195);
            button1.Name = "button1";
            button1.Size = new Size(104, 31);
            button1.TabIndex = 11;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 131);
            label1.Name = "label1";
            label1.Size = new Size(378, 20);
            label1.TabIndex = 10;
            label1.Text = "Scan the Generated Serial Number to end the process.";
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(28, 99);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(369, 27);
            txt_serialnumber.TabIndex = 9;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // pbimage
            // 
            pbimage.Image = (Image)resources.GetObject("pbimage.Image");
            pbimage.Location = new Point(148, 12);
            pbimage.Name = "pbimage";
            pbimage.Size = new Size(121, 80);
            pbimage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbimage.TabIndex = 8;
            pbimage.TabStop = false;
            // 
            // EndProcessScanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 260);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txt_serialnumber);
            Controls.Add(pbimage);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EndProcessScanner";
            Text = "EndProcessScanner";
            ((System.ComponentModel.ISupportInitialize)pbimage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txt_serialnumber;
        private PictureBox pbimage;
    }
}