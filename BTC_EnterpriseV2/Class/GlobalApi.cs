namespace BTC_EnterpriseV2.Class
{
    public static class GlobalApi
    {

        private static readonly string BaseUrl = "https://app.btcp-enterprise.com/api/";

        // API Endpoints
        public static readonly string ScanSerial = $"{BaseUrl}scan-serial";
        public static readonly string KitList = $"{BaseUrl}kit-list";
        public static readonly string ManufacturingOrders = $"{BaseUrl}manufacturing-order";
        public static readonly string LoginProduction = $"{BaseUrl}login-production";
        public static readonly string kitlistItem_scanbulk = $"{BaseUrl}kit-list-item/scan-bulk";
        public static readonly string Save_Serial = $"{BaseUrl}serial/save-serial";
        public static readonly string AdminLogin = $"{BaseUrl}login";

        public static string GetScanSerialUrl()
        {
            return ScanSerial;
        }

        public static string GetKitListUrl()
        {
            return KitList;
        }

        public static string GetManufacturingOrdersUrl()
        {
            return ManufacturingOrders;
        }
        public static string GetLoginProductionUrl()
        {
            return LoginProduction;
        }
        public static string GetKitlistItemScanBulkUrl()
        {
            return kitlistItem_scanbulk;
        }
        public static string GetSaveSerialUrl()
        {
            return Save_Serial;
        }

        public static string GetAdminLoginUrl()
        {
            return AdminLogin;
        }
    }
}
