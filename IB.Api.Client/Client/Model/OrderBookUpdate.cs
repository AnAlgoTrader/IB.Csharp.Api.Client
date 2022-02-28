using System.Collections.Generic;

namespace IB.Api.Client.Model
{
    public class OrderBookUpdate
    {
        public double SumOffer { get; set; }
        public double SumBid { get; set; }
        public bool IsValid { get; set; }
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
        public void ValidateOrderBook()
        {
            var valid = true;
            for (int index = 1; index <= 9; index++)
            {
                valid = valid && OrderBookLines[index].Price < OrderBookLines[index - 1].Price;
            }
            for (int index = 11; index <= 19; index++)
            {
                valid = valid && OrderBookLines[index].Price > OrderBookLines[index - 1].Price;
            }
            valid = valid && OrderBookLines[10].Price > OrderBookLines[0].Price;
            IsValid = valid;
        }
    }
}
