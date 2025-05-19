using System.Globalization;

namespace BTCP_EnterpriseV2.Class
{
    public class Get_Realtime
    {
        public async Task<string[]> Realtime()
        {
            try
            {
                return await Task.Run(() =>
                {
                    DateTime localDate = DateTime.Now;
                    string[] cultureNames = { "en-US", "en-GB", "fr-FR", "de-DE", "ru-RU" };
                    string[] rtrn_data = new string[cultureNames.Length];

                    for (int i = 0; i < cultureNames.Length; i++)
                    {
                        var culture = new CultureInfo(cultureNames[i]);
                        rtrn_data[i] = localDate.ToString(culture);
                    }

                    return rtrn_data;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Array.Empty<string>();
            }
        }


    }
}
