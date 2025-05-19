namespace BTC_EnterpriseV2.Modal
{
    partial class GetModalFrm
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
            txt_serial = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txt_serial
            // 
            txt_serial.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_serial.Location = new Point(29, 36);
            txt_serial.Name = "txt_serial";
            txt_serial.Size = new Size(526, 38);
            txt_serial.TabIndex = 0;
            txt_serial.TextAlign = HorizontalAlignment.Center;
            txt_serial.KeyDown += txt_serial_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(181, 79);
            label1.Name = "label1";
            label1.Size = new Size(219, 28);
            label1.TabIndex = 1;
            label1.Text = "Scan MO ID to Proceed.";
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(408, 133);
            button1.Name = "button1";
            button1.Size = new Size(147, 41);
            button1.TabIndex = 2;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GetModalFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(582, 184);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txt_serial);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GetModalFrm";
            Text = "GetModalFrm";
            Load += GetModalFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_serial;
        private Label label1;
        private Button button1;
    }
}