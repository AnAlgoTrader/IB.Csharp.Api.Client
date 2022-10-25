using System;
using System.Collections.Generic;
using System.Linq;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Helper
{
    public class PortfolioHelper
    {
        public static void CalculatePortfolioPnl(PortfolioUpdate portfolioUpdate, List<Trade> trades)
        {
            var pnl = trades.Where(x => x.TradeAction == portfolioUpdate.Action).Sum(x => x.Pnl);
            portfolioUpdate.UnrealizedPnl = Math.Round(pnl.Value, 2);
        }

        public static double? CalculateTradePnl(Trade trade, double currentPrice)
        {
            if (trade.FillPrice != null)
            {
                var pnl = (currentPrice - trade.FillPrice) * double.Parse(trade.Multiplier) * trade.Quantity;
                var commission = trade.Commission * 3;
                if (trade.TradeAction == nameof(TradeAction.BUY))
                    return Math.Round(pnl.Value - commission, 2);
                else
                    return Math.Round((pnl.Value * -1.0) - commission, 2);
            }
            return 0;
        }

        public static void CalculateTradesPnl(List<Trade> trades, HistoricalTickBidAsk tick)
        {
            if (trades.Count > 0)
            {
                trades.ForEach(trade =>
                {
                    var price = trade.TradeAction == nameof(TradeAction.BUY) ? tick.PriceBid : tick.PriceAsk;
                    trade.Pnl = CalculateTradePnl(trade, price);
                });
            }
        }
    }
}
