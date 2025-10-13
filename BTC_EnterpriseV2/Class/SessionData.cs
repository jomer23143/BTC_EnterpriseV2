using System.Data;

namespace BTC_EnterpriseV2.Class
{
    public static class SessionData
    {
        public static DataTable TempData { get; private set; }
        public static DataTable TempDataLicense { get; private set; }

        static SessionData()
        {
            TempData = new DataTable();
            TempData.Columns.Add("id", typeof(string));
            TempData.Columns.Add("FullName", typeof(string));
            TempData.Columns.Add("Position", typeof(string));
            TempData.Columns.Add("Token", typeof(string));


            TempDataLicense = new DataTable();
            TempDataLicense.Columns.Add("id", typeof(int));
            TempDataLicense.Columns.Add("name", typeof(string));
            TempDataLicense.Columns.Add("license_no", typeof(string));
            TempDataLicense.Columns.Add("product_id", typeof(int));
            TempDataLicense.Columns.Add("product_name", typeof(string));
            TempDataLicense.Columns.Add("expiry_date", typeof(string));

        }
    }
}
