using System;

namespace IB.Api.Client.Helper
{
    public class DateHelper
    {
        public static string ConvertToApiDate(DateTime dateTime){
            return dateTime.ToString("yyyyMMdd HH:mm:ss");
        }
    }
}
