using System;
using System.Collections.Generic;
using IB.Api.Client.Client.Model;
using IB.Api.Client.Helper;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Client
{
    public partial class IBClient
    {
        private Dictionary<int, List<Bar>> _historicalData = new Dictionary<int, List<Bar>>();
        public event EventHandler<Tuple<int, List<Bar>>> HistoricalDataUpdateEndReceived;
        public event EventHandler<BarUpdate> BarUpdateReceived;
        public void GetHistoricalData(int reqId, Contract contract, DateTime endTime, Duration duration, string barSize, WhatToShow whatToShow, Rth rth, bool keepUpToDate)
        {
            _historicalData.Add(reqId, new List<Bar>());
            string end = string.Empty;
            if (!keepUpToDate)
                end = DateHelper.ConvertToApiDate(endTime);
            ClientSocket.reqHistoricalData(reqId, contract, end, duration.GetDuration(), BarSize.OneMinute, whatToShow.ToString(), (int)rth, 1, keepUpToDate, null);
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
        public void historicalNews(int requestId, string time, string providerCode, string articleId, string headline)
        {
            throw new NotImplementedException();
        }
        public void historicalNewsEnd(int requestId, bool hasMore)
        {
            throw new NotImplementedException();
        }
        public void historicalTicks(int reqId, HistoricalTick[] ticks, bool done)
        {
            throw new NotImplementedException();
        }
        public void historicalTicksBidAsk(int reqId, HistoricalTickBidAsk[] ticks, bool done)
        {
            throw new NotImplementedException();
        }
        public void historicalTicksLast(int reqId, HistoricalTickLast[] ticks, bool done)
        {
            throw new NotImplementedException();
        }
    }
}
