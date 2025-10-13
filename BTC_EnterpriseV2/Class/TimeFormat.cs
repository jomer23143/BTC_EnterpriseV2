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


        public static TimeSpan ParseCustomDuration(string durationString)
        {
            if (string.IsNullOrEmpty(durationString) || durationString.Trim().Equals("0", StringComparison.OrdinalIgnoreCase))
            {
                return TimeSpan.Zero;
            }

            int days = 0;
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            string[] parts = durationString.Split(':');

            foreach (string part in parts)
            {
                // Split each part by space and get the first number
                string[] tokens = part.Trim().Split(' ');

                if (tokens.Length >= 2 && int.TryParse(tokens[0], out int value))
                {
                    string unit = tokens[1].ToLower();

                    if (unit.StartsWith("day"))
                    {
                        days = value;
                    }
                    else if (unit.StartsWith("hr")) // Checks for hrs
                    {
                        hours = value;
                    }
                    else if (unit.StartsWith("min")) // Checks for mins
                    {
                        minutes = value;
                    }
                    else if (unit.StartsWith("second")) // Checks for seconds
                    {
                        seconds = value;
                    }
                }
            }


            return new TimeSpan(days, hours, minutes, seconds);
        }

    }
}
