using IB.Api.Client.Proprietary;

namespace IB.Api.Client.Model
{
    public class BarUpdate
    {
        public int RequestId { get; set; }
        public Bar Bar { get; set; }
    }
}
