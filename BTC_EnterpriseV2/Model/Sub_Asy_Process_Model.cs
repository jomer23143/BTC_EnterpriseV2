namespace BTC_EnterpriseV2.Model
{
    internal class Sub_Asy_Process_Model
    {
        public class Root
        {
            public int? id { get; set; }
            public int sequence_number { get; set; }
            public int manufacturing_order_segment_id { get; set; }
            public int manufacturing_order_sequence_number { get; set; }
            public int manufacturing_order_station_status_id { get; set; }
            public string name { get; set; }
            public string product_ref_code { get; set; }
            public string product_ref_count { get; set; }
            public int is_serial { get; set; }
            public string mo_id { get; set; }
            public string serial_number { get; set; }
            public List<Process> process { get; set; }
            public List<Duration> duration { get; set; }
            public List<Serial> serial { get; set; }
        }
        public List<Process> process { get; set; }
        public List<Serial> serial { get; set; }

        public class Process
        {
            public string id { get; set; }
            public string manufacturing_order_id { get; set; }
            public string manufacturing_order_station_id { get; set; }
            public string manufacturing_order_process_status_id { get; set; }
            public string? name { get; set; }
            public string? ipn_number { get; set; }
            public int? serial_quantity { get; set; }
            public int? serial_count { get; set; }
            public int is_kit_list { get; set; }
            public string? invoice_serial_number { get; set; }
            public string? harness_serial_number { get; set; }
            public string? machine_tool_torque_name { get; set; }
            public string? machine_tool_torque_value { get; set; }
            public string? is_build_america_buy_america { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Status status { get; set; }
            public List<Duration> duration { get; set; }
            public List<Serial> serial { get; set; }
        }

        public class Status
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Color { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
        public class Serial
        {
            public int id { get; set; }
            public int manufacturing_order_process_id { get; set; }
            public string serial_number { get; set; }
        }

        public class Duration
        {
            public int id { get; set; }
            public int manufacturing_order_process_id { get; set; }
            public int manufacturing_order_process_status_id { get; set; }
            public string start_time { get; set; }
            public string end_time { get; set; }
            public string remarks { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Status status { get; set; }
        }

    }
}
