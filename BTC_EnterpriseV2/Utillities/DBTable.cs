

namespace BTCP_EnterpriseV2.Utillities
{
    internal class DBTable
    {
        private string table;
        private Dictionary<string, string> converted_list;
        private List<string> list;

        public DBTable(string table, Dictionary<string, string> converted_list, List<string> list)
        {
            this.table = table;
            this.converted_list = converted_list;
            this.list = list;
        }

        internal string GenerateCreateUpdate(Dictionary<string, string> converted_list, Dictionary<string, string> primary_values, string compare_field, string compare_value)
        {
            throw new NotImplementedException();
        }

        internal string GenerateFilter(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }

        internal string GenerateInsert(Dictionary<string, string> converted_list)
        {
            throw new NotImplementedException();
        }

        internal string GenerateInsertUsingSelect(Dictionary<string, string> converted_list, string selectTable, string[] parameters)
        {
            throw new NotImplementedException();
        }

        internal string GenerateUpdate(Dictionary<string, string> converted_list, Dictionary<string, string> primary_values, string compare_field1, string compare_field2)
        {
            throw new NotImplementedException();
        }
    }
}