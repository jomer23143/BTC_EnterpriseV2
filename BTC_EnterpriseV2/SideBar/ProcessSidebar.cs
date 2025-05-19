using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.Forms;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.SideBar
{
    public partial class ProcessSidebar : Form
    {
        private object id = new object();
        private object jsonResponse = new object();
        public string? themoid;
        public string? segment;

        public ProcessSidebar(object id, string segment, string moid)
        {
            InitializeComponent();
            lbl_process.Text = segment;
            this.id = id ?? throw new ArgumentNullException(nameof(id)); // Ensure 'id' is not null
            Process_Panel.AutoScroll = true;
            this.themoid = moid ?? throw new ArgumentNullException(nameof(moid)); // Ensure 'moid' is not null
            this.segment = segment ?? throw new ArgumentNullException(nameof(segment)); // Ensure 'segment' is not null

            // Fix: Ensure id.ToString() is not null before passing it to Myrequest
            string idString = id.ToString() ?? throw new ArgumentNullException(nameof(id), "id.ToString() returned null");
            Myrequest(idString, themoid);
        }


        private async void Myrequest(string moidmodid, string boomid)
        {
            string jsonResponse = "";

            try
            {
                string apiUrl = $"https://app.btcp-enterprise.com/api/product-segment-process?product_segment_id=1";
                // string postData = $"https://app.btcp-enterprise.com/api/product?bom_item={boomid}&with_segment={id}&with_process={id}";
                Console.WriteLine($"API URL: {apiUrl}");

                jsonResponse = await WebRequestApi.GetData_httpclient(apiUrl);

                Console.WriteLine($"Raw API Response: {jsonResponse}");

                if (string.IsNullOrEmpty(jsonResponse) || jsonResponse.Trim().StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //var root = JsonConvert.DeserializeObject<Root>(jsonResponse);

                var processList = JsonConvert.DeserializeObject<List<ProcessSidebar_Model.ProcessItem>>(jsonResponse);

                //if (root?.data == null || root.data.Count == 0)
                //{
                //    MessageBox.Show("No valid data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //var firstDatum = root.data[0];

                //if (firstDatum.segment == null || firstDatum.segment.Count == 0)
                //{
                //    MessageBox.Show("No segment data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //    var segment = firstDatum.segment[0];

                //if (segment.process == null || segment.process.Count == 0)
                //{
                //    MessageBox.Show("No process data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //// UI updates
                //Process_Panel.Invoke((MethodInvoker)(() =>
                //{
                //    Process_Panel.Controls.Clear();

                //    foreach (var proc in segment.process)
                //    {
                //        Button btn = new Button
                //        {
                //            Text = proc.name,
                //            Width = 220,
                //            Height = 60,
                //            BackColor = Color.SteelBlue,
                //            Font = new Font("Arial", 10, FontStyle.Bold),
                //            Cursor = Cursors.Hand,
                //            ForeColor = Color.White,
                //            FlatStyle = FlatStyle.Flat,
                //            Tag = proc.id
                //        };
                //        btn.FlatAppearance.BorderSize = 0;
                //        btn.Click += ProcessButton_Click;

                //        Process_Panel.Controls.Add(btn);
                //    }
                //}));
                if (processList == null || processList.Count == 0)
                {
                    MessageBox.Show("No process data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Process_Panel.Invoke((MethodInvoker)(() =>
                {
                    Process_Panel.Controls.Clear();

                    foreach (var proc in processList)
                    {
                        Button btn = new Button
                        {
                            Text = proc.name,
                            Width = 220,
                            Height = 60,
                            BackColor = Color.SteelBlue,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            Cursor = Cursors.Hand,
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Tag = proc.id
                        };
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Click += ProcessButton_Click;

                        Process_Panel.Controls.Add(btn);
                    }
                }));


            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse: {jsonResponse}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ProcessButton_Click(object sender, EventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Safely retrieve the MainDashboard instance from Application.OpenForms
                if (Application.OpenForms["MainDashboard"] is MainDashboard mainDashboard)
                {
                    string processId = clickedButton.Tag?.ToString() ?? string.Empty; // Ensure processId is not null
                    string processName = clickedButton.Text ?? string.Empty; // Ensure processName is not null
                    string moid = this.themoid ?? string.Empty; // Ensure themoid is not null
                    string seg = segment ?? string.Empty; // Ensure segment is not null
                    string serialnumber = string.Empty;
                    string toplvlipn = string.Empty;
                    string generatedcode = "SUBD1C500DS24A0001";

                    //ProcessForm.Sub_assyfrm subasy = new ProcessForm.Sub_assyfrm(moid, serialnumber, toplvlipn, seg, processName, generatedcode);
                    //mainDashboard.LoadChildForm(subasy);
                }
                else
                {
                    MessageBox.Show("MainDashboard form is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
