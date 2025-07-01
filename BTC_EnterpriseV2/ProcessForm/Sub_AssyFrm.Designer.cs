namespace BTC_EnterpriseV2.ProcessForm
{
    partial class Sub_AssyFrm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sub_AssyFrm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel_info2 = new Panel();
            btn_scan = new Button();
            PB_qrcode = new PictureBox();
            lbl_qrinfo = new Label();
            lbl_generatedserial = new Label();
            label7 = new Label();
            panel_info1 = new Panel();
            panel_segment = new Panel();
            lbl_segment = new Label();
            panel_moid = new Panel();
            lbl_toplvlipn = new Label();
            panel_processname = new Panel();
            lbl_station = new Label();
            panel_statusprocess = new Panel();
            lbl_processStatus = new Label();
            label9 = new Label();
            label3 = new Label();
            label5 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel_operator = new Panel();
            lbl_operator = new Label();
            label13 = new Label();
            panel_duration = new Panel();
            lbl_duration = new Label();
            label10 = new Label();
            panel_end = new Panel();
            lbl_timeEnd = new Label();
            label8 = new Label();
            panel_dateend = new Panel();
            lbl_date_end = new Label();
            label11 = new Label();
            panel_date = new Panel();
            lbl_date = new Label();
            label6 = new Label();
            panel_start = new Panel();
            lbl_timestart = new Label();
            label2 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewImageColumn();
            timer1 = new System.Windows.Forms.Timer(components);
            pb_loader = new PictureBox();
            panel1.SuspendLayout();
            panel_info2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_qrcode).BeginInit();
            panel_info1.SuspendLayout();
            panel_segment.SuspendLayout();
            panel_moid.SuspendLayout();
            panel_processname.SuspendLayout();
            panel_statusprocess.SuspendLayout();
            panel2.SuspendLayout();
            panel_operator.SuspendLayout();
            panel_duration.SuspendLayout();
            panel_end.SuspendLayout();
            panel_dateend.SuspendLayout();
            panel_date.SuspendLayout();
            panel_start.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_loader).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 45, 55);
            panel1.Controls.Add(panel_info2);
            panel1.Controls.Add(panel_info1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1623, 114);
            panel1.TabIndex = 0;
            // 
            // panel_info2
            // 
            panel_info2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel_info2.BackColor = Color.FromArgb(22, 27, 45);
            panel_info2.Controls.Add(btn_scan);
            panel_info2.Controls.Add(PB_qrcode);
            panel_info2.Controls.Add(lbl_qrinfo);
            panel_info2.Controls.Add(lbl_generatedserial);
            panel_info2.Controls.Add(label7);
            panel_info2.Location = new Point(1252, 0);
            panel_info2.Name = "panel_info2";
            panel_info2.Size = new Size(363, 108);
            panel_info2.TabIndex = 0;
            // 
            // btn_scan
            // 
            btn_scan.BackColor = Color.FromArgb(17, 40, 86);
            btn_scan.Cursor = Cursors.Hand;
            btn_scan.FlatAppearance.BorderSize = 0;
            btn_scan.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            btn_scan.FlatStyle = FlatStyle.Flat;
            btn_scan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_scan.ForeColor = Color.White;
            btn_scan.Location = new Point(11, 25);
            btn_scan.Name = "btn_scan";
            btn_scan.Size = new Size(317, 71);
            btn_scan.TabIndex = 2;
            btn_scan.Text = "Tap to End the Process";
            btn_scan.UseVisualStyleBackColor = false;
            btn_scan.Click += btn_scan_Click;
            // 
            // PB_qrcode
            // 
            PB_qrcode.Image = (Image)resources.GetObject("PB_qrcode.Image");
            PB_qrcode.Location = new Point(19, 26);
            PB_qrcode.Name = "PB_qrcode";
            PB_qrcode.Size = new Size(60, 50);
            PB_qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_qrcode.TabIndex = 1;
            PB_qrcode.TabStop = false;
            // 
            // lbl_qrinfo
            // 
            lbl_qrinfo.Font = new Font("Segoe UI", 7.8F);
            lbl_qrinfo.ForeColor = Color.White;
            lbl_qrinfo.Location = new Point(89, 29);
            lbl_qrinfo.Name = "lbl_qrinfo";
            lbl_qrinfo.Size = new Size(224, 37);
            lbl_qrinfo.TabIndex = 0;
            lbl_qrinfo.Text = "Please scan the qr \r\ncode to end to process.\r\n";
            // 
            // lbl_generatedserial
            // 
            lbl_generatedserial.Font = new Font("Segoe UI", 7.8F);
            lbl_generatedserial.ForeColor = Color.White;
            lbl_generatedserial.Location = new Point(132, 6);
            lbl_generatedserial.Name = "lbl_generatedserial";
            lbl_generatedserial.Size = new Size(224, 16);
            lbl_generatedserial.TabIndex = 0;
            lbl_generatedserial.Text = "Top Level IPN :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7.8F);
            label7.ForeColor = Color.Lime;
            label7.Location = new Point(11, 6);
            label7.Name = "label7";
            label7.Size = new Size(112, 17);
            label7.TabIndex = 0;
            label7.Text = "Generated Serial :";
            // 
            // panel_info1
            // 
            panel_info1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_info1.BackColor = Color.FromArgb(22, 27, 45);
            panel_info1.Controls.Add(panel_segment);
            panel_info1.Controls.Add(panel_moid);
            panel_info1.Controls.Add(panel_processname);
            panel_info1.Controls.Add(panel_statusprocess);
            panel_info1.Controls.Add(label3);
            panel_info1.Controls.Add(label5);
            panel_info1.Controls.Add(label1);
            panel_info1.Location = new Point(10, 3);
            panel_info1.Name = "panel_info1";
            panel_info1.Size = new Size(1236, 105);
            panel_info1.TabIndex = 0;
            // 
            // panel_segment
            // 
            panel_segment.BackColor = Color.FromArgb(37, 45, 55);
            panel_segment.Controls.Add(lbl_segment);
            panel_segment.Location = new Point(196, 47);
            panel_segment.Name = "panel_segment";
            panel_segment.Size = new Size(250, 33);
            panel_segment.TabIndex = 2;
            // 
            // lbl_segment
            // 
            lbl_segment.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_segment.ForeColor = Color.FromArgb(7, 222, 151);
            lbl_segment.Location = new Point(12, 3);
            lbl_segment.Name = "lbl_segment";
            lbl_segment.Size = new Size(222, 23);
            lbl_segment.TabIndex = 0;
            lbl_segment.Text = "Sub Assembly";
            // 
            // panel_moid
            // 
            panel_moid.BackColor = Color.FromArgb(37, 45, 55);
            panel_moid.Controls.Add(lbl_toplvlipn);
            panel_moid.Location = new Point(196, 11);
            panel_moid.Name = "panel_moid";
            panel_moid.Size = new Size(250, 33);
            panel_moid.TabIndex = 2;
            // 
            // lbl_toplvlipn
            // 
            lbl_toplvlipn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_toplvlipn.ForeColor = Color.FromArgb(7, 222, 151);
            lbl_toplvlipn.Location = new Point(12, 5);
            lbl_toplvlipn.Name = "lbl_toplvlipn";
            lbl_toplvlipn.Size = new Size(222, 23);
            lbl_toplvlipn.TabIndex = 0;
            lbl_toplvlipn.Text = "Top Level IPN :";
            // 
            // panel_processname
            // 
            panel_processname.BackColor = Color.FromArgb(37, 45, 55);
            panel_processname.Controls.Add(lbl_station);
            panel_processname.Location = new Point(594, 11);
            panel_processname.Name = "panel_processname";
            panel_processname.Size = new Size(290, 62);
            panel_processname.TabIndex = 1;
            // 
            // lbl_station
            // 
            lbl_station.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_station.ForeColor = Color.FromArgb(7, 222, 151);
            lbl_station.Location = new Point(8, 0);
            lbl_station.Name = "lbl_station";
            lbl_station.Size = new Size(273, 62);
            lbl_station.TabIndex = 0;
            lbl_station.Text = "Test Process LCD Attachment This to the last";
            lbl_station.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_statusprocess
            // 
            panel_statusprocess.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel_statusprocess.BackColor = Color.FromArgb(12, 54, 18);
            panel_statusprocess.Controls.Add(lbl_processStatus);
            panel_statusprocess.Controls.Add(label9);
            panel_statusprocess.Location = new Point(995, 11);
            panel_statusprocess.Name = "panel_statusprocess";
            panel_statusprocess.Size = new Size(218, 62);
            panel_statusprocess.TabIndex = 0;
            // 
            // lbl_processStatus
            // 
            lbl_processStatus.AutoSize = true;
            lbl_processStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_processStatus.ForeColor = Color.FromArgb(7, 222, 151);
            lbl_processStatus.Location = new Point(93, 15);
            lbl_processStatus.Name = "lbl_processStatus";
            lbl_processStatus.Size = new Size(113, 28);
            lbl_processStatus.TabIndex = 0;
            lbl_processStatus.Text = "Processing";
            lbl_processStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(13, 15);
            label9.Name = "label9";
            label9.Size = new Size(74, 28);
            label9.TabIndex = 0;
            label9.Text = "Status :";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(16, 50);
            label3.Name = "label3";
            label3.Size = new Size(176, 23);
            label3.TabIndex = 0;
            label3.Text = "Production Segment :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(466, 16);
            label5.Name = "label5";
            label5.Size = new Size(122, 23);
            label5.TabIndex = 0;
            label5.Text = "Process Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 0;
            label1.Text = "Product MO ID :";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(panel_operator);
            panel2.Controls.Add(panel_duration);
            panel2.Controls.Add(panel_end);
            panel2.Controls.Add(panel_dateend);
            panel2.Controls.Add(panel_date);
            panel2.Controls.Add(panel_start);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 666);
            panel2.Name = "panel2";
            panel2.Size = new Size(1623, 101);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel_operator
            // 
            panel_operator.Anchor = AnchorStyles.Bottom;
            panel_operator.BackColor = Color.FromArgb(22, 27, 45);
            panel_operator.Controls.Add(lbl_operator);
            panel_operator.Controls.Add(label13);
            panel_operator.Location = new Point(1130, 51);
            panel_operator.Name = "panel_operator";
            panel_operator.Size = new Size(412, 43);
            panel_operator.TabIndex = 0;
            // 
            // lbl_operator
            // 
            lbl_operator.AutoSize = true;
            lbl_operator.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_operator.ForeColor = Color.FromArgb(255, 128, 0);
            lbl_operator.Location = new Point(122, 8);
            lbl_operator.Name = "lbl_operator";
            lbl_operator.Size = new Size(148, 25);
            lbl_operator.TabIndex = 0;
            lbl_operator.Text = "Sample Operator";
            lbl_operator.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(13, 7);
            label13.Name = "label13";
            label13.Size = new Size(101, 28);
            label13.TabIndex = 0;
            label13.Text = "Operator :";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_duration
            // 
            panel_duration.Anchor = AnchorStyles.Bottom;
            panel_duration.BackColor = Color.FromArgb(22, 27, 45);
            panel_duration.Controls.Add(lbl_duration);
            panel_duration.Controls.Add(label10);
            panel_duration.Location = new Point(1129, 6);
            panel_duration.Name = "panel_duration";
            panel_duration.Size = new Size(412, 43);
            panel_duration.TabIndex = 0;
            // 
            // lbl_duration
            // 
            lbl_duration.AutoSize = true;
            lbl_duration.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_duration.ForeColor = Color.Yellow;
            lbl_duration.Location = new Point(109, 11);
            lbl_duration.Name = "lbl_duration";
            lbl_duration.Size = new Size(80, 25);
            lbl_duration.TabIndex = 0;
            lbl_duration.Text = "00:00:00";
            lbl_duration.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(13, 7);
            label10.Name = "label10";
            label10.Size = new Size(98, 28);
            label10.TabIndex = 0;
            label10.Text = "Duration :";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_end
            // 
            panel_end.Anchor = AnchorStyles.Bottom;
            panel_end.BackColor = Color.FromArgb(22, 27, 45);
            panel_end.Controls.Add(lbl_timeEnd);
            panel_end.Controls.Add(label8);
            panel_end.Location = new Point(636, 6);
            panel_end.Name = "panel_end";
            panel_end.Size = new Size(238, 43);
            panel_end.TabIndex = 0;
            // 
            // lbl_timeEnd
            // 
            lbl_timeEnd.AutoSize = true;
            lbl_timeEnd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_timeEnd.ForeColor = Color.Red;
            lbl_timeEnd.Location = new Point(128, 8);
            lbl_timeEnd.Name = "lbl_timeEnd";
            lbl_timeEnd.Size = new Size(86, 28);
            lbl_timeEnd.TabIndex = 0;
            lbl_timeEnd.Text = "00:00:00";
            lbl_timeEnd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(13, 7);
            label8.Name = "label8";
            label8.Size = new Size(101, 28);
            label8.TabIndex = 0;
            label8.Text = "Time End :";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_dateend
            // 
            panel_dateend.Anchor = AnchorStyles.Bottom;
            panel_dateend.BackColor = Color.FromArgb(22, 27, 45);
            panel_dateend.Controls.Add(lbl_date_end);
            panel_dateend.Controls.Add(label11);
            panel_dateend.Location = new Point(636, 51);
            panel_dateend.Name = "panel_dateend";
            panel_dateend.Size = new Size(403, 43);
            panel_dateend.TabIndex = 0;
            // 
            // lbl_date_end
            // 
            lbl_date_end.AutoSize = true;
            lbl_date_end.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_date_end.ForeColor = Color.Red;
            lbl_date_end.Location = new Point(140, 8);
            lbl_date_end.Name = "lbl_date_end";
            lbl_date_end.Size = new Size(233, 28);
            lbl_date_end.TabIndex = 0;
            lbl_date_end.Text = "wendesday,May-28-2025";
            lbl_date_end.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(11, 7);
            label11.Name = "label11";
            label11.Size = new Size(100, 28);
            label11.TabIndex = 0;
            label11.Text = "Date End :";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_date
            // 
            panel_date.Anchor = AnchorStyles.Bottom;
            panel_date.BackColor = Color.FromArgb(22, 27, 45);
            panel_date.Controls.Add(lbl_date);
            panel_date.Controls.Add(label6);
            panel_date.Location = new Point(126, 51);
            panel_date.Name = "panel_date";
            panel_date.Size = new Size(403, 43);
            panel_date.TabIndex = 0;
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_date.ForeColor = Color.LimeGreen;
            lbl_date.Location = new Point(140, 8);
            lbl_date.Name = "lbl_date";
            lbl_date.Size = new Size(233, 28);
            lbl_date.TabIndex = 0;
            lbl_date.Text = "wendesday,May-28-2025";
            lbl_date.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 7);
            label6.Name = "label6";
            label6.Size = new Size(130, 28);
            label6.TabIndex = 0;
            label6.Text = "Date Started :";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_start
            // 
            panel_start.Anchor = AnchorStyles.Bottom;
            panel_start.BackColor = Color.FromArgb(22, 27, 45);
            panel_start.Controls.Add(lbl_timestart);
            panel_start.Controls.Add(label2);
            panel_start.Location = new Point(126, 6);
            panel_start.Name = "panel_start";
            panel_start.Size = new Size(238, 43);
            panel_start.TabIndex = 0;
            // 
            // lbl_timestart
            // 
            lbl_timestart.AutoSize = true;
            lbl_timestart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_timestart.ForeColor = Color.LimeGreen;
            lbl_timestart.Location = new Point(128, 8);
            lbl_timestart.Name = "lbl_timestart";
            lbl_timestart.Size = new Size(86, 28);
            lbl_timestart.TabIndex = 0;
            lbl_timestart.Text = "00:00:00";
            lbl_timestart.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(13, 7);
            label2.Name = "label2";
            label2.Size = new Size(109, 28);
            label2.TabIndex = 0;
            label2.Text = "Time Start :";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 552);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1615, 114);
            panel4.Name = "panel4";
            panel4.Size = new Size(8, 552);
            panel4.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.SeaGreen;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = Color.SeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(10, 114);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(22, 27, 45);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1605, 552);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "No.";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Process";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Serialized Material";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Serial Qty";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Column5.HeaderText = "Scan Item Serial";
            Column5.Image = (Image)resources.GetObject("Column5.Image");
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Resizable = DataGridViewTriState.True;
            Column5.SortMode = DataGridViewColumnSortMode.Automatic;
            Column5.Width = 178;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pb_loader
            // 
            pb_loader.Anchor = AnchorStyles.Top;
            pb_loader.Image = (Image)resources.GetObject("pb_loader.Image");
            pb_loader.Location = new Point(636, 222);
            pb_loader.Name = "pb_loader";
            pb_loader.Size = new Size(361, 263);
            pb_loader.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_loader.TabIndex = 3;
            pb_loader.TabStop = false;
            // 
            // Sub_AssyFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1623, 767);
            Controls.Add(pb_loader);
            Controls.Add(dataGridView1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Sub_AssyFrm";
            Text = "Sub_AssyFrm";
            Load += Sub_AssyFrm_Load;
            SizeChanged += Sub_AssyFrm_SizeChanged;
            panel1.ResumeLayout(false);
            panel_info2.ResumeLayout(false);
            panel_info2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_qrcode).EndInit();
            panel_info1.ResumeLayout(false);
            panel_info1.PerformLayout();
            panel_segment.ResumeLayout(false);
            panel_moid.ResumeLayout(false);
            panel_processname.ResumeLayout(false);
            panel_statusprocess.ResumeLayout(false);
            panel_statusprocess.PerformLayout();
            panel2.ResumeLayout(false);
            panel_operator.ResumeLayout(false);
            panel_operator.PerformLayout();
            panel_duration.ResumeLayout(false);
            panel_duration.PerformLayout();
            panel_end.ResumeLayout(false);
            panel_end.PerformLayout();
            panel_dateend.ResumeLayout(false);
            panel_dateend.PerformLayout();
            panel_date.ResumeLayout(false);
            panel_date.PerformLayout();
            panel_start.ResumeLayout(false);
            panel_start.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_loader).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private DataGridView dataGridView1;
        private Panel panel_info2;
        private Panel panel_info1;
        private Label lbl_generatedserial;
        private Label label7;
        private Label lbl_segment;
        private Label lbl_station;
        private Label label3;
        private Label label5;
        private Label lbl_toplvlipn;
        private Label label1;
        private Button btn_scan;
        private PictureBox PB_qrcode;
        private Label lbl_qrinfo;
        private Panel panel_duration;
        private Label lbl_duration;
        private Label label10;
        private Panel panel_end;
        private Label lbl_timeEnd;
        private Label label8;
        private Panel panel_start;
        private Label lbl_timestart;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Panel panel_date;
        private Label lbl_date;
        private Label label6;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewImageColumn Column5;
        private Panel panel_statusprocess;
        private Label lbl_processStatus;
        private Label label9;
        private Panel panel_processname;
        private Panel panel_segment;
        private Panel panel_moid;
        private Panel panel_dateend;
        private Label lbl_date_end;
        private Label label11;
        private Panel panel_operator;
        private Label lbl_operator;
        private Label label13;
        private PictureBox pb_loader;
    }
}