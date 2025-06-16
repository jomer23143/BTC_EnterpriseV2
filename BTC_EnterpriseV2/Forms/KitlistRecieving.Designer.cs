namespace BTC_EnterpriseV2.Forms
{
    partial class KitlistRecieving
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitlistRecieving));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            txtmo_number = new TextBox();
            panel2 = new Panel();
            btncomplete = new Button();
            dataGridView1 = new DataGridView();
            Pb_loading = new PictureBox();
            colstatus_item = new DataGridViewCheckBoxColumn();
            colpart_serial = new DataGridViewTextBoxColumn();
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
            colkit_list_id = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Pb_loading).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(22, 27, 45);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1088, 44);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(100, 180, 45);
            label1.Location = new Point(10, 14);
            label1.Name = "label1";
            label1.Size = new Size(159, 23);
            label1.TabIndex = 0;
            label1.Text = "Kit List Recieving";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 61);
            label2.Name = "label2";
            label2.Size = new Size(105, 21);
            label2.TabIndex = 1;
            label2.Text = "MO Number :";
            // 
            // txtmo_number
            // 
            txtmo_number.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtmo_number.Location = new Point(129, 56);
            txtmo_number.Margin = new Padding(3, 2, 3, 2);
            txtmo_number.Name = "txtmo_number";
            txtmo_number.Size = new Size(364, 32);
            txtmo_number.TabIndex = 2;
            txtmo_number.TextChanged += textBox1_TextChanged;
            txtmo_number.KeyDown += txtmo_number_KeyDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(btncomplete);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 471);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1088, 48);
            panel2.TabIndex = 3;
            // 
            // btncomplete
            // 
            btncomplete.BackColor = Color.FromArgb(109, 180, 62);
            btncomplete.Cursor = Cursors.Hand;
            btncomplete.FlatAppearance.BorderSize = 0;
            btncomplete.FlatAppearance.MouseOverBackColor = Color.Lime;
            btncomplete.FlatStyle = FlatStyle.Flat;
            btncomplete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncomplete.ForeColor = Color.White;
            btncomplete.Location = new Point(10, 5);
            btncomplete.Margin = new Padding(3, 2, 3, 2);
            btncomplete.Name = "btncomplete";
            btncomplete.Size = new Size(159, 34);
            btncomplete.TabIndex = 0;
            btncomplete.Text = "Save";
            btncomplete.UseVisualStyleBackColor = false;
            btncomplete.Click += btncomplete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.DimGray;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.DimGray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colstatus_item, colpart_serial, colipn, coldescription, coltype, colmfg, colmfgprodcode, collocation, colstock, colunitqty, colmoqty, colwipqty, colpickqty, colshortqty, colkit_quantity, colrecieved_quantity, colreject_quantity, colunit, colinvoicenumber, colkitted, colindividualkitted, coltrack, colrack, colcomment, colcreated_at, colupdated_at, colstatus, colhistory, colid, colmo_id, colitem_number, colgroup, colkit_list_id });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(10, 86);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1068, 380);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // Pb_loading
            // 
            Pb_loading.Anchor = AnchorStyles.Top;
            Pb_loading.Image = (Image)resources.GetObject("Pb_loading.Image");
            Pb_loading.Location = new Point(478, 230);
            Pb_loading.Margin = new Padding(3, 2, 3, 2);
            Pb_loading.Name = "Pb_loading";
            Pb_loading.Size = new Size(133, 114);
            Pb_loading.SizeMode = PictureBoxSizeMode.StretchImage;
            Pb_loading.TabIndex = 5;
            Pb_loading.TabStop = false;
            // 
            // colstatus_item
            // 
            colstatus_item.HeaderText = " Check(if complete)";
            colstatus_item.MinimumWidth = 6;
            colstatus_item.Name = "colstatus_item";
            colstatus_item.Resizable = DataGridViewTriState.True;
            colstatus_item.SortMode = DataGridViewColumnSortMode.Automatic;
            colstatus_item.Width = 125;
            // 
            // colpart_serial
            // 
            colpart_serial.DataPropertyName = "part_serial";
            colpart_serial.HeaderText = "Serial Number";
            colpart_serial.MinimumWidth = 6;
            colpart_serial.Name = "colpart_serial";
            colpart_serial.Visible = false;
            colpart_serial.Width = 125;
            // 
            // colipn
            // 
            colipn.DataPropertyName = "ipn";
            colipn.HeaderText = "Internal PN";
            colipn.MinimumWidth = 6;
            colipn.Name = "colipn";
            colipn.Width = 125;
            // 
            // coldescription
            // 
            coldescription.DataPropertyName = "description";
            coldescription.HeaderText = "Description";
            coldescription.MinimumWidth = 6;
            coldescription.Name = "coldescription";
            coldescription.Width = 125;
            // 
            // coltype
            // 
            coltype.DataPropertyName = "type";
            coltype.HeaderText = "Type";
            coltype.MinimumWidth = 6;
            coltype.Name = "coltype";
            coltype.Width = 125;
            // 
            // colmfg
            // 
            colmfg.DataPropertyName = "manufacturing";
            colmfg.HeaderText = "Mfg";
            colmfg.MinimumWidth = 6;
            colmfg.Name = "colmfg";
            colmfg.Visible = false;
            colmfg.Width = 125;
            // 
            // colmfgprodcode
            // 
            colmfgprodcode.DataPropertyName = "manufacturing_product_code";
            colmfgprodcode.HeaderText = "Mfg Product Code";
            colmfgprodcode.MinimumWidth = 6;
            colmfgprodcode.Name = "colmfgprodcode";
            colmfgprodcode.Visible = false;
            colmfgprodcode.Width = 125;
            // 
            // collocation
            // 
            collocation.DataPropertyName = "source_location";
            collocation.HeaderText = "Location";
            collocation.MinimumWidth = 6;
            collocation.Name = "collocation";
            collocation.Visible = false;
            collocation.Width = 125;
            // 
            // colstock
            // 
            colstock.DataPropertyName = "stock";
            colstock.HeaderText = "Stock";
            colstock.MinimumWidth = 6;
            colstock.Name = "colstock";
            colstock.Visible = false;
            colstock.Width = 125;
            // 
            // colunitqty
            // 
            colunitqty.DataPropertyName = "unit_quantity";
            colunitqty.HeaderText = "Unit Quantity";
            colunitqty.MinimumWidth = 6;
            colunitqty.Name = "colunitqty";
            colunitqty.Visible = false;
            colunitqty.Width = 125;
            // 
            // colmoqty
            // 
            colmoqty.DataPropertyName = "mo_quantity";
            colmoqty.HeaderText = "MO Quantity";
            colmoqty.MinimumWidth = 6;
            colmoqty.Name = "colmoqty";
            colmoqty.Visible = false;
            colmoqty.Width = 125;
            // 
            // colwipqty
            // 
            colwipqty.DataPropertyName = "wip_quantity";
            colwipqty.HeaderText = "WIP Quantity";
            colwipqty.MinimumWidth = 6;
            colwipqty.Name = "colwipqty";
            colwipqty.Visible = false;
            colwipqty.Width = 125;
            // 
            // colpickqty
            // 
            colpickqty.DataPropertyName = "pick_quantity";
            colpickqty.HeaderText = "Pick Quantity";
            colpickqty.MinimumWidth = 6;
            colpickqty.Name = "colpickqty";
            colpickqty.Width = 125;
            // 
            // colshortqty
            // 
            colshortqty.DataPropertyName = "short_quantity";
            colshortqty.HeaderText = "Short Quantity";
            colshortqty.MinimumWidth = 6;
            colshortqty.Name = "colshortqty";
            colshortqty.Width = 125;
            // 
            // colkit_quantity
            // 
            colkit_quantity.HeaderText = "Kit Quantity";
            colkit_quantity.MinimumWidth = 6;
            colkit_quantity.Name = "colkit_quantity";
            colkit_quantity.Visible = false;
            colkit_quantity.Width = 125;
            // 
            // colrecieved_quantity
            // 
            colrecieved_quantity.HeaderText = "Recieved Quantity";
            colrecieved_quantity.MinimumWidth = 6;
            colrecieved_quantity.Name = "colrecieved_quantity";
            colrecieved_quantity.Visible = false;
            colrecieved_quantity.Width = 125;
            // 
            // colreject_quantity
            // 
            colreject_quantity.HeaderText = "Reject Quantity";
            colreject_quantity.MinimumWidth = 6;
            colreject_quantity.Name = "colreject_quantity";
            colreject_quantity.Visible = false;
            colreject_quantity.Width = 125;
            // 
            // colunit
            // 
            colunit.DataPropertyName = "unit";
            colunit.HeaderText = "Unit UOM";
            colunit.MinimumWidth = 6;
            colunit.Name = "colunit";
            colunit.Width = 125;
            // 
            // colinvoicenumber
            // 
            colinvoicenumber.DataPropertyName = "invoice_number";
            colinvoicenumber.HeaderText = "Invoice #";
            colinvoicenumber.MinimumWidth = 6;
            colinvoicenumber.Name = "colinvoicenumber";
            colinvoicenumber.Visible = false;
            colinvoicenumber.Width = 125;
            // 
            // colkitted
            // 
            colkitted.DataPropertyName = "kitted";
            colkitted.HeaderText = "Kittted";
            colkitted.MinimumWidth = 6;
            colkitted.Name = "colkitted";
            colkitted.Width = 125;
            // 
            // colindividualkitted
            // 
            colindividualkitted.DataPropertyName = "individual_kitting";
            colindividualkitted.HeaderText = "Individual Kitted";
            colindividualkitted.MinimumWidth = 6;
            colindividualkitted.Name = "colindividualkitted";
            colindividualkitted.Visible = false;
            colindividualkitted.Width = 125;
            // 
            // coltrack
            // 
            coltrack.DataPropertyName = "track";
            coltrack.HeaderText = "Track";
            coltrack.MinimumWidth = 6;
            coltrack.Name = "coltrack";
            coltrack.Width = 125;
            // 
            // colrack
            // 
            colrack.DataPropertyName = "rack";
            colrack.HeaderText = "Rack";
            colrack.MinimumWidth = 6;
            colrack.Name = "colrack";
            colrack.Visible = false;
            colrack.Width = 125;
            // 
            // colcomment
            // 
            colcomment.DataPropertyName = "comment";
            colcomment.HeaderText = "Comment";
            colcomment.MinimumWidth = 6;
            colcomment.Name = "colcomment";
            colcomment.Width = 125;
            // 
            // colcreated_at
            // 
            colcreated_at.DataPropertyName = "created_at";
            colcreated_at.HeaderText = "created_at";
            colcreated_at.MinimumWidth = 6;
            colcreated_at.Name = "colcreated_at";
            colcreated_at.Visible = false;
            colcreated_at.Width = 125;
            // 
            // colupdated_at
            // 
            colupdated_at.DataPropertyName = "updated_at";
            colupdated_at.HeaderText = "updated_at";
            colupdated_at.MinimumWidth = 6;
            colupdated_at.Name = "colupdated_at";
            colupdated_at.Visible = false;
            colupdated_at.Width = 125;
            // 
            // colstatus
            // 
            colstatus.DataPropertyName = "status";
            colstatus.HeaderText = "status";
            colstatus.MinimumWidth = 6;
            colstatus.Name = "colstatus";
            colstatus.Visible = false;
            colstatus.Width = 125;
            // 
            // colhistory
            // 
            colhistory.DataPropertyName = "history";
            colhistory.HeaderText = "history";
            colhistory.MinimumWidth = 6;
            colhistory.Name = "colhistory";
            colhistory.Visible = false;
            colhistory.Width = 125;
            // 
            // colid
            // 
            colid.DataPropertyName = "id";
            colid.HeaderText = "id";
            colid.MinimumWidth = 6;
            colid.Name = "colid";
            colid.Visible = false;
            colid.Width = 125;
            // 
            // colmo_id
            // 
            colmo_id.DataPropertyName = "mo_id";
            colmo_id.HeaderText = "mo id";
            colmo_id.MinimumWidth = 6;
            colmo_id.Name = "colmo_id";
            colmo_id.Visible = false;
            colmo_id.Width = 125;
            // 
            // colitem_number
            // 
            colitem_number.DataPropertyName = "item_number";
            colitem_number.HeaderText = "item number";
            colitem_number.MinimumWidth = 6;
            colitem_number.Name = "colitem_number";
            colitem_number.Visible = false;
            colitem_number.Width = 125;
            // 
            // colgroup
            // 
            colgroup.DataPropertyName = "group";
            colgroup.HeaderText = "group";
            colgroup.MinimumWidth = 6;
            colgroup.Name = "colgroup";
            colgroup.Visible = false;
            colgroup.Width = 125;
            // 
            // colkit_list_id
            // 
            colkit_list_id.DataPropertyName = "kit_list_item_status_id";
            colkit_list_id.HeaderText = "kit_list_id";
            colkit_list_id.MinimumWidth = 6;
            colkit_list_id.Name = "colkit_list_id";
            colkit_list_id.Visible = false;
            colkit_list_id.Width = 125;
            // 
            // KitlistRecieving
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1088, 519);
            Controls.Add(Pb_loading);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(txtmo_number);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "KitlistRecieving";
            Text = "KitlistRecieving";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Pb_loading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox txtmo_number;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button btncomplete;
        private PictureBox Pb_loading;
        private DataGridViewCheckBoxColumn colstatus_item;
        private DataGridViewTextBoxColumn colpart_serial;
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
        private DataGridViewTextBoxColumn colkit_list_id;
    }
}