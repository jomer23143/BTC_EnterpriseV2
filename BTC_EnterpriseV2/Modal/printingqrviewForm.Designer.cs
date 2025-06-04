namespace BTC_EnterpriseV2.Modal
{
    partial class printingqrviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(printingqrviewForm));
            panel1 = new Panel();
            btn_close = new Button();
            lbl_moid = new Label();
            lbl_serial = new Label();
            label3 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            pb_loader = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_loader).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_close);
            panel1.Controls.Add(lbl_moid);
            panel1.Controls.Add(lbl_serial);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 50);
            panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Image = (Image)resources.GetObject("btn_close.Image");
            btn_close.Location = new Point(825, 6);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(47, 38);
            btn_close.TabIndex = 2;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // lbl_moid
            // 
            lbl_moid.AutoSize = true;
            lbl_moid.Font = new Font("Calibri", 12F);
            lbl_moid.ForeColor = Color.White;
            lbl_moid.Location = new Point(455, 16);
            lbl_moid.Name = "lbl_moid";
            lbl_moid.Size = new Size(140, 24);
            lbl_moid.TabIndex = 1;
            lbl_moid.Text = "0000566565225";
            // 
            // lbl_serial
            // 
            lbl_serial.AutoSize = true;
            lbl_serial.Font = new Font("Calibri", 12F);
            lbl_serial.ForeColor = Color.White;
            lbl_serial.Location = new Point(162, 16);
            lbl_serial.Name = "lbl_serial";
            lbl_serial.Size = new Size(140, 24);
            lbl_serial.TabIndex = 1;
            lbl_serial.Text = "TestserialNuber";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(382, 12);
            label3.Name = "label3";
            label3.Size = new Size(76, 28);
            label3.TabIndex = 1;
            label3.Text = "MOID :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(153, 28);
            label1.TabIndex = 1;
            label1.Text = "Serial Number :";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 499);
            panel2.Name = "panel2";
            panel2.Size = new Size(884, 11);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.FromArgb(22, 27, 45);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(884, 449);
            dataGridView1.TabIndex = 2;
            // 
            // pb_loader
            // 
            pb_loader.Image = (Image)resources.GetObject("pb_loader.Image");
            pb_loader.Location = new Point(346, 133);
            pb_loader.Name = "pb_loader";
            pb_loader.Size = new Size(199, 171);
            pb_loader.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_loader.TabIndex = 3;
            pb_loader.TabStop = false;
            // 
            // printingqrviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(884, 510);
            Controls.Add(pb_loader);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "printingqrviewForm";
            Text = "printingqrviewForm";
            Load += printingqrviewForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_loader).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Label lbl_moid;
        private Label lbl_serial;
        private Label label3;
        private Label label1;
        private Button btn_close;
        private PictureBox pb_loader;
    }
}