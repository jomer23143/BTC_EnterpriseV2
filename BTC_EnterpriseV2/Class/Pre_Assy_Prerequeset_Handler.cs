using System.Diagnostics;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Class
{
    public class Pre_Assy_Prerequeset_Handler
    {
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        public async Task<int> CheckPrerequesit(string serial, int station, int sequence)
        {
            try
            {
                var postData = new
                {
                    serial_number = serial.Trim(),
                    station = station,
                    sequence_number = sequence
                };

                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                // Send API request
                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
                Debug.WriteLine("Response: " + jsonResponse);

                // Validate response
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1; // -1 = error
                }

                var items = JsonConvert.DeserializeObject<List<Sub_Asy_Process_Model.Root>>(jsonResponse);

                if (items == null)
                {
                    MessageBox.Show("Failed to parse API response.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                // Check condition
                bool hasHolsterWithStatus3 = items.Any(x =>
                    x.name == "Holster" && x.manufacturing_order_station_status_id == 3);

                return hasHolsterWithStatus3 ? 1 : 0; //1 Means true or exists, 0 means false or does not exist
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
                return -1;
            }
        }

    }
}
