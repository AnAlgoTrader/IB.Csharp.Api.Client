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

        public void ReqMarketDepth(int reqId, Contract contract, decimal ratio)
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
        public virtual void updateMktDepth(int tickerId, int position, int operation, int side, decimal price, int size)
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

            if (position == 19)
                OrderBookUpdateReceived?.Invoke(this, _orderBookUpdates[tickerId]);
        }
        public virtual void tickPrice(int tickerId, int field, decimal price, TickAttrib attribs)
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
    }
}
