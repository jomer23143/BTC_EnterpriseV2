namespace BTC_EnterpriseV2.Class
{
    public class TimeFormat
    {
        public string FormatDuration(TimeSpan duration)
        {
            return $"{duration.Days} Day{(duration.Days != 1 ? "s" : "")} : " +
                   $"{duration.Hours} hr{(duration.Hours != 1 ? "s" : "")} : " +
                   $"{duration.Minutes} min{(duration.Minutes != 1 ? "s" : "")} : " +
                   $"{duration.Seconds} Second{(duration.Seconds != 1 ? "s" : "")}";
        }

    }
}
