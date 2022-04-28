using System;

namespace IB.Api.Client.Helper
{
    public class DateHelper
    {
        public static string ConvertToApiDate(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd HH:mm:ss");
        }

        public static DateTime UnixTimeStampToDateTime(double time)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(time).ToLocalTime();
            return dateTime;
        }
    }
}
