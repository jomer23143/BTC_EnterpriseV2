namespace BTC_EnterpriseV2.Utillities
{
    internal class DictionaryBuilder
    {
        public Dictionary<string, object> Build_Login(string email, string password)
        {
            return new Dictionary<string, object>
            {
                { "email", email.Trim() },
                { "password", password.Trim() }
            };
        }

        public Dictionary<string, object> BuildPostData(string serial)
        {
            return new Dictionary<string, object>
            {
                { "serial_number", serial.Trim() }
            };
        }


        public Dictionary<string, object> BuildPostData(string serial, int segmentId)
        {
            var postData = new Dictionary<string, object>
            {
                { "serial_number", serial.Trim() },
                { "manufacturing_order_segment_sequence_number", segmentId }
            };

            return postData;
        }

        public Dictionary<string, object> BuildPost_EndProcessData1(string serial, int status, string remark, string rfid)
        {
            var postData = new Dictionary<string, object>
            {
                { "serial_number", serial.Trim() },
                { "status_id", status },
                { "remarks", remark },
                { "employee_rfid", rfid.Trim() }
            };
            return postData;
        }
        public Dictionary<string, object> BuildPost_EndProcessData2(string serial, int segment, int status, string rfid)
        {
            var postData = new Dictionary<string, object>
            {
                    { "serial_number", serial.Trim() },
                    { "manufacturing_order_segment_sequence_number", segment },
                    { "status_id", status },
                    { "employee_rfid", rfid.Trim() }
            };
            return postData;
        }


        public readonly Dictionary<string, string> CodeNameMap = new Dictionary<string, string>
        {
            { "101", "Warehouse Kitting" },
            { "102", "Kitlist Receiving" },
            { "1", "Sub-Assembly" },
            { "2", "Pre-Assembly" },
            { "3", "Rain Test" },
            { "4", "Main Assembly" },
            { "5", "In-Station QC" },
            { "6", "EQL Test" },
            { "7", "Final Assembly" },
            { "8", "Final QC" },
            { "9", "Packing" }
        };
    }
}
