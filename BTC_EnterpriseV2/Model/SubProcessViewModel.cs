namespace BTC_EnterpriseV2.Model
{
    internal class SubProcessViewModel
    {
        public class Root
        {
            public int id { get; set; }
            public int manufacturing_order_id { get; set; }
            public int manufacturing_order_station_id { get; set; }
            public int manufacturing_order_process_status_id { get; set; }
            public string name { get; set; }
            public int is_build_america_buy_america { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Status status { get; set; }
            public List<SubProcess> sub_process { get; set; }
            public List<Duration> duration { get; set; }
        }

        public class Status
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class SubProcess
        {
            public int id { get; set; }
            public int manufacturing_order_id { get; set; }
            public int manufacturing_order_station_id { get; set; }
            public int manufacturing_order_process_id { get; set; }
            public int manufacturing_order_process_status_id { get; set; }
            public string name { get; set; }
            public string ipn_number { get; set; }
            public int serial_quantity { get; set; }
            public int serial_count { get; set; }
            public int is_kit_list { get; set; }
            public int is_serial { get; set; }
            public int is_torque { get; set; }
            public string invoice_serial_number { get; set; }
            public string harness_serial_number { get; set; }
            public string machine_tool_torque_name { get; set; }
            public string machine_tool_torque_value { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<object> serial { get; set; } // can be replaced with a Serial class if needed
        }

        public class Duration
        {
            public int id { get; set; }
            public int manufacturing_order_process_id { get; set; }
            public int manufacturing_order_process_status_id { get; set; }
            public string start_time { get; set; }   // string because it's "2025-08-19 13:42:03" (not ISO8601)
            public string end_time { get; set; }
            public string remarks { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Status status { get; set; }
        }







    }
}
