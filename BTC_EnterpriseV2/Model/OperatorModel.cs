namespace BTC_EnterpriseV2.Model
{
    public class OperatorModel
    {

        public class ApiResponse
        {
            public User user { get; set; }
            public string token { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string rfid_no { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public DateTime? email_verified_at { get; set; }
            public string employee_id { get; set; }
            public string job_title { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }

            public Profile profile { get; set; }
            public Employee employee { get; set; }
        }

        public class Profile
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string last_name { get; set; }
            public string gender { get; set; }
            public string birth_date { get; set; }
            public string contact_number { get; set; }
            public string permanent_address { get; set; }
            public string present_address { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<object> media { get; set; }
        }

        public class Employee
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public string employee_id_no { get; set; }
            public int department_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }

            public List<LicenseAssignment> licenses { get; set; }
        }

        public class LicenseAssignment
        {
            public int id { get; set; }
            public int employee_id { get; set; }
            public int? product_id { get; set; }
            public string product_name { get; set; }
            public int license_id { get; set; }
            public string license_type { get; set; }
            public string license_code { get; set; }
            public int? license_count { get; set; }
            public string license_no { get; set; }
            public bool? approved { get; set; }
            public DateTime? approved_date { get; set; }
            public DateTime? expiry_date { get; set; }
            public int is_active { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }

            public License license { get; set; }
        }

        public class License
        {
            public int id { get; set; }
            public string department_id { get; set; }
            public string name { get; set; }
            public int license_type_id { get; set; }
            public string code { get; set; }
            public string training_requirements { get; set; }
            public string license_approval_requirements { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }

            public LicenseType license_type { get; set; }
        }

        public class LicenseType
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }



    }
}
