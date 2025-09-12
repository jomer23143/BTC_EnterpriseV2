namespace BTC_EnterpriseV2.Forms
{
    partial class Warehouse_Kitting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehouse_Kitting));
            panel1 = new Panel();
            label1 = new Label();
            txtmo_number = new TextBox();
            label2 = new Label();
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            lbl_rowcount = new Label();
            btnincomplete = new Button();
            btncomplete = new Button();
            bunifuloading = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bunifuloading).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(22, 27, 45);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1158, 44);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(100, 180, 45);
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(175, 23);
            label1.TabIndex = 0;
            label1.Text = "Warehouse Kitting";
            // 
            // txtmo_number
            // 
            txtmo_number.BorderStyle = BorderStyle.FixedSingle;
            txtmo_number.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtmo_number.Location = new Point(125, 48);
            txtmo_number.Margin = new Padding(3, 2, 3, 2);
            txtmo_number.Name = "txtmo_number";
            txtmo_number.Size = new Size(244, 29);
            txtmo_number.TabIndex = 5;
            txtmo_number.KeyDown += txtmo_number_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 52);
            label2.Name = "label2";
            label2.Size = new Size(105, 21);
            label2.TabIndex = 4;
            label2.Text = "MO Number :";
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.AllowFiltering = true;
            sfDataGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sfDataGrid1.Location = new Point(10, 85);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.Size = new Size(1134, 492);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CellStyle.Font.Bold = false;
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HeaderStyle.Font.Bold = true;
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 6;
            sfDataGrid1.Text = "sfDataGrid1";
            sfDataGrid1.CellClick += sfDataGrid1_CellClick;
            // 
            // lbl_rowcount
            // 
            lbl_rowcount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_rowcount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_rowcount.ForeColor = SystemColors.GrayText;
            lbl_rowcount.Location = new Point(1004, 588);
            lbl_rowcount.Name = "lbl_rowcount";
            lbl_rowcount.Size = new Size(113, 21);
            lbl_rowcount.TabIndex = 7;
            lbl_rowcount.Text = "0 out of 0";
            lbl_rowcount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnincomplete
            // 
            btnincomplete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnincomplete.BackColor = Color.Teal;
            btnincomplete.Cursor = Cursors.Hand;
            btnincomplete.FlatAppearance.BorderSize = 0;
            btnincomplete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnincomplete.FlatStyle = FlatStyle.Flat;
            btnincomplete.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnincomplete.ForeColor = Color.White;
            btnincomplete.Location = new Point(114, 582);
            btnincomplete.Margin = new Padding(3, 2, 3, 2);
            btnincomplete.Name = "btnincomplete";
            btnincomplete.Size = new Size(96, 35);
            btnincomplete.TabIndex = 8;
            btnincomplete.Text = "Incomplete";
            btnincomplete.UseVisualStyleBackColor = false;
            btnincomplete.Click += btnincomplete_Click;
            // 
            // btncomplete
            // 
            btncomplete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btncomplete.BackColor = Color.Teal;
            btncomplete.Cursor = Cursors.Hand;
            btncomplete.FlatAppearance.BorderSize = 0;
            btncomplete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btncomplete.FlatStyle = FlatStyle.Flat;
            btncomplete.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btncomplete.ForeColor = Color.White;
            btncomplete.Location = new Point(12, 582);
            btncomplete.Margin = new Padding(3, 2, 3, 2);
            btncomplete.Name = "btncomplete";
            btncomplete.Size = new Size(96, 35);
            btncomplete.TabIndex = 9;
            btncomplete.Text = "Complete";
            btncomplete.UseVisualStyleBackColor = false;
            btncomplete.Click += btncomplete_Click;
            // 
            // bunifuloading
            // 
            bunifuloading.Anchor = AnchorStyles.Top;
            bunifuloading.BackColor = Color.White;
            bunifuloading.Image = (Image)resources.GetObject("bunifuloading.Image");
            bunifuloading.Location = new Point(505, 201);
            bunifuloading.Margin = new Padding(3, 2, 3, 2);
            bunifuloading.Name = "bunifuloading";
            bunifuloading.Size = new Size(160, 144);
            bunifuloading.SizeMode = PictureBoxSizeMode.StretchImage;
            bunifuloading.TabIndex = 10;
            bunifuloading.TabStop = false;
            // 
            // Warehouse_Kitting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 626);
            Controls.Add(bunifuloading);
            Controls.Add(btnincomplete);
            Controls.Add(btncomplete);
            Controls.Add(lbl_rowcount);
            Controls.Add(sfDataGrid1);
            Controls.Add(txtmo_number);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Warehouse_Kitting";
            Text = "Warehouse_Kitting";
            Load += Warehouse_Kitting_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bunifuloading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtmo_number;
        private Label label2;
        private Label lbl_rowcount;
        private Button btnincomplete;
        private Button btncomplete;
        private PictureBox bunifuloading;
        public Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
    }
}