using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.Utillities
{
    public class ApiHelper
    {
        public static async Task<JToken?> PostJsonAsync(string url, Dictionary<string, object> postData)
        {
            try
            {
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                string response = await WebRequestApi.PostRequest(url, json);
                Debug.WriteLine("Response: " + response);

                if (string.IsNullOrWhiteSpace(response) || response.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                var token = JToken.Parse(response);

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error?.message ?? "Unknown error"}", "API Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                return token;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
                MessageBox.Show($"Unhandled Error: {ex.Message}", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }




    }
}
