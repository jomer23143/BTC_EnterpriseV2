using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json.Linq;

namespace BTC_EnterpriseV2.Services
{
    public class LoginService_PrintQRFrm
    {

        private readonly string _loginAdminApiUrl = GlobalApi.GetAdminLoginUrl();
        private readonly string email = "super_admin@btcpower.com";
        private readonly string password = "password";
        private readonly string _manufacturingOrderApi = GlobalApi.GetManufacturingOrdersUrl();
        public async Task<string?> LoginAsync()
        {
            DictionaryBuilder dbuilder = new DictionaryBuilder();

            var responseJson = await ApiHelper.Get_AdminLoginJsonAsync(
                _loginAdminApiUrl,
                dbuilder.Build_Login(email, password)
            );

            if (responseJson == null)
                return null;

            var result = responseJson.ToObject<Model.LoginToken.Root>();

            return result?.token; // return token only, no UI
        }

        public async Task<List<PrintQR_Model.Main>?> GetDataAsync(string moid, string token)
        {
            var api = $"{_manufacturingOrderApi}?with_segment=1&with_station=1&with_process=0&mo_id={moid}&per_row=9999";

            string jsonResponse = await WebRequestApi.GetData_Token_httpclient(api, token);

            if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                return null; // invalid response

            var parsedToken = JToken.Parse(jsonResponse);

            if (parsedToken.Type == JTokenType.Object && parsedToken["message"] != null)
                return null; // API returned error message

            if (parsedToken.Type == JTokenType.Object && parsedToken["data"] != null)
            {
                var rootObj = parsedToken.ToObject<PrintQR_Model.RootWrapper>();
                return rootObj?.data ?? new List<PrintQR_Model.Main>();
            }

            return null; // unexpected format
        }

    }
}
