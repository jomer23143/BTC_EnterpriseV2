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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessScanner));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            button1 = new Button();
            lbl_msg = new Label();
            txt_serialnumber = new TextBox();
            pbimage = new PictureBox();
            panel_processname = new Panel();
            lbl_processname = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            lbl_scancount = new Label();
            lbl_generatedserial = new Label();
            ((System.ComponentModel.ISupportInitialize)pbimage).BeginInit();
            panel_processname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(522, 287);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(114, 30);
            button1.TabIndex = 7;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lbl_msg
            // 
            lbl_msg.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_msg.ForeColor = Color.White;
            lbl_msg.Location = new Point(50, 138);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(519, 15);
            lbl_msg.TabIndex = 6;
            lbl_msg.Text = "Please Scan Item Serial Number here.";
            lbl_msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(127, 110);
            txt_serialnumber.Margin = new Padding(3, 2, 3, 2);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(376, 25);
            txt_serialnumber.TabIndex = 5;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.TextChanged += txt_serialnumber_TextChanged;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // pbimage
            // 
            pbimage.Image = (Image)resources.GetObject("pbimage.Image");
            pbimage.Location = new Point(279, 45);
            pbimage.Margin = new Padding(3, 2, 3, 2);
            pbimage.Name = "pbimage";
            pbimage.Size = new Size(82, 60);
            pbimage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbimage.TabIndex = 4;
            pbimage.TabStop = false;
            // 
            // panel_processname
            // 
            panel_processname.BackColor = Color.White;
            panel_processname.Controls.Add(lbl_processname);
            panel_processname.Location = new Point(10, 5);
            panel_processname.Margin = new Padding(3, 2, 3, 2);
            panel_processname.Name = "panel_processname";
            panel_processname.Size = new Size(626, 35);
            panel_processname.TabIndex = 8;
            // 
            // lbl_processname
            // 
            lbl_processname.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_processname.Location = new Point(9, 4);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(606, 27);
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
            dataGridView1.Location = new Point(10, 178);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(626, 105);
            dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 161);
            label2.Name = "label2";
            label2.Size = new Size(158, 15);
            label2.TabIndex = 6;
            label2.Text = "Scaned Items Serial Number";
            // 
            // lbl_scancount
            // 
            lbl_scancount.AutoSize = true;
            lbl_scancount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_scancount.ForeColor = Color.White;
            lbl_scancount.Location = new Point(186, 160);
            lbl_scancount.Name = "lbl_scancount";
            lbl_scancount.Size = new Size(61, 15);
            lbl_scancount.TabIndex = 6;
            lbl_scancount.Text = "0 out of 5";
            // 
            // lbl_generatedserial
            // 
            lbl_generatedserial.AutoSize = true;
            lbl_generatedserial.ForeColor = Color.White;
            lbl_generatedserial.Location = new Point(75, 59);
            lbl_generatedserial.Name = "lbl_generatedserial";
            lbl_generatedserial.Size = new Size(38, 15);
            lbl_generatedserial.TabIndex = 10;
            lbl_generatedserial.Text = "label3";
            lbl_generatedserial.Visible = false;
            // 
            // ProcessScanner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(647, 322);
            Controls.Add(dataGridView1);
            Controls.Add(lbl_generatedserial);
            Controls.Add(panel_processname);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(lbl_scancount);
            Controls.Add(lbl_msg);
            Controls.Add(txt_serialnumber);
            Controls.Add(pbimage);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProcessScanner";
            Text = "ProcessScanner";
            Load += ProcessScanner_Load;
            ((System.ComponentModel.ISupportInitialize)pbimage).EndInit();
            panel_processname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lbl_msg;
        private TextBox txt_serialnumber;
        private PictureBox pbimage;
        private Panel panel_processname;
        private Label label2;
        private Label lbl_scancount;
        private Label lbl_processname;
        private DataGridView dataGridView1;
        private Label lbl_generatedserial;
    }
}