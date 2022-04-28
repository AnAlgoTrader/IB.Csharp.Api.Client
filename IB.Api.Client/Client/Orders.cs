using System;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Orders
    public partial class IBClient
    {
        public event EventHandler<CommissionUpdate> CommissionUpdateReceived;
        public event EventHandler<ExecutionUpdate> ExecutionUpdateReceived;
        public event EventHandler<OrderUpdate> OrderUpdateReceived;
        public event EventHandler<OpenOrderUpdate> OpenOrderUpdateReceived;
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
        public void RequestOrders()
        {
            ClientSocket.reqAllOpenOrders();
        }
        public void PlaceOrder(int orderId, Contract contract, Order order)
        {
            ClientSocket.placeOrder(orderId, contract, order);
        }
        public void CancelOrder(int orderId)
        {
            ClientSocket.cancelOrder(orderId);
        }
        public void RequestExecutions(int reqId)
        {
            ClientSocket.reqExecutions(reqId, new ExecutionFilter());
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
            ExecutionUpdateReceived?.Invoke(this, new ExecutionUpdate
            {
                Account = execution.AcctNumber,
                Symbol = contract.Symbol,
                SecType = contract.SecType,
                ExecutionId = execution.ExecId,
                OrderRef = execution.OrderRef,
                Side = execution.Side
            });
        }
        public void execDetailsEnd(int reqId)
        {
        }
        public void openOrderEnd()
        {
        }
        public void orderStatus(int orderId, string status, decimal filled, decimal remaining, decimal avgFillPrice, int permId, int parentId, decimal lastFillPrice, int clientId, string whyHeld, decimal mktCapPrice)
        {
            var orderUpdate = new OrderUpdate
            {
                OrderId = orderId,
                Status = status,
                FilledAmount = filled,
                RemainingAmount = remaining,
                AvgFillPrice = avgFillPrice,
                PermId = permId,
                ParentId = parentId,
                LastFillPrice = lastFillPrice,
                ClientId = clientId,
                WhyHeld = whyHeld,
                MktCapPrice = mktCapPrice
            };
            OrderUpdateReceived?.Invoke(this, orderUpdate);
        }
        public void commissionReport(CommissionReport commissionReport)
        {
            CommissionUpdateReceived?.Invoke(this, new CommissionUpdate
            {
                ExecutionId = commissionReport.ExecId,
                Commission = commissionReport.Commission
            });
        }
        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            OpenOrderUpdateReceived?.Invoke(this, new OpenOrderUpdate
            {
                OrderId = orderId,
                Contract = contract,
                Order = order,
                OrderState = orderState
            });
        } 
    }
}
