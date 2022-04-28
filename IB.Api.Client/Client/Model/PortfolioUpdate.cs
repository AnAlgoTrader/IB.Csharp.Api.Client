using System;
using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class PortfolioUpdate
    {
        [JsonProperty("updatedOn")]
        public DateTime UpdatedOn;

        [JsonProperty("updated")]
        public string Updated
        {
            get
            {
                return $"{UpdatedOn.ToShortDateString()} {UpdatedOn.ToShortTimeString()} ";
            }
        }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("position")]
        public decimal Position { get; set; }

        [JsonProperty("unrealizedPnl")]
        public decimal UnrealizedPnl { get; set; }

        [JsonProperty("contractId")]
        public int ContractId { get; set; }

        [JsonProperty("realizedPnl")]
        public decimal RealizedPnl { get; internal set; }

        [JsonProperty("accountName")]
        public string AccountName { get; internal set; }
    }
}
