namespace BTC_EnterpriseV2.Modal
{
    partial class timerv2
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
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            SuspendLayout();
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.Location = new Point(12, 47);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.Size = new Size(776, 391);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 0;
            sfDataGrid1.Text = "sfDataGrid1";
            sfDataGrid1.CellButtonClick += sfDataGrid1_CellButtonClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(106, 29);
            button1.TabIndex = 1;
            button1.Text = "Datagridview";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timerv2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(sfDataGrid1);
            Name = "timerv2";
            Text = "timerv2";
            Load += timerv2_Load;
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Button button1;
    }
}