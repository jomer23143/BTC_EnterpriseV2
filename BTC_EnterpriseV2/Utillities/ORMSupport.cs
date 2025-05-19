using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;
using System.Drawing;

namespace BTCP_Enterprise
{

    public class DBTable
    {
        public String table { get; set; }
        public List<String> columns;
        public Dictionary<String, String> insert_list;
        public List<String> primary_keys;

        public DBTable(String table, Dictionary<String, String> aliases, List<String> primary_keys)
        {
            this.table = table;
            insert_list = aliases;
            columns = aliases.Keys.ToList();
            this.primary_keys = primary_keys;
        }

        public Dictionary<String, String> GetPrimaryValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();
            foreach (String primary_key in primary_keys)
            {
                foreach (String insert_key in insert_list.Keys)
                {
                    if (insert_key == primary_key)
                        result.Add(insert_key, insert_list[insert_key]);
                }
            }
            return result;
        }

        #region Generate DB Scripts Methods
        public String GenerateFilter(Dictionary<String, String> primary_values)
        {
            String result = "";
            List<String> primary_keys = primary_values.Keys.ToList();
            if (primary_keys.Count > 0)
                result = " WHERE ";

            foreach (String key in primary_keys)
            {
                char[] delims = { '.' };
                String cleaned = (key.Contains('.') ? key.Split(delims)[1] : key);
                if (primary_keys.IndexOf(key) > 0)
                    result += " AND ";
                result += String.Format(" {0} = '{1}'", cleaned, primary_values[key].Replace("'", "''"));
            }

            return result;
        }

        public String GenerateSelect(String keywords, int records)
        {            
            // Format the primary columns
            String result = "SELECT TOP " + records;
            foreach (String column in columns)
            {
                if (columns.IndexOf(column) > 0)
                    result += ",";
                result += String.Format(" {0} [{1}] ", column, insert_list[column]);
            }

            // Format the primay table
            result += " FROM " + table;

            // Format the keywords
            List<String> words = keywords.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < words.Count; i++ )
            {
                String word = words[i];
                foreach (String column in columns)
                {
                    int j = columns.IndexOf(column);
                    if (j == 0 && i==0)
                    {
                        result += String.Format(" WHERE ({0} LIKE '%{1}%' ", column, word);
                    }
                    else 
                    {
                        result += String.Format(" OR {0} LIKE '%{1}%'", column, word);
                    }
                }
            }

            if (words.Count > 0)
            {
                result += ")";
            }

            return string.Format("{0};", result);
        }

        public String GenerateInsert(Dictionary<String, String> insertList)
        {
            CleanDictionaries(insertList);
          

            String result = "INSERT INTO ";
            char[] delim = { ' ' };
            result += table.Split(delim)[0] + "(";
            List<String> insertColumns = insertList.Keys.ToList();


            for (int i = 0; i < insertColumns.Count; i++)
            {
                char[] delims = { '.' };
                String cleaned = (insertColumns[i].Contains('.') ? (insertColumns[i].Split(delims))[1] : insertColumns[i]);
                result += (i == insertColumns.Count - 1) ? cleaned + ")" : cleaned + ",";
            }
            result += "VALUES(";

            for (int i = 0; i < insertColumns.Count; i++)
            {
                result += (i == insertColumns.Count - 1) ? "'" + insertList[insertColumns[i]].Replace("'", "''") + "')" : "'" + insertList[insertColumns[i]].Replace("'", "''") + "',";
            }

            return string.Format("{0};", result);

        }

        public String GenerateInsertUsingSelect(Dictionary<String, String> insertList, String SelectTable, params String[] parameters)
        {
            CleanDictionaries(insertList);

            Dictionary<String, String> col = new Dictionary<string, string>();
            foreach (string s in parameters)
                col.Add(s, s);
            String result = "INSERT INTO ";
            char[] delim = { ' ' };
            result += table.Split(delim)[0] + "(";
            List<String> insertColumns = insertList.Keys.ToList();


            for (int i = 0; i < insertColumns.Count; i++)
            {
                char[] delims = { '.' };
                String cleaned = (insertColumns[i].Contains('.') ? (insertColumns[i].Split(delims))[1] : insertColumns[i]);
                result += (i == insertColumns.Count - 1) ? cleaned + ")" : cleaned + ",";
            }
            result += "SELECT ";
            for (int i = 0; i < insertColumns.Count; i++)
            {
                if (col.ContainsKey(insertColumns[i]))
                    result += (i == insertColumns.Count - 1) ? "" + insertList[insertColumns[i]].Replace("'", "''") + "" : "" + insertList[insertColumns[i]].Replace("'", "''") + ",";
                else
                    result += (i == insertColumns.Count - 1) ? "'" + insertList[insertColumns[i]].Replace("'", "''") + "'" : "'" + insertList[insertColumns[i]].Replace("'", "''") + "',";
            }
            result += " FROM " + SelectTable;

            return string.Format("{0};\r\n", result);
        }


        public String GenerateUpdate(Dictionary<String, String> updateList, Dictionary<String, String> primary_values)
        {
            return GenerateUpdate(updateList, primary_values, null, null);
        }

        public String GenerateUpdate(Dictionary<String, String> updateList, Dictionary<String, String> primary_values, String compare_field, String compare_value)
        {
          

            String result = "";
            char[] delim = { ' ' };
            String compare_sql = "";
            if (compare_field != null)
            {
                compare_sql = GetVersionCompareSQL(this, compare_field, compare_value);
            }

            result = String.Format(" UPDATE {0} SET ", table.Split(delim));
            List<String> columns = updateList.Keys.ToList();
            for (int i = 0; i < columns.Count; i++)
            {
                char[] delims = { '.' };
                String cleaned = (columns[i].Contains('.') ? (columns[i].Split(delims))[1] : columns[i]);
                //if(!updateList.Contains(primary_values))
                bool found = false;
                foreach (KeyValuePair<String, String> kvp in primary_values)
                {
                    if (kvp.Key == columns[i])
                    {
                        found = true;
                        break;
                    }
                }

                if(!found)
                    result += String.Format(" {0}= '{1}' " + ((i == columns.Count - 1) ? "" : ","), cleaned, updateList[columns[i]].Replace("'","''"));
            }
            result += GenerateFilter(primary_values);
            result = compare_sql + result;
            return string.Format("{0};", result);
        }
 
        public String GenerateDelete(Dictionary<String, String> primary_values)
        {
            char[] delim = { ' ' };
            String result = String.Format(@"DELETE FROM {0} " + GenerateFilter(primary_values), table.Split(delim));
            return string.Format("{0};", result);
        }

        private static String GetVersionCompareSQL(DBTable table, String compare_field, String compare_value)
        {
            return String.Format(@" IF (SELECT ISNULL(COUNT(*),0) FROM {0} {1} AND CAST( {2} AS VARCHAR(1000)) = CAST( CAST( '{3}' AS datetime)AS VARCHAR(1000))) =0  BEGIN THROW 50000, 'The {0} version is not up to date. Please refresh the page.', 1; END ", table.table.Replace("'", ""), table.GenerateFilter(table.GetPrimaryValues()), compare_field.Replace("'", ""), compare_value.Replace("'", "''"));
        }



        public String GenerateCreateUpdate(Dictionary<String, String> valueList, Dictionary<String, String> primary_values)
        {
            return GenerateCreateUpdate(valueList, primary_values,null,null);
        }


        public String GenerateCreateUpdate(Dictionary<String, String> valueList, Dictionary<String, String> primary_values, String compare_field, String compare_value)
        {
            String result = "";
            char[] delim = { ' ' };
            

            CleanDictionaries(valueList);
            result += String.Format(@"IF EXISTS (SELECT TOP 1 * FROM {0} {1})
                            BEGIN
                               {2};
                            END
                            ELSE
                            BEGIN
	                            {3};
                            END ", table.Split(delim)[0], GenerateFilter(primary_values),GenerateUpdate(valueList,primary_values,compare_field, compare_value),GenerateInsert(valueList));

            return result;
        }

        public static void CleanDictionaries(Dictionary<String, String> dict)
        {
            List<String> for_delete = new List<String>();
            foreach (String key in dict.Keys)
            {
                String value = dict[key];
                if (value.Trim() == "")
                    for_delete.Add(key);
            }
            foreach (String key in for_delete)
            {
                dict.Remove(key);
            }
        }

        #endregion
        
    }


}
