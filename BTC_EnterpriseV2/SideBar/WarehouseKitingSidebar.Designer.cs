namespace BTCP_EnterpriseV2.SideBar
{
    partial class WarehouseKitingSidebar
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
            label1 = new Label();
            btn_warehousekiting = new Button();
            btn_ncticket = new Button();
            btn_abi = new Button();
            SuspendLayout();
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
            label1.TabIndex = 0;
            label1.Text = "Warehouse Kiting";
            label1.TextAlign = ContentAlignment.MiddleCenter;
          //  label1.Click += this.label1_Click;
            // 
            // btn_warehousekiting
            // 
            btn_warehousekiting.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_warehousekiting.BackColor = Color.FromArgb(109, 180, 62);
            btn_warehousekiting.Cursor = Cursors.Hand;
            btn_warehousekiting.FlatAppearance.BorderSize = 0;
            btn_warehousekiting.FlatAppearance.MouseOverBackColor = Color.SeaGreen;
            btn_warehousekiting.FlatStyle = FlatStyle.Flat;
            btn_warehousekiting.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_warehousekiting.ForeColor = Color.White;
            btn_warehousekiting.Location = new Point(12, 85);
            btn_warehousekiting.Name = "btn_warehousekiting";
            btn_warehousekiting.Size = new Size(232, 60);
            btn_warehousekiting.TabIndex = 1;
            btn_warehousekiting.Text = "Warehouse Kiting";
            btn_warehousekiting.UseVisualStyleBackColor = false;
            btn_warehousekiting.Click += btn_warehousekiting_Click;
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
            btn_ncticket.Location = new Point(12, 165);
            btn_ncticket.Name = "btn_ncticket";
            btn_ncticket.Size = new Size(232, 60);
            btn_ncticket.TabIndex = 1;
            btn_ncticket.Text = "NC Ticket";
            btn_ncticket.UseVisualStyleBackColor = false;
            btn_ncticket.Click += btn_ncticket_Click;
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
            btn_abi.Location = new Point(12, 245);
            btn_abi.Name = "btn_abi";
            btn_abi.Size = new Size(232, 60);
            btn_abi.TabIndex = 1;
            btn_abi.Text = "ABI";
            btn_abi.UseVisualStyleBackColor = false;
            btn_abi.Click += btn_abi_Click;
            // 
            // WarehouseKitingSidebar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(256, 825);
            Controls.Add(btn_abi);
            Controls.Add(btn_ncticket);
            Controls.Add(btn_warehousekiting);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WarehouseKitingSidebar";
            Text = "WarehouseKitingSidebar";
            Load += WarehouseKitingSidebar_Load;
            SizeChanged += WarehouseKitingSidebar_SizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btn_warehousekiting;
        private Button btn_ncticket;
        private Button btn_abi;
    }
}