namespace BTC_EnterpriseV2.Modal
{
    partial class ScanSerialNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanSerialNumber));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btn_close = new Button();
            btnsave_serial = new Button();
            panel2 = new Panel();
            lbl_rowcount = new Label();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtserial_number = new TextBox();
            panel1 = new Panel();
            dgSerialnumber = new DataGridView();
            colscan = new DataGridViewCheckBoxColumn();
            colpart_serial = new DataGridViewTextBoxColumn();
            colid = new DataGridViewTextBoxColumn();
            coliscan = new DataGridViewTextBoxColumn();
            colitem_list_item_id = new DataGridViewTextBoxColumn();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSerialnumber).BeginInit();
            SuspendLayout();
            // 
            // btn_close
            // 
            btn_close.BackColor = Color.Transparent;
            btn_close.BackgroundImage = (Image)resources.GetObject("btn_close.BackgroundImage");
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.Cursor = Cursors.Hand;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_close.ForeColor = Color.White;
            btn_close.Location = new Point(514, 7);
            btn_close.Margin = new Padding(3, 2, 3, 2);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(34, 24);
            btn_close.TabIndex = 0;
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
            btnsave_serial.Location = new Point(10, 2);
            btnsave_serial.Margin = new Padding(3, 2, 3, 2);
            btnsave_serial.Name = "btnsave_serial";
            btnsave_serial.Size = new Size(173, 34);
            btnsave_serial.TabIndex = 0;
            btnsave_serial.Text = "Save Serial";
            btnsave_serial.UseVisualStyleBackColor = false;
            btnsave_serial.Click += btnsave_serial_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(22, 27, 45);
            panel2.Controls.Add(btnsave_serial);
            panel2.Controls.Add(lbl_rowcount);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 421);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(559, 46);
            panel2.TabIndex = 5;
            // 
            // lbl_rowcount
            // 
            lbl_rowcount.AutoSize = true;
            lbl_rowcount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_rowcount.ForeColor = Color.White;
            lbl_rowcount.Location = new Point(459, 5);
            lbl_rowcount.Name = "lbl_rowcount";
            lbl_rowcount.Size = new Size(81, 21);
            lbl_rowcount.TabIndex = 6;
            lbl_rowcount.Text = "0 out of 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 26);
            label1.Name = "label1";
            label1.Size = new Size(36, 21);
            label1.TabIndex = 6;
            label1.Text = "IPN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(200, 80);
            label3.Name = "label3";
            label3.Size = new Size(152, 21);
            label3.TabIndex = 6;
            label3.Text = "Scan Serial Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SpringGreen;
            label2.Location = new Point(186, 6);
            label2.Name = "label2";
            label2.Size = new Size(180, 25);
            label2.TabIndex = 0;
            label2.Text = "Scan Serial Number";
            // 
            // txtserial_number
            // 
            txtserial_number.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtserial_number.Location = new Point(139, 52);
            txtserial_number.Margin = new Padding(3, 2, 3, 2);
            txtserial_number.Name = "txtserial_number";
            txtserial_number.Size = new Size(289, 29);
            txtserial_number.TabIndex = 7;
            txtserial_number.TextAlign = HorizontalAlignment.Center;
            txtserial_number.KeyDown += txtserial_number_KeyDown;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(22, 27, 45);
            panel1.Controls.Add(btn_close);
            panel1.Controls.Add(txtserial_number);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(559, 117);
            panel1.TabIndex = 4;
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
            dgSerialnumber.Columns.AddRange(new DataGridViewColumn[] { colscan, colpart_serial, colid, coliscan, colitem_list_item_id });
            dgSerialnumber.EnableHeadersVisualStyles = false;
            dgSerialnumber.Location = new Point(10, 122);
            dgSerialnumber.Margin = new Padding(3, 2, 3, 2);
            dgSerialnumber.Name = "dgSerialnumber";
            dgSerialnumber.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgSerialnumber.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgSerialnumber.Size = new Size(538, 296);
            dgSerialnumber.TabIndex = 7;
            dgSerialnumber.CellClick += dgSerialnumber_CellClick;
            dgSerialnumber.CellContentClick += dgSerialnumber_CellContentClick;
            dgSerialnumber.RowPostPaint += dgSerialnumber_RowPostPaint;
            // 
            // colscan
            // 
            colscan.FillWeight = 53.4759369F;
            colscan.HeaderText = "(Check if scan)";
            colscan.MinimumWidth = 6;
            colscan.Name = "colscan";
            colscan.ReadOnly = true;
            // 
            // colpart_serial
            // 
            colpart_serial.DataPropertyName = "kit_list_part_serial_number";
            colpart_serial.FillWeight = 146.524063F;
            colpart_serial.HeaderText = "Serial Number";
            colpart_serial.MinimumWidth = 6;
            colpart_serial.Name = "colpart_serial";
            colpart_serial.Resizable = DataGridViewTriState.True;
            colpart_serial.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colid
            // 
            colid.DataPropertyName = "id";
            colid.HeaderText = "ID";
            colid.MinimumWidth = 6;
            colid.Name = "colid";
            colid.Resizable = DataGridViewTriState.True;
            colid.SortMode = DataGridViewColumnSortMode.NotSortable;
            colid.Visible = false;
            // 
            // coliscan
            // 
            coliscan.DataPropertyName = "is_scan";
            coliscan.HeaderText = "Column1";
            coliscan.MinimumWidth = 6;
            coliscan.Name = "coliscan";
            coliscan.Resizable = DataGridViewTriState.True;
            coliscan.SortMode = DataGridViewColumnSortMode.NotSortable;
            coliscan.Visible = false;
            // 
            // colitem_list_item_id
            // 
            colitem_list_item_id.DataPropertyName = "kit_list_item_id";
            colitem_list_item_id.HeaderText = "item id";
            colitem_list_item_id.Name = "colitem_list_item_id";
            colitem_list_item_id.ReadOnly = true;
            colitem_list_item_id.Visible = false;
            // 
            // ScanSerialNumber
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 467);
            Controls.Add(dgSerialnumber);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ScanSerialNumber";
            Text = "ScanSerialNumber";
            Load += ScanSerialNumber_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgSerialnumber).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_close;
        private Button btnsave_serial;
        private Panel panel2;
        private Label lbl_rowcount;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox txtserial_number;
        private Panel panel1;
        private DataGridView dgSerialnumber;
        private DataGridViewCheckBoxColumn colscan;
        private DataGridViewTextBoxColumn colpart_serial;
        private DataGridViewTextBoxColumn colid;
        private DataGridViewTextBoxColumn coliscan;
        private DataGridViewTextBoxColumn colitem_list_item_id;
    }
}