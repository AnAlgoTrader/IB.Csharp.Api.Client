using System;
using System.Collections.Generic;
using System.Linq;
using IB.Api.Client.Model;
namespace IB.Api.Client.Helper
{
    public class PortfolioHelper
    {
        public static void CalculatePortfolioPnl(PortfolioUpdate portfolioUpdate, List<Trade> trades)
        {
            var pnl = trades.Where(x => x.TradeAction == portfolioUpdate.Action).Sum(x => x.Pnl);
            portfolioUpdate.UnrealizedPnl = Math.Round(pnl.Value, 2);
        }
        public static void CalculatePortfolioPnl(PortfolioUpdate portfolioUpdate, List<BracketTrade> trades)
        {
            var pnl = trades.Where(x => x.ParentTrade.TradeAction == portfolioUpdate.Action).Sum(x => x.ParentTrade.Pnl);
            portfolioUpdate.UnrealizedPnl = Math.Round(pnl.Value, 2);
        }
        public static double? CalculateTradePnl(BracketTrade trade, double currentPrice)
        {
            var pnl = (currentPrice - trade.ParentTrade.FillPrice) * double.Parse(trade.ParentTrade.Multiplier) * trade.ParentTrade.Quantity;
            var commission = trade.ParentTrade.Commission * 3;
            if (trade.ParentTrade.TradeAction == nameof(TradeAction.BUY))
                return Math.Round(pnl.Value - commission, 2);
            else
                return Math.Round((pnl.Value * -1.0) - commission, 2);
        }
        public static void CalculateTradesPnl(List<BracketTrade> trades, double price)
        {
            if (trades.Count > 0)
            {
                trades.Where(x => x.StopTrade.Status != OrderStatus.FILLED && x.TakeProfitTrade.Status != OrderStatus.FILLED).ToList().ForEach(trade =>
                {
                    if (trade.ParentTrade.Status == OrderStatus.FILLED)
                        trade.ParentTrade.Pnl = CalculateTradePnl(trade, price);
                    else trade.ParentTrade.Pnl = 0;
                });
            }
        }
    }
}
