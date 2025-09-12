using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_EnterpriseV2.Class
{
     public class Global
    {
        public static string UserToken = "";
        public static List<license>? dt_license { get; set; }
        public class license
        {
            public int id { get; set; }
            public int employee_id { get; set; }
            public int license_id { get; set; }
            public string? license_name { get; set; }
            public string? license_no { get; set; }
            public int license_type_id { get; set; }
            public string? license_type_name { get; set; }

        }
    }
}
