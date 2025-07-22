namespace BTC_EnterpriseV2.Modal
{
    partial class ViewStationGeneratedSerials_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewStationGeneratedSerials_1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btn_close = new Button();
            panel2 = new Panel();
            btn_print_all = new Button();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 45, 55);
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 50);
            panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            btn_close.BackgroundImage = (Image)resources.GetObject("btn_close.BackgroundImage");
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Location = new Point(783, 5);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(38, 38);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(btn_print_all);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 652);
            panel2.Name = "panel2";
            panel2.Size = new Size(840, 68);
            panel2.TabIndex = 1;
            // 
            // btn_print_all
            // 
            btn_print_all.BackColor = Color.FromArgb(22, 27, 45);
            btn_print_all.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            btn_print_all.FlatStyle = FlatStyle.Flat;
            btn_print_all.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_print_all.ForeColor = Color.White;
            btn_print_all.Image = (Image)resources.GetObject("btn_print_all.Image");
            btn_print_all.ImageAlign = ContentAlignment.MiddleLeft;
            btn_print_all.Location = new Point(566, 7);
            btn_print_all.Name = "btn_print_all";
            btn_print_all.RightToLeft = RightToLeft.No;
            btn_print_all.Size = new Size(255, 49);
            btn_print_all.TabIndex = 4;
            btn_print_all.Text = "Print Preview";
            btn_print_all.UseVisualStyleBackColor = false;
            btn_print_all.Click += btn_print_all_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
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
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 50);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(840, 602);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ViewStationGeneratedSerials_1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(840, 720);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ViewStationGeneratedSerials_1";
            Text = "ViewStationGeneratedSerials_1";
            Load += ViewStationGeneratedSerials_1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Button btn_print_all;
        private DataGridView dataGridView1;
        private Button btn_close;
    }
}