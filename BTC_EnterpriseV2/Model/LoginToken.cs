namespace BTC_EnterpriseV2.Model
{
    public class LoginToken
    {
        public class Permission
        {
            public int id { get; set; }
            public string name { get; set; }
            public string guard_name { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Pivot pivot { get; set; }
        }

        public class Pivot
        {
            public string model_type { get; set; }
            public int model_id { get; set; }
            public int permission_id { get; set; }
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

        public class Root
        {
            public User user { get; set; }
            public string token { get; set; }
        }

        public class Settings
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public int is_dark { get; set; }
            public string theme_header { get; set; }
            public string theme_header_text { get; set; }
            public string theme_background { get; set; }
            public string theme_button { get; set; }
            public string theme_button_text { get; set; }
            public string theme_menu { get; set; }
            public string theme_menu_text { get; set; }
            public string theme_input { get; set; }
            public string theme_color { get; set; }
            public string theme_background_color { get; set; }
            public string theme_component_header { get; set; }
            public string theme_component_header_text { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public object rfid_no { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public object email_verified_at { get; set; }
            public object employee_id { get; set; }
            public object job_title { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public List<Permission> permissions { get; set; }
            public Settings settings { get; set; }
            public Profile profile { get; set; }
        }

    }
}
