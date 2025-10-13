using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2;

namespace BTC_EnterpriseV2.Class
{
    public class SegmentProcess
    {
        public string SegmentName { get; set; }
        public string ProcessType { get; set; }
    }

    public class Load_Registry
    {
        public List<SegmentProcess> LoadDataRegistry()
        {
            List<SegmentProcess> result = new List<SegmentProcess>();

            try
            {
                RegistrySupport_Operation registry = new RegistrySupport_Operation();
                string data = registry.Read(Def.REGKEY_SUB);

                if (string.IsNullOrEmpty(data))
                {
                    data = $"BTC_ENTERPRISE<limiter>DefaultSection<limiter>DefaultCode<limiter>";
                    registry.Write(Def.REGKEY_SUB, data);
                }

                string[] programs = data.Split(
                    new string[] { "<limiter1>" },
                    StringSplitOptions.RemoveEmptyEntries
                );

                foreach (string program in programs)
                {
                    string[] records = program.Split(
                        new string[] { "<limiter>" },
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    if (records.Length >= 2) // ✅ need only 2 fields (segment + processType)
                    {
                        result.Add(new SegmentProcess
                        {
                            SegmentName = records[0].Trim(),
                            ProcessType = records[1].Trim()
                        });
                    }
                    else
                    {
                        MessageBox.Show("Invalid data format in registry.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }
    }

}
