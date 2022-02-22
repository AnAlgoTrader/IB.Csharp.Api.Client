using System.Collections.Generic;

namespace IB.Api.Client.Model
{
    public class OrderBookUpdate
    {
        public double SumOffer { get; set; }
        public double SumBid { get; set; }
        public int Direction
        {
            get
            {
                return SumOffer > SumBid ? 1 : 0;
            }
        }
        public double SumDifference
        {
            get
            {
                return SumOffer - SumBid;
            }
        }
        public OrderBookLine[] OrderBookLines { get; set; }
        public double CurrentPrice { get; set; }
        public List<Trade> Trades { get; set; }
        public int TickerId { get; internal set; }
        public double Ratio { get; internal set; }
    }
}
