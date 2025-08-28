namespace BTC_EnterpriseV2.Modal
{
    partial class scantorque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(scantorque));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel_processname = new Panel();
            lbl_processname = new Label();
            txt_torque = new TextBox();
            lbl_msg = new Label();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            lbl_scancount = new Label();
            panel1.SuspendLayout();
            panel_processname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel_processname);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(767, 75);
            panel1.TabIndex = 0;
            // 
            // panel_processname
            // 
            panel_processname.Anchor = AnchorStyles.Top;
            panel_processname.BackColor = Color.White;
            panel_processname.Controls.Add(lbl_processname);
            panel_processname.Location = new Point(20, 19);
            panel_processname.Name = "panel_processname";
            panel_processname.Size = new Size(737, 44);
            panel_processname.TabIndex = 0;
            // 
            // lbl_processname
            // 
            lbl_processname.Dock = DockStyle.Fill;
            lbl_processname.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_processname.Location = new Point(0, 0);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(737, 44);
            lbl_processname.TabIndex = 0;
            lbl_processname.Text = "Material Name";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_torque
            // 
            txt_torque.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_torque.Location = new Point(159, 187);
            txt_torque.Name = "txt_torque";
            txt_torque.Size = new Size(469, 34);
            txt_torque.TabIndex = 1;
            txt_torque.TextAlign = HorizontalAlignment.Center;
            txt_torque.KeyDown += txt_torque_KeyDown;
            // 
            // lbl_msg
            // 
            lbl_msg.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_msg.ForeColor = Color.Navy;
            lbl_msg.Location = new Point(27, 224);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(715, 32);
            lbl_msg.TabIndex = 2;
            lbl_msg.Text = "Scan Torque Machine  Serial Here.!";
            lbl_msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(324, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(148, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
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
            dataGridView1.Location = new Point(27, 296);
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
            dataGridView1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(37, 273);
            label2.Name = "label2";
            label2.Size = new Size(213, 20);
            label2.TabIndex = 8;
            label2.Text = "Scaned Torque Serial Number";
            // 
            // lbl_scancount
            // 
            lbl_scancount.AutoSize = true;
            lbl_scancount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_scancount.ForeColor = Color.Brown;
            lbl_scancount.Location = new Point(256, 273);
            lbl_scancount.Name = "lbl_scancount";
            lbl_scancount.Size = new Size(78, 20);
            lbl_scancount.TabIndex = 9;
            lbl_scancount.Text = "0 out of 1";
            // 
            // scantorque
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(767, 407);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(lbl_scancount);
            Controls.Add(pictureBox1);
            Controls.Add(lbl_msg);
            Controls.Add(txt_torque);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "scantorque";
            Text = "scantorque";
            Load += scantorque_Load;
            panel1.ResumeLayout(false);
            panel_processname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl_msg;
        private PictureBox pictureBox1;
        private Label lbl_processname;
        public TextBox txt_torque;
        private Panel panel_processname;
        private DataGridView dataGridView1;
        private Label label2;
        private Label lbl_scancount;
    }
}