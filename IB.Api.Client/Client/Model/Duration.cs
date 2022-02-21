using System;

namespace IB.Api.Client.Client.Model
{
    /// <summary>
    /// Ref: https://interactivebrokers.github.io/tws-api/historical_bars.html#hd_duration
    /// </summary>
    public enum DurationType
    {
        S,
        D,
        W,
        M,
        Y
    }

    public class Duration{
        public int Unit { get; set; }
        public DurationType DurationType { get; set; }

        internal string GetDuration()
        {
            return $"{Unit} {DurationType}";
        }
    }
}
