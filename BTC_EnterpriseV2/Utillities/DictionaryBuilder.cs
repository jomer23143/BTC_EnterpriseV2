namespace BTC_EnterpriseV2.Utillities
{
    internal class DictionaryBuilder
    {
        // Overload 1: for Sub-Assy
        public Dictionary<string, object> BuildPostData(string serial)
        {
            return new Dictionary<string, object>
            {
                { "serial_number", serial.Trim() }
            };
        }

        // Overload 2: for Pre-Assy (with segment ID)
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
            { "1", "Warehouse Kitting" },
            { "2", "Kitlist Receiving" },
            { "3", "Sub-Assembly" },
            { "4", "Pre-Assembly" },
            { "5", "Rain Test" },
            { "6", "Main Assembly" },
            { "7", "In-Station QC" },
            { "8", "EQL Test" },
            { "9", "Final Assembly" },
            { "10", "Final QC" },
            { "11", "Packing" }
        };
    }
}
