namespace BTC_EnterpriseV2.Model
{
    internal class UserIdentifiactionModel
    {
        internal object? item;
        internal object? items;

        public User? user { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string? rfid_no { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? employee_id { get; set; }
        public string? job_title { get; set; }
        public Profile? profile { get; set; }
    }

    public class Profile
    {
        public string? first_name { get; set; }
        public string? middle_name { get; set; }
        public string? last_name { get; set; }
        public string? gender { get; set; }
        public string? birth_date { get; set; }
        public string? contact_number { get; set; }
    }
}
