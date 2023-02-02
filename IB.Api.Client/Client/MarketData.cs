using System;
using System.Collections.Generic;
using System.Linq;
using IB.Api.Client.Model;
using IBApi;
using IB.Api.Client.Helper;

namespace IB.Api.Client
{
    //MarketData
    public partial class IBClient
    {
        private readonly PriceUpdate _priceUpdate = new PriceUpdate();
        private readonly Dictionary<int, OrderBookUpdate> _orderBookUpdates = new Dictionary<int, OrderBookUpdate>();
        public event EventHandler<OrderBookUpdate> OrderBookUpdateReceived;
        public event EventHandler<PriceUpdate> PriceUpdateReceived;
        public event EventHandler<HistoricalTickBidAsk> TimeAndSalesUpdateReceived;
        public event EventHandler<RealTimeBarUpdate> BarUpdateReceived;
        public void SubscribeToTimeAndSales(int reqId, Contract contract)
        {
            ClientSocket.ReqTickByTickData(reqId, contract, "BidAsk", 0, true);
        }
        public void SubscribeToRealTimePrice(Contract contract)
        {
            ClientSocket.ReqMktData(1064, contract, "221", false, false, null);
        }
        public void SubscribeToDefaultBar(Contract contract)
        {
            ClientSocket.ReqRealTimeBars(1074, contract, 0, nameof(WhatToShow.TRADES), false, null);
        }
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

            ClientSocket.ReqMarketDepth(reqId, contract, 10, false, null);
            Notify($"Subscribed to {contract.Symbol} marketDepth");
        }
        public void UpdateMktDepth(int tickerId, int position, int operation, int side, double price, decimal size)
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
            _orderBookUpdates[tickerId].OrderBookLines[position].PercentageOfBook = Math.Round(100 * _orderBookUpdates[tickerId].OrderBookLines[position].Size / max);
            _orderBookUpdates[tickerId].CurrentPrice = _orderBookUpdates[tickerId].OrderBookLines[0].Price;

            if (position == 19)
                OrderBookUpdateReceived?.Invoke(this, _orderBookUpdates[tickerId]);
        }
        public virtual void TickPrice(int tickerId, int field, double price, TickAttrib attribs)
        {
            switch (field)
            {
                case 1:
                    {
                        _priceUpdate.Bid = price;
                        break;
                    }
                case 2:
                    {
                        _priceUpdate.Ask = price;
                        break;
                    }
            }
        }
        public void TickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice, decimal bidSize, decimal askSize, TickAttribBidAsk tickAttribBidAsk)
        {
            _ = reqId;
            var tick = new HistoricalTickBidAsk
            {
                Time = time,
                PriceAsk = askPrice,
                PriceBid = bidPrice,
                SizeAsk = askSize,
                SizeBid = bidSize,
                TickAttribBidAsk = tickAttribBidAsk
            };
            TimeAndSalesUpdateReceived?.Invoke(this, tick);
        }
        public void MarketDataType(int reqId, int marketDataType)
        {
            _priceUpdate.MarketDataType = marketDataType;
        }
        public void TickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            _priceUpdate.MinTick = minTick;
            _priceUpdate.BboExchange = bboExchange;
            _priceUpdate.SnapshotPermissions = snapshotPermissions;
        }
        public virtual void TickSize(int tickerId, int field, decimal size)
        {
            switch (field)
            {
                case 0:
                    {
                        _priceUpdate.BidSize = size;
                        break;
                    }
                case 3:
                    {
                        _priceUpdate.AskSize = size;
                        SetPriceBar();
                        PriceUpdateReceived?.Invoke(this, _priceUpdate);
                        break;
                    }
            }
        }

        private void SetPriceBar()
        {
            var now = DateTime.Now;
            var epochTime = DateHelper.DateToEpoch(new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0));

            if (epochTime != _priceUpdate.Time)
            {
                _priceUpdate.Time = epochTime;
                _priceUpdate.Open = _priceUpdate.Bid;
                _priceUpdate.Close = _priceUpdate.Ask;
                _priceUpdate.High = _priceUpdate.Ask;
                _priceUpdate.Low = _priceUpdate.Bid;
                _priceUpdate.Volume = 0;
            }
            else
            {
                _priceUpdate.Close = _priceUpdate.Ask;
                _priceUpdate.High = _priceUpdate.Ask > _priceUpdate.High ? _priceUpdate.Ask : _priceUpdate.High;
                _priceUpdate.Low = _priceUpdate.Bid < _priceUpdate.Low ? _priceUpdate.Bid : _priceUpdate.Low;
            }
        }

        public virtual void TickString(int tickerId, int tickType, string value) { }
        public virtual void TickGeneric(int tickerId, int field, double value) { }
        public void RealtimeBar(int reqId, long date, double open, double high, double low, double close, decimal volume, decimal WAP, int count)
        {
            _ = reqId;
            BarUpdateReceived?.Invoke(this, new RealTimeBarUpdate(date, open, high, low, close, volume, count, WAP));
        }
    }
}
