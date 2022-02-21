using System;
using IB.Api.Client.Helper;
using IB.Api.Client.Model;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Examples
{
    public class RequestNews
    {
        public static void RunGetNewsProviders(ConnectionDetails connectionDetails)
        {
            var ibClient = new IBClient();
            ibClient.NotificationReceived += new EventHandler<Notification>(Common.NotificationReceived);
            ibClient.NewsProvidersUpdateReceived += new EventHandler<NewsProvider[]>(NewsProvidersUpdateReceived);
            ibClient = ConnectionHelper.StartIbClient(ibClient, connectionDetails);
            ibClient.GetNewsProviders();
        }
        private static void NewsProvidersUpdateReceived(object sender, NewsProvider[] newsProviders)
        {
            foreach (var newsProvider in newsProviders)
            {
                Console.WriteLine($"Code:{newsProvider.ProviderCode} Name:{newsProvider.ProviderName}");
            }
        }
    }
}
