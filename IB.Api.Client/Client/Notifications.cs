using System;
using IB.Api.Client.Client.Model;

namespace IB.Api.Client.Client
{
    /// <summary>
    /// IB API sends notifications through error methods, not all are errors, some of them are just user messages for information
    /// </summary>
    public partial class IBClient
    {
        public event EventHandler<Notification> NotificationReceived;
        public void error(Exception e)
        {
            var notification = new Notification
            {
                Id = 0,
                Code = 0,
                Message = e.Message,
                NotificationType = NotificationType.Error
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void error(string error)
        {
            var notification = new Notification
            {
                Id = 0,
                Code = 0,
                Message = error,
                NotificationType = NotificationType.Error
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void error(int id, int code, string errorMsg)
        {
            var notification = new Notification
            {
                Id = id,
                Code = code,
                Message = errorMsg,
                NotificationType = NotificationType.Information
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void Notify(string message)
        {
            var notification = new Notification
            {
                Id = 0,
                Code = 0,
                Message = message,
                NotificationType = NotificationType.Information
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void connectAck()
        {
            throw new NotImplementedException();
        }
        public void connectionClosed()
        {
            throw new NotImplementedException();
        }
    }
}
