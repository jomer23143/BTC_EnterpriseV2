namespace BTC_EnterpriseV2.Forms
{
    partial class PrintQRFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintQRFrm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            txt_moid = new TextBox();
            label1 = new Label();
            panel_dgvHolder = new Panel();
            pb_loader = new PictureBox();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel_dgvHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_loader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txt_moid);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1340, 60);
            panel1.TabIndex = 0;
            // 
            // txt_moid
            // 
            txt_moid.BackColor = Color.White;
            txt_moid.BorderStyle = BorderStyle.FixedSingle;
            txt_moid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_moid.Location = new Point(173, 17);
            txt_moid.Name = "txt_moid";
            txt_moid.Size = new Size(386, 34);
            txt_moid.TabIndex = 1;
            txt_moid.TextAlign = HorizontalAlignment.Center;
            txt_moid.KeyDown += txt_moid_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 20);
            label1.Name = "label1";
            label1.Size = new Size(124, 28);
            label1.TabIndex = 0;
            label1.Text = "Scan MOID :";
            // 
            // panel_dgvHolder
            // 
            panel_dgvHolder.Controls.Add(pb_loader);
            panel_dgvHolder.Controls.Add(dataGridView1);
            panel_dgvHolder.Dock = DockStyle.Fill;
            panel_dgvHolder.Location = new Point(0, 60);
            panel_dgvHolder.Name = "panel_dgvHolder";
            panel_dgvHolder.Size = new Size(1340, 599);
            panel_dgvHolder.TabIndex = 1;
            // 
            // pb_loader
            // 
            pb_loader.Anchor = AnchorStyles.Top;
            pb_loader.Image = (Image)resources.GetObject("pb_loader.Image");
            pb_loader.Location = new Point(453, 28);
            pb_loader.Name = "pb_loader";
            pb_loader.Size = new Size(425, 425);
            pb_loader.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_loader.TabIndex = 2;
            pb_loader.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.FromArgb(22, 27, 45);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1340, 599);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // PrintQRFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(1340, 659);
            Controls.Add(panel_dgvHolder);
            Controls.Add(panel1);
            Name = "PrintQRFrm";
            Text = "PrintQRFrm";
            Load += PrintQRFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_dgvHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_loader).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txt_moid;
        private Panel panel_dgvHolder;
        private DataGridView dataGridView1;
        private PictureBox pb_loader;
    }
}