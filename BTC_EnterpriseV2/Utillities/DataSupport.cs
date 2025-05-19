using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BTCP_EnterpriseV2.Utillities
{
    public class DataSupport : IDisposable
    {
        public static SqlConnection TestConnection;
        public static SqlTransaction TestTransaction;
        private static String connectString = "";
        private SqlConnection conn;
        public static int id = 1;

        public static String GetWarehouseCode()
        {
            return RunDataSet(String.Format("SELECT TOP 1 [Warehouse_code] FROM base_warehouses WHERE Warehouse_code = '{0}'", Utils.DBConnection["OMS"]["WNAME"])).Tables[0].Rows[0][0].ToString();
        }

        public static String GetWarehouseIndex()
        {
            return RunDataSet(String.Format("SELECT TOP 1 warehouse_index FROM base_warehouses WHERE Warehouse_code = '{0}'", Utils.DBConnection["OMS"]["WNAME"])).Tables[0].Rows[0][0].ToString();
        }

        public String ConnectionString
        {
            get
            {
                ///result = SqlCon.connectionString(ID);
                Utils.SetConnectionDetails();
                return connectString == "" ? BTCP_EnterpriseV2.Connection.GetConnectionStringReg : connectString;
            }
            set { connectString = value; }
        }

        #region SQL SCRIPT GENERATORS

        public static String GetInsert(String table, Dictionary<String, Object> insert_list)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            var dbtable = new DBTable(table, converted_list, new List<string>());
            result = dbtable.GenerateInsert(converted_list);
            return result + ";\r\n";
        }

        public static String GetInsertWithIndex(String table, Dictionary<String, Object> insert_list, String SelectTable, params String[] parameters)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            DBTable dbtable = new DBTable(table, converted_list, new List<String>());
            result = dbtable.GenerateInsertUsingSelect(converted_list, SelectTable, parameters);
            return result + ";\r\n";
        }

        public static String GetDelete(String table, params Object[] filters)
        {
            return GetDelete(table, Utils.ToDictionary(filters));
        }

        public static String GetDelete(String table, Dictionary<String, String> filters)
        {
            String result = String.Format("DELETE FROM " + table + " WHERE ");
            List<String> keys = filters.Keys.ToList();
            foreach (String key in keys)
            {
                if (keys.IndexOf(key) > 0)
                    result += " AND ";
                result += String.Format(" {0} = '{1}' ", key, filters[key].Replace("'", "''"));
            }
            return result;
        }

        public static String GetUpsert(String table, Dictionary<String, Object> insert_list, params String[] parameters)
        {
            return GetUpsert(table, insert_list, parameters.ToList());
        }

        public static String GetUpsert(String table, Dictionary<String, Object> insert_list, List<String> primary_keys)
        {
            return GetUpsert(table, insert_list, primary_keys, null, null);
        }

        public static String GetUpsert(String table, Dictionary<String, Object> insert_list, List<String> primary_keys, String compare_field, String compare_value)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            DBTable dbtable = new DBTable(table, converted_list, primary_keys);
            Dictionary<String, String> primary_values = new Dictionary<String, String>();
            foreach (String key in primary_keys)
            {
                primary_values.Add(key, insert_list[key].ToString());
            }
            result += dbtable.GenerateCreateUpdate(converted_list, primary_values, compare_field, compare_value);
            return result;
        }

        public static String GetUpdate(String table, Dictionary<String, Object> insert_list, List<String> primary_keys)
        {
            return GetUpdate(table, insert_list, primary_keys, null, null);
        }

        public static String GetUpdate(String table, Dictionary<String, Object> insert_list, List<String> primary_keys, String compare_field, String compare_value)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            DBTable dbtable = new DBTable(table, converted_list, primary_keys);
            Dictionary<String, String> primary_values = new Dictionary<String, String>();
            foreach (String key in primary_keys)
            {
                primary_values.Add(key, insert_list[key].ToString());
            }
            result = dbtable.GenerateUpdate(converted_list, primary_values, compare_field, compare_field);
            return result;
        }

        public static String GetWhereClause(Dictionary<String, String> filters)
        {
            String result = "";
            DBTable dbtable = new DBTable("", new Dictionary<String, String>(), filters.Keys.ToList());
            result = dbtable.GenerateFilter(filters);
            return result;
        }

        #endregion SQL SCRIPT GENERATORS

        #region RUN QUERY

        /// <summary>
        /// Runs a SQL from you database whatever
        /// </summary>
        /// <param name="sql">adsfasdf</param>
        /// <returns></returns>
        public static int RunNonQuery(String sql)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteNonQuery(sql);
        }

        public static int RunNonQuery(String sql, params Object[] parameters)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteNonQuery(sql, parameters);
        }

        public static int RunNonQuery(String sql, IsolationLevel level, params Object[] parameters)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteNonQuery(sql, level, parameters);
        }

        public static int RunNonQuery(String sql, IsolationLevel level, Dictionary<String, Object> parameters)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteNonQuery(sql, level, parameters);
        }

        public static DataSet RunDataSet(String sql)
        {
            if (UnitTestDetector.IsInUnitTest)
            {
                SqlCommand cmd = TestConnection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = TestTransaction;
                return ExecuteDataSet(cmd);
            }

            DataSupport ds = new DataSupport();
            return ds.ExecuteDataSet(sql);
        }

        public static DataSet RunDataSet(String sql, params Object[] parameters)
        {
            if (UnitTestDetector.IsInUnitTest)
            {
                SqlCommand cmd = TestConnection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = TestTransaction;
                return ExecuteDataSet(cmd, parameters);
            }
            DataSupport ds = new DataSupport();
            return ds.ExecuteDataSet(sql, parameters);
        }

        public static DataSet RunDataSet(String sql, Dictionary<String, Object> parameters)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteDataSet(sql, parameters);
        }

        public static Object RunScalar(String sql)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteScalar(sql);
        }

        public static Object RunScalar(String sql, params Object[] parameters)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteScalar(sql, Utils.ToDict(parameters));
        }

        public static Object RunScalar(String sql, Dictionary<String, Object> parameters)
        {
            DataSupport ds = new DataSupport();
            return ds.ExecuteScalar(sql, parameters);
        }

        #endregion RUN QUERY

        #region TRANSACTION CODE MANAGEMENT

        public static String GetNextMenuCode(String menu, String menu_prefix)
        {
            String result = "";
            String building_id = "WEB";

            DataSet ds = RunDataSet(String.Format("SELECT menu_current FROM base_doctype WHERE doctype_index = '{0}' ", menu));
            String next_value = ds.Tables[0].Rows[0][0].ToString();
            result = String.Format("{0}-{1}-{2}", building_id, menu_prefix, next_value);
            return result;
        }

        public static String GetNextMenuCodeInt(String menu, String menu_affix)
        {
            String result = "";

            DataSet ds = RunDataSet(String.Format("SELECT current_no FROM Base_DocType WHERE doctype_index = '{0}' ", menu) + UpdateMenuCode(menu));
            String next_value = ds.Tables[0].Rows[0][0].ToString();
            result = GetWarehouseCode() + "-" + menu_affix + "-" + next_value;
            return result;
        }

        public static String GetNextMenuCodeIntNonUpdate(String menu, string menu_affix)
        {
            DataSet ds = DataSupport.RunDataSet(String.Format("SELECT current_no FROM Base_DocType WHERE doctype_index = '{0}' ", menu));
            string next_value = ds.Tables[0].Rows[0]["current_no"].ToString();
            return $"{GetWarehouseCode()}-{menu_affix}-{next_value}";
        }

        public static void IncrementDocumentNumber(string menu)
        {
            RunDataSet(UpdateMenuCode(menu));
        }

        public static String UpdateMenuCode(String menu)
        {
            String result = "";
            result = String.Format(" UPDATE Base_DocType SET current_no = current_no + 1 WHERE doctype_index = '{0}';", menu);
            return result;
        }

        #endregion TRANSACTION CODE MANAGEMENT

        public void Dispose()
        {
            conn.Dispose();
        }

        private static void WrapExceptionInFriendlyMessage(SqlException ex)
        {
            if (ex.Number == 2627) // Primary Key
                throw new Exception("Save Failed. The CODE / ID you inputted is a duplicate. ", ex);
            if (ex.Number == 8114) // Parse Error Into Numeric
                throw new Exception("Save Failed. Typed LETTERS or SYMBOLS into textboxes that require only NUMBERS", ex);
        }

        private static DataSet ConvertDataReaderToDataSet(SqlDataReader reader)
        {
            DataSet dataSet = new DataSet();
            do
            {
                // Create new data table

                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    // A query returning records was executed

                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        // Create a column name that is unique in the data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        // Add the column definition to the data table
                        DataColumn column = new DataColumn(columnName);
                        try
                        {
                            dataTable.Columns.Add(column);
                        }
                        catch (DuplicateNameException)
                        {
                            int count = 0;
                            while (dataTable.Columns[columnName] != null)
                            {
                                columnName += count;
                                count++;
                            }
                            column.ColumnName = columnName;
                            dataTable.Columns.Add(column);
                        }
                    }

                    dataSet.Tables.Add(dataTable);

                    // Fill the data table we just created

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // No records were returned

                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());

            foreach (DataTable dt in dataSet.Tables)
            {
                dt.AcceptChanges();
            }
            reader.Close();
            return dataSet;
        }

        private static Dictionary<String, String> ConvertToStringValues(Dictionary<String, Object> list)
        {
            Dictionary<String, String> result = new Dictionary<String, String>();
            foreach (String key in list.Keys)
            {
                result.Add(key, list[key].ToString());
            }
            return result;
        }

        #region LEGACY LOGIC CODE

        /// <summary>
        /// A SQL Manager Object with the default connection string
        /// </summary>
        public DataSupport()
        {
            String conString = ConnectionString;
            this.conn = new SqlConnection(conString);
        }

        /// <summary>
        /// A SQL Manager Object
        /// </summary>
        /// <param name="conn">The custom connection string</param>
        public DataSupport(String conn)
        {
            String conString = conn;
            this.conn = new SqlConnection(conString);
        }

        public int ExecuteNonQuery(String sql, params Object[] parameters)
        {
            return ExecuteNonQuery(sql, IsolationLevel.ReadCommitted, Utils.ToDict(parameters));
        }

        /// <summary>
        /// Run an unescaped and non-parameterized sql
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>Number of rows affected</returns>
        public int ExecuteNonQuery(String sql)
        {
            if (UnitTestDetector.IsInUnitTest)
                throw new AccessViolationException();
            int result = 0;
            try
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                result = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                result = 0;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Run an unescaped and non-parameterized sql
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>Result Set</returns>
        public DataSet ExecuteDataSet(String sql)
        {
            DataSet result = null;
            try
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                result = ConvertDataReaderToDataSet(command.ExecuteReader());
            }
            catch (SqlException ex)
            {
                ex.ToString();
                result = null;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        //public static DataTable RunDataTableDapper(string sql, Dictionary<string, object> kvp = null)
        //{
        //    using (var conn = new SqlConnection(AutobackUp.Connection.GetOMSConnectionString()))
        //    {
        //        IDataReader reader;

        //        if (kvp == null)
        //            reader = conn.ExecuteReader(sql);
        //        else
        //            reader = conn.ExecuteReader(sql, new DynamicParameters(kvp));

        //        var table = new DataTable();

        //        table.Load(reader);

        //        return table;
        //    }
        //}

        public static String GetUnparameterizedSQL(String sql, SqlParameterCollection parameters)
        {
            String result = sql;
            foreach (SqlParameter kvp in parameters)
                result = result.Replace("@" + kvp.ParameterName, "'" + kvp.Value + "'");
            return result;
        }

        public DataSet ExecuteDataSet(String sql, params Object[] parameters)
        {
            return ExecuteDataSet(sql, Utils.ToDict(parameters));
        }

        /// <summary>
        /// Run an parameterized sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters">P</param>
        /// <returns>Result Set</returns>
        public DataSet ExecuteDataSet(String sql, Dictionary<String, Object> parameters)
        {
            DataSet result = null;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }

                // GetUnparameterizedSQL(sql, command.Parameters);
                result = ConvertDataReaderToDataSet(command.ExecuteReader());
            }
            catch (SqlException ex)
            {
                ex.ToString();
                result = null;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Run an parameterized sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns>The contents of the first cell of the first row of the Result Set</returns>
        public Object ExecuteScalar(String sql, Dictionary<String, Object> parameters)
        {
            Object result = null;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }
                result = command.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                ex.ToString();
                result = null;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Run an unescaped and non-parameterized sql
        /// </summary>
        /// <param name="sql">The contents of the first cell of the first row of the Result Set</param>
        /// <returns>The contents of the first cell of the first row of the Result Set</returns>
        public Object ExecuteScalar(String sql)
        {
            return ExecuteScalar(sql, null);
        }

        /// <summary>
        /// Run an parameterized sql
        /// <
        /// /summary>
        /// <param name="sql"></param>
        /// <param name="level">Locking Mechanism for the Transaction</param>
        /// <param name="parameters"></param>
        /// <returns>Number of Rows Affected</returns>
        public int ExecuteNonQuery(String sql, IsolationLevel level, Dictionary<String, Object> parameters)
        {
            if (UnitTestDetector.IsInUnitTest)
                throw new AccessViolationException();
            int result = 0;
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction(level);
                SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                command.CommandText = sql;
                command.CommandTimeout = 60000;
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }
                result = command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (SqlException ex)
            {
                result = 0;
                trans.Rollback();
                WrapExceptionInFriendlyMessage(ex);
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int ExecuteNonQueryBulk(List<String> sql_list)
        {
            if (UnitTestDetector.IsInUnitTest)
                throw new AccessViolationException();
            int result = 0;
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                // command.CommandText = sql;
                command.CommandTimeout = 60000;

                result = command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (SqlException ex)
            {
                result = 0;
                trans.Rollback();
                WrapExceptionInFriendlyMessage(ex);
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Run an unescaped and non-parameterized sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="level"></param>
        /// <returns>Number of Rows Affected</returns>
        public int ExecuteNonQuery(String sql, IsolationLevel level)
        {
            if (UnitTestDetector.IsInUnitTest)
                throw new AccessViolationException();
            int result = 0;
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction(level);
                SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                command.CommandText = sql;
                command.CommandTimeout = 60000;

                result = command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (SqlException ex)
            {
                result = 0;
                trans.Rollback();
                WrapExceptionInFriendlyMessage(ex);
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Run an parameterized sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="level"></param>
        /// <returns>D</returns>
        public DataSet ExecuteDataSet(String sql, IsolationLevel level)
        {
            DataSet result = null;

            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = ConvertDataReaderToDataSet(reader);
                reader.Close();
            }
            catch (SqlException ex)
            {
                ex.ToString();
                result = null;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        #endregion LEGACY LOGIC CODE

        public static DataSet ExecuteDataSet(SqlCommand cmd)
        {
            return ExecuteDataSet(cmd, new Dictionary<string, object>());
        }

        public static DataSet ExecuteDataSet(SqlCommand cmd, params Object[] list)
        {
            return ExecuteDataSet(cmd, ConvertToDict(list));
        }

        private static Dictionary<string, object> ConvertToDict(Object[] list)
        {
            Dictionary<String, Object> dict = new Dictionary<string, object>();
            if (list.Length % 2 != 0)
                throw new ArgumentException("Must be odd number in the list");
            for (int i = 0; i < list.Length; i += 2)
                dict.Add(list[i].ToString(), list[i + 1]);
            return dict;
        }

        public static DataSet ExecuteDataSet(SqlCommand cmd, Dictionary<String, Object> parameters)
        {
            DataSet result = null;
            if (parameters != null)
                foreach (KeyValuePair<String, Object> kvp in parameters)
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            result = ConvertDataReaderToDataSet(cmd.ExecuteReader());
            return result;
        }
        public static DataTable RunDataTableDapper(string sql)
        {
            using (var conn = new SqlConnection(BTCP_EnterpriseV2.Connection.GetConnectionStringReg))
            {
                IDataReader reader;
                reader = conn.ExecuteReader(sql);
                var table = new DataTable();

                table.Load(reader);

                return table;
            }
        }

        public static DataTable RunDataTableDapper(string sql, object param)
        {
            using (var conn = new SqlConnection(BTCP_EnterpriseV2.Connection.GetConnectionStringReg))
            {
                IDataReader reader;
                reader = conn.ExecuteReader(sql, param);
                var table = new DataTable();
                table.Load(reader);

                return table;
            }
        }
        public DataTable RunDataTableDapper(string sql, Dictionary<string, object> kvp = null)
        {
            var table = new DataTable();
            try
            {
                IDataReader reader;

                conn.Open();
                if (kvp == null)
                    reader = conn.ExecuteReader(sql);
                else
                    reader = conn.ExecuteReader(sql, new DynamicParameters(kvp));

                table.Load(reader);
            }
            catch
            {
                conn.Close();
            }
            finally
            {
                conn.Close();
                SqlConnection.ClearPool(conn);
            }
            return table;
        }
    }
}
