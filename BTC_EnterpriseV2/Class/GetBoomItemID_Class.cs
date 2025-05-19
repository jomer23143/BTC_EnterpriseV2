using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Class
{
    internal class GetBoomItemID_Class
    {
        private object jsonResponse;

        public class MO_data
        {
            public int id { get; set; }
            public object kit_list_type_id { get; set; }
            public int kit_list_status_id { get; set; }
            public string mo_id { get; set; }
            public object pcn_number { get; set; }
            public string description { get; set; }
            public string location { get; set; }
            public string bom_item { get; set; }
            public string bom_revision_number { get; set; }
            public string order_quantity { get; set; }
            public string order_date { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public object status { get; set; }
        }

        public class MO_response
        {
            public int current_page { get; set; }
            public List<MO_data> data { get; set; }
        }


        public async Task<object[]> getBoomID(string moid)
        {
            object[] rtrn_data = new object[1];
            try
            {
                string api_url = $"https://app.btcp-enterprise.com/api/kit-list?mo_id={moid}";

                string jsonResponse = await WebRequestApi.GetData_httpclient(api_url);

                Console.WriteLine($"Raw API Response: {jsonResponse}");

                if (string.IsNullOrEmpty(jsonResponse) || jsonResponse.Trim().StartsWith("<"))
                {
                    var type = CustomeAlert.Alertype.Warning;
                    var alert = new Modal.CustomeAlert("API ERROR", "Invalid response from server.", type);
                    alert.ShowDialog();
                    //  return;
                }

                var result = JsonConvert.DeserializeObject<MO_response>(jsonResponse);
                var moItem = result?.data?.FirstOrDefault()?.bom_item;

                if (string.IsNullOrEmpty(moItem))
                {
                    MessageBox.Show("BOM Item not found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // return;
                }
                rtrn_data[0] = moItem;
                Console.WriteLine($"BOM Item: {moItem}");

                // Use moItem as needed
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse: {jsonResponse}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                var type = CustomeAlert.Alertype.Warning;
                var alert = new Modal.CustomeAlert("API ERROR", ex.Message, type);
                alert.ShowDialog();
            }
            return rtrn_data;
        }
    }
}
