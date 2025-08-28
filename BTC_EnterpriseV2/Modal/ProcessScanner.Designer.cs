namespace BTC_EnterpriseV2.Modal
{
    partial class ProcessScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessScanner));
            lbl_msg = new Label();
            txt_serialnumber = new TextBox();
            panel_processname = new Panel();
            lbl_processname = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            lbl_scancount = new Label();
            lbl_generatedserial = new Label();
            pictureBox1 = new PictureBox();
            panel_processname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_msg
            // 
            lbl_msg.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_msg.ForeColor = Color.White;
            lbl_msg.Location = new Point(65, 193);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(593, 20);
            lbl_msg.TabIndex = 6;
            lbl_msg.Text = "Please Scan Item Serial Number here.";
            lbl_msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(166, 135);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(430, 31);
            txt_serialnumber.TabIndex = 5;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.TextChanged += txt_serialnumber_TextChanged;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // panel_processname
            // 
            panel_processname.BackColor = Color.White;
            panel_processname.Controls.Add(lbl_processname);
            panel_processname.Location = new Point(11, 7);
            panel_processname.Name = "panel_processname";
            panel_processname.Size = new Size(715, 47);
            panel_processname.TabIndex = 8;
            // 
            // lbl_processname
            // 
            lbl_processname.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_processname.Location = new Point(10, 5);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(693, 36);
            lbl_processname.TabIndex = 0;
            lbl_processname.Text = "test";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.FromArgb(37, 45, 55);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(11, 285);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(715, 98);
            dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 262);
            label2.Name = "label2";
            label2.Size = new Size(201, 20);
            label2.TabIndex = 6;
            label2.Text = "Scaned Items Serial Number";
            // 
            // lbl_scancount
            // 
            lbl_scancount.AutoSize = true;
            lbl_scancount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_scancount.ForeColor = Color.White;
            lbl_scancount.Location = new Point(223, 260);
            lbl_scancount.Name = "lbl_scancount";
            lbl_scancount.Size = new Size(78, 20);
            lbl_scancount.TabIndex = 6;
            lbl_scancount.Text = "0 out of 5";
            // 
            // lbl_generatedserial
            // 
            lbl_generatedserial.AutoSize = true;
            lbl_generatedserial.ForeColor = Color.White;
            lbl_generatedserial.Location = new Point(86, 79);
            lbl_generatedserial.Name = "lbl_generatedserial";
            lbl_generatedserial.Size = new Size(50, 20);
            lbl_generatedserial.TabIndex = 10;
            lbl_generatedserial.Text = "label3";
            lbl_generatedserial.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(306, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // ProcessScanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(734, 421);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(lbl_generatedserial);
            Controls.Add(panel_processname);
            Controls.Add(label2);
            Controls.Add(lbl_scancount);
            Controls.Add(lbl_msg);
            Controls.Add(txt_serialnumber);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProcessScanner";
            Text = "ProcessScanner";
            Load += ProcessScanner_Load;
            panel_processname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_msg;
        private Panel panel_processname;
        private Label label2;
        private Label lbl_scancount;
        private Label lbl_processname;
        private DataGridView dataGridView1;
        private Label lbl_generatedserial;
        private PictureBox pictureBox1;
        public TextBox txt_serialnumber;
    }
}