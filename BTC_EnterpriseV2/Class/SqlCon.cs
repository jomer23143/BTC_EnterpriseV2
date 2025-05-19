using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace BTCP_EnterpriseV2.Class
{
    public static class SqlCon
    {
        public static async Task<SqlConnection> connections(string sqlconn)
        {
            SqlConnection conn;
            conn = new SqlConnection();
            //   conn.ConnectionString = "Data source=194.163.40.175;initial catalog=icehrm; uid=root;pwd=";
            conn.ConnectionString = sqlconn;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await Task.Run(() =>
                    {
                        //    conn.Open();
                        Console.WriteLine("Success");
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return conn;
        }
        public static string AssemblyDirectory
        {
            get
            {
                string path = Assembly.GetExecutingAssembly().Location;
                string? dir = System.IO.Path.GetDirectoryName(path);
                if (dir == null)
                {
                    Console.WriteLine("Warning: Assembly directory could not be determined.");
                    return string.Empty;
                }
                return dir;
            }
        }


        public static string connectionString(int con)
        {
            string txtpath = "";
            string connection = "";
            if (con == 1)
                txtpath = $@"{AssemblyDirectory}\connection\connectionString.txt";
            else
                txtpath = $@"{AssemblyDirectory}\connection\Cloud.txt";

            try
            {
                if (File.Exists(txtpath))
                {
                    using (StreamReader sr = new StreamReader(txtpath))
                    {
                        connection = sr.ReadLine() ?? string.Empty;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }

            return connection;
        }

    }
}
