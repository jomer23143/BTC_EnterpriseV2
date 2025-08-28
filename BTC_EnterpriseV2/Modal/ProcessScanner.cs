using System.Data;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.ProcessForm;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ProcessScanner : Form
    {
        public string serialnumber;
        public string processname;
        public string moid;
        public int rowindex;
        public string qty;
        public string count;
        public string processId;
        public int tempqty = 0;
        public int tempcount = 0;
        public event Action<string?> SerialScanned = delegate { };
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        private string PostMaterial = GlobalApi.GetPostMaterialAssignSerialUrl();
        private int is_kit_list = 0;
        private DataTable dataserials;
        public ProcessScanner(int rowindex, string processid, string processname, string generatedseril, string qty, string count, int iskitlist, DataTable table_serials)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            // yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedTextBox(txt_serialnumber, 6, Color.White);
            yUI.RoundedPanelDocker(panel_processname, 6);
            this.rowindex = rowindex;
            this.processId = processid;
            this.lbl_processname.Text = processname;
            this.qty = qty;
            this.count = count;
            this.serialnumber = generatedseril;
            this.is_kit_list = iskitlist;
            this.dataserials = table_serials;
            lbl_msg.Text = "Please scan the serial number of the item to be processed.";
        }

        private async void ProcessScanner_Load(object sender, EventArgs e)
        {
            tempqty = int.Parse(qty);
            tempcount = int.Parse(count);
            lbl_scancount.Text = count + " out of " + qty;
            lbl_generatedserial.Text = serialnumber;
            int myprocessid = int.Parse(processId);
            LoadProcessData(dataserials);
        }

        private void LoadProcessData(DataTable serials)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("NoProcess", "No.");
            dataGridView1.Columns.Add("serial_number", "Item Serial Number");
            dataGridView1.Columns["NoProcess"].Width = 50;

            int index = 1;
            foreach (DataRow serial in serials.Rows)
            {
                if (processId == serial[1].ToString())
                {
                    dataGridView1.Rows.Add(index++, serial[2]);
                }
            }
        }

        private async void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_serialnumber.Text))
                {
                    MessageBox.Show("Please enter a serial number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tempcount < tempqty)
                {
                    await PostItemSerial(
                        lbl_generatedserial.Text,
                        processId
                    );

                    txt_serialnumber.Clear();

                    lbl_scancount.Text = $"{tempcount} out of {tempqty}";


                    if (tempcount == tempqty)
                    {
                        string viewImagePath = Path.Combine(Application.StartupPath, "Assets", "viewsacn.png");
                        Image viewImage = Image.FromFile(viewImagePath);
                        Image resizedImage2 = ResizeImage(viewImage, 60, 60);

                        Sub_AssyFrm.instance.dgv1.Rows[rowindex].Cells["ScanItemSerial"].Value = resizedImage2;

                        Image ResizeImage(Image img, int width, int height)
                        {
                            Bitmap bmp = new Bitmap(width, height);
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                g.DrawImage(img, 0, 0, width, height);
                            }
                            return bmp;
                        }
                        //   Sub_AssyFrm.dtserials = dataserials;
                    }
                }
                else
                {
                    MessageBox.Show("You have already met the required number of items.", "Scanning Validator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_serialnumber_TextChanged(object sender, EventArgs e)
        {

        }

        public async Task PostItemSerial(string serial, string processid)
        {
            try
            {
                // Sanitize inputs
                var postData = new
                {
                    serial = processid.Trim(),
                    material_id = serial.Trim(),

                };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(PostMaterial, json);

                // Check if the response is empty or invalid HTML
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    ShowMessage("Invalid response from server.", Color.Red);
                    return;
                }
                var token = JToken.Parse(jsonResponse);

                // Handle object-based response (likely error/info)
                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    string message = token["message"]?.ToString();
                    string kitSerialError = token["errors"]?["kit_serial"]?.FirstOrDefault()?.ToString();

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        ShowMessage(message, Color.Orange);
                    }
                    else if (!string.IsNullOrWhiteSpace(kitSerialError))
                    {
                        ShowMessage(kitSerialError, Color.Red);
                    }
                    else
                    {
                        ShowMessage("An unknown error occurred.", Color.Red);
                    }

                    return;
                }
                // Handle array-based response (expected successful data)
                if (token.Type == JTokenType.Array)
                {
                    List<Sub_Asy_Process_Model.Root> result;
                    try
                    {
                        result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    }
                    catch (Exception parseEx)
                    {
                        ShowMessage("Failed to parse process data.", Color.Red);
                        //  Debug.WriteLine("Parse Error: " + parseEx);
                        return;
                    }

                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        ShowMessage("No valid process data returned.", Color.Red);
                        return;
                    }
                    lbl_generatedserial.Text = data.serial_number;

                    bool exists = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Any(r => r.Cells["serial_number"].Value?.ToString() == data.serial_number);

                    if (!exists)
                    {
                        tempcount++;
                        int rowNumber = dataGridView1.Rows.Count + 1;
                        dataGridView1.Rows.Add(rowNumber, is_kit_list);

                        int index = 0;
                        dataserials.Rows.Add(index++, processId, txt_serialnumber.Text.Trim());
                        Sub_AssyFrm.instance.dgv1.Rows[rowindex].Cells["serial_count"].Value = tempcount;

                        //ShowMessage("Kitlist Part Number is Available.", Color.Green);
                    }
                    else
                    {
                        ShowMessage("This serial number has already been scanned.", Color.Orange);
                    }


                }
                else
                {
                    ShowMessage("Unexpected response format.", Color.Red);
                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Color.Orange);
            }

        }

        public async Task Get_Process_response(string serial, string processid, string kitserial, int iskitlist)
        {
            try
            {
                // Sanitize inputs
                var postData = new
                {
                    process_id = processid.Trim(),
                    kit_serial = kitserial.Trim(),
                    serial_number = serial.Trim(),
                    is_kit_list = iskitlist
                };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);

                // Check if the response is empty or invalid HTML
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    ShowMessage("Invalid response from server.", Color.Red);
                    return;
                }
                var token = JToken.Parse(jsonResponse);

                // Handle object-based response (likely error/info)
                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    string message = token["message"]?.ToString();
                    string kitSerialError = token["errors"]?["kit_serial"]?.FirstOrDefault()?.ToString();

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        ShowMessage(message, Color.Orange);
                    }
                    else if (!string.IsNullOrWhiteSpace(kitSerialError))
                    {
                        ShowMessage(kitSerialError, Color.Red);
                    }
                    else
                    {
                        ShowMessage("An unknown error occurred.", Color.Red);
                    }

                    return;
                }
                // Handle array-based response (expected successful data)
                if (token.Type == JTokenType.Array)
                {
                    List<Sub_Asy_Process_Model.Root> result;
                    try
                    {
                        result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    }
                    catch (Exception parseEx)
                    {
                        ShowMessage("Failed to parse process data.", Color.Red);
                        //  Debug.WriteLine("Parse Error: " + parseEx);
                        return;
                    }

                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        ShowMessage("No valid process data returned.", Color.Red);
                        return;
                    }
                    lbl_generatedserial.Text = data.serial_number;

                    bool exists = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Any(r => r.Cells["serial_number"].Value?.ToString() == data.serial_number);

                    if (!exists)
                    {
                        tempcount++;
                        int rowNumber = dataGridView1.Rows.Count + 1;
                        dataGridView1.Rows.Add(rowNumber, kitserial);

                        int index = 0;
                        dataserials.Rows.Add(index++, processId, txt_serialnumber.Text.Trim());
                        Sub_AssyFrm.instance.dgv1.Rows[rowindex].Cells["serial_count"].Value = tempcount;

                        //ShowMessage("Kitlist Part Number is Available.", Color.Green);
                    }
                    else
                    {
                        ShowMessage("This serial number has already been scanned.", Color.Orange);
                    }


                }
                else
                {
                    ShowMessage("Unexpected response format.", Color.Red);
                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Color.Orange);
            }

        }

        private void ShowMessage(string message, Color color)
        {
            lbl_msg.ForeColor = color;
            lbl_msg.Text = message;
        }




    }
}
