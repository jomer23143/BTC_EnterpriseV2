namespace BTC_EnterpriseV2.SideBar
{
    partial class ProcessSidebar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessSidebar));
            lbl_process = new Label();
            Process_Panel = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            Process_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_process
            // 
            lbl_process.BackColor = Color.FromArgb(37, 45, 55);
            lbl_process.Dock = DockStyle.Top;
            lbl_process.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_process.ForeColor = Color.SeaGreen;
            lbl_process.Location = new Point(0, 0);
            lbl_process.Name = "lbl_process";
            lbl_process.Size = new Size(383, 62);
            lbl_process.TabIndex = 0;
            lbl_process.Text = "Sub-Assy";
            lbl_process.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Process_Panel
            // 
            Process_Panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Process_Panel.Controls.Add(pictureBox1);
            Process_Panel.Location = new Point(12, 73);
            Process_Panel.Name = "Process_Panel";
            Process_Panel.Size = new Size(359, 665);
            Process_Panel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(349, 313);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ProcessSidebar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 40, 85);
            ClientSize = new Size(383, 756);
            Controls.Add(Process_Panel);
            Controls.Add(lbl_process);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProcessSidebar";
            Text = "ProcessSidebar";
            Process_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_process;
        private FlowLayoutPanel Process_Panel;
        private PictureBox pictureBox1;
    }
}