using System;
using System.Threading;
using IB.Api.Client.Model;
using IBApi;

namespace IB.Api.Client.Helper
{
    public static class ConnectionHelper
    {
        public static IBClient StartIbClient(IBClient ibClient, ConnectionDetails connectionDetails)
        {
            ibClient.ClientSocket.EConnect(connectionDetails.Host, connectionDetails.Port, connectionDetails.ClientId);
            var reader = new EReader(ibClient.ClientSocket, ibClient.Signal);
            reader.Start();
            new Thread(() =>
            {
                while (ibClient.ClientSocket.IsConnected())
                {
                    ibClient.Signal.WaitForSignal();
                    reader.ProcessMsgs();
                }
            })
            { IsBackground = true }.Start();

            //Force the thread to sleep in order to get all notifications from the gateway before going ahead
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return ibClient;
        }
    }
}
