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
        public void Error(string message)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = 0,
                Code = 0,
                Message = message,
                NotificationType = GetNotificationType(message)
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void Error(int id, int errorCode, string message, string advancedOrderRejectJson)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = 0,
                Code = 0,
                Message = message,
                NotificationType = GetNotificationType(message),
                AdvancedOrderRejectJson = advancedOrderRejectJson
            };
            NotificationReceived?.Invoke(this, notification);
        }
        public void Error(int id, int code, string message)
        {
            var notification = new Notification
            {
                At = DateTime.Now,
                Id = id,
                Code = code,
                Message = message,
                NotificationType = GetNotificationType(message)
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
                NotificationType = GetNotificationType(message)
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
                NotificationType = GetNotificationType(message)
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

        public NotificationType GetNotificationType(string message)
        {
            if (message.Contains("data farm connection is OK"))
                return NotificationType.OK;

            if (message.Contains("data farm connection is inactive"))
                return NotificationType.Error;

            return NotificationType.Information;
        }
    }
}
