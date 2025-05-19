namespace BTC_EnterpriseV2.Forms
{
    partial class SegmentFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SegmentFrm));
            panel1 = new Panel();
            lbl_Test = new Label();
            label1 = new Label();
            panel2 = new Panel();
            flowlayoutsegment = new FlowLayoutPanel();
            pb_loading = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            flowlayoutsegment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_loading).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl_Test);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1228, 80);
            panel1.TabIndex = 0;
            // 
            // lbl_Test
            // 
            lbl_Test.AutoSize = true;
            lbl_Test.Location = new Point(143, 43);
            lbl_Test.Name = "lbl_Test";
            lbl_Test.Size = new Size(50, 20);
            lbl_Test.TabIndex = 1;
            lbl_Test.Text = "label2";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(100, 180, 45);
            label1.Location = new Point(393, 9);
            label1.Name = "label1";
            label1.Size = new Size(479, 62);
            label1.TabIndex = 0;
            label1.Text = "Production Segment";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(22, 27, 45);
            panel2.Controls.Add(flowlayoutsegment);
            panel2.Location = new Point(12, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(1204, 685);
            panel2.TabIndex = 1;
            // 
            // flowlayoutsegment
            // 
            flowlayoutsegment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowlayoutsegment.BackColor = Color.Transparent;
            flowlayoutsegment.Controls.Add(pb_loading);
            flowlayoutsegment.Location = new Point(162, 16);
            flowlayoutsegment.Name = "flowlayoutsegment";
            flowlayoutsegment.Size = new Size(907, 636);
            flowlayoutsegment.TabIndex = 0;
            // 
            // pb_loading
            // 
            pb_loading.BackColor = Color.Transparent;
            pb_loading.Image = (Image)resources.GetObject("pb_loading.Image");
            pb_loading.Location = new Point(3, 3);
            pb_loading.Name = "pb_loading";
            pb_loading.Size = new Size(904, 633);
            pb_loading.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_loading.TabIndex = 0;
            pb_loading.TabStop = false;
            // 
            // SegmentFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(1228, 788);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SegmentFrm";
            Text = "SegmentFrm";
            Load += SegmentFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            flowlayoutsegment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_loading).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private FlowLayoutPanel flowlayoutsegment;
        private PictureBox pb_loading;
        private Label lbl_Test;
    }
}