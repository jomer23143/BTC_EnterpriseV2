using System.Reflection;
using System.Text;

namespace BTCP_EnterpriseV2
{
    public static class Def
    {
        /// <summary>
        /// DO NOT CHANGE!!!
        /// Registry Key
        /// </summary>
        ////public const string REGKEY_SUB = @"EVGL SYSTEM";
        ///
        public static string REGKEY_SUB
        {
            get { return GetREGKEY(); }
        }

        public const string REGKEY_ROOT = @"HKEY_CURRENT_USER\Software";

        public const byte GRID_K_PARENT = 0x1;

        private static string GetREGKEY()
        {
            string filename = string.Format(@"{0}\{1} - {2}", Path.GetDirectoryName(Application.ExecutablePath), Path.GetFileNameWithoutExtension(Assembly.GetAssembly(typeof(Utils)).CodeBase), "REGKEYSUB.def");
            if (!File.Exists(filename))
            {
                using (FileStream fs = File.Create(filename))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes(@"programs_key101");
                    fs.Write(title, 0, title.Length);
                }
            }

            string result = "";
            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(filename))
            {
                result = sr.ReadLine();
            }

            return result;
        }
    }
}
