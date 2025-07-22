using System.Data;
<<<<<<< HEAD
using System.Diagnostics;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
=======
using BTC_EnterpriseV2.Class;
>>>>>>> origin/newUpdate
using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ViewScanedDetails : Form
    {
        private string ApiUrl = GlobalApi.GetScanSerialUrl();
        public string serialnumber;
        public string processname;
        public string moid;
        public int rowindex;
        public string qty;
        public string count;
        public string processId;
        public int tempqty = 0;
        public int tempcount = 0;
<<<<<<< HEAD
        DataTable dtSerial;
        public ViewScanedDetails(int rowindex, string processid, string processname, string generatedseril, string qty, string count,DataTable dtserial)
=======
        private DataTable data_items;

        public ViewScanedDetails(int rowindex, string processid, string processname, string generatedserial, DataTable dtitems)
>>>>>>> origin/newUpdate
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedButton(btnClose, 6, Color.DarkSlateBlue);
            this.rowindex = rowindex;
            this.processId = processid;
            this.lbl_processname.Text = "Scanned Items of : " + processname;
            this.qty = qty;
            this.count = count;
<<<<<<< HEAD
            this.serialnumber = generatedseril;
            dtSerial = dtserial;
=======
            this.serialnumber = generatedserial;
            this.data_items = dtitems;
>>>>>>> origin/newUpdate
        }

        private async void ViewScanedDetails_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            LoadProcessData(dtSerial);
            //lbl_generatedserial.Text = serialnumber;
            //int myprocessid = int.Parse(processId);
            //await Get_ScannedItems(serialnumber, myprocessid);
=======
            lbl_generatedserial.Text = serialnumber;
            int myprocessid = int.Parse(processId);
            LoadProcessData(data_items);
            //  await Get_ScannedItems(serialnumber, myprocessid);
>>>>>>> origin/newUpdate
        }




        private void LoadProcessData(DataTable items)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("NoProcess", "No.");
            dataGridView1.Columns.Add("serial_number", "Item Serial Number");

            dataGridView1.Columns["NoProcess"].Width = 50;

            int index = 1;
            foreach (DataRow serial in items.Rows)
            {
                dataGridView1.Rows.Add(index++, serial[2]);
            }
        }
        private void LoadProcessData(DataTable dt)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("NoProcess", "No.");
            dataGridView1.Columns.Add("serial_number", "Item Serial Number");

            dataGridView1.Columns["NoProcess"].Width = 50;

            int index = 1;
            foreach (DataRow serial in dt.Rows)
            {
                if (processId == serial[1].ToString())
                {
                    dataGridView1.Rows.Add(index++, serial[2]);
                }
                
            }
        }




















        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
