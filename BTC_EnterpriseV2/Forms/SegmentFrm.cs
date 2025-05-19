using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.Forms;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Forms
{

    public partial class SegmentFrm : Form
    {
        public string? boom_item;
        private object jsonResponse = new object();
        public SegmentFrm(string moid)
        {
            InitializeComponent();
            this.boom_item = moid;
        }

        private void SegmentFrm_Load(object sender, EventArgs e)
        {
            Console.WriteLine($"MOID: {boom_item}");
            lbl_Test.Text = boom_item;
            string url = $"https://app.btcp-enterprise.com/api/product?with_segment={boom_item}";
            RequesTProductSegment(url, boom_item);
        }

        private async void RequesTProductSegment(string apiUrl, string moid)
        {
            try
            {
                string jsonResponse = await WebRequestApi.GetData_httpclient(apiUrl);

                Console.WriteLine($"Raw API Response: {jsonResponse}");

                if (string.IsNullOrEmpty(jsonResponse) || jsonResponse.Trim().StartsWith("<"))
                {
                    CustomeAlert.Alertype type = CustomeAlert.Alertype.Warning;
                    Modal.CustomeAlert alert = new Modal.CustomeAlert("API ERROR", "Invalid response from server.", type);
                    alert.ShowDialog();
                    return;
                }

                var root = JsonConvert.DeserializeObject<Segment_Model.Root>(jsonResponse);
                var response = root?.data?.FirstOrDefault()?.segment;


                if (response == null || response.Count == 0)
                {

                    CustomeAlert.Alertype type = CustomeAlert.Alertype.Warning;
                    Modal.CustomeAlert alert = new Modal.CustomeAlert("Attention: API Error", "No data available\", \"We couldn't find any items for your request.", type);
                    alert.ShowDialog();
                    return;
                }

                flowlayoutsegment.Invoke((MethodInvoker)(() =>
                {
                    flowlayoutsegment.Controls.Clear();

                    Panel loadingContainer = new Panel
                    {
                        Width = flowlayoutsegment.ClientSize.Width,
                        Height = flowlayoutsegment.ClientSize.Height,
                        BackColor = Color.Transparent // optional
                    };


                    pb_loading.Location = new Point(
                        (loadingContainer.Width - pb_loading.Width) / 10,
                        (loadingContainer.Height - pb_loading.Height) / 10
                    );
                    pb_loading.Visible = true;


                    loadingContainer.Controls.Add(pb_loading);
                    flowlayoutsegment.Controls.Add(loadingContainer);

                    flowlayoutsegment.Controls.Clear();

                    foreach (var process in response)
                    {
                        Button btn = new Button
                        {
                            Text = $"{process.name}",
                            Width = 440,
                            Height = 100,
                            BackColor = process.is_active == 1 ? Color.FromArgb(100, 180, 45) : Color.SeaGreen,
                            Font = new Font("Arial", 14, FontStyle.Bold),
                            Cursor = Cursors.Hand,
                            ForeColor = Color.White,
                            Enabled = process.is_active == 1,
                            FlatAppearance = { BorderSize = 0 },
                            FlatStyle = FlatStyle.Flat,
                            Tag = process.id
                        };

                        btn.Click += ProcessButton_Click;
                        flowlayoutsegment.Controls.Add(btn);
                    }


                    pb_loading.Visible = false;
                }));
            }

            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse: {jsonResponse}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                CustomeAlert.Alertype type = CustomeAlert.Alertype.Warning;
                Modal.CustomeAlert alert = new Modal.CustomeAlert("API ERROR", ex.Message, type);
                alert.ShowDialog();

            }
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                MainDashboard mainDashboard = (MainDashboard)Application.OpenForms["MainDashboard"];
                object processId = clickedButton.Tag;
                string processName = clickedButton.Text;
                SideBar.ProcessSidebar process = new SideBar.ProcessSidebar(processId, processName, lbl_Test.Text);
                mainDashboard.LoadSideBar(process);
            }
        }


    }
}
