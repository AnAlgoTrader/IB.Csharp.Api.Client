using System;
using System.Collections.Generic;
using IB.Api.Client.Model;
using IB.Api.Client.Helper;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    public partial class IBClient
    {
        private List<WhatToShow> _allowedTimeAndSalesTickTypes = new List<WhatToShow> { WhatToShow.TRADES, WhatToShow.BID_ASK, WhatToShow.MIDPOINT };
        private Dictionary<int, List<Bar>> _historicalData = new Dictionary<int, List<Bar>>();
        private Dictionary<int, List<HistoricalTick>> _historicalTicks = new Dictionary<int, List<HistoricalTick>>();
        private Dictionary<int, List<HistoricalTickBidAsk>> _historicalTickBidAsk = new Dictionary<int, List<HistoricalTickBidAsk>>();
        private Dictionary<int, List<HistoricalTickLast>> _historicalTickLast = new Dictionary<int, List<HistoricalTickLast>>();
        public event EventHandler<Tuple<int, List<Bar>>> HistoricalDataUpdateEndReceived;
        public event EventHandler<BarUpdate> BarUpdateReceived;
        public event EventHandler<Tuple<int, List<HistoricalTick>>> TimeAndSalesHistoricalTickUpdateReceived;
        public event EventHandler<Tuple<int, List<HistoricalTickBidAsk>>> TimeAndSalesHistoricalTickBidAskUpdateReceived;
        public event EventHandler<Tuple<int, List<HistoricalTickLast>>> TimeAndSalesHistoricalTickLastUpdateReceived;
        public void GetHistoricalData(int reqId, Contract contract, DateTime endTime, Duration duration, string barSize, WhatToShow whatToShow, Rth rth, bool keepUpToDate)
        {
            _historicalData.Add(reqId, new List<Bar>());
            string end = string.Empty;
            if (!keepUpToDate)
                end = DateHelper.ConvertToApiDate(endTime);
            ClientSocket.reqHistoricalData(reqId, contract, end, duration.GetDuration(), BarSize.OneMinute, whatToShow.ToString(), (int)rth, 1, keepUpToDate, null);
            Notify($"Historical data for symbol {contract.Symbol} requested");
        }
        public void GetHistoricalTimeAndSales(int reqId, Contract contract, DateTime start, WhatToShow whatToShow)
        {
            if (_allowedTimeAndSalesTickTypes.Contains(whatToShow))
            {
                var startTime = DateHelper.ConvertToApiDate(start);
                InitializeHistoricalTickDictionary(reqId, whatToShow);
                ClientSocket.reqHistoricalTicks(reqId, contract, startTime, null, 1000, whatToShow.ToString(), 1, true, null);
                Notify($"Time and Sales for symbol {contract.Symbol} requested");
            }
            else NotifyError($"WhatToShow tick type: {whatToShow} not allowed");
        }
        private void InitializeHistoricalTickDictionary(int reqId, WhatToShow whatToShow)
        {
            switch (whatToShow)
            {
                case WhatToShow.TRADES:{
                    _historicalTickLast[reqId] = new List<HistoricalTickLast>();
                        break;
                    }
                case WhatToShow.MIDPOINT:
                    {
                        _historicalTicks[reqId] = new List<HistoricalTick>();
                        break;
                    }
                case WhatToShow.BID_ASK:
                    {
                        _historicalTickBidAsk[reqId] = new List<HistoricalTickBidAsk>();
                        break;
                    }
            }
        }
        public void historicalData(int reqId, Bar bar)
        {
            _historicalData[reqId].Add(bar);
        }
        public void historicalDataEnd(int reqId, string startDate, string endDate)
        {
            var data = _historicalData[reqId];
            HistoricalDataUpdateEndReceived?.Invoke(this, new Tuple<int, List<Bar>>(reqId, data));
        }
        public void historicalDataUpdate(int reqId, Bar bar)
        {
            var barUpdate = new BarUpdate
            {
                RequestId = reqId,
                Bar = bar
            };
            BarUpdateReceived?.Invoke(this, barUpdate);
        }
        public void historicalTicks(int reqId, HistoricalTick[] ticks, bool done)
        {
            _historicalTicks[reqId].AddRange(ticks);
            if (done)
            {
                TimeAndSalesHistoricalTickUpdateReceived?.Invoke(this, new Tuple<int, List<HistoricalTick>>(reqId, _historicalTicks[reqId]));
                _historicalTicks[reqId] = new List<HistoricalTick>();
            }
        }
        public void historicalTicksBidAsk(int reqId, HistoricalTickBidAsk[] ticks, bool done)
        {
            _historicalTickBidAsk[reqId].AddRange(ticks);
            if (done)
            {
                TimeAndSalesHistoricalTickBidAskUpdateReceived?.Invoke(this, new Tuple<int, List<HistoricalTickBidAsk>>(reqId, _historicalTickBidAsk[reqId]));
                _historicalTickBidAsk[reqId] = new List<HistoricalTickBidAsk>();
            }
        }
        public void historicalTicksLast(int reqId, HistoricalTickLast[] ticks, bool done)
        {
            _historicalTickLast[reqId].AddRange(ticks);
            if (done)
            {
                TimeAndSalesHistoricalTickLastUpdateReceived?.Invoke(this, new Tuple<int, List<HistoricalTickLast>>(reqId, _historicalTickLast[reqId]));
                _historicalTickLast[reqId] = new List<HistoricalTickLast>();
            }
        }
        public void realtimeBar(int reqId, long date, decimal open, decimal high, decimal low, decimal close, long volume, decimal WAP, int count)
        {

        }
    }
}
