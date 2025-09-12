using System.Diagnostics;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Class
{
    public class Pre_Assy_Prerequeset_Handler
    {
        private string scanserial_api = GlobalApi.GetScanSerialUrl();

        private async Task<List<Sub_Asy_Process_Model.Root>?> FetchSubAssyDataAsync(string serial, int stationId, int sequence)
        {
            var postData = new
            {
                serial_number = serial.Trim(),
                station = stationId,
                sequence_number = sequence
            };

            string json = JsonConvert.SerializeObject(postData);
            Debug.WriteLine("Request JSON: " + json);

            string jsonResponse = await WebRequestApi.PostRequest(scanserial_api, json);
            Debug.WriteLine("Response: " + jsonResponse);

            if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
            {
                MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            try
            {
                var items = JsonConvert.DeserializeObject<List<Sub_Asy_Process_Model.Root>>(jsonResponse);
                return items;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private async Task<List<Sub_Asy_Process_Model.Root>?> FetchPreAssyDataAsync(string serial, int stationId, int sequence)
        {
            var postData = new
            {
                serial_number = serial.Trim(),
                station = stationId,
                sequence_number = sequence
            };

            string json = JsonConvert.SerializeObject(postData);
            Debug.WriteLine("Request JSON: " + json);

            string jsonResponse = await WebRequestApi.PostRequest(scanserial_api, json);
            Debug.WriteLine("Response: " + jsonResponse);

            if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
            {
                MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            try
            {
                var items = JsonConvert.DeserializeObject<List<Sub_Asy_Process_Model.Root>>(jsonResponse);
                return items;
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // Checks if Holster is done (status 3)
        public async Task<int> CheckHolsterStatusAsync(string serial, int stationId, int sequence)
        {
            var items = await FetchSubAssyDataAsync(serial, stationId, sequence);

            if (items == null)
                return -1;

            bool hasHolsterDone = items.Any(x => x.name == "Holster" && x.manufacturing_order_station_status_id == 3);
            return hasHolsterDone ? 1 : 0;
        }

        // Checks if Station 1 is done
        public async Task<int> CheckStation_2(string serial, int stationId, int sequence) //for station 2
        {
            var stations = await FetchPreAssyDataAsync(serial, 1, sequence);

            bool hasStation1Done = stations.Any(x => x.name == "Station 1" && x.manufacturing_order_station_status_id == 3);
            if (!hasStation1Done)
            {
                new CustomeAlert("Pre Assymble Warning", "Pre-requesite Station 1 is not yet done in Pre-Assy. 😌 ", CustomeAlert.Alertype.Warning).ShowDialog();
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public async Task<int> CheckStation_3(string serial, int stationId, int sequence) //for station 3
        {
            var items = await FetchSubAssyDataAsync(serial, stationId, sequence);
            var stations = await FetchPreAssyDataAsync(serial, 2, sequence);
            if (items == null)
            {
                MessageBox.Show("Error retrieving data.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            bool hasLCDdisplay = items.Any(x => x.name == "LCD Display" && x.manufacturing_order_station_status_id == 3);
            bool hasPaymentSystem = items.Any(x => x.name == "Payment System Sub-Assy" && x.manufacturing_order_station_status_id == 3);
            if (!hasLCDdisplay)
            {
                new CustomeAlert("Pre Assymble Warning", "Pre-requesite - LCD Display - is not yet done in Sub-Assembly. 😌 ", CustomeAlert.Alertype.Warning).ShowDialog();
                return 0;
            }
            if (!hasPaymentSystem)
            {
                new CustomeAlert("Pre Assymble Warning", "Pre-requesite - Payment System Sub-Assy - is not yet done in Sub-Assembly. 😌 ", CustomeAlert.Alertype.Warning).ShowDialog();
                return 0;
            }
            if (stations == null)
            {
                MessageBox.Show("Error retrieving station data.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            bool hasStation1Done = stations.Any(x => x.name == "Station 1" && x.manufacturing_order_station_status_id == 3);
            bool hasStation2Done = stations.Any(x => x.name == "Station 2" && x.manufacturing_order_station_status_id == 3);
            if (!hasStation1Done)
            {
                new CustomeAlert("Pre Assymble Warning", "Pre-requesite Station 1 is not yet done in Pre-Assy. 😌 ", CustomeAlert.Alertype.Warning).ShowDialog();
                return 0;
            }
            if (!hasStation2Done)
            {
                new CustomeAlert("Pre Assymble Warning", "Pre-requesite Station 2 is not yet done in Pre-Assy. 😌 ", CustomeAlert.Alertype.Warning).ShowDialog();
                return 0;
            }
            else
            {
                return 1;
            }

        }


        ///this is the checking process for pre-assembly  station 1
        public async Task<int> ChckFunction(string serial, int stationId, int sequence)
        {
            var resultData = await CheckData(serial, stationId, sequence);
            if (resultData != null)
            {

                var filtered = resultData
                    .Where(x => x.manufacturing_order_station_status_id != 1)
                    .ToList();
                var tempHolder = filtered;

                foreach (var item in tempHolder)
                {
                    if (string.IsNullOrWhiteSpace(item.assign_process_id?.ToString()))
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        private async Task<List<Pre_Assy_Model.ManufacturingStation>?> CheckData(string serial, int stationId, int sequence)
        {
            var postData = new Dictionary<string, object>
                 {
                { "serial_number", serial.Trim() },
                { "manufacturing_order_segment_sequence_number", stationId },
                { "sequence_number", sequence }
                 };

            var token = await ApiHelper.PostJsonAsync(scanserial_api, postData,Global.UserToken);
            if (token == null)
                return null;

            // Deserialize into list of list
            var stationGroups = token.ToObject<List<List<Pre_Assy_Model.ManufacturingStation>>>();

            if (stationGroups != null && stationGroups.Any())
            {
                var firstGroup = stationGroups[0];

                foreach (var station in firstGroup)
                {
                    Console.WriteLine($"Station: {station.name}, Status: {station.manufacturing_order_station_status_id}");
                }

                return firstGroup;
            }

            return null;
        }



    }

}
