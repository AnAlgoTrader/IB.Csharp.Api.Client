namespace IB.Api.Client.Model
{

    public class BracketTrade
    {
        public Trade ParentTrade { get; set; }
        public Trade StopTrade { get; set; }
        public Trade TakeProfitTrade { get; set; }
    }
}
