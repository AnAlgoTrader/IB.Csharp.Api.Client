using System.Collections.Generic;

namespace IB.Api.Client.Model
{
    public class OptionParameterDefinition
    {
        public string Exchange { get; internal set; }
        public int UnderlyingConId { get; internal set; }
        public string TradingClass { get; internal set; }
        public string Multiplier { get; internal set; }
        public HashSet<string> Expirations { get; internal set; }
        public HashSet<double> Strikes { get; internal set; }
    }
}
