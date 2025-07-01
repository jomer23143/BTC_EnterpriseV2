namespace BTC_EnterpriseV2.Modal
{
    partial class AddSerialNumber
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSerialNumber));
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            btn_close = new Button();
            btnsave_serial = new Button();
            label1 = new Label();
            dgSerialnumber = new DataGridView();
            colpart_serial = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            colscan = new DataGridViewTextBoxColumn();
            bunifuloading = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSerialnumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bunifuloading).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(22, 27, 45);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(639, 56);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SpringGreen;
            label2.Location = new Point(190, 9);
            label2.Name = "label2";
            label2.Size = new Size(268, 38);
            label2.TabIndex = 0;
            label2.Text = "Add Serial Number";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(22, 27, 45);
            panel2.Controls.Add(btn_close);
            panel2.Controls.Add(btnsave_serial);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 562);
            panel2.Name = "panel2";
            panel2.Size = new Size(639, 61);
            panel2.TabIndex = 1;
            // 
            // btn_close
            // 
            btn_close.BackColor = Color.Salmon;
            btn_close.Cursor = Cursors.Hand;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_close.ForeColor = Color.White;
            btn_close.Location = new Point(429, 0);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(198, 46);
            btn_close.TabIndex = 0;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = false;
            btn_close.Click += btn_close_Click;
            // 
            // btnsave_serial
            // 
            btnsave_serial.BackColor = Color.FromArgb(109, 180, 62);
            btnsave_serial.Cursor = Cursors.Hand;
            btnsave_serial.FlatAppearance.BorderSize = 0;
            btnsave_serial.FlatAppearance.MouseOverBackColor = Color.Green;
            btnsave_serial.FlatStyle = FlatStyle.Flat;
            btnsave_serial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnsave_serial.ForeColor = Color.White;
            btnsave_serial.Location = new Point(12, 3);
            btnsave_serial.Name = "btnsave_serial";
            btnsave_serial.Size = new Size(198, 46);
            btnsave_serial.TabIndex = 0;
            btnsave_serial.Text = "Save Serial";
            btnsave_serial.UseVisualStyleBackColor = false;
            btnsave_serial.Click += btnsave_serial_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 59);
            label1.Name = "label1";
            label1.Size = new Size(45, 28);
            label1.TabIndex = 2;
            label1.Text = "IPN";
            // 
            // dgSerialnumber
            // 
            dgSerialnumber.AllowUserToDeleteRows = false;
            dgSerialnumber.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSerialnumber.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgSerialnumber.BackgroundColor = Color.White;
            dgSerialnumber.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.SeaGreen;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgSerialnumber.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgSerialnumber.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSerialnumber.Columns.AddRange(new DataGridViewColumn[] { colpart_serial, Column1, colscan });
            dgSerialnumber.EnableHeadersVisualStyles = false;
            dgSerialnumber.Location = new Point(12, 90);
            dgSerialnumber.Name = "dgSerialnumber";
            dgSerialnumber.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgSerialnumber.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgSerialnumber.Size = new Size(615, 466);
            dgSerialnumber.TabIndex = 3;
            dgSerialnumber.RowPostPaint += dgSerialnumber_RowPostPaint;
            // 
            // colpart_serial
            // 
            colpart_serial.DataPropertyName = "kit_list_part_serial_number";
            colpart_serial.HeaderText = "Serial Number";
            colpart_serial.MinimumWidth = 6;
            colpart_serial.Name = "colpart_serial";
            // 
            // Column1
            // 
            Column1.DataPropertyName = "id";
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Visible = false;
            // 
            // colscan
            // 
            colscan.DataPropertyName = "is_scan";
            colscan.HeaderText = "Scan";
            colscan.MinimumWidth = 6;
            colscan.Name = "colscan";
            colscan.Visible = false;
            // 
            // bunifuloading
            // 
            bunifuloading.BackColor = Color.White;
            bunifuloading.Image = (Image)resources.GetObject("bunifuloading.Image");
            bunifuloading.Location = new Point(262, 254);
            bunifuloading.Name = "bunifuloading";
            bunifuloading.Size = new Size(118, 101);
            bunifuloading.SizeMode = PictureBoxSizeMode.StretchImage;
            bunifuloading.TabIndex = 0;
            bunifuloading.TabStop = false;
            // 
            // AddSerialNumber
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(639, 623);
            Controls.Add(bunifuloading);
            Controls.Add(dgSerialnumber);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddSerialNumber";
            Text = "AddSerialNumber";
            Load += AddSerialNumber_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgSerialnumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)bunifuloading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private DataGridView dgSerialnumber;
        private Button btnsave_serial;
        private DataGridViewTextBoxColumn colpart_serial;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn colscan;
        private PictureBox bunifuloading;
        private Label label2;
        private Button btn_close;
    }
}