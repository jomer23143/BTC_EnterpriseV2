namespace BTC_EnterpriseV2.Settings
{
    partial class setupfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setupfrm));
            label1 = new Label();
            txtname = new TextBox();
            label2 = new Label();
            txtcode = new TextBox();
            btn_save = new Button();
            panel1 = new Panel();
            btn_close = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(29, 41);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 1;
            label1.Text = "Section Name:";
            // 
            // txtname
            // 
            txtname.BackColor = Color.FromArgb(37, 45, 55);
            txtname.BorderStyle = BorderStyle.None;
            txtname.Font = new Font("Segoe UI", 12F);
            txtname.ForeColor = Color.White;
            txtname.Location = new Point(179, 42);
            txtname.Name = "txtname";
            txtname.Size = new Size(168, 27);
            txtname.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(370, 41);
            label2.Name = "label2";
            label2.Size = new Size(143, 28);
            label2.TabIndex = 1;
            label2.Text = "Section Code :";
            // 
            // txtcode
            // 
            txtcode.BackColor = Color.FromArgb(37, 45, 55);
            txtcode.BorderStyle = BorderStyle.None;
            txtcode.Font = new Font("Segoe UI", 12F);
            txtcode.ForeColor = Color.White;
            txtcode.Location = new Point(519, 42);
            txtcode.Name = "txtcode";
            txtcode.Size = new Size(93, 27);
            txtcode.TabIndex = 2;
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.FromArgb(17, 40, 86);
            btn_save.FlatAppearance.BorderSize = 0;
            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_save.ForeColor = Color.White;
            btn_save.Location = new Point(430, 8);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(228, 53);
            btn_save.TabIndex = 3;
            btn_save.Text = "save";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(670, 49);
            panel1.TabIndex = 4;
            // 
            // btn_close
            // 
            btn_close.BackgroundImage = (Image)resources.GetObject("btn_close.BackgroundImage");
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Location = new Point(623, 12);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(26, 23);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(txtcode);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtname);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(670, 129);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_save);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 177);
            panel3.Name = "panel3";
            panel3.Size = new Size(670, 72);
            panel3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 5);
            label3.Name = "label3";
            label3.Size = new Size(124, 41);
            label3.TabIndex = 1;
            label3.Text = "Registry";
            // 
            // setupfrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(670, 249);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "setupfrm";
            Text = "setupfrm";
            Load += setupfrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox txtname;
        private Label label2;
        private TextBox txtcode;
        private Button btn_save;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button btn_close;
        private Label label3;
    }
}