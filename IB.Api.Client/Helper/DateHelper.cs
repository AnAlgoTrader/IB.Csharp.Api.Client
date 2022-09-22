using System.Globalization;
using System;
using System.Text.RegularExpressions;

namespace IB.Api.Client.Helper
{
    public static class DateHelper
    {
        public const string EuropeanDateFormat = "dd/MM/yyyy HH:mm:ss";
        public const string AmericanDateFormat = "yyyyMMdd HH:mm:ss";
        public static string ConvertToApiDate(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd HH:mm:ss");
        }
        public static DateTime UnixTimeStampToDateTime(double time)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(time).ToLocalTime();
        }
        public static long DateToEpoch(DateTime date, long multiplier = 1)
        {
            return Convert.ToInt64((date - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds * multiplier);
        }
        public static DateTime ApiToDate(string date)
        {
            return DateTime.ParseExact(Regex.Replace(date, @"\s+", " "), AmericanDateFormat, CultureInfo.InvariantCulture);
        }
    }
}
