using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Model
{
    public class TrailingTrade
    {
        public Trade ParentTrade { get; set; }
        public Trade TrailingStop { get; set; }
        public Order TrailingStopOrder { get; set; }
    }
}
