using System.Diagnostics;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Class
{
    internal class Request_Process
    {
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";

        public static async Task<Sub_Asy_Process_Model.Root?> Get_SubAsy_Process(string serial)
        {
            try
            {
                var postData = new { serial_number = serial };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);

                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                var response = JsonConvert.DeserializeObject<Sub_Asy_Process_Model.Root>(jsonResponse);

                if (response == null || response.serial_number == null)
                {
                    MessageBox.Show("Failed to parse API response.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                return response;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
                // MessageBox.Show($"Error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

}
