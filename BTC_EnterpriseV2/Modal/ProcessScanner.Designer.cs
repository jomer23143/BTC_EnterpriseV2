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
            label1 = new Label();
            txt_serialnumber = new TextBox();
            pbimage = new PictureBox();
            panel_processname = new Panel();
            lbl_processname = new Label();
            panel_dgv = new Panel();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            lbl_scancount = new Label();
            lbl_generatedserial = new Label();
            ((System.ComponentModel.ISupportInitialize)pbimage).BeginInit();
            panel_processname.SuspendLayout();
            panel_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Salmon;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(501, 384);
            button1.Name = "button1";
            button1.Size = new Size(104, 31);
            button1.TabIndex = 7;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(181, 176);
            label1.Name = "label1";
            label1.Size = new Size(264, 20);
            label1.TabIndex = 6;
            label1.Text = "Please Scan Item Serial Number here.";
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(125, 146);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(369, 27);
            txt_serialnumber.TabIndex = 5;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.TextChanged += txt_serialnumber_TextChanged;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // pbimage
            // 
            pbimage.Image = (Image)resources.GetObject("pbimage.Image");
            pbimage.Location = new Point(243, 60);
            pbimage.Name = "pbimage";
            pbimage.Size = new Size(121, 80);
            pbimage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbimage.TabIndex = 4;
            pbimage.TabStop = false;
            // 
            // panel_processname
            // 
            panel_processname.BackColor = Color.White;
            panel_processname.Controls.Add(lbl_processname);
            panel_processname.Location = new Point(12, 7);
            panel_processname.Name = "panel_processname";
            panel_processname.Size = new Size(593, 47);
            panel_processname.TabIndex = 8;
            // 
            // lbl_processname
            // 
            lbl_processname.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_processname.Location = new Point(10, 5);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(575, 36);
            lbl_processname.TabIndex = 0;
            lbl_processname.Text = "test";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_dgv
            // 
            panel_dgv.BackColor = Color.White;
            panel_dgv.Controls.Add(dataGridView1);
            panel_dgv.Location = new Point(12, 238);
            panel_dgv.Name = "panel_dgv";
            panel_dgv.Size = new Size(593, 140);
            panel_dgv.TabIndex = 9;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
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
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(593, 140);
            dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 215);
            label2.Name = "label2";
            label2.Size = new Size(201, 20);
            label2.TabIndex = 6;
            label2.Text = "Scaned Items Serial Number";
            // 
            // lbl_scancount
            // 
            lbl_scancount.AutoSize = true;
            lbl_scancount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_scancount.Location = new Point(212, 214);
            lbl_scancount.Name = "lbl_scancount";
            lbl_scancount.Size = new Size(78, 20);
            lbl_scancount.TabIndex = 6;
            lbl_scancount.Text = "0 out of 5";
            // 
            // lbl_generatedserial
            // 
            lbl_generatedserial.AutoSize = true;
            lbl_generatedserial.Location = new Point(86, 79);
            lbl_generatedserial.Name = "lbl_generatedserial";
            lbl_generatedserial.Size = new Size(50, 20);
            lbl_generatedserial.TabIndex = 10;
            lbl_generatedserial.Text = "label3";
            lbl_generatedserial.Visible = false;
            // 
            // ProcessScanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 421);
            Controls.Add(lbl_generatedserial);
            Controls.Add(panel_dgv);
            Controls.Add(panel_processname);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(lbl_scancount);
            Controls.Add(label1);
            Controls.Add(txt_serialnumber);
            Controls.Add(pbimage);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProcessScanner";
            Text = "ProcessScanner";
            Load += ProcessScanner_Load;
            ((System.ComponentModel.ISupportInitialize)pbimage).EndInit();
            panel_processname.ResumeLayout(false);
            panel_dgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txt_serialnumber;
        private PictureBox pbimage;
        private Panel panel_processname;
        private Panel panel_dgv;
        private Label label2;
        private Label lbl_scancount;
        private Label lbl_processname;
        private DataGridView dataGridView1;
        private Label lbl_generatedserial;
    }
}