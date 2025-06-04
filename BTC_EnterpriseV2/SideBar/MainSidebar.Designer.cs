namespace BTC_EnterpriseV2.SideBar
{
    partial class MainSidebar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSidebar));
            button1 = new Button();
            btn_printqr = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(12, 91);
            button1.Name = "button1";
            button1.Size = new Size(214, 66);
            button1.TabIndex = 0;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = true;
            // 
            // btn_printqr
            // 
            btn_printqr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_printqr.FlatAppearance.BorderSize = 0;
            btn_printqr.FlatStyle = FlatStyle.Flat;
            btn_printqr.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_printqr.ForeColor = Color.White;
            btn_printqr.Image = (Image)resources.GetObject("btn_printqr.Image");
            btn_printqr.ImageAlign = ContentAlignment.MiddleLeft;
            btn_printqr.Location = new Point(12, 167);
            btn_printqr.Name = "btn_printqr";
            btn_printqr.Size = new Size(214, 66);
            btn_printqr.TabIndex = 0;
            btn_printqr.Text = "Print QR Code";
            btn_printqr.UseVisualStyleBackColor = true;
            btn_printqr.Click += btn_printqr_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(12, 243);
            button3.Name = "button3";
            button3.Size = new Size(214, 66);
            button3.TabIndex = 0;
            button3.Text = "Chart";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(12, 319);
            button4.Name = "button4";
            button4.Size = new Size(214, 66);
            button4.TabIndex = 0;
            button4.Text = "Segments";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(12, 395);
            button5.Name = "button5";
            button5.Size = new Size(214, 66);
            button5.TabIndex = 0;
            button5.Text = "Station";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(12, 471);
            button6.Name = "button6";
            button6.Size = new Size(214, 66);
            button6.TabIndex = 0;
            button6.Text = "Settings";
            button6.UseVisualStyleBackColor = true;
            // 
            // MainSidebar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(238, 761);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(btn_printqr);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainSidebar";
            Text = "MainSidebar";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btn_printqr;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}