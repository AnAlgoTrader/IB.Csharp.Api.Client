using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class PriceUpdate
    {
        [JsonProperty("bid")]
        public decimal Bid { get; set; }
        [JsonProperty("ask")]
        public decimal Ask { get; set; }
    }
}
