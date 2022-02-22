using System;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Positions
    public partial class IBClient
    {
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
    }
}
