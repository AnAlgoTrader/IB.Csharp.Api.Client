using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class PriceUpdate
    {
        [JsonProperty("time")]
        public double Time { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("bid")]
        public double Bid { get; set; }

        [JsonProperty("bidSize")]
        public decimal BidSize { get; set; }

        [JsonProperty("ask")]
        public double Ask { get; set; }

        [JsonProperty("askSize")]
        public decimal AskSize { get; set; }

        [JsonProperty("marketDataType")]
        public int MarketDataType { get; set; }

        [JsonProperty("minTick")]
        public double MinTick { get; set; }

        [JsonProperty("snapshotPermissions")]
        public int SnapshotPermissions { get; set; }

        [JsonProperty("bboExchange")]
        public string BboExchange { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("vwap")]
        public double Vwap { get; set; }

        [JsonProperty("parentTimeFrame")]
        public PriceUpdate ParentTimeFrame { get; set; }
    }
}