using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using BTCP_EnterpriseV2.Utillities;
using Utility.ModifyRegistry;

public static class Utils
{
    public static double RoundUp(double input, int places)
    {
        double multiplier = Math.Pow(10, Convert.ToDouble(places));
        return Math.Ceiling(input * multiplier) / multiplier;
    }
    public static Dictionary<String, Dictionary<String, String>> DBConnection
    { get; set; }

    public static string Join(string str, string existing, string separator = ",")
    {
        if (IsNull(existing)) return str;
        if (IsNull(str)) return existing;

        return string.Format("{1}{2}{0}", str, existing, separator);
    }

    public static bool IsInt(object obj)
    {
        if (obj == null) return true;

        int temp = 0;
        return int.TryParse(obj.ToString(), out temp);
    }

    public static bool IsDate(String val)
    {
        if (IsNull(val)) return false;
        DateTime temp;
        if (DateTime.TryParse(val, out temp))
            return true;
        else
            return false;

    }

    public static string Quote(string val)
    {
        if (IsNull(val)) return string.Empty;

        return string.Format("'{0}'", Clean(val));
    }

    public static string Quote(object obj)
    {
        if (IsNull(obj)) string.Format("'{0}'", String.Empty);

        return string.Format("'{0}'", obj);
    }

    public static long ToLong(object obj)
    {
        var val = Clean(obj);
        return ToLong(val);
    }

    public static long ToLong(string val)
    {
        long l = 0;
        long.TryParse(val, NumberStyles.Any, CultureInfo.CurrentCulture, out l);
        return l;
    }

    public static long ToLong(double val)
    {
        if (val == 0) return 0;
        return Convert.ToInt64(Math.Truncate(val));
    }

    //toval

    public static double ToVal(int val)
    {
        if (val == 0) return 0d;
        return Convert.ToDouble(val);
    }

    public static double ToVal(object obj)
    {

        if (obj is decimal)
        {
            var vald = (decimal)obj;
            return decimal.ToDouble(vald);
        }
        else
        {
            var val = Clean(obj);
            return ToVal(val);
        }
    }

    public static double ToVal(string val)
    {
        var d = 0d;
        double.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out d);
        return d;
    }

    //to dec

    public static decimal ToDec(string val)
    {
        decimal d = 0;
        decimal.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out d);
        return d;
    }

    //tobool
    public static bool ToBool(int val)
    {
        switch (val)
        {
            case 1:
            case -1:
                return true;

            default:
                return false;

        }
    }

    public static bool ToBool(double val)
    {
        switch (val)
        {
            case 1:
            case -1:
                return true;

            default:
                return false;

        }
    }

    public static bool ToBool(string val)
    {
        switch (Clean(val))
        {
            case "TRUE":
            case "T":
            case "Y":
            case "YES":
            case "1":
            case "-1":
            case "OK":
                return true;

            default:
                return false;

        }
    }

    public static bool ToBool(object obj)
    {
        if (obj == null) return false;
        if (obj is bool)
        {
            return (bool)obj;
        }
        else if (obj is string)
        {
            return ToBool(obj.ToString());
        }
        else if (obj is int)
        {
            return ToBool(ToInt(obj.ToString()));
        }
        else if (obj is double)
        {
            return ToBool(ToVal(obj.ToString()));
        }
        else
        {
            return false;
        }
    }

    public static int ToInt(object obj)
    {
        var s = Clean(obj);
        return int.Parse(s, System.Globalization.NumberStyles.Any);
    }


    public static bool IsNull(string val)
    {
        return string.IsNullOrWhiteSpace(val);
    }

    public static bool IsNull(params string[] val)
    {
        foreach (var s in val)
            if (IsNull(s)) return true;

        return false;
    }

    public static bool IsNull<T>(IEnumerable<T> collection)
    {
        if (collection == null) return true;
        if (collection.Count() <= 0) return true;

        return false;
    }


    public static bool IsNull(object obj)
    {
        if (obj == null) return true;

        if (obj.GetType() == typeof(string))
            return string.IsNullOrWhiteSpace(obj.ToString());
        else if (obj.GetType() == typeof(DBNull))
            return true;

        else
            return false;
    }

    public static bool IsNull(DataTable dt)
    {
        if (dt == null) return true;
        if (dt.Rows.Count <= 0) return true;

        return false;
    }


    public static string Clean(object obj)
    {
        if (obj == null) return string.Empty;

        return obj.ToString();
    }
    public static string Clean(object obj, bool upper)
    {
        var str = Clean(obj);
        if (upper) return str.ToUpper();
        return str;
    }

    public static Image ToImage(string base64)
    {
        if (IsNull(base64)) return null;

        byte[] bytes = Convert.FromBase64String(base64);

        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
        }

        return image;
    }
    public static String ToString(object obj)
    {
        return String.Format("{0}", obj);
    }

    public static Dictionary<String, Object> ToDict(params Object[] arr)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        String key = null;
        for (int i = 0; i < arr.Length; i++)
        {
            var str = arr[i].ToString();
            var is_even = i % 2 == 0;
            if (is_even)
            {
                result.Add(str, null);
                key = str;
            }
            else
            {
                result[key] = str;
            }
        }
        return result;
    }

    public static String RenderProgressBar(int perc, String color, String text_color)
    {
        var perc_width = perc * 2;
        var base_width = 100 * 2;
        if (perc_width <= 50)
            perc_width = 50;
        String result = @"<div style='background-color:" + color + ";text-align:center;color:" + text_color + @";display:inline-block; width:" + perc_width + @"px;padding:5px;border-top-left-radius:10px;border-bottom-left-radius:10px;margin:0px;border:1px black solid;border-right:0px;'>" + perc + @" % </div><div style='background-color:white;color:white;display:inline-block; width:" + (base_width - perc_width) + @"px;padding:5px;border-top-right-radius:10px;border-bottom-right-radius:10px;margin:0px;margin:0px;border:1px black solid;border-left:0px;'>&nbsp;</div>";
        if (perc == 0)
            result = "<div style='background-color:white;text-align:center;color:black;display:inline-block;width:" + base_width + "px;padding:5px;border-radius:10px;border:1px solid black;'>0 %</div>";
        return result;
    }

    public static Dictionary<String, DataRow> BuildIndex(String SQLCommand, String ColumnName)
    {
        DataTable table = DataSupport.RunDataSet(SQLCommand).Tables[0];
        Dictionary<String, DataRow> index = new Dictionary<String, DataRow>(table.Rows.Count);
        foreach (DataRow Row in table.Rows)
        { index[Row[ColumnName].ToString()] = Row; }
        return index;
    }

    public static Dictionary<String, DataRow> BuildIndex_DataTable(DataTable table, String ColumnName)
    {
        Dictionary<String, DataRow> index = new Dictionary<String, DataRow>(table.Rows.Count);
        foreach (DataRow Row in table.Rows)
        { index[Row[ColumnName].ToString()] = Row; }
        return index;
    }

    public static Dictionary<String, DataRow> BuildIndex(String SQLCommand, List<String> ColumnName, String seperator)
    {
        DataTable table = DataSupport.RunDataSet(SQLCommand).Tables[0];
        Dictionary<String, DataRow> index = new Dictionary<String, DataRow>(table.Rows.Count);
        foreach (DataRow Row in table.Rows)
        {
            String key = "";
            int cnt = 0;

            foreach (String col in ColumnName)
            {
                if (cnt == ColumnName.Count - 1)
                    key += Row[col].ToString().Trim();
                else
                    key += Row[col].ToString().Trim() + seperator;
                cnt++;
            }

            index[key] = Row;
        }
        return index;
    }

    public static Dictionary<String, Object> ConvertToDict(this NameValueCollection form)
    {
        var result = new Dictionary<String, Object>();
        foreach (var key in form.Keys)
            result.Add(key.ToString(), form[key.ToString()]);
        return result;
    }

    public static T ParseAsEnum<T>(this String str)
    {
        foreach (T t in (T[])Enum.GetValues(typeof(T)))
            if (t.ToString() == str.Replace(" ", "_"))
                return t;
        throw new KeyNotFoundException();
    }

    public static DataTable ForEvery(this DataTable dt, Func<DataRow, DataRow> func)
    {
        foreach (DataRow row in dt.Rows)
            func(row);
        return dt;
    }

    public static DataRow ForEvery(this DataRow row, Func<Object, Object> func)
    {
        DataTable dt = row.Table;
        foreach (DataColumn col in dt.Columns)
            row[col] = func(row[col]);
        return row;
    }

    public static List<String> ToList(params String[] parameters)
    {
        return parameters.ToList();
    }

    public static Dictionary<String, String> ToDictionary(params Object[] arr)
    {
        Dictionary<string, String> result = new Dictionary<string, String>();
        String? key = null;
        for (int i = 0; i < arr.Length; i++)
        {
            var str = arr[i].ToString();
            var is_even = i % 2 == 0;
            if (is_even)
            {
                result.Add(str, null);
                key = str;
            }
            else
            {
                result[key] = str;
            }
        }
        return result;
    }

    public static Dictionary<String, Object> AsDict(params Object[] arr)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        for (int i = 0; i < arr.Length; i++)
            result.Add(arr[i].ToString(), arr[i]);
        return result;
    }

    public static Dictionary<string, object> GetPercentageDict()
    {
        var dict = new Dictionary<String, Object>();
        for (int i = 0; i <= 100; i++)
            dict.Add(i.ToString(), i.ToString("00") + " %");
        return dict;
    }

    public static Dictionary<String, Object> GetCount(int start, int end)
    {
        Dictionary<String, Object> result = new Dictionary<string, object>();
        for (int i = start; i <= end; i++)
            result.Add(i.ToString("00"), i.ToString("00"));
        return result;
    }

    public static string Linkify(string str, Boolean bookings, Boolean payments, Boolean admin)
    {
        if (bookings)
        {
            Regex re = new Regex(@"Booking\s#\d*", RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(str);
            foreach (Match mt in mc)
                str = str.Replace(mt.ToString(), "<strong>" + "<a href='javascript:show_booking_details(\"" + mt.ToString().Split('#')[1] + "\");'>" + mt + "</a>" + "</strong>");
        }
        if (payments)
        {
            Regex re = new Regex(@"Payment\s#\d*", RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(str);
            foreach (Match mt in mc)
                str = str.Replace(mt.ToString(), "<strong>" + "<a href='javascript:show_payment_details(\"" + mt.ToString().Split('#')[1] + "\");'>" + mt + "</a>" + "</strong>");
        }
        if (admin)
        {
            Regex re = new Regex(@"by\s\w*", RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(str);
            foreach (Match mt in mc)
                str = str.Replace(mt.ToString(), "<strong>" + "<a href='javascript:show_admin_adjustments(\"" + mt.ToString().Split(' ')[1] + "\");'>" + mt + "</a>" + "</strong>");
        }
        return str;
    }

    public static void SetConnectionDetails()
    {
        RegistrySupport registry = new RegistrySupport();
        String data = registry.Read(BTCP_EnterpriseV2.Def.REGKEY_SUB);

        if (data == null)
            return;

        String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<String, Dictionary<String, String>> conn = new Dictionary<String, Dictionary<String, String>>();
        foreach (String program in programs)
        {
            String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<String, String> details = new Dictionary<String, String>();
            details.Add("NAME", records[0]);
            details.Add("SERVER", records[1]);
            details.Add("USERNAME", records[2]);
            details.Add("PASSWORD", records[3]);
            details.Add("DBNAME", records[4]);
            switch (records[0].ToUpper())
            {
                case "BTC_ENTERPRISE":
                    conn.Add("BTC_ENTERPRISE", details);
                    break;
                case "PTA":
                    conn.Add("PTA", details);
                    break;
            }
        }
        DBConnection = conn;
    }
    public static byte[] ConvertImageToByteArray(Image imageToConvert,
                               System.Drawing.Imaging.ImageFormat formatOfImage)
    {
        byte[] Ret;
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
        }
        catch (Exception) { throw; }
        return Ret;
    }

    public static DateTime RandomDate()
    {
        var random = new Random();
        int dayMinRange = 1095;
        int dayMaxRange = 1827;
        return DateTime.Today.AddDays(random.Next(dayMinRange, dayMaxRange));
    }

    internal static object ConvertImageToByteArray(Image image)
    {
        throw new NotImplementedException();
    }
}

public static class UnitTestDetector
{
    static UnitTestDetector()
    {
        string testAssemblyName = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
        IsInUnitTest = AppDomain.CurrentDomain.GetAssemblies()
            .Any(a => a.FullName.StartsWith(testAssemblyName));
    }

    public static bool IsInUnitTest { get; private set; }
}