namespace BTC_EnterpriseV2.Model
{
    public class PrintQR_Model
    {
        public class RootWrapper
        {
            public int current_page { get; set; }
            public List<Main> data { get; set; }
        }

        public class Main
        {
            public int id { get; set; }
            public string serial_number { get; set; }
            public string mo_id { get; set; }
            public string bom_item { get; set; }
            public string bom_revision_number { get; set; }
            public List<Segment> segment { get; set; }
        }

        public class Segment
        {
            public int id { get; set; }
            public string name { get; set; }
            public List<Station> station { get; set; }
            public string manufacturing_order_id { get; set; }
        }

        public class Station
        {
            public int id { get; set; }
            public string name { get; set; }
            public string product_ref_code { get; set; }
            public string serial_number { get; set; }
            public string is_serial { get; set; } // or bool if it's always true/false
            public string manufacturing_order_id { get; set; }
            public string mo_id { get; set; } // Assuming this is a string, adjust if it's an int
        }



    }

}
