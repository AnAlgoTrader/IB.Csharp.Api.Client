using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class PriceUpdate
    {
        [JsonProperty("bid")]
        public double Bid { get; set; }
        [JsonProperty("ask")]
        public double Ask { get; set; }
    }
}
