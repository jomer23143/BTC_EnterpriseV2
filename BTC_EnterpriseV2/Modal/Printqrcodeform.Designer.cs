namespace BTC_EnterpriseV2.Modal
{
    partial class Printqrcodeform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Printqrcodeform));
            panel1 = new Panel();
            lbl_moid = new Label();
            label1 = new Label();
            btn_close = new Button();
            panel2 = new Panel();
            label_printcount = new Label();
            btn_print = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pb_loader = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_loader).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 45, 55);
            panel1.Controls.Add(lbl_moid);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 42);
            panel1.TabIndex = 0;
            // 
            // lbl_moid
            // 
            lbl_moid.AutoSize = true;
            lbl_moid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_moid.ForeColor = Color.White;
            lbl_moid.Location = new Point(12, 7);
            lbl_moid.Name = "lbl_moid";
            lbl_moid.Size = new Size(177, 28);
            lbl_moid.TabIndex = 1;
            lbl_moid.Text = "MOID : CE0340343";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(308, 7);
            label1.Name = "label1";
            label1.Size = new Size(248, 28);
            label1.TabIndex = 1;
            label1.Text = "Generated Serial QR Code";
            // 
            // btn_close
            // 
            btn_close.BackgroundImage = (Image)resources.GetObject("btn_close.BackgroundImage");
            btn_close.BackgroundImageLayout = ImageLayout.Center;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Location = new Point(817, 3);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(43, 36);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(label_printcount);
            panel2.Controls.Add(btn_print);
            panel2.Dock = DockStyle.Bottom;
            panel2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            panel2.Location = new Point(0, 513);
            panel2.Name = "panel2";
            panel2.Size = new Size(884, 66);
            panel2.TabIndex = 1;
            // 
            // label_printcount
            // 
            label_printcount.AutoSize = true;
            label_printcount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_printcount.ForeColor = Color.Gainsboro;
            label_printcount.Location = new Point(368, 18);
            label_printcount.Name = "label_printcount";
            label_printcount.Size = new Size(125, 28);
            label_printcount.TabIndex = 1;
            label_printcount.Text = "Printed : 0/0";
            // 
            // btn_print
            // 
            btn_print.BackColor = Color.FromArgb(22, 27, 45);
            btn_print.FlatAppearance.BorderColor = Color.Lime;
            btn_print.FlatStyle = FlatStyle.Flat;
            btn_print.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_print.ForeColor = Color.White;
            btn_print.Image = (Image)resources.GetObject("btn_print.Image");
            btn_print.ImageAlign = ContentAlignment.MiddleLeft;
            btn_print.Location = new Point(656, 11);
            btn_print.Name = "btn_print";
            btn_print.Size = new Size(204, 43);
            btn_print.TabIndex = 0;
            btn_print.Text = "Print";
            btn_print.UseVisualStyleBackColor = false;
            btn_print.Click += btn_print_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(pb_loader);
            flowLayoutPanel1.Location = new Point(12, 48);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(860, 459);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // pb_loader
            // 
            pb_loader.Image = (Image)resources.GetObject("pb_loader.Image");
            pb_loader.Location = new Point(3, 3);
            pb_loader.Name = "pb_loader";
            pb_loader.Size = new Size(845, 439);
            pb_loader.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_loader.TabIndex = 2;
            pb_loader.TabStop = false;
            // 
            // Printqrcodeform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(884, 579);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Printqrcodeform";
            Text = "Printqrcodeform";
            Load += Printqrcodeform_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_loader).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btn_print;
        private Button btn_close;
        private Label label1;
        private Label lbl_moid;
        private PictureBox pb_loader;
        private Label label_printcount;
    }
}