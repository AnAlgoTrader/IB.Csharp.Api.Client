using System;
using System.Collections.Generic;
using IB.Api.Client.Client;
using IB.Api.Client.Client.Model;
using IB.Api.Client.Helper;
using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Examples
{
    public class DataDownload
    {
        private static Contract _contract = new Contract
        {
            Symbol = "EUR",
            SecType = "CASH",
            Currency = "GBP",
            Exchange = "IDEALPRO"
        };
        public static void RunBasicDownload(ConnectionDetails connectionDetails)
        {
            var ibClient = new IBClient();
            ibClient.NotificationReceived += new EventHandler<Notification>(Common.NotificationReceived);
            ibClient.HistoricalDataUpdateEndReceived += new EventHandler<Tuple<int, List<Bar>>>(HistoricalDataUpdateEndReceived);
            ibClient = ConnectionHelper.StartIbClient(ibClient, connectionDetails);            

            var duration = new Duration { Unit = 1, DurationType = DurationType.D };
            ibClient.GetHistoricalData(1005, _contract, DateTime.Now, duration, BarSize.FiveMinutes, WhatToShow.MIDPOINT, Rth.No, false);
        }
        public static void RunDownloadWithUpdates(ConnectionDetails connectionDetails)
        {
            var ibClient = new IBClient();
            ibClient.NotificationReceived += new EventHandler<Notification>(Common.NotificationReceived);
            ibClient.HistoricalDataUpdateEndReceived += new EventHandler<Tuple<int, List<Bar>>>(HistoricalDataUpdateEndReceived);
            ibClient.BarUpdateReceived += new EventHandler<BarUpdate>(BarUpdateReceived);
            ibClient = ConnectionHelper.StartIbClient(ibClient, connectionDetails);

            var duration = new Duration { Unit = 1, DurationType = DurationType.D };
            ibClient.GetHistoricalData(1005, _contract, DateTime.Now, duration, BarSize.FiveMinutes, WhatToShow.MIDPOINT, Rth.No, true);
        }
        public static void RunGetTimeAndSales(ConnectionDetails connectionDetails)
        {
            var ibClient = new IBClient();
            ibClient.NotificationReceived += new EventHandler<Notification>(Common.NotificationReceived);
            ibClient = ConnectionHelper.StartIbClient(ibClient, connectionDetails);
            ibClient.GetTimeAndSales(1005, _contract, DateTime.Now, WhatToShow.ADJUSTED_LAST);
        }
        private static void BarUpdateReceived(object sender, BarUpdate barUpdate)
        {
             Console.WriteLine($"{DateTime.Now}: Open:{barUpdate.Bar.Open} High:{barUpdate.Bar.High} Close:{barUpdate.Bar.Close} Low:{barUpdate.Bar.Low}");
        }
        private static void HistoricalDataUpdateEndReceived(object sender, Tuple<int, List<Bar>> data)
        {
            Console.WriteLine($"{DateTime.Now}: Historical data received");
            data.Item2.ForEach(x =>
            {
                Console.WriteLine($"{x.Open},{x.Close},{x.High},{x.Low},{x.Volume}");
            });
        }
    }
}
