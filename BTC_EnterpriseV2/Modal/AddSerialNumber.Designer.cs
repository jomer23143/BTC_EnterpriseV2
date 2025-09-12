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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSerialNumber));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btn_close = new Button();
            label2 = new Label();
            panel2 = new Panel();
            lbl_rowcount = new Label();
            btnsave_serial = new Button();
            label1 = new Label();
            dgSerialnumber = new DataGridView();
            colpart_serial = new DataGridViewTextBoxColumn();
            colkitlist_item_id = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            colscan = new DataGridViewTextBoxColumn();
            colstatus_id = new DataGridViewTextBoxColumn();
            bunifuloading = new PictureBox();
            txtserial_number = new TextBox();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSerialnumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bunifuloading).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(22, 27, 45);
            panel1.Controls.Add(btn_close);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(559, 42);
            panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            btn_close.BackColor = Color.Transparent;
            btn_close.BackgroundImage = (Image)resources.GetObject("btn_close.BackgroundImage");
            btn_close.BackgroundImageLayout = ImageLayout.Zoom;
            btn_close.Cursor = Cursors.Hand;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_close.ForeColor = Color.White;
            btn_close.Location = new Point(521, 2);
            btn_close.Margin = new Padding(3, 2, 3, 2);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(35, 34);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = false;
            btn_close.Click += btn_close_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SpringGreen;
            label2.Location = new Point(166, 7);
            label2.Name = "label2";
            label2.Size = new Size(210, 30);
            label2.TabIndex = 0;
            label2.Text = "Add Serial Number";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(22, 27, 45);
            panel2.Controls.Add(lbl_rowcount);
            panel2.Controls.Add(btnsave_serial);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 469);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(559, 46);
            panel2.TabIndex = 1;
            // 
            // lbl_rowcount
            // 
            lbl_rowcount.AutoSize = true;
            lbl_rowcount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_rowcount.ForeColor = Color.White;
            lbl_rowcount.Location = new Point(448, 9);
            lbl_rowcount.Name = "lbl_rowcount";
            lbl_rowcount.Size = new Size(81, 21);
            lbl_rowcount.TabIndex = 7;
            lbl_rowcount.Text = "0 out of 0";
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
            btnsave_serial.Location = new Point(10, 2);
            btnsave_serial.Margin = new Padding(3, 2, 3, 2);
            btnsave_serial.Name = "btnsave_serial";
            btnsave_serial.Size = new Size(173, 34);
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
            label1.Location = new Point(10, 44);
            label1.Name = "label1";
            label1.Size = new Size(36, 21);
            label1.TabIndex = 2;
            label1.Text = "IPN";
            // 
            // dgSerialnumber
            // 
            dgSerialnumber.AllowUserToAddRows = false;
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
            dgSerialnumber.Columns.AddRange(new DataGridViewColumn[] { colpart_serial, colkitlist_item_id, Column1, colscan, colstatus_id });
            dgSerialnumber.EnableHeadersVisualStyles = false;
            dgSerialnumber.Location = new Point(10, 126);
            dgSerialnumber.Margin = new Padding(3, 2, 3, 2);
            dgSerialnumber.Name = "dgSerialnumber";
            dgSerialnumber.ReadOnly = true;
            dgSerialnumber.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgSerialnumber.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgSerialnumber.Size = new Size(538, 339);
            dgSerialnumber.TabIndex = 3;
            dgSerialnumber.RowPostPaint += dgSerialnumber_RowPostPaint;
            // 
            // colpart_serial
            // 
            colpart_serial.DataPropertyName = "kit_list_part_serial_number";
            colpart_serial.HeaderText = "Serial Number";
            colpart_serial.MinimumWidth = 6;
            colpart_serial.Name = "colpart_serial";
            colpart_serial.ReadOnly = true;
            // 
            // colkitlist_item_id
            // 
            colkitlist_item_id.DataPropertyName = "kit_list_item_id";
            colkitlist_item_id.HeaderText = "item_id";
            colkitlist_item_id.Name = "colkitlist_item_id";
            colkitlist_item_id.ReadOnly = true;
            colkitlist_item_id.Visible = false;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "id";
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            // 
            // colscan
            // 
            colscan.DataPropertyName = "is_scan";
            colscan.HeaderText = "Scan";
            colscan.MinimumWidth = 6;
            colscan.Name = "colscan";
            colscan.ReadOnly = true;
            colscan.Visible = false;
            // 
            // colstatus_id
            // 
            colstatus_id.DataPropertyName = "kit_list_item_serial_number_status_id";
            colstatus_id.HeaderText = "status_id";
            colstatus_id.Name = "colstatus_id";
            colstatus_id.ReadOnly = true;
            colstatus_id.Visible = false;
            // 
            // bunifuloading
            // 
            bunifuloading.BackColor = Color.White;
            bunifuloading.Image = (Image)resources.GetObject("bunifuloading.Image");
            bunifuloading.Location = new Point(239, 244);
            bunifuloading.Margin = new Padding(3, 2, 3, 2);
            bunifuloading.Name = "bunifuloading";
            bunifuloading.Size = new Size(103, 99);
            bunifuloading.SizeMode = PictureBoxSizeMode.StretchImage;
            bunifuloading.TabIndex = 0;
            bunifuloading.TabStop = false;
            // 
            // txtserial_number
            // 
            txtserial_number.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtserial_number.Location = new Point(139, 71);
            txtserial_number.Margin = new Padding(3, 2, 3, 2);
            txtserial_number.Name = "txtserial_number";
            txtserial_number.Size = new Size(289, 29);
            txtserial_number.TabIndex = 9;
            txtserial_number.TextAlign = HorizontalAlignment.Center;
            txtserial_number.KeyDown += txtserial_number_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(200, 99);
            label3.Name = "label3";
            label3.Size = new Size(152, 21);
            label3.TabIndex = 8;
            label3.Text = "Scan Serial Number";
            // 
            // AddSerialNumber
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(559, 515);
            Controls.Add(txtserial_number);
            Controls.Add(label3);
            Controls.Add(bunifuloading);
            Controls.Add(dgSerialnumber);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddSerialNumber";
            Text = "AddSerialNumber";
            Load += AddSerialNumber_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private PictureBox bunifuloading;
        private Label label2;
        private Button btn_close;
        private Label lbl_rowcount;
        private TextBox txtserial_number;
        private Label label3;
        private DataGridViewTextBoxColumn colpart_serial;
        private DataGridViewTextBoxColumn colkitlist_item_id;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn colscan;
        private DataGridViewTextBoxColumn colstatus_id;
    }
}