namespace BTC_EnterpriseV2.Modal
{
    partial class PreAssy_ProcessScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreAssy_ProcessScanner));
            label1 = new Label();
            txt_serial = new TextBox();
            button1 = new Button();
            lbl_processname = new Label();
            lbl_msg = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(134, 140);
            label1.Name = "label1";
            label1.Size = new Size(201, 28);
            label1.TabIndex = 0;
            label1.Text = "Scan Top Level Serial";
            // 
            // txt_serial
            // 
            txt_serial.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_serial.Location = new Point(79, 103);
            txt_serial.Name = "txt_serial";
            txt_serial.Size = new Size(325, 34);
            txt_serial.TabIndex = 1;
            txt_serial.KeyDown += txt_serial_KeyDown;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(424, 12);
            button1.Name = "button1";
            button1.Size = new Size(32, 28);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lbl_processname
            // 
            lbl_processname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_processname.ForeColor = Color.White;
            lbl_processname.Location = new Point(79, 20);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(325, 80);
            lbl_processname.TabIndex = 3;
            lbl_processname.Text = "label2";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_msg
            // 
            lbl_msg.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_msg.ForeColor = Color.White;
            lbl_msg.Location = new Point(12, 168);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(444, 28);
            lbl_msg.TabIndex = 0;
            lbl_msg.Text = "Scan Top Level Serial";
            lbl_msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PreAssy_ProcessScanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(468, 205);
            Controls.Add(lbl_processname);
            Controls.Add(button1);
            Controls.Add(txt_serial);
            Controls.Add(lbl_msg);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PreAssy_ProcessScanner";
            Text = "PreAssy_ProcessScanner";
            Load += PreAssy_ProcessScanner_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_serial;
        private Button button1;
        private Label lbl_processname;
        private Label lbl_msg;
    }
}