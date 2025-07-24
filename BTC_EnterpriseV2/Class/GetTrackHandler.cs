using System.Data;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Class
{
    public class GetTrackHandler
    {
        private DataTable ipn_list = new DataTable("ipn_list");
        public async Task<DataTable?> PostData(string moid, List<string> ipnNumbers)
        {
            try
            {
                var kitListDetails = await GetKitListItemDetailsAsync(moid);
                if (kitListDetails == null)
                {
                    MessageBox.Show("Failed to load kit list item details.");
                    return new DataTable();
                }

                return PopulateKitList_item(kitListDetails, ipnNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }


        private async Task<Model.kitlist.GetData?> GetKitListItemDetailsAsync(string moId)
        {
            string url = $"https://app.btcp-enterprise.com/api/kit-list-item?mo_id={moId}&per_row=9999";
            var json = await GetMohDetails(url);
            return JsonConvert.DeserializeObject<Model.kitlist.GetData>(json);
        }


        private DataTable dt_items = new DataTable("dt_items");

        private DataTable PopulateKitList_item(Model.kitlist.GetData model, List<string> ipnNumbers)
        {
            dt_items.Clear();
            dt_items.Columns.Clear();
            dt_items.Columns.AddRange(new[]
            {
        new DataColumn("id"), new DataColumn("mo_id"), new DataColumn("ipn"),
        new DataColumn("description"), new DataColumn("unit_quantity"), new DataColumn("track")
    });

            foreach (var item in model?.data ?? new())
                dt_items.Rows.Add(item.id, item.mo_id, item.ipn, item.description, item.unit_quantity, item.track);

            // ✅ Now filter using the passed list of IPNs
            var filtered = dt_items.AsEnumerable()
                .Where(r => ipnNumbers.Contains(r["ipn"]?.ToString()))
                .ToList();

            if (!filtered.Any())
                return dt_items.Clone(); // empty but same structure

            return filtered.CopyToDataTable();
        }


        private async Task<string> GetMohDetails(string url)
        {
            DataTable dt = new DataTable();
            string responseData = "";
            await Task.Run(async () =>
            {

                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),

                    };
                    HttpResponseMessage response = await client.SendAsync(request);
                    responseData = await response.Content.ReadAsStringAsync();

                }
            });
            return responseData;
        }


    }
}
