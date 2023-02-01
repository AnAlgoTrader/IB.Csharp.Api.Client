namespace IB.Api.Client.Model
{
    public class RealTimeBarUpdate
    {
        public RealTimeBarUpdate(long date, double open, double high, double low, double close, decimal volume, int count, decimal wap)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Count = count;
            Wap = wap;
        }

        public long Date { get; }
        public double Open { get; }
        public double High { get; }
        public double Low { get; }
        public double Close { get; }
        public decimal Volume { get; }
        public int Count { get; }
        public decimal Wap { get; }
        public BarAnnotation BarAnnotation { get; set; }
    }
}
