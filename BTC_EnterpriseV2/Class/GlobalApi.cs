namespace BTC_EnterpriseV2.Class
{
    public static class GlobalApi
    {

        private static readonly string BaseUrl = "https://app.btcp-enterprise.com/api/";

        // API Endpoints
        public static readonly string ScanSerial = $"{BaseUrl}scan-serial";
        public static readonly string Scan = $"{BaseUrl}scan";
        public static readonly string GetSubP = $"{BaseUrl}view-sub-process";
        public static readonly string PostProcess = $"{BaseUrl}process";
        public static readonly string PostMaterialAssignSerial = $"{BaseUrl}material-assign-serial";
        public static readonly string PostMaterialAssignTorque = $"{BaseUrl}material-assign-torque";
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
        //new
        public static string GetScanUrl()
        {
            return Scan;
        }
        //new
        public static string GetGetSubPUrl()
        {
            return GetSubP;
        }

        //new Pos
        public static string GetPostProcessUrl()
        {
            return PostProcess;
        }

        public static string GetPostMaterialAssignSerialUrl()
        {
            return PostMaterialAssignSerial;
        }

        public static string GetPostMaterialAssignTorqueUrl()
        {
            return PostMaterialAssignTorque;
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
