using IB.Api.Client.Model;

namespace IB.Api.Client
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}