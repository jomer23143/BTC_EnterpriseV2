namespace BTC_EnterpriseV2.Modal
{
    partial class ProcessDoneModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessDoneModal));
            label1 = new Label();
            button1 = new Button();
            btn_proceed_preassy = new Button();
            label2 = new Label();
            label3 = new Label();
            lbl_processname = new Label();
            btn_close = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(193, 57);
            label1.Name = "label1";
            label1.Size = new Size(312, 31);
            label1.TabIndex = 0;
            label1.Text = "This process is already done.";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(98, 222);
            button1.Name = "button1";
            button1.Size = new Size(231, 64);
            button1.TabIndex = 1;
            button1.Text = "View Process Items";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btn_proceed_preassy
            // 
            btn_proceed_preassy.FlatAppearance.BorderSize = 0;
            btn_proceed_preassy.FlatStyle = FlatStyle.Flat;
            btn_proceed_preassy.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_proceed_preassy.ForeColor = Color.White;
            btn_proceed_preassy.Location = new Point(380, 222);
            btn_proceed_preassy.Name = "btn_proceed_preassy";
            btn_proceed_preassy.Size = new Size(231, 64);
            btn_proceed_preassy.TabIndex = 1;
            btn_proceed_preassy.Text = "Proceed Pre-Assembly";
            btn_proceed_preassy.UseVisualStyleBackColor = true;
            btn_proceed_preassy.Click += btn_proceed_preassy_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(339, 238);
            label2.Name = "label2";
            label2.Size = new Size(31, 28);
            label2.TabIndex = 0;
            label2.Text = "or";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(38, 111);
            label3.Name = "label3";
            label3.Size = new Size(167, 31);
            label3.TabIndex = 0;
            label3.Text = "Process Name:";
            // 
            // lbl_processname
            // 
            lbl_processname.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_processname.ForeColor = Color.Lime;
            lbl_processname.Location = new Point(203, 111);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(393, 95);
            lbl_processname.TabIndex = 0;
            lbl_processname.Text = "Process Name:";
            // 
            // btn_close
            // 
            btn_close.BackgroundImage = (Image)resources.GetObject("btn_close.BackgroundImage");
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Location = new Point(638, 12);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(43, 32);
            btn_close.TabIndex = 2;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += button3_Click;
            // 
            // ProcessDoneModal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(708, 323);
            Controls.Add(btn_close);
            Controls.Add(btn_proceed_preassy);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(lbl_processname);
            Controls.Add(label3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProcessDoneModal";
            Text = "ProcessDoneModal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button btn_proceed_preassy;
        private Label label2;
        private Label label3;
        private Label lbl_processname;
        private Button btn_close;
    }
}