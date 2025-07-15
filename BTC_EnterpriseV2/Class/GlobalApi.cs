namespace BTC_EnterpriseV2.Class
{
    public static class GlobalApi
    {

        private static readonly string BaseUrl = "https://app.btcp-enterprise.com/api/";

        // API Endpoints
        public static readonly string ScanSerial = $"{BaseUrl}scan-serial";
        public static readonly string KitList = $"{BaseUrl}kit-list";
        public static readonly string ManufacturingOrders = $"{BaseUrl}manufacturing-orders";

        public static string GetScanSerialUrl()
        {
            return ScanSerial;
        }
    }
}
