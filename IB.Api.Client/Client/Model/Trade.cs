using System;
using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class Trade
    {
        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("executionId")]
        public string ExecutionId { get; set; }

        [JsonProperty("at")]
        public DateTime? At { get; set; }

        [JsonProperty("targetFilledAt")]
        public DateTime? TargetFilledAt { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("localSymbol")]
        public string LocalSymbol { get; set; }

        [JsonProperty("tradeAction")]
        public string TradeAction { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("avgPrice")]
        public decimal AvgPrice { get; set; }

        [JsonProperty("fillPrice")]
        public decimal? FillPrice { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("multiplier")]
        public decimal Multiplier { get; set; }

        [JsonProperty("commission")]
        public decimal Commission { get; set; }

        [JsonProperty("targetOrderRef")]
        public string TargetOrderRef { get; set; }

        [JsonProperty("targetStatus")]
        public string TargetStatus { get; set; }

        [JsonProperty("targetAction")]
        public string TargetAction { get; set; }

        [JsonProperty("targetOrderType")]
        public string TargetOrderType { get; set; }

        [JsonProperty("targetLimitPrice")]
        public decimal TargetLimitPrice { get; set; }

        [JsonProperty("targetFillPrice")]
        public decimal? TargetFillPrice { get; set; }

        [JsonProperty("pnl")]
        public decimal Pnl { get; set; }

        [JsonProperty("orderId")]
        public int? OrderId { get; set; }

        [JsonProperty("targetId")]
        public int? TargetId { get; set; }

        [JsonProperty("attemptedPrice")]
        public decimal AttemptedPrice { get; set; }
        
        [JsonProperty("attemptedLimitPrice")]
        public decimal AttemptedLimitPrice { get; set; }

        [JsonProperty("targetCommission")]
        public decimal? TargetCommission { get; set; }

        [JsonProperty("targetExecutionId")]
        public string TargetExecutionId { get; set; }
    }
}
