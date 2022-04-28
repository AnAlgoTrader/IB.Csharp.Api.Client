using System;
using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class AccountUpdate
    {
        [JsonProperty("updatedOn")]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty("updated")]
        public string Updated
        {
            get
            {
                return $"{UpdatedOn.ToShortDateString()} {UpdatedOn.ToShortTimeString()} ";
            }
        }

        [JsonProperty("accountCode")]
        public string AccountCode { get; set; }

        [JsonProperty("acountType")]
        public string AccountType { get; set; }

        [JsonProperty("availableFunds")]
        public decimal AvailableFunds { get; set; }

        [JsonProperty("buyingPower")]
        public decimal BuyingPower { get; set; }

        [JsonProperty("cashGbp")]
        public decimal CashGbp { get; set; }

        [JsonProperty("cashUsd")]
        public decimal CashUsd { get; set; }

        [JsonProperty("excessLiquidity")]
        public decimal ExcessLiquidity { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("pnl")]
        public string Pnl { get; set; }

        [JsonProperty("cashUsdControl")]
        public decimal CashUsdControl { get; set; }

        [JsonProperty("cashUsdNet")]
        public decimal CashUsdNet { get; set; }

        public void SetValue(string key, string value, string currency)
        {
            AccountCode = key == "AccountCode" ? value : AccountCode;
            AccountType = key == "AccountType" ? value : AccountType;
            AvailableFunds = key == "AvailableFunds" ? decimal.Parse(value) : AvailableFunds;
            BuyingPower = key == "BuyingPower" ? decimal.Parse(value) : BuyingPower;
            CashGbp = key == "CashBalance" && currency == "GBP" ? decimal.Parse(value) : CashGbp;
            CashUsd = key == "CashBalance" && currency == "USD" ? decimal.Parse(value) : CashUsd;
            ExcessLiquidity = key == "ExcessLiquidity" ? decimal.Parse(value) : ExcessLiquidity;
        }
    }
}
