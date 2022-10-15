using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Model
{
    public class Future : Contract
    {
        public int ReqTickerId { get; set; }
        public Future(int reqTickerId, string symbol, string localSymbol, string lastTradeDateOrContractMonth, string exchange, double multiplier, string currency)
        {
            this.ReqTickerId = reqTickerId;
            this.Symbol = symbol;
            this.LocalSymbol = localSymbol;
            this.LastTradeDateOrContractMonth = lastTradeDateOrContractMonth;
            this.Exchange = exchange;
            this.Multiplier = multiplier;
            this.Currency = currency;
            this.SecType = "FUT";
        }
    }
}
