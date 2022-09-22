using System;
using IB.Api.Client.Model;

namespace IB.Api.Client
{
    /// <summary>
    /// IB API sends notifications through error methods, not all are errors, some of them are just user messages for information
    /// </summary>
    public partial class IBClient
    {
        public event EventHandler<Notification> NotificationReceived;
        public void Error(Exception e)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = 0,
                Code = 0,
                Message = e.Message,
                NotificationType = NotificationType.Error
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void Error(string error)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = 0,
                Code = 0,
                Message = error,
                NotificationType = NotificationType.Error
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void Error(int id, int code, string errorMsg)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = id,
                Code = code,
                Message = errorMsg,
                NotificationType = errorMsg.IndexOf("ERROR", StringComparison.OrdinalIgnoreCase) >= 0 ? NotificationType.Error : NotificationType.Information
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void Notify(string message)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = 0,
                Code = 0,
                Message = message,
                NotificationType = NotificationType.Information
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void NotifyError(string message)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = 0,
                Code = 0,
                Message = message,
                NotificationType = NotificationType.Error
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void ConnectAck()
        {
            Notify("Connection Acknowledged");
        }
        public void ConnectionClosed()
        {
            Notify("Connection Closed");
        }
    }
}
