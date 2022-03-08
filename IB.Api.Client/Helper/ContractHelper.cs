using System;
using System.Collections.Generic;
using System.Globalization;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Helper
{
    public class ContractHelper
    {
        public static List<TradingHours> GetTradingHours(ContractDetails contractDetails)
        {
            var dateFormat = "yyyyMMdd:HHmm";
            var output = new List<TradingHours>();
            var tradingHours = contractDetails.TradingHours.Split(";");
            foreach (var item in tradingHours)
            {
                var tradingHoursItem = item.Trim();
                if (tradingHoursItem.Length > 0)
                {
                    if (ValidTradingHoursItem(tradingHoursItem))
                    {
                        var hours = tradingHoursItem.Split("-");
                        var tradingHour = new TradingHours
                        {
                            Start = DateTime.ParseExact(hours[0].Trim(), dateFormat, CultureInfo.InvariantCulture),
                            End = DateTime.ParseExact(hours[1].Trim(), dateFormat, CultureInfo.InvariantCulture)
                        };
                        output.Add(tradingHour);
                    }
                }
            }
            return output;
        }

        private static bool ValidTradingHoursItem(string tradingHoursItem)
        {
            return !tradingHoursItem.Contains("CLOSED");
        }
    }
}
