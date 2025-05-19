namespace BTC_EnterpriseV2.Modal
{
    partial class CustomeAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomeAlert));
            picIcon = new PictureBox();
            lbl_alertTitle = new Label();
            lblMessage = new Label();
            panel1 = new Panel();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            SuspendLayout();
            // 
            // picIcon
            // 
            picIcon.Image = (Image)resources.GetObject("picIcon.Image");
            picIcon.Location = new Point(12, 26);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(108, 108);
            picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picIcon.TabIndex = 0;
            picIcon.TabStop = false;
            // 
            // lbl_alertTitle
            // 
            lbl_alertTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_alertTitle.Location = new Point(137, 17);
            lbl_alertTitle.Name = "lbl_alertTitle";
            lbl_alertTitle.Size = new Size(303, 30);
            lbl_alertTitle.TabIndex = 1;
            lbl_alertTitle.Text = "Confirm Part Not-Installed";
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.DimGray;
            lblMessage.Location = new Point(137, 59);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(315, 74);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Confirm Part Not-Installed";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(12, 147);
            panel1.Name = "panel1";
            panel1.Size = new Size(440, 5);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(22, 27, 45);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(312, 162);
            button1.Name = "button1";
            button1.Size = new Size(140, 36);
            button1.TabIndex = 3;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // CustomeAlert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(464, 210);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(lblMessage);
            Controls.Add(lbl_alertTitle);
            Controls.Add(picIcon);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CustomeAlert";
            Text = "CustomeAlert";
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picIcon;
        private Label lbl_alertTitle;
        private Label lblMessage;
        private Panel panel1;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}