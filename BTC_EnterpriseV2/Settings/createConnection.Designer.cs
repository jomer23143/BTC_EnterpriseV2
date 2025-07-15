namespace BTC_EnterpriseV2.Settings
{
    partial class createConnection
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
            programsGrid = new DataGridView();
            btn_test = new Button();
            btn_save = new Button();
            gridcolName = new DataGridViewTextBoxColumn();
            gridcolserver = new DataGridViewTextBoxColumn();
            gridcoluser = new DataGridViewTextBoxColumn();
            gridcolpassword = new DataGridViewTextBoxColumn();
            gridcoldbname = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)programsGrid).BeginInit();
            SuspendLayout();
            // 
            // programsGrid
            // 
            programsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            programsGrid.Columns.AddRange(new DataGridViewColumn[] { gridcolName, gridcolserver, gridcoluser, gridcolpassword, gridcoldbname });
            programsGrid.Location = new Point(39, 24);
            programsGrid.Name = "programsGrid";
            programsGrid.RowHeadersWidth = 51;
            programsGrid.Size = new Size(753, 188);
            programsGrid.TabIndex = 0;
            programsGrid.CellFormatting += programsGrid_CellFormatting;
            // 
            // btn_test
            // 
            btn_test.Location = new Point(528, 218);
            btn_test.Name = "btn_test";
            btn_test.Size = new Size(129, 39);
            btn_test.TabIndex = 1;
            btn_test.Text = "Test Connection";
            btn_test.UseVisualStyleBackColor = true;
            btn_test.Click += btn_test_Click;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(663, 218);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(129, 39);
            btn_save.TabIndex = 1;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // gridcolName
            // 
            gridcolName.HeaderText = "Name";
            gridcolName.MinimumWidth = 6;
            gridcolName.Name = "gridcolName";
            gridcolName.Width = 125;
            // 
            // gridcolserver
            // 
            gridcolserver.HeaderText = "Server";
            gridcolserver.MinimumWidth = 6;
            gridcolserver.Name = "gridcolserver";
            gridcolserver.Width = 125;
            // 
            // gridcoluser
            // 
            gridcoluser.HeaderText = "UserName";
            gridcoluser.MinimumWidth = 6;
            gridcoluser.Name = "gridcoluser";
            gridcoluser.Width = 125;
            // 
            // gridcolpassword
            // 
            gridcolpassword.HeaderText = "Password";
            gridcolpassword.MinimumWidth = 6;
            gridcolpassword.Name = "gridcolpassword";
            gridcolpassword.Width = 125;
            // 
            // gridcoldbname
            // 
            gridcoldbname.HeaderText = "DBName";
            gridcoldbname.MinimumWidth = 6;
            gridcoldbname.Name = "gridcoldbname";
            gridcoldbname.Width = 125;
            // 
            // createConnection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 282);
            Controls.Add(btn_save);
            Controls.Add(btn_test);
            Controls.Add(programsGrid);
            Name = "createConnection";
            Text = "createConnection";
            Load += createConnection_Load;
            ((System.ComponentModel.ISupportInitialize)programsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView programsGrid;
        private Button btn_test;
        private Button btn_save;
        private DataGridViewTextBoxColumn gridcolName;
        private DataGridViewTextBoxColumn gridcolserver;
        private DataGridViewTextBoxColumn gridcoluser;
        private DataGridViewTextBoxColumn gridcolpassword;
        private DataGridViewTextBoxColumn gridcoldbname;
    }
}