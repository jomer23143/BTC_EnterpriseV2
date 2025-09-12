namespace BTC_EnterpriseV2.Model
{
    public class LoginToken
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Employee
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public string? employee_id_no { get; set; }
            public int department_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<License>? licenses { get; set; }
        }

        public class License
        {
            public int id { get; set; }
            public int employee_id { get; set; }
            public int license_id { get; set; }
            public int is_active { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public License2? license { get; set; }
        }

        public class License2
        {
            public int id { get; set; }
            public string? name { get; set; }
            public string? license_no { get; set; }
            public int license_type_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public LicenseType? license_type { get; set; }
        }

        public class LicenseType
        {
            public int id { get; set; }
            public string? name { get; set; }
            public object? description { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class Profile
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public string? first_name { get; set; }
            public string? middle_name { get; set; }
            public string? last_name { get; set; }
            public string? gender { get; set; }
            public string? birth_date { get; set; }
            public string? contact_number { get; set; }
            public string? permanent_address { get; set; }
            public string? present_address { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<object>? media { get; set; }
        }

        public class Root
        {
            public User? user { get; set; }
            public string? token { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string? rfid_no { get; set; }
            public string? name { get; set; }
            public string? email { get; set; }
            public object? email_verified_at { get; set; }
            public object? employee_id { get; set; }
            public object? job_title { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Profile? profile { get; set; }
            public Employee? employee { get; set; }
        }
    }
}
