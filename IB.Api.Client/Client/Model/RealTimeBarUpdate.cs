namespace IB.Api.Client.Client.Model
{
    public class RealTimeBarUpdate
    {
        public RealTimeBarUpdate(long date, double open, double high, double low, double close, long volume, int count, double wap)
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
        public long Volume { get; }
        public int Count { get; }
        public double Wap { get; }
    }
}
