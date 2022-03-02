using System;
using System.Collections.Generic;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Metadata
    public partial class IBClient
    {
        private List<ContractDetails> _contracts;
        public event EventHandler<List<ContractDetails>> ContractDetailsReceived;
        public void GetFutureContractDetails(string symbol, SecurityType securityType)
        {
            _contracts = new List<ContractDetails>();

            ClientSocket.reqContractDetails(1020, new Contract
            {
                Symbol = symbol,
                SecType = securityType.ToString()
            });
        }
        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            _contracts.Add(contractDetails);
        }
        public void contractDetailsEnd(int reqId)
        {
            ContractDetailsReceived?.Invoke(this, _contracts);
        }
    }
}
