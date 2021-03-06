using IB.Api.Client.Proprietary;

namespace IB.Api.Client
{
    //Main
    public partial class IBClient : EWrapper
    {
        internal readonly EClientSocket ClientSocket;
        internal readonly EReaderSignal Signal;
        public IBClient()
        {
            Signal = new EReaderMonitorSignal();
            ClientSocket = new EClientSocket(this, Signal);
        }        
    }
}