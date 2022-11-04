using IB.Api.Client.Model;

namespace IB.Api.Client.Model
{
    public class BracketTrade
    {
        public Trade Parent { get; set; }
        public Trade TakeProfit { get; set; }
        public Trade StopLoss { get; set; }
    }
}
