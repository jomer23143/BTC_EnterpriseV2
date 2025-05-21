using System.Net;
using System.Text;

namespace BTC_EnterpriseV2.Utillities
{
    public class WebRequestApi
    {


        public static async Task<string> GetData_httwebrequest(string url)
        {
            string res = "";
            WebRequest requestObject = WebRequest.Create(url);
            requestObject.Method = "GET";
            HttpWebResponse response = null;
            requestObject.Timeout = 10000;
            response = (HttpWebResponse)await requestObject.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                res = sr.ReadToEnd();
                sr.Close();
            }
            return res;
        }
        public static async Task<string> PostData_httpwebrequest(string url, string json)
        {
            try
            {
                string respond = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Accept = "application/json";
                byte[] requestBody = Encoding.UTF8.GetBytes(json);
                httpWebRequest.ContentLength = requestBody.Length;

                using (Stream stream = await httpWebRequest.GetRequestStreamAsync())
                {
                    stream.Write(requestBody, 0, requestBody.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public static async Task<string> GetData_httpclient(string url)
        {
            string responseData = "";
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    //  Content = new StringContent(data, Encoding.UTF8, "application/json")
                };
                HttpResponseMessage response = await client.SendAsync(request);
                responseData = await response.Content.ReadAsStringAsync();
            }
            return responseData;
        }
        public static async Task<string> PostData_httpclient(string url, string data)
        {
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                response = await client.PostAsync(url, content);
                responseData = await response.Content.ReadAsStringAsync();
            }
            return responseData;
        }

        //this is for getting operator info
        public static async Task<string> Operator_httpclient(string url, string jsonData)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string responseData = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server Error: {response.StatusCode}\n{responseData}");
                }

                return responseData;
            }
        }
        public static async Task<string> PostRequest(string url, string jsonData)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = await client.SendAsync(request);
                string responseData = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server Error: {response.StatusCode}\n{responseData}");
                }

                return responseData;
            }
        }


    }
}
