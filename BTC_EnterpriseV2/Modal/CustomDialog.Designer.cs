namespace BTC_EnterpriseV2.Modal
{
    partial class CustomDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDialog));
            btn_cancel = new Button();
            btn_proceed = new Button();
            lblMessage = new Label();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btn_cancel
            // 
            btn_cancel.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btn_cancel.FlatStyle = FlatStyle.Flat;
            btn_cancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cancel.ForeColor = Color.FromArgb(255, 128, 0);
            btn_cancel.Image = (Image)resources.GetObject("btn_cancel.Image");
            btn_cancel.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cancel.Location = new Point(423, 244);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(183, 46);
            btn_cancel.TabIndex = 7;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_proceed
            // 
            btn_proceed.FlatAppearance.BorderColor = Color.SpringGreen;
            btn_proceed.FlatStyle = FlatStyle.Flat;
            btn_proceed.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_proceed.ForeColor = Color.SpringGreen;
            btn_proceed.Image = (Image)resources.GetObject("btn_proceed.Image");
            btn_proceed.ImageAlign = ContentAlignment.MiddleLeft;
            btn_proceed.Location = new Point(93, 244);
            btn_proceed.Name = "btn_proceed";
            btn_proceed.Size = new Size(183, 46);
            btn_proceed.TabIndex = 8;
            btn_proceed.Text = "Proceed";
            btn_proceed.UseVisualStyleBackColor = true;
            btn_proceed.Click += btn_proceed_Click;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Calibri", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(93, 58);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(513, 173);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "Process Name:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(33, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(312, 31);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "This process is already done.";
            // 
            // CustomDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(696, 312);
            Controls.Add(btn_cancel);
            Controls.Add(btn_proceed);
            Controls.Add(lblMessage);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomDialog";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "CustomDialog";
            Load += CustomDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_cancel;
        private Button btn_proceed;
        private Label lblMessage;
        private Label lblTitle;
    }
}