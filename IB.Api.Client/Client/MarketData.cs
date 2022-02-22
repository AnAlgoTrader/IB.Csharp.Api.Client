using System;
using System.Collections.Generic;
using System.Linq;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //MarketData
    public partial class IBClient
    {
        private PriceUpdate _priceUpdate = new PriceUpdate();
        private Dictionary<int, OrderBookUpdate> _orderBookUpdates = new Dictionary<int, OrderBookUpdate>();
        public event EventHandler<OrderBookUpdate> OrderBookUpdateReceived;
        public event EventHandler<PriceUpdate> PriceUpdateReceived;

        public void ReqMarketDepth(int reqId, Contract contract, double ratio)
        {   
            var orderBookUpdate = new OrderBookUpdate
            {
                Ratio = ratio,
                OrderBookLines = new OrderBookLine[20]
            };
            for (int iterator = 0; iterator < orderBookUpdate.OrderBookLines.Length; iterator++)
                orderBookUpdate.OrderBookLines[iterator] = new OrderBookLine();
            _orderBookUpdates.Add(reqId, orderBookUpdate);

            ClientSocket.reqMarketDepth(reqId, contract, 10, false, null);
            Notify($"Subscribed to {contract.Symbol} marketDepth");
        }
        public virtual void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            if (side == 0)
                position += 10;

            _orderBookUpdates[tickerId].OrderBookLines[position] = new OrderBookLine
            {
                Position = position,
                Operation = operation,
                Side = side,
                Price = price,
                Size = size
            };
            _orderBookUpdates[tickerId].TickerId = tickerId;
            var max = _orderBookUpdates[tickerId].OrderBookLines.Max(x => x.Size);
            var sumBySide = _orderBookUpdates[tickerId].OrderBookLines.Where(x => x.Side == side).Sum(x => x.Size);
            if (side == 1)
                _orderBookUpdates[tickerId].SumBid = sumBySide;
            else
                _orderBookUpdates[tickerId].SumOffer = sumBySide;
            _orderBookUpdates[tickerId].OrderBookLines[position].PercentageOfBook = Math.Round((100 * _orderBookUpdates[tickerId].OrderBookLines[position].Size) / max);
            _orderBookUpdates[tickerId].CurrentPrice = _orderBookUpdates[tickerId].OrderBookLines[0].Price;
            OrderBookUpdateReceived?.Invoke(this, _orderBookUpdates[tickerId]);
        }
        public virtual void tickPrice(int tickerId, int field, double price, TickAttrib attribs)
        {
            switch (field)
            {
                case 1:
                    {
                        if (_priceUpdate.Bid != price)
                        {
                            _priceUpdate.Bid = price;
                            PriceUpdateReceived?.Invoke(this, _priceUpdate);
                        }
                        break;
                    }
                case 2:
                    {
                        if (_priceUpdate.Ask != price)
                        {
                            _priceUpdate.Ask = price;
                            PriceUpdateReceived?.Invoke(this, _priceUpdate);
                        }
                        break;
                    }
            }
        }
        public virtual void tickSize(int tickerId, int field, int size)
        {
            //Console.WriteLine("Tick Size. Ticker Id:" + tickerId + ", Field: " + field + ", Size: " + size);
        }
        public virtual void tickString(int tickerId, int tickType, string value)
        {
            //Console.WriteLine("Tick string. Ticker Id:" + tickerId + ", Type: " + tickType + ", Value: " + value);
        }
        public virtual void tickGeneric(int tickerId, int field, double value)
        {
            //Console.WriteLine("Tick Generic. Ticker Id:" + tickerId + ", Field: " + field + ", Value: " + value);
        }
        public void tickByTickAllLast(int reqId, int tickType, long time, double price, int size, TickAttribLast tickAttriblast, string exchange, string specialConditions)
        {
            throw new NotImplementedException();
        }
        public void tickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice, int bidSize, int askSize, TickAttribBidAsk tickAttribBidAsk)
        {
            throw new NotImplementedException();
        }
        public void tickByTickMidPoint(int reqId, long time, double midPoint)
        {
            throw new NotImplementedException();
        }
        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate)
        {
            throw new NotImplementedException();
        }
        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            //Console.WriteLine("TickOptionComputation. TickerId: " + tickerId + ", field: " + field + ", ImpliedVolatility: " + impliedVolatility + ", Delta: " + delta
            //    + ", OptionPrice: " + optPrice + ", pvDividend: " + pvDividend + ", Gamma: " + gamma + ", Vega: " + vega + ", Theta: " + theta + ", UnderlyingPrice: " + undPrice);
        }
        public void tickSnapshotEnd(int tickerId)
        {
            //Console.WriteLine("TickSnapshotEnd: " + tickerId);
        }
        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size, bool isSmartDepth)
        {
            //Console.WriteLine("UpdateMarketDepthL2. " + tickerId + " - Position: " + position + ", Operation: " + operation + ", Side: " + side + ", Price: " + price + ", Size: " + size + ", isSmartDepth: " + isSmartDepth);
        }
        public void tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            //Console.WriteLine("id={0} minTick = {1} bboExchange = {2} snapshotPermissions = {3}", tickerId, minTick, bboExchange, snapshotPermissions);
        }
    }
}
