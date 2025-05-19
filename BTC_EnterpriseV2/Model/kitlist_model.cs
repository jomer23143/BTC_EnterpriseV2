namespace BTC_EnterpriseV2.Model
{
    internal class kitlist_model
    {
        public class manufacturing_order
        {
            public string mo_id { get; set; }
            public string pcn_number { get; set; }
            public string description { get; set; }
            public string location { get; set; }
            public string bom_item { get; set; }
            public string bom_revision_number { get; set; }
            public string order_quantity { get; set; }
            public string order_date { get; set; }
            public string kit_date { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public List<item> kit_list_items { get; set; }
        }
        public class item
        {
            public string part_serial { get; set; }
            public object mo_id { get; set; }
            public object item_number { get; set; }
            public object group { get; set; }
            public object ipn { get; set; }
            public object description { get; set; }
            public object type { get; set; }
            public object manufacturing { get; set; }
            public object manufacturing_product_code { get; set; }
            public object source_location { get; set; }
            public object stock { get; set; }
            public object unit_quantity { get; set; }
            public object mo_quantity { get; set; }
            public object wip_quantity { get; set; }
            public object pick_quantity { get; set; }
            public object short_quantity { get; set; }
            public object unit { get; set; }
            public object invoice_number { get; set; }
            public object kitted { get; set; }
            public object individual_kitting { get; set; }
            public object track { get; set; }
            public object rack { get; set; }
            public object comment { get; set; }
        }
        public class GetData
        {
            public object current_page { get; set; }
            public List<manufacturing_order_items> data { get; set; }
            public string next_page_url { get; set; }
            public string prev_page_url { get; set; }
            public int to { get; set; }
            public string total { get; set; }
        }
        public class manufacturing_order_getdata
        {
            public int id { get; set; }
            public string mo_id { get; set; }
            public string pcn_number { get; set; }
            public string description { get; set; }
            public string location { get; set; }
            public string bom_item { get; set; }
            public string bom_revision_number { get; set; }
            public string order_quantity { get; set; }
            public string order_date { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public List<manufacturing_order_items> manufacturing_order_items { get; set; }
        }
        //public class manufacturing_order_items
        //{
        //    public int id { get; set; }
        //    public string part_serial { get; set; }
        //    public string mo_id { get; set; }
        //    public string item_number { get; set; }
        //    public string group { get; set; }
        //    public string ipn { get; set; }
        //    public string description { get; set; }
        //    public string type { get; set; }
        //    public string manufacturing { get; set; }
        //    public string manufacturing_product_code { get; set; }
        //    public string source_location { get; set; }
        //    public string stock { get; set; }
        //    public string unit_quantity { get; set; }
        //    public string mo_quantity { get; set; }
        //    public string wip_quantity { get; set; }
        //    public string pick_quantity { get; set; }
        //    public string short_quantity { get; set; }
        //    public string unit { get; set; }
        //    public string invoice_number { get; set; }
        //    public string kitted { get; set; }
        //    public string individual_kitting { get; set; }
        //    public string track { get; set; }
        //    public string rack { get; set; }
        //    public string comment { get; set; }
        //    public string created_at { get; set; }
        //    public string updated_at { get; set; }
        //    public string status { get; set; }
        //    public string[] history { get; set; }
        //}
        public class error_logs
        {
            public error errors { get; set; }
            public string message { get; set; }
        }
        public class error
        {
            public string[] mo_id { get; set; }
        }

        public class serial_number
        {
            public int id { get; set; }
            public string part_serial { get; set; }
        }
        public class kitted_quantity
        {
            public int id { get; set; }
            public string kitted { get; set; }
            public string comment { get; set; }
        }
        public class add_serial_number
        {
            public List<serial_number> kit_list_items { get; set; }
        }
        public class update_kitting_quantity
        {
            public List<kitted_quantity> kit_list_items { get; set; }
        }


        //my additional Model 
        public class Status
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class manufacturing_order_items
        {
            public int id { get; set; }
            public int kit_list_id { get; set; }
            public int? kit_list_item_type_id { get; set; }
            public int kit_list_item_status_id { get; set; }
            public string mo_id { get; set; }
            public string item_number { get; set; }
            public string group { get; set; }
            public string ipn { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string manufacturing { get; set; }
            public string manufacturing_product_code { get; set; }
            public string source_location { get; set; }
            public string unit_quantity { get; set; }
            public int mo_quantity { get; set; }
            public int wip_quantity { get; set; }
            public int pick_quantity { get; set; }
            public int? short_quantity { get; set; }
            public int? kit_quantity { get; set; }
            public int received_quantity { get; set; }
            public int used_quantity { get; set; }
            public int reject_quantity { get; set; }
            public string unit { get; set; }
            public string invoice_number { get; set; }
            public string kitted { get; set; }
            public string individual_kitting { get; set; }
            public string track { get; set; }
            public string rack { get; set; }
            public string comment { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<object> serial { get; set; }

            // ✅ This must match the JSON structure!
            public Status status { get; set; }
        }



    }
}
