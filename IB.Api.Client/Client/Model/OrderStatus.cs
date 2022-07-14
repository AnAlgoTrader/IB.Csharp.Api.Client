namespace IB.Api.Client.Model
{
    public class OrderStatus
    {
        public static string UNKNOWN = "UNKNOWN";
        public static string FILLED = "Filled";
        public static string CANCELLED = "Cancelled";
        public static string PENDING_CANCEL = "PendingCancel";
        public static string INACTIVE = "Inactive";
        public static string ACTIVE = "Active";
        public static string CLOSED = "Closed";
    }
}
