namespace BTC_EnterpriseV2.ABI
{
    partial class ABI_Frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABI_Frm));
            btn_submit = new Button();
            label2 = new Label();
            cmb_abi = new ComboBox();
            textBox_abi_reason = new TextBox();
            panel_detail = new Panel();
            label_details = new Label();
            label4 = new Label();
            chckbox = new CheckBox();
            panel_detail.SuspendLayout();
            SuspendLayout();
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.DarkSlateBlue;
            btn_submit.Cursor = Cursors.Hand;
            btn_submit.FlatAppearance.BorderSize = 0;
            btn_submit.FlatStyle = FlatStyle.Flat;
            btn_submit.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_submit.ForeColor = Color.White;
            btn_submit.Image = (Image)resources.GetObject("btn_submit.Image");
            btn_submit.ImageAlign = ContentAlignment.MiddleLeft;
            btn_submit.Location = new Point(686, 412);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(323, 67);
            btn_submit.TabIndex = 0;
            btn_submit.Text = "Submit";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(44, 17);
            label2.Name = "label2";
            label2.Size = new Size(217, 28);
            label2.TabIndex = 2;
            label2.Text = "Select Reason for ABI :";
            // 
            // cmb_abi
            // 
            cmb_abi.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_abi.FormattingEnabled = true;
            cmb_abi.Location = new Point(281, 17);
            cmb_abi.Name = "cmb_abi";
            cmb_abi.Size = new Size(742, 33);
            cmb_abi.TabIndex = 3;
            cmb_abi.SelectedIndexChanged += cmb_abi_SelectedIndexChanged;
            // 
            // textBox_abi_reason
            // 
            textBox_abi_reason.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_abi_reason.Location = new Point(281, 108);
            textBox_abi_reason.Multiline = true;
            textBox_abi_reason.Name = "textBox_abi_reason";
            textBox_abi_reason.Size = new Size(747, 81);
            textBox_abi_reason.TabIndex = 4;
            textBox_abi_reason.TextChanged += textBox_abi_reason_TextChanged;
            // 
            // panel_detail
            // 
            panel_detail.Anchor = AnchorStyles.Top;
            panel_detail.BackColor = Color.White;
            panel_detail.Controls.Add(label_details);
            panel_detail.Location = new Point(152, 234);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(857, 157);
            panel_detail.TabIndex = 5;
            // 
            // label_details
            // 
            label_details.Dock = DockStyle.Fill;
            label_details.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label_details.ForeColor = Color.Black;
            label_details.Location = new Point(0, 0);
            label_details.Name = "label_details";
            label_details.Size = new Size(857, 157);
            label_details.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(166, 203);
            label4.Name = "label4";
            label4.Size = new Size(142, 28);
            label4.TabIndex = 2;
            label4.Text = "Details for ABI";
            // 
            // chckbox
            // 
            chckbox.AutoSize = true;
            chckbox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chckbox.ForeColor = Color.White;
            chckbox.Location = new Point(281, 68);
            chckbox.Name = "chckbox";
            chckbox.Size = new Size(153, 32);
            chckbox.TabIndex = 6;
            chckbox.Text = "Other reason";
            chckbox.UseVisualStyleBackColor = true;
            chckbox.CheckedChanged += chckbox_CheckedChanged;
            // 
            // ABI_Frm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(1102, 491);
            Controls.Add(btn_submit);
            Controls.Add(chckbox);
            Controls.Add(panel_detail);
            Controls.Add(textBox_abi_reason);
            Controls.Add(cmb_abi);
            Controls.Add(label4);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ABI_Frm";
            Text = "ABI_Frm";
            Load += ABI_Frm_Load;
            panel_detail.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_submit;
        private Label label2;
        private ComboBox cmb_abi;
        private TextBox textBox_abi_reason;
        private Panel panel_detail;
        private Label label_details;
        private Label label4;
        private CheckBox chckbox;
    }
}