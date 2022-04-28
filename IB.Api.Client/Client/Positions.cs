using System;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Positions
    public partial class IBClient
    {
        public event EventHandler<PortfolioUpdate> PortfolioUpdateReceived;
        public void updatePortfolio(Contract contract, decimal position, decimal marketPrice, decimal marketValue, decimal averageCost, decimal unrealizedPNL, decimal realizedPNL, string accountName)
        {
            var portfolioUpdate = new PortfolioUpdate
            {
                AccountName = accountName,
                UpdatedOn = DateTime.Now,
                Symbol = contract.Symbol,
                Position = position,
                UnrealizedPnl = unrealizedPNL,
                RealizedPnl = realizedPNL,
                ContractId = contract.ConId
            };
            PortfolioUpdateReceived?.Invoke(this, portfolioUpdate);
        }
    }
}
