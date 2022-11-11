using System;
using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class Trade
    {
        [JsonProperty("orderId")]
        public int? OrderId { get; set; }

        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("executionId")]
        public string ExecutionId { get; set; }

        [JsonProperty("at")]
        public DateTime? At { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("localSymbol")]
        public string LocalSymbol { get; set; }

        [JsonProperty("tradeAction")]
        public string TradeAction { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }        

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("multiplier")]
        public string Multiplier { get; set; }

        [JsonProperty("commission")]
        public double Commission { get; set; }

        [JsonProperty("pnl")]
        public double? Pnl { get; set; }        

        [JsonProperty("limitPrice")]
        public double LimitPrice { get; set; }

        [JsonProperty("stopPrice")]
        public double StopPrice { get; set; }

        [JsonProperty("fillPrice")]
        public double? FillPrice { get; set; }

        [JsonProperty("avgPrice")]
        public double AvgPrice { get; set; }

        [JsonProperty("drawdown")]
        public double? Drawdown { get; set; }

        [JsonProperty("lastPrice")]
        public double? LastPrice { get; set; }

        [JsonProperty("initialStop")]
        public double InitialStop { get; set; }
    }
}
