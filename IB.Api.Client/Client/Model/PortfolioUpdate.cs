using System;
using Newtonsoft.Json;

namespace IB.Api.Client.Model
{    public class PortfolioUpdate
    {
        [JsonProperty("updatedOn")]
        public DateTime? UpdatedOn;

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("position")]
        public double Position { get; set; }

        [JsonProperty("unrealizedPnl")]
        public double UnrealizedPnl { get; set; }
        
        [JsonProperty("contactId")]
        public int ContractId { get; set; }
    }
}
