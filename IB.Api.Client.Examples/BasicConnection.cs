using System;
using IB.Api.Client.Client;
using IB.Api.Client.Client.Model;
using IB.Api.Client.Helper;

namespace IB.Api.Client.Examples
{
    public class BasicConnection
    {
        public static void Run(ConnectionDetails connectionDetails)
        {
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
