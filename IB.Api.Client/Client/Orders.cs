using System;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Orders
    public partial class IBClient
    {
        private int _nextOrderId;
        public int NextOrderId
        {
            get { return _nextOrderId; }
            set { _nextOrderId = value; }
        }
        public void nextValidId(int orderId)
        {
            NextOrderId = orderId;
            Notify($"Next valid Order Id ({orderId})");
        }
        public void completedOrder(Contract contract, Order order, OrderState orderState)
        {
            throw new NotImplementedException();
        }

        public void completedOrdersEnd()
        {
            throw new NotImplementedException();
        }
        public void execDetails(int reqId, Contract contract, Execution execution)
        {
            throw new NotImplementedException();
        }

        public void execDetailsEnd(int reqId)
        {
            throw new NotImplementedException();
        }
        public void openOrderEnd()
        {
            throw new NotImplementedException();
        }
        public void orderBound(long orderId, int apiClientId, int apiOrderId)
        {
            throw new NotImplementedException();
        }
        public void orderStatus(int orderId, string status, double filled, double remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld, double mktCapPrice)
        {
            throw new NotImplementedException();
        }
    }
}
