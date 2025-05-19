namespace BTC_EnterpriseV2.Forms
{
    partial class Warehousekitting
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehousekitting));
            panel1 = new Panel();
            label1 = new Label();
            btnAddSerial = new Button();
            btnscan = new Button();
            label2 = new Label();
            txtmo_number = new TextBox();
            panel2 = new Panel();
            txtserial_number = new TextBox();
            lbl_rowcount = new Label();
            label3 = new Label();
            btnserial = new Button();
            btnnext = new Button();
            btnprevious_page = new Button();
            btnincomplete = new Button();
            btncomplete = new Button();
            dataGridView1 = new DataGridView();
            colipn = new DataGridViewTextBoxColumn();
            coldescription = new DataGridViewTextBoxColumn();
            coltype = new DataGridViewTextBoxColumn();
            colmfg = new DataGridViewTextBoxColumn();
            colmfgprodcode = new DataGridViewTextBoxColumn();
            collocation = new DataGridViewTextBoxColumn();
            colstock = new DataGridViewTextBoxColumn();
            colunitqty = new DataGridViewTextBoxColumn();
            colmoqty = new DataGridViewTextBoxColumn();
            colwipqty = new DataGridViewTextBoxColumn();
            colpickqty = new DataGridViewTextBoxColumn();
            colshortqty = new DataGridViewTextBoxColumn();
            colkit_quantity = new DataGridViewTextBoxColumn();
            colrecieved_quantity = new DataGridViewTextBoxColumn();
            colreject_quantity = new DataGridViewTextBoxColumn();
            colunit = new DataGridViewTextBoxColumn();
            colinvoicenumber = new DataGridViewTextBoxColumn();
            colkitted = new DataGridViewTextBoxColumn();
            colindividualkitted = new DataGridViewTextBoxColumn();
            coltrack = new DataGridViewTextBoxColumn();
            colrack = new DataGridViewTextBoxColumn();
            colcomment = new DataGridViewTextBoxColumn();
            colcreated_at = new DataGridViewTextBoxColumn();
            colupdated_at = new DataGridViewTextBoxColumn();
            colstatus = new DataGridViewTextBoxColumn();
            colhistory = new DataGridViewTextBoxColumn();
            colid = new DataGridViewTextBoxColumn();
            colmo_id = new DataGridViewTextBoxColumn();
            colitem_number = new DataGridViewTextBoxColumn();
            colgroup = new DataGridViewTextBoxColumn();
            colkit_list_status_item = new DataGridViewTextBoxColumn();
            bunifuloading = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bunifuloading).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(22, 27, 45);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1390, 59);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(100, 180, 45);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 29);
            label1.TabIndex = 0;
            label1.Text = "Warehouse Kitting";
            // 
            // btnAddSerial
            // 
            btnAddSerial.BackColor = Color.Teal;
            btnAddSerial.Cursor = Cursors.Hand;
            btnAddSerial.FlatAppearance.BorderSize = 0;
            btnAddSerial.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnAddSerial.FlatStyle = FlatStyle.Flat;
            btnAddSerial.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddSerial.ForeColor = Color.White;
            btnAddSerial.Location = new Point(12, 65);
            btnAddSerial.Name = "btnAddSerial";
            btnAddSerial.Size = new Size(176, 47);
            btnAddSerial.TabIndex = 1;
            btnAddSerial.Text = "Add Serial";
            btnAddSerial.UseVisualStyleBackColor = false;
            btnAddSerial.Click += btnAddSerial_Click;
            // 
            // btnscan
            // 
            btnscan.BackColor = Color.Teal;
            btnscan.Cursor = Cursors.Hand;
            btnscan.FlatAppearance.BorderSize = 0;
            btnscan.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnscan.FlatStyle = FlatStyle.Flat;
            btnscan.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnscan.ForeColor = Color.White;
            btnscan.Location = new Point(194, 65);
            btnscan.Name = "btnscan";
            btnscan.Size = new Size(176, 47);
            btnscan.TabIndex = 1;
            btnscan.Text = "Scan Serial";
            btnscan.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(963, 91);
            label2.Name = "label2";
            label2.Size = new Size(131, 28);
            label2.TabIndex = 2;
            label2.Text = "MO Number :";
            // 
            // txtmo_number
            // 
            txtmo_number.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtmo_number.BorderStyle = BorderStyle.FixedSingle;
            txtmo_number.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtmo_number.Location = new Point(1097, 85);
            txtmo_number.Name = "txtmo_number";
            txtmo_number.Size = new Size(278, 34);
            txtmo_number.TabIndex = 3;
            txtmo_number.KeyDown += txtmo_number_KeyDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtserial_number);
            panel2.Controls.Add(lbl_rowcount);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnserial);
            panel2.Controls.Add(btnnext);
            panel2.Controls.Add(btnprevious_page);
            panel2.Controls.Add(btnincomplete);
            panel2.Controls.Add(btncomplete);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 679);
            panel2.Name = "panel2";
            panel2.Size = new Size(1390, 68);
            panel2.TabIndex = 4;
            // 
            // txtserial_number
            // 
            txtserial_number.BorderStyle = BorderStyle.None;
            txtserial_number.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtserial_number.Location = new Point(535, 15);
            txtserial_number.Name = "txtserial_number";
            txtserial_number.Size = new Size(209, 27);
            txtserial_number.TabIndex = 5;
            // 
            // lbl_rowcount
            // 
            lbl_rowcount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_rowcount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_rowcount.ForeColor = SystemColors.GrayText;
            lbl_rowcount.Location = new Point(1246, 9);
            lbl_rowcount.Name = "lbl_rowcount";
            lbl_rowcount.Size = new Size(129, 28);
            lbl_rowcount.TabIndex = 4;
            lbl_rowcount.Text = "0 out of 0";
            lbl_rowcount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(383, 15);
            label3.Name = "label3";
            label3.Size = new Size(146, 28);
            label3.TabIndex = 4;
            label3.Text = "Serial Number :";
            // 
            // btnserial
            // 
            btnserial.BackColor = Color.FromArgb(109, 180, 62);
            btnserial.Cursor = Cursors.Hand;
            btnserial.FlatAppearance.BorderSize = 0;
            btnserial.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnserial.FlatStyle = FlatStyle.Flat;
            btnserial.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnserial.ForeColor = Color.White;
            btnserial.Location = new Point(12, 9);
            btnserial.Name = "btnserial";
            btnserial.Size = new Size(110, 47);
            btnserial.TabIndex = 1;
            btnserial.Text = "Save Serial";
            btnserial.UseVisualStyleBackColor = false;
            // 
            // btnnext
            // 
            btnnext.Anchor = AnchorStyles.Top;
            btnnext.BackColor = Color.FromArgb(109, 180, 62);
            btnnext.Cursor = Cursors.Hand;
            btnnext.FlatAppearance.BorderSize = 0;
            btnnext.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnnext.FlatStyle = FlatStyle.Flat;
            btnnext.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnnext.ForeColor = Color.White;
            btnnext.Location = new Point(903, 3);
            btnnext.Name = "btnnext";
            btnnext.Size = new Size(110, 40);
            btnnext.TabIndex = 1;
            btnnext.Text = "Next";
            btnnext.UseVisualStyleBackColor = false;
            btnnext.Click += btnnext_Click;
            // 
            // btnprevious_page
            // 
            btnprevious_page.Anchor = AnchorStyles.Top;
            btnprevious_page.BackColor = Color.FromArgb(109, 180, 62);
            btnprevious_page.Cursor = Cursors.Hand;
            btnprevious_page.FlatAppearance.BorderSize = 0;
            btnprevious_page.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnprevious_page.FlatStyle = FlatStyle.Flat;
            btnprevious_page.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnprevious_page.ForeColor = Color.White;
            btnprevious_page.Location = new Point(787, 3);
            btnprevious_page.Name = "btnprevious_page";
            btnprevious_page.Size = new Size(110, 40);
            btnprevious_page.TabIndex = 1;
            btnprevious_page.Text = "Previous";
            btnprevious_page.UseVisualStyleBackColor = false;
            btnprevious_page.Click += btnprevious_page_Click;
            // 
            // btnincomplete
            // 
            btnincomplete.BackColor = Color.FromArgb(109, 180, 62);
            btnincomplete.Cursor = Cursors.Hand;
            btnincomplete.FlatAppearance.BorderSize = 0;
            btnincomplete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btnincomplete.FlatStyle = FlatStyle.Flat;
            btnincomplete.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnincomplete.ForeColor = Color.White;
            btnincomplete.Location = new Point(244, 9);
            btnincomplete.Name = "btnincomplete";
            btnincomplete.Size = new Size(110, 47);
            btnincomplete.TabIndex = 1;
            btnincomplete.Text = "Incomplete";
            btnincomplete.UseVisualStyleBackColor = false;
            btnincomplete.Click += btnincomplete_Click;
            // 
            // btncomplete
            // 
            btncomplete.BackColor = Color.FromArgb(109, 180, 62);
            btncomplete.Cursor = Cursors.Hand;
            btncomplete.FlatAppearance.BorderSize = 0;
            btncomplete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 0);
            btncomplete.FlatStyle = FlatStyle.Flat;
            btncomplete.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btncomplete.ForeColor = Color.White;
            btncomplete.Location = new Point(128, 9);
            btncomplete.Name = "btncomplete";
            btncomplete.Size = new Size(110, 47);
            btncomplete.TabIndex = 1;
            btncomplete.Text = "Complete";
            btncomplete.UseVisualStyleBackColor = false;
            btncomplete.Click += btncomplete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colipn, coldescription, coltype, colmfg, colmfgprodcode, collocation, colstock, colunitqty, colmoqty, colwipqty, colpickqty, colshortqty, colkit_quantity, colrecieved_quantity, colreject_quantity, colunit, colinvoicenumber, colkitted, colindividualkitted, coltrack, colrack, colcomment, colcreated_at, colupdated_at, colstatus, colhistory, colid, colmo_id, colitem_number, colgroup, colkit_list_status_item });
            dataGridView1.Location = new Point(12, 125);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(1363, 548);
            dataGridView1.TabIndex = 5;
            // 
            // colipn
            // 
            colipn.DataPropertyName = "ipn";
            colipn.HeaderText = "Internal IPN ";
            colipn.MinimumWidth = 6;
            colipn.Name = "colipn";
            // 
            // coldescription
            // 
            coldescription.DataPropertyName = "description";
            coldescription.HeaderText = "Description";
            coldescription.MinimumWidth = 6;
            coldescription.Name = "coldescription";
            // 
            // coltype
            // 
            coltype.DataPropertyName = "type";
            coltype.HeaderText = "Type";
            coltype.MinimumWidth = 6;
            coltype.Name = "coltype";
            // 
            // colmfg
            // 
            colmfg.DataPropertyName = "manufacturing";
            colmfg.HeaderText = "Mfg";
            colmfg.MinimumWidth = 6;
            colmfg.Name = "colmfg";
            colmfg.Visible = false;
            // 
            // colmfgprodcode
            // 
            colmfgprodcode.DataPropertyName = "manufacturing_product_code";
            colmfgprodcode.HeaderText = "Mfg Product Code";
            colmfgprodcode.MinimumWidth = 6;
            colmfgprodcode.Name = "colmfgprodcode";
            colmfgprodcode.Visible = false;
            // 
            // collocation
            // 
            collocation.DataPropertyName = "source_location";
            collocation.HeaderText = "Location";
            collocation.MinimumWidth = 6;
            collocation.Name = "collocation";
            collocation.Visible = false;
            // 
            // colstock
            // 
            colstock.DataPropertyName = "stock";
            colstock.HeaderText = "Stock";
            colstock.MinimumWidth = 6;
            colstock.Name = "colstock";
            colstock.Visible = false;
            // 
            // colunitqty
            // 
            colunitqty.DataPropertyName = "unit_quantity";
            colunitqty.HeaderText = "Unit Qty";
            colunitqty.MinimumWidth = 6;
            colunitqty.Name = "colunitqty";
            colunitqty.Visible = false;
            // 
            // colmoqty
            // 
            colmoqty.DataPropertyName = "mo_quantity";
            colmoqty.HeaderText = "Mo Quantity";
            colmoqty.MinimumWidth = 6;
            colmoqty.Name = "colmoqty";
            colmoqty.Visible = false;
            // 
            // colwipqty
            // 
            colwipqty.DataPropertyName = "wip_quantity";
            colwipqty.HeaderText = "Wip Quantity";
            colwipqty.MinimumWidth = 6;
            colwipqty.Name = "colwipqty";
            colwipqty.Visible = false;
            // 
            // colpickqty
            // 
            colpickqty.DataPropertyName = "pick_quantity";
            colpickqty.HeaderText = "Pick Quantity";
            colpickqty.MinimumWidth = 6;
            colpickqty.Name = "colpickqty";
            // 
            // colshortqty
            // 
            colshortqty.DataPropertyName = "short_quantity";
            colshortqty.HeaderText = "Short Quantity";
            colshortqty.MinimumWidth = 6;
            colshortqty.Name = "colshortqty";
            // 
            // colkit_quantity
            // 
            colkit_quantity.HeaderText = "Kit Quantity";
            colkit_quantity.MinimumWidth = 6;
            colkit_quantity.Name = "colkit_quantity";
            colkit_quantity.Visible = false;
            // 
            // colrecieved_quantity
            // 
            colrecieved_quantity.HeaderText = "Recieved Quantity";
            colrecieved_quantity.MinimumWidth = 6;
            colrecieved_quantity.Name = "colrecieved_quantity";
            colrecieved_quantity.Visible = false;
            // 
            // colreject_quantity
            // 
            colreject_quantity.HeaderText = "Reject Quantity";
            colreject_quantity.MinimumWidth = 6;
            colreject_quantity.Name = "colreject_quantity";
            colreject_quantity.Visible = false;
            // 
            // colunit
            // 
            colunit.DataPropertyName = "unit";
            colunit.HeaderText = "Unit UOM";
            colunit.MinimumWidth = 6;
            colunit.Name = "colunit";
            // 
            // colinvoicenumber
            // 
            colinvoicenumber.DataPropertyName = "invoice_number";
            colinvoicenumber.HeaderText = "Invoice #";
            colinvoicenumber.MinimumWidth = 6;
            colinvoicenumber.Name = "colinvoicenumber";
            colinvoicenumber.Visible = false;
            // 
            // colkitted
            // 
            colkitted.DataPropertyName = "kitted";
            colkitted.HeaderText = "Kitted";
            colkitted.MinimumWidth = 6;
            colkitted.Name = "colkitted";
            // 
            // colindividualkitted
            // 
            colindividualkitted.DataPropertyName = "individual_kitting";
            colindividualkitted.HeaderText = "Individual Kitted";
            colindividualkitted.MinimumWidth = 6;
            colindividualkitted.Name = "colindividualkitted";
            colindividualkitted.Visible = false;
            // 
            // coltrack
            // 
            coltrack.DataPropertyName = "track";
            coltrack.HeaderText = "Track";
            coltrack.MinimumWidth = 6;
            coltrack.Name = "coltrack";
            coltrack.ReadOnly = true;
            // 
            // colrack
            // 
            colrack.DataPropertyName = "rack";
            colrack.HeaderText = "Rack";
            colrack.MinimumWidth = 6;
            colrack.Name = "colrack";
            colrack.ReadOnly = true;
            colrack.Visible = false;
            // 
            // colcomment
            // 
            colcomment.DataPropertyName = "comment";
            colcomment.HeaderText = "Comment";
            colcomment.MinimumWidth = 6;
            colcomment.Name = "colcomment";
            // 
            // colcreated_at
            // 
            colcreated_at.DataPropertyName = "created_at";
            colcreated_at.HeaderText = "created_at";
            colcreated_at.MinimumWidth = 6;
            colcreated_at.Name = "colcreated_at";
            colcreated_at.Visible = false;
            // 
            // colupdated_at
            // 
            colupdated_at.DataPropertyName = "updated_at";
            colupdated_at.HeaderText = "updated_at";
            colupdated_at.MinimumWidth = 6;
            colupdated_at.Name = "colupdated_at";
            colupdated_at.Visible = false;
            // 
            // colstatus
            // 
            colstatus.DataPropertyName = "status";
            colstatus.HeaderText = "status";
            colstatus.MinimumWidth = 6;
            colstatus.Name = "colstatus";
            colstatus.Visible = false;
            // 
            // colhistory
            // 
            colhistory.DataPropertyName = "history";
            colhistory.HeaderText = "history";
            colhistory.MinimumWidth = 6;
            colhistory.Name = "colhistory";
            colhistory.Visible = false;
            // 
            // colid
            // 
            colid.DataPropertyName = "id";
            colid.HeaderText = "id";
            colid.MinimumWidth = 6;
            colid.Name = "colid";
            colid.Visible = false;
            // 
            // colmo_id
            // 
            colmo_id.DataPropertyName = "mo_id";
            colmo_id.HeaderText = "mo id";
            colmo_id.MinimumWidth = 6;
            colmo_id.Name = "colmo_id";
            colmo_id.Visible = false;
            // 
            // colitem_number
            // 
            colitem_number.DataPropertyName = "item_number";
            colitem_number.HeaderText = "item number";
            colitem_number.MinimumWidth = 6;
            colitem_number.Name = "colitem_number";
            colitem_number.Visible = false;
            // 
            // colgroup
            // 
            colgroup.DataPropertyName = "group";
            colgroup.HeaderText = "group";
            colgroup.MinimumWidth = 6;
            colgroup.Name = "colgroup";
            colgroup.Visible = false;
            // 
            // colkit_list_status_item
            // 
            colkit_list_status_item.DataPropertyName = "kit_list_item_status_id";
            colkit_list_status_item.HeaderText = "kitlist status item";
            colkit_list_status_item.MinimumWidth = 6;
            colkit_list_status_item.Name = "colkit_list_status_item";
            colkit_list_status_item.Visible = false;
            // 
            // bunifuloading
            // 
            bunifuloading.Anchor = AnchorStyles.Top;
            bunifuloading.Image = (Image)resources.GetObject("bunifuloading.Image");
            bunifuloading.Location = new Point(612, 296);
            bunifuloading.Name = "bunifuloading";
            bunifuloading.Size = new Size(161, 140);
            bunifuloading.SizeMode = PictureBoxSizeMode.StretchImage;
            bunifuloading.TabIndex = 1;
            bunifuloading.TabStop = false;
            // 
            // Warehousekitting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1390, 747);
            Controls.Add(bunifuloading);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(txtmo_number);
            Controls.Add(label2);
            Controls.Add(btnscan);
            Controls.Add(btnAddSerial);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Warehousekitting";
            Text = "Warehousekitting";
            Load += Warehousekitting_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bunifuloading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnAddSerial;
        private Button btnscan;
        private Label label2;
        private TextBox txtmo_number;
        private Panel panel2;
        private Button btnserial;
        private Button btncomplete;
        private DataGridView dataGridView1;
        private TextBox txtserial_number;
        private Label lbl_rowcount;
        private Label label3;
        private Button btnincomplete;
        private DataGridViewTextBoxColumn colipn;
        private DataGridViewTextBoxColumn coldescription;
        private DataGridViewTextBoxColumn coltype;
        private DataGridViewTextBoxColumn colmfg;
        private DataGridViewTextBoxColumn colmfgprodcode;
        private DataGridViewTextBoxColumn collocation;
        private DataGridViewTextBoxColumn colstock;
        private DataGridViewTextBoxColumn colunitqty;
        private DataGridViewTextBoxColumn colmoqty;
        private DataGridViewTextBoxColumn colwipqty;
        private DataGridViewTextBoxColumn colpickqty;
        private DataGridViewTextBoxColumn colshortqty;
        private DataGridViewTextBoxColumn colkit_quantity;
        private DataGridViewTextBoxColumn colrecieved_quantity;
        private DataGridViewTextBoxColumn colreject_quantity;
        private DataGridViewTextBoxColumn colunit;
        private DataGridViewTextBoxColumn colinvoicenumber;
        private DataGridViewTextBoxColumn colkitted;
        private DataGridViewTextBoxColumn colindividualkitted;
        private DataGridViewTextBoxColumn coltrack;
        private DataGridViewTextBoxColumn colrack;
        private DataGridViewTextBoxColumn colcomment;
        private DataGridViewTextBoxColumn colcreated_at;
        private DataGridViewTextBoxColumn colupdated_at;
        private DataGridViewTextBoxColumn colstatus;
        private DataGridViewTextBoxColumn colhistory;
        private DataGridViewTextBoxColumn colid;
        private DataGridViewTextBoxColumn colmo_id;
        private DataGridViewTextBoxColumn colitem_number;
        private DataGridViewTextBoxColumn colgroup;
        private DataGridViewTextBoxColumn colkit_list_status_item;
        private Button btnnext;
        private Button btnprevious_page;
        private PictureBox bunifuloading;
    }
}