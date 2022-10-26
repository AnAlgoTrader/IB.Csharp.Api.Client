using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class PriceUpdate
    {
        [JsonProperty("bid")]
        public double Bid { get; set; }

        [JsonProperty("bidSize")]
        public int BidSize { get; set; }

        [JsonProperty("ask")]
        public double Ask { get; set; }

        [JsonProperty("askSize")]
        public int AskSize { get; set; }

        [JsonProperty("marketDataType")]
        public int MarketDataType { get; set; }

        [JsonProperty("minTick")]
        public double MinTick { get; set; }

        [JsonProperty("snapshotPermissions")]
        public int SnapshotPermissions { get; set; }

        [JsonProperty("bboExchange")]
        public string BboExchange { get; set; }
    }
}