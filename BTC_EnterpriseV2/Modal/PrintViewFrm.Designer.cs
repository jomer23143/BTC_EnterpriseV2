namespace BTC_EnterpriseV2.Modal
{
    partial class PrintViewFrm
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
            printPreviewControl1 = new PrintPreviewControl();
            SuspendLayout();
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Location = new Point(42, 12);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(835, 514);
            printPreviewControl1.TabIndex = 0;
            // 
            // PrintViewFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 564);
            Controls.Add(printPreviewControl1);
            Name = "PrintViewFrm";
            Text = "PrintViewFrm";
            ResumeLayout(false);
        }

        #endregion

        private PrintPreviewControl printPreviewControl1;
    }
}