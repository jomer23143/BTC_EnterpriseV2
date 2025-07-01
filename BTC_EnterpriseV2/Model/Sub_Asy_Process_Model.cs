namespace BTC_EnterpriseV2.Model
{
    internal class Sub_Asy_Process_Model
    {
        public class Root
        {
            public int id { get; set; }
            public int manufacturing_order_segment_id { get; set; }
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
            public int id { get; set; }
            public int manufacturing_order_station_id { get; set; }
            public int manufacturing_order_process_status_id { get; set; }
            public string name { get; set; }
            public string ipn_number { get; set; }
            public int serial_quantity { get; set; }
            public int serial_count { get; set; }

            public int is_kit_list { get; set; }
            public List<Serial> serial { get; set; }
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
            public int manufacturing_order_station_id { get; set; }
            public int manufacturing_order_station_status_id { get; set; }
            public string serial_number { get; set; }
            public string start_time { get; set; }
            public string end_time { get; set; }
            public string remarks { get; set; }
        }

    }
}
