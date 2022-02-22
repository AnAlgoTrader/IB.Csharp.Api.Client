using System;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Positions
    public partial class IBClient
    {
        public event EventHandler<PortfolioUpdate> PortfolioUpdateReceived;
        public void position(string account, Contract contract, double pos, double avgCost)
        {
            throw new NotImplementedException();
        }
        public void positionEnd()
        {
            throw new NotImplementedException();
        }
        public void positionMulti(int requestId, string account, string modelCode, Contract contract, double pos, double avgCost)
        {
            throw new NotImplementedException();
        }
        public void positionMultiEnd(int requestId)
        {
            throw new NotImplementedException();
        }  
        public void updatePortfolio(Contract contract, double position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
            var portfolioUpdate = new PortfolioUpdate
            {
                UpdatedOn = DateTime.Now,
                Symbol = contract.Symbol,
                Position = position,
                UnrealizedPnl = unrealizedPNL,
                ContractId = contract.ConId
            };
            PortfolioUpdateReceived?.Invoke(this, portfolioUpdate);
        }
    }
}
