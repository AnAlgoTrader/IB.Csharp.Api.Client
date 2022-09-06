using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            var lastTradeDateOrContractMonth = contractDetails.Contract.LastTradeDateOrContractMonth;
            var tradingHours = contractDetails.TradingHours.Split(';');
            foreach (var item in tradingHours)
            {
                var tradingHoursItem = item.Trim();
                if (tradingHoursItem.Length > 0)
                {
                    if (ValidTradingHoursItem(tradingHoursItem))
                    {
                        var hours = tradingHoursItem.Split('-');
                        var tradingHour = new TradingHours
                        {
                            Symbol = contractDetails.Contract.Symbol,
                            Start = DateTime.ParseExact(hours[0].Trim(), dateFormat, CultureInfo.InvariantCulture).ToLocalTime(),
                            End = DateTime.ParseExact(hours[1].Trim(), dateFormat, CultureInfo.InvariantCulture).ToLocalTime(),
                            LastTradeDate = DateTime.ParseExact(lastTradeDateOrContractMonth.Trim(), "yyyyMMdd", CultureInfo.InvariantCulture).ToShortDateString()
                        };
                        output.Add(tradingHour);
                    }
                }
            }
            return output.OrderBy(x => x.Start).ToList(); ;
        }

        public static TradingHours GetNextSession(ContractDetails contractDetails)
        {
            var tradingHours = GetTradingHours(contractDetails);

            var nextSession = tradingHours.Where(x =>
                (DateTime.Now > x.Start && DateTime.Now < x.End) ||
                (DateTime.Now < x.Start && DateTime.Now < x.End)
                )
                .FirstOrDefault();

            return nextSession;
        }

        private static bool ValidTradingHoursItem(string tradingHoursItem)
        {
            return !tradingHoursItem.Contains("CLOSED");
        }

        /// <summary>
        /// An example of EUR/USD would be symbol=EUR and currency=USD
        /// </summary>
        /// <param name="ibClient"></param>
        /// <param name="symbol"></param>
        /// <param name="currency"></param>
        public static void RequestForexContract(IBClient ibClient, string symbol, string currency)
        {
            ibClient.GetContractDetails(new Contract
            {
                Symbol = symbol,
                SecType = SecurityType.CASH.ToString(),
                Exchange = "IDEALPRO",
                Currency = currency
            });
        }

        public static void RequestFutureContract(IBClient ibClient, string symbol)
        {
            ibClient.GetContractDetails(symbol, SecurityType.FUT);
        }

        public static void RequestComodityContract(IBClient ibClient, string symbol, string currency)
        {
            ibClient.GetContractDetails(new Contract
            {
                Symbol = symbol,
                SecType = SecurityType.CMDTY.ToString(),
                Exchange = "SMART",
                Currency = currency
            });
        }
    }
}
