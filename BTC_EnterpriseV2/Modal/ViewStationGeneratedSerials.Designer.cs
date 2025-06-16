namespace BTC_EnterpriseV2.Modal
{
    partial class ViewStationGeneratedSerials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewStationGeneratedSerials));
            dataGridView1 = new DataGridView();
            btn_print = new Button();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            btn_print_all = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.FromArgb(22, 27, 45);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-3, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(735, 453);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btn_print
            // 
            btn_print.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            btn_print.FlatStyle = FlatStyle.Flat;
            btn_print.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_print.ForeColor = Color.White;
            btn_print.ImageAlign = ContentAlignment.MiddleLeft;
            btn_print.Location = new Point(516, 480);
            btn_print.Margin = new Padding(3, 2, 3, 2);
            btn_print.Name = "btn_print";
            btn_print.RightToLeft = RightToLeft.No;
            btn_print.Size = new Size(184, 45);
            btn_print.TabIndex = 1;
            btn_print.Text = "Print View All";
            btn_print.UseVisualStyleBackColor = true;
            btn_print.Click += btn_print_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // btn_print_all
            // 
            btn_print_all.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            btn_print_all.FlatStyle = FlatStyle.Flat;
            btn_print_all.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_print_all.ForeColor = Color.White;
            btn_print_all.Image = (Image)resources.GetObject("btn_print_all.Image");
            btn_print_all.ImageAlign = ContentAlignment.MiddleLeft;
            btn_print_all.Location = new Point(311, 481);
            btn_print_all.Margin = new Padding(3, 2, 3, 2);
            btn_print_all.Name = "btn_print_all";
            btn_print_all.RightToLeft = RightToLeft.No;
            btn_print_all.Size = new Size(178, 45);
            btn_print_all.TabIndex = 2;
            btn_print_all.Text = "Print All";
            btn_print_all.UseVisualStyleBackColor = true;
            btn_print_all.Click += btn_print_all_Click;
            // 
            // ViewStationGeneratedSerials
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(735, 540);
            Controls.Add(btn_print_all);
            Controls.Add(btn_print);
            Controls.Add(dataGridView1);
            Controls.Add(reportViewer1);
            Name = "ViewStationGeneratedSerials";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewStationGeneratedSerials";
            Load += ViewStationGeneratedSerials_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_print;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Button btn_print_all;
    }
}