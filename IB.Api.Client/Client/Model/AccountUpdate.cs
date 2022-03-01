using System;
using Newtonsoft.Json;

namespace IB.Api.Client.Model
{
    public class AccountUpdate
    {
        [JsonProperty("updatedOn")]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty("updated")]
        public string Updated {
            get
            {
                return $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} ";
            }
        }            

        [JsonProperty("accountCode")]
        public string AccountCode { get; set; }

        [JsonProperty("acountType")]
        public string AccountType { get; set; }

        [JsonProperty("availableFunds")]
        public double AvailableFunds { get; set; }

        [JsonProperty("buyingPower")]
        public double BuyingPower { get; set; }

        [JsonProperty("cashGbp")]
        public double CashGbp { get; set; }

        [JsonProperty("cashUsd")]
        public double CashUsd { get; set; }

        [JsonProperty("excessLiquidity")]
        public double ExcessLiquidity { get; set; }
        
        [JsonProperty("side")]
        public string Side { get; set; }

        public void SetValue(string key, string value, string currency)
        {
            AccountCode = key == "AccountCode" ? value : AccountCode;
            AccountType = key == "AccountType" ? value : AccountType;
            AvailableFunds = key == "AvailableFunds" ? double.Parse(value) : AvailableFunds;
            BuyingPower = key == "BuyingPower" ? double.Parse(value) : BuyingPower;
            CashGbp = key == "CashBalance" && currency == "GBP" ? double.Parse(value) : CashGbp;
            CashUsd = key == "CashBalance" && currency == "USD" ? double.Parse(value) : CashUsd;
            ExcessLiquidity = key == "ExcessLiquidity" ? double.Parse(value) : ExcessLiquidity;
        }
    }
}
