using BTC_EnterpriseV2.Modal;

namespace BTC_EnterpriseV2.Class
{
    public class ShowCustomizeAlert
    {
        public static void ShowMsg(string title, string message, CustomeAlert.Alertype type)
        {
            CustomeAlert alert = new CustomeAlert(title, message, type);
            alert.ShowDialog();
        }

    }
}
