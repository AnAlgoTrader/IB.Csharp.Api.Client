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
        public static void RunBasicDownload(ConnectionDetails connectionDetails)
        {
            var ibClient = new IBClient();
            ibClient.NotificationReceived += new EventHandler<Notification>(Common.NotificationReceived);
            ibClient.HistoricalDataUpdateReceived += new EventHandler<Tuple<int, List<Bar>>>(HistoricalDataUpdateReceived);
            ibClient = ConnectionHelper.StartIbClient(ibClient, connectionDetails);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var contract = new Contract
            {
                Symbol = "EUR",
                SecType = "CASH",
                Currency = "GBP",
                Exchange = "IDEALPRO"
            };

            var duration = new Duration { Unit = 1, DurationType = DurationType.D };
            ibClient.GetHistoricalData(1005, contract, DateTime.Now, duration, BarSize.FiveMinutes, WhatToShow.MIDPOINT, Rth.No);

            //keep the console alive
            Console.ReadLine();
        }

        private static void HistoricalDataUpdateReceived(object sender, Tuple<int, List<Bar>> data)
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
