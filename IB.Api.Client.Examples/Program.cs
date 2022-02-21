using System;
using IB.Api.Client.Client;
using IB.Api.Client.Client.Model;
using IB.Api.Client.Helper;

namespace IB.Api.Client.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionDetails = new ConnectionDetails
            {
                Host = "127.0.0.1",
                Port = 4002,
                ClientId = 0
            };

            var ibClient = new IBClient();
            ibClient.NotificationReceived += new EventHandler<Notification>(NotificationReceived);
            ibClient = ConnectionHelper.StartIbClient(ibClient, connectionDetails);

            //keep the console alive
            Console.ReadLine();
        }

        private static void NotificationReceived(object sender, Notification notification)
        {
            Console.WriteLine($"Type:{notification.NotificationType} Code:{notification.Code} Id:{notification.Id} Message:{notification.Message}");
        }
    }
}
