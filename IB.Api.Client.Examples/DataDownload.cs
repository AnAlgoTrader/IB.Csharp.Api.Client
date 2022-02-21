using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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
            Thread.Sleep(TimeSpan.FromSeconds(5));

            var duration = new Duration { Unit = 1, DurationType = DurationType.D };
            ibClient.GetHistoricalData(1005, _contract, DateTime.Now, duration, BarSize.FiveMinutes, WhatToShow.MIDPOINT, Rth.No, false);

            //keep the console alive
            Console.ReadLine();
        }
        public static void RunDownloadWithUpdates(ConnectionDetails connectionDetails)
        {

            var ibClient = new IBClient();
            ibClient.NotificationReceived += new EventHandler<Notification>(Common.NotificationReceived);
            ibClient.HistoricalDataUpdateEndReceived += new EventHandler<Tuple<int, List<Bar>>>(HistoricalDataUpdateEndReceived);
            ibClient.BarUpdateReceived += new EventHandler<BarUpdate>(BarUpdateReceived);
            ibClient = ConnectionHelper.StartIbClient(ibClient, connectionDetails);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            var duration = new Duration { Unit = 1, DurationType = DurationType.D };
            ibClient.GetHistoricalData(1005, _contract, DateTime.Now, duration, BarSize.FiveMinutes, WhatToShow.MIDPOINT, Rth.No, true);

            //keep the console alive
            Console.ReadLine();
        }
        private static void BarUpdateReceived(object sender, BarUpdate barUpdate)
        {
             Console.WriteLine($"{DateTime.Now}: Open:{barUpdate.Bar.Open} High:{barUpdate.Bar.High} Close:{barUpdate.Bar.Close} Low:{barUpdate.Bar.Low}");
        }
        private static void HistoricalDataUpdateEndReceived(object sender, Tuple<int, List<Bar>> data)
        {
            var fileName = $"./{data.Item1}.csv";
            Console.WriteLine($"{DateTime.Now}: Save historical data to file: {fileName}");
            var csvData = data.Item2.Select(x =>
                $"{x.Open},{x.Close},{x.High},{x.Low},{x.Volume}"
            ).ToList();
            File.WriteAllLines(fileName, csvData);
        }
    }
}
