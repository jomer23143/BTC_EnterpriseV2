namespace BTC_EnterpriseV2.Model
{
    public class ProcessSidebar_Model
    {
        public class ProcessItem
        {
            public int id { get; set; }
            public int product_segment_station_id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int is_serial { get; set; }
            public int is_active { get; set; }
            public string ipn_number { get; set; }
            public int? serial_quantity { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }
    }
}
