namespace BTC_EnterpriseV2.Model
{
    public class Segment_Model
    {

        public class ApiResponse
        {
            public int id { get; set; }
            public string bom_item { get; set; }
            public string description { get; set; }
            public string bom_revision_number { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<Segment> segment { get; set; }
        }

        public class Link
        {
            public string url { get; set; }
            public string label { get; set; }
            public bool active { get; set; }
        }

        public class Root
        {
            public int current_page { get; set; }
            public List<ApiResponse> data { get; set; }
            public string first_page_url { get; set; }
            public int from { get; set; }
            public int last_page { get; set; }
            public string last_page_url { get; set; }
            public List<Link> links { get; set; }
            public object next_page_url { get; set; }
            public string path { get; set; }
            public int per_page { get; set; }
            public object prev_page_url { get; set; }
            public int to { get; set; }
            public int total { get; set; }
        }

        public class Segment
        {
            public int id { get; set; }
            public int product_id { get; set; }
            public string name { get; set; }
            public object descripion { get; set; }
            public int is_serial { get; set; }
            public int is_active { get; set; }
            public object format { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }


    }

}
