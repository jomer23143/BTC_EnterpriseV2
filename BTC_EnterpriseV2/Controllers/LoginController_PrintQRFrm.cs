using System.Diagnostics;
using BTC_EnterpriseV2.Services;

namespace BTC_EnterpriseV2.Controllers
{
    internal class LoginController_PrintQRFrm

    {
        private readonly LoginService_PrintQRFrm _loginService;

        public LoginController_PrintQRFrm(LoginService_PrintQRFrm loginService)
        {
            _loginService = loginService;
        }

        public async Task HandleLoginAsync(string username, string password)
        {
            try
            {
                string? token = await _loginService.LoginAsync();

                if (string.IsNullOrEmpty(token))
                {
                    MessageBox.Show(
                        "No valid employee data returned.",
                        "API Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // Store token somewhere (e.g., session, config)
                Debug.WriteLine($"Token: {token}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
