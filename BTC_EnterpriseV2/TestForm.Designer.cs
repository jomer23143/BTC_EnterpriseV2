namespace BTC_EnterpriseV2
{
    partial class TestForm
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
            sfDataGrid2 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid2).BeginInit();
            SuspendLayout();
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            sfDataGrid1.Location = new Point(27, 73);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.PreviewRowHeight = 35;
            sfDataGrid1.RowHeight = 60;
            sfDataGrid1.Size = new Size(902, 653);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 0;
            sfDataGrid1.Text = "sfDataGrid1";
            sfDataGrid1.CurrentCellActivated += sfDataGrid1_CurrentCellActivated;
            // 
            // sfDataGrid2
            // 
            sfDataGrid2.AccessibleName = "Table";
            sfDataGrid2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            sfDataGrid2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            sfDataGrid2.Location = new Point(935, 110);
            sfDataGrid2.Name = "sfDataGrid2";
            sfDataGrid2.PreviewRowHeight = 35;
            sfDataGrid2.Size = new Size(781, 616);
            sfDataGrid2.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid2.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid2.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid2.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid2.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid2.TabIndex = 1;
            sfDataGrid2.Text = "sfDataGrid2";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(935, 62);
            label1.Name = "label1";
            label1.Size = new Size(781, 45);
            label1.TabIndex = 2;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1728, 780);
            Controls.Add(label1);
            Controls.Add(sfDataGrid2);
            Controls.Add(sfDataGrid1);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid2;
        private Label label1;
    }
}