using System.Threading;
using IB.Api.Client.Client;
using IB.Api.Client.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Helper
{
    public class ConnectionHelper
    {
        public static IBClient StartIbClient(IBClient ibClient, ConnectionDetails connectionDetails)
        {
            ibClient.ClientSocket.eConnect(connectionDetails.Host, connectionDetails.Port, connectionDetails.ClientId);
            var reader = new EReader(ibClient.ClientSocket, ibClient.Signal);
            reader.Start();
            new Thread(() =>
            {
                while (ibClient.ClientSocket.IsConnected())
                {
                    ibClient.Signal.waitForSignal();
                    reader.processMsgs();
                }
            })
            { IsBackground = true }.Start();
            return ibClient;
        }
    }
}
