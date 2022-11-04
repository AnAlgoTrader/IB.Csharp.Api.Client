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
        public static void CalculatePortfolioPnl(PortfolioUpdate portfolioUpdate, List<BracketTrade> trades)
        {
            var pnl = trades.Where(x => x.Parent.TradeAction == portfolioUpdate.Action).Sum(x => x.Parent.Pnl);
            portfolioUpdate.UnrealizedPnl = Math.Round(pnl.Value, 2);
        }

        public static double? CalculateTradePnl(Trade trade, double currentPrice)
        {
            var pnl = (currentPrice - trade.FillPrice) * double.Parse(trade.Multiplier) * trade.Quantity;
            var commission = trade.Commission * 3;
            if (trade.TradeAction == nameof(TradeAction.BUY))
                return Math.Round(pnl.Value - commission, 2);
            else
                return Math.Round((pnl.Value * -1.0) - commission, 2);
        }
        public static double? CalculateTradePnl(BracketTrade trade, double currentPrice)
        {
            var pnl = (currentPrice - trade.Parent.FillPrice) * double.Parse(trade.Parent.Multiplier) * trade.Parent.Quantity;
            var commission = trade.Parent.Commission * 3;
            if (trade.Parent.TradeAction == nameof(TradeAction.BUY))
                return Math.Round(pnl.Value - commission, 2);
            else
                return Math.Round((pnl.Value * -1.0) - commission, 2);
        }

        public static void CalculateTradesPnl(List<Trade> trades, HistoricalTickBidAsk tick)
        {
            if (trades.Count > 0)
            {
                trades.Where(x => string.IsNullOrEmpty(x.TargetStatus)).ToList().ForEach(trade =>
                {
                    if (trade.Status == OrderStatus.FILLED)
                    {
                        var price = trade.TradeAction == nameof(TradeAction.BUY) ? tick.PriceBid : tick.PriceAsk;
                        trade.Pnl = CalculateTradePnl(trade, price);
                    }
                    else trade.Pnl = 0;
                });
            }
        }

        public static void CalculateTradesPnl(List<Trade> trades, double price)
        {
            if (trades.Count > 0)
            {
                trades.Where(x => string.IsNullOrEmpty(x.TargetStatus)).ToList().ForEach(trade =>
                {
                    if (trade.Status == OrderStatus.FILLED)
                        trade.Pnl = CalculateTradePnl(trade, price);
                    else trade.Pnl = 0;
                });
            }
        }

        public static void CalculateTradesPnl(List<BracketTrade> trades, double price)
        {
            if (trades.Count > 0)
            {
                trades.Where(x => x.TakeProfit.Status != OrderStatus.FILLED && x.StopLoss.Status != OrderStatus.FILLED).ToList().ForEach(trade =>
                {
                    if (trade.Parent.Status == OrderStatus.FILLED)
                        trade.Parent.Pnl = CalculateTradePnl(trade, price);
                    else trade.Parent.Pnl = 0;
                });
            }
        }
    }
}
