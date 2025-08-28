namespace BTC_EnterpriseV2.Modal
{
    partial class TabFrm
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
            panel_top = new Panel();
            btn_break = new Button();
            btn_abi = new Button();
            panel3 = new Panel();
            btn_cancel = new Button();
            panel_main = new Panel();
            panel_top.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel_top
            // 
            panel_top.BackColor = Color.FromArgb(22, 27, 45);
            panel_top.Controls.Add(btn_break);
            panel_top.Controls.Add(btn_abi);
            panel_top.Dock = DockStyle.Top;
            panel_top.Location = new Point(0, 0);
            panel_top.Name = "panel_top";
            panel_top.Size = new Size(1102, 67);
            panel_top.TabIndex = 0;
            // 
            // btn_break
            // 
            btn_break.BackColor = Color.FromArgb(37, 45, 55);
            btn_break.FlatAppearance.BorderSize = 0;
            btn_break.FlatStyle = FlatStyle.Flat;
            btn_break.ForeColor = Color.White;
            btn_break.Location = new Point(62, 12);
            btn_break.Name = "btn_break";
            btn_break.Size = new Size(485, 48);
            btn_break.TabIndex = 0;
            btn_break.Text = "Break";
            btn_break.UseVisualStyleBackColor = false;
            btn_break.Click += btn_break_Click;
            // 
            // btn_abi
            // 
            btn_abi.BackColor = Color.FromArgb(37, 45, 55);
            btn_abi.FlatAppearance.BorderSize = 0;
            btn_abi.FlatStyle = FlatStyle.Flat;
            btn_abi.ForeColor = Color.White;
            btn_abi.Location = new Point(553, 12);
            btn_abi.Name = "btn_abi";
            btn_abi.Size = new Size(485, 48);
            btn_abi.TabIndex = 0;
            btn_abi.Text = "ABI";
            btn_abi.UseVisualStyleBackColor = false;
            btn_abi.Click += btn_abi_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(22, 27, 45);
            panel3.Controls.Add(btn_cancel);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 566);
            panel3.Name = "panel3";
            panel3.Size = new Size(1102, 71);
            panel3.TabIndex = 1;
            // 
            // btn_cancel
            // 
            btn_cancel.FlatAppearance.BorderSize = 0;
            btn_cancel.FlatStyle = FlatStyle.Flat;
            btn_cancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(821, 6);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(217, 54);
            btn_cancel.TabIndex = 0;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // panel_main
            // 
            panel_main.Dock = DockStyle.Fill;
            panel_main.Location = new Point(0, 67);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(1102, 499);
            panel_main.TabIndex = 2;
            // 
            // TabFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(1102, 637);
            Controls.Add(panel_main);
            Controls.Add(panel3);
            Controls.Add(panel_top);
            Name = "TabFrm";
            Text = "TabFrm";
            Load += TabFrm_Load;
            panel_top.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_top;
        private Button btn_break;
        private Button btn_abi;
        private Panel panel3;
        private Panel panel_main;
        public Button btn_cancel;
    }
}