using System;
using System.Threading;
using IB.Api.Client.Client;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            startClient();

            //keep the console alive
            Console.ReadLine();
        }
        private static void startClient()
        {
            //double check your API settings for these details
            var host = "127.0.0.1";
            var port = 4002;
            var clientId = 0;

            var ibClient = new IBClient();
            ibClient.ClientSocket.eConnect(host, port, clientId);
            var reader = new EReader(ibClient.ClientSocket, ibClient.Signal);

            ibClient.NotificationReceived += new EventHandler<Notification>(NotificationReceived);

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
        }
        private static void NotificationReceived(object sender, Notification notification)
        {
            Console.WriteLine($"Type:{notification.NotificationType} Code:{notification.Code} Id:{notification.Id} Message:{notification.Message}");
        }
    }
}
