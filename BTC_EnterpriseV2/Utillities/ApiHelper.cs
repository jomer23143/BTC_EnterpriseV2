using System.Diagnostics;
using System.Net.Http.Headers;
using BTC_EnterpriseV2.Modal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTC_EnterpriseV2.Utillities
{
    public class ApiHelper
    {
        public static async Task<JToken?> PostJsonAsync(string url, Dictionary<string, object> postData,string Token)
        {
            try
            {
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                string response = await WebRequestApi.PostRequest(url, json,Token);
                Debug.WriteLine("Response: " + response);

                if (string.IsNullOrWhiteSpace(response) || response.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                var token = JToken.Parse(response);

                // Check for known error structure
                if (token.Type == JTokenType.Object && token["errors"] != null)
                {
                    string message = token["message"]?.ToString() ?? "Unknown error.";
                    string? detailed = token["errors"]?["station_serial_number"]?.FirstOrDefault()?.ToString();

                    string fullMessage = $"{message}\n\nDetails: {detailed}";
                    MessageBox.Show(fullMessage, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return null;
                }

                return token;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON parsing failed: {ex.Message}", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                ShowAlert("Process Notification", $" {ex.Message}", CustomeAlert.Alertype.Information);
                return null;
            }
        }
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

                // Check for known error structure
                if (token.Type == JTokenType.Object && token["errors"] != null)
                {
                    string message = token["message"]?.ToString() ?? "Unknown error.";
                    string? detailed = token["errors"]?["station_serial_number"]?.FirstOrDefault()?.ToString();

                    string fullMessage = $"{message}\n\nDetails: {detailed}";
                    MessageBox.Show(fullMessage, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return null;
                }

                return token;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON parsing failed: {ex.Message}", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                ShowAlert("Process Notification", $" {ex.Message}", CustomeAlert.Alertype.Information);
                return null;
            }
        }
        public static async Task<JToken?> PostJsonAsync(string url, List<Dictionary<string, object>> postData,string Token)
        {
            try
            {
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                string response = await WebRequestApi.PostRequest(url, json,Token);
                Debug.WriteLine("Response: " + response);

                if (string.IsNullOrWhiteSpace(response) || response.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                var token = JToken.Parse(response);

                // Check for known error structure
                if (token.Type == JTokenType.Object && token["errors"] != null)
                {
                    string message = token["message"]?.ToString() ?? "Unknown error.";
                    string? detailed = token["errors"]?["station_serial_number"]?.FirstOrDefault()?.ToString();

                    string fullMessage = $"{message}\n\nDetails: {detailed}";
                    MessageBox.Show(fullMessage, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return null;
                }

                return token;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON parsing failed: {ex.Message}", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                ShowAlert("Process Notification", $" {ex.Message}", CustomeAlert.Alertype.Information);
                return null;
            }
        }
        public static async Task<JToken?> PostJsonAsync(string url, string json,string Token)
        {
            try
            {
                string response = await WebRequestApi.PostRequest(url, json,Token);
                Debug.WriteLine("Response: " + response);

                if (string.IsNullOrWhiteSpace(response) || response.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                var token = JToken.Parse(response);

                // Check for known error structure
                if (token.Type == JTokenType.Object && token["errors"] != null)
                {
                    string message = token["message"]?.ToString() ?? "Unknown error.";
                    string? detailed = token["errors"]?["station_serial_number"]?.FirstOrDefault()?.ToString();

                    string fullMessage = $"{message}\n\nDetails: {detailed}";
                    MessageBox.Show(fullMessage, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return null;
                }

                return token;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON parsing failed: {ex.Message}", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                ShowAlert("Process Notification", $" {ex.Message}", CustomeAlert.Alertype.Information);
                return null;
            }
        }

        private static void ShowAlert(string title, string message, CustomeAlert.Alertype type)
        {
            new CustomeAlert(title, message, type).ShowDialog();
        }
        public static async Task<JToken?> Get_AdminLoginJsonAsync(string url, Dictionary<string, object> postData)
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

                // Check for known error structure
                if (token.Type == JTokenType.Object && token["errors"] != null)
                {
                    string message = token["message"]?.ToString() ?? "Unknown error.";
                    string? detailed = token["errors"]?["station_serial_number"]?.FirstOrDefault()?.ToString();

                    string fullMessage = $"{message}\n\nDetails: {detailed}";
                    MessageBox.Show(fullMessage, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return null;
                }

                return token;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON parsing failed: {ex.Message}", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<JToken?> Get_ProcessWithJsonAsync(string url, Dictionary<string, object> postData, string Authtoken)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authtoken);
                string json = JsonConvert.SerializeObject(postData);

                string response = await WebRequestApi.PostRequest(url, json);
                Debug.WriteLine("Response: " + response);

                if (string.IsNullOrWhiteSpace(response) || response.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                var token = JToken.Parse(response);

                // Check for known error structure
                if (token.Type == JTokenType.Object && token["errors"] != null)
                {
                    string message = token["message"]?.ToString() ?? "Unknown error.";
                    string? detailed = token["errors"]?["station_serial_number"]?.FirstOrDefault()?.ToString();

                    string fullMessage = $"{message}\n\nDetails: {detailed}";
                    MessageBox.Show(fullMessage, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return null;
                }

                return token;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON parsing failed: {ex.Message}", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
