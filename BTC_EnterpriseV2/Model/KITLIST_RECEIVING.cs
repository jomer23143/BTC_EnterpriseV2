using OpenTK.Platform.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTC_EnterpriseV2.Model
{
    public class KITLIST_RECEIVING
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class Item
        {
            public int id { get; set; }
            public int kit_list_received_id { get; set; }
            public int kit_list_item_id { get; set; }
            public int kit_list_received_item_status_id { get; set; }
            public int actual_quantity { get; set; }
            public int short_quantity { get; set; }
            public int received_quantity { get; set; }
            public object comment { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public KitListItem kit_list_item { get; set; }
            public Status status { get; set; }
        }

        public class KitList
        {
            public int id { get; set; }
            public object kit_list_type_id { get; set; }
            public int kit_list_status_id { get; set; }
            public string mo_id { get; set; }
            public string pcn_number { get; set; }
            public string description { get; set; }
            public string location { get; set; }
            public string bom_item { get; set; }
            public string bom_revision_number { get; set; }
            public string order_quantity { get; set; }
            public string order_date { get; set; }
            public int is_build_america_buy_america { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class KitListItem
        {
            public int id { get; set; }
            public int kit_list_id { get; set; }
            public object kit_list_item_type_id { get; set; }
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
            public object stock { get; set; }
            public string unit_quantity { get; set; }
            public int mo_quantity { get; set; }
            public int wip_quantity { get; set; }
            public int pick_quantity { get; set; }
            public int? short_quantity { get; set; }
            public object kit_quantity { get; set; }
            public int received_quantity { get; set; }
            public int used_quantity { get; set; }
            public int reject_quantity { get; set; }
            public string unit { get; set; }
            public object invoice_number { get; set; }
            public string kitted { get; set; }
            public object individual_kitting { get; set; }
            public string track { get; set; }
            public object rack { get; set; }
            public string comment { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public int kit_list_id { get; set; }
            public int kit_list_received_status_id { get; set; }
            public object? received_date { get; set; }
            public int received_by { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public KitList? kit_list { get; set; }
            public Status? status { get; set; }
            public List<Item>? items { get; set; }
        }

        public class Status
        {
            public int id { get; set; }
            public string? name { get; set; }
            public string? description { get; set; }
            public string? color { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }
        public class Sf_Header
        {
            public string group { get; set; }
            public int kit_list_received_id { get; set; }
            public bool selected { get; set; }
            public int id { get; set; }
            public int kit_list_received_item_status_id { get; set; }
            public string? ipn { get; set; }
            public string? description { get; set; }
            public string? type { get; set; }
            public int actual_quantity { get; set; }
            public int short_quantity { get; set; }
            public int received_quantity { get; set; }
            public string? unit { get; set; }
            public string? track { get;set; }
            public string? comment { get; set; }
            public string? status { get; set; }

        }
        public class item_data
        {
            public int id { get; set; }
            public int kit_list_received_item_status_id { get; set; }
            public int short_quantity { get; set; }
            public int received_quantity { get; set; }
            public string? comment { get; set; }
        }
        public class item_root
        {
            public List<item_data>? items { get; set; }
        }
    }
}
