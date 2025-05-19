namespace BTC_EnterpriseV2.SideBar
{
    partial class Kitlist_Sidebar
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
            btn_abi = new Button();
            btn_ncticket = new Button();
            btn_kitlist = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_abi
            // 
            btn_abi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_abi.BackColor = Color.FromArgb(109, 180, 62);
            btn_abi.Cursor = Cursors.Hand;
            btn_abi.FlatAppearance.BorderSize = 0;
            btn_abi.FlatAppearance.MouseOverBackColor = Color.SeaGreen;
            btn_abi.FlatStyle = FlatStyle.Flat;
            btn_abi.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_abi.ForeColor = Color.White;
            btn_abi.Location = new Point(12, 240);
            btn_abi.Name = "btn_abi";
            btn_abi.Size = new Size(232, 60);
            btn_abi.TabIndex = 3;
            btn_abi.Text = "ABI";
            btn_abi.UseVisualStyleBackColor = false;
            // 
            // btn_ncticket
            // 
            btn_ncticket.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_ncticket.BackColor = Color.FromArgb(109, 180, 62);
            btn_ncticket.Cursor = Cursors.Hand;
            btn_ncticket.FlatAppearance.BorderSize = 0;
            btn_ncticket.FlatAppearance.MouseOverBackColor = Color.SeaGreen;
            btn_ncticket.FlatStyle = FlatStyle.Flat;
            btn_ncticket.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ncticket.ForeColor = Color.White;
            btn_ncticket.Location = new Point(12, 160);
            btn_ncticket.Name = "btn_ncticket";
            btn_ncticket.Size = new Size(232, 60);
            btn_ncticket.TabIndex = 4;
            btn_ncticket.Text = "NC Ticket";
            btn_ncticket.UseVisualStyleBackColor = false;
            // 
            // btn_kitlist
            // 
            btn_kitlist.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_kitlist.BackColor = Color.FromArgb(109, 180, 62);
            btn_kitlist.Cursor = Cursors.Hand;
            btn_kitlist.FlatAppearance.BorderSize = 0;
            btn_kitlist.FlatAppearance.MouseOverBackColor = Color.SeaGreen;
            btn_kitlist.FlatStyle = FlatStyle.Flat;
            btn_kitlist.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_kitlist.ForeColor = Color.White;
            btn_kitlist.Location = new Point(12, 80);
            btn_kitlist.Name = "btn_kitlist";
            btn_kitlist.Size = new Size(232, 60);
            btn_kitlist.TabIndex = 5;
            btn_kitlist.Text = "Kit List";
            btn_kitlist.UseVisualStyleBackColor = false;
            btn_kitlist.Click += btn_kitlist_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(37, 45, 55);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(256, 63);
            label1.TabIndex = 2;
            label1.Text = "Kitlist Recieving";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Kitlist_Sidebar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 771);
            Controls.Add(btn_abi);
            Controls.Add(btn_ncticket);
            Controls.Add(btn_kitlist);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Kitlist_Sidebar";
            Text = "Kitlist_Sidebar";
            SizeChanged += Kitlist_Sidebar_SizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_abi;
        private Button btn_ncticket;
        private Button btn_kitlist;
        private Label label1;
    }
}