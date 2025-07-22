namespace BTC_EnterpriseV2.Model
{
    public class Pre_Assy_Model
    {
        public class ManufacturingStation
        {
            public int id { get; set; }
            public int sequence_number { get; set; }
            public int manufacturing_order_id { get; set; }
            public int manufacturing_order_segment_id { get; set; }
            public int manufacturing_order_segment_sequence_number { get; set; }
            public int manufacturing_order_station_status_id { get; set; }
            public string name { get; set; }
            public string product_ref_code { get; set; }
            public int product_ref_count { get; set; }
            public int is_serial { get; set; }
            public string mo_id { get; set; }
            public string serial_number { get; set; }
            public string top_level_serial_number { get; set; }
            public int? assign_process_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }


    }
}
