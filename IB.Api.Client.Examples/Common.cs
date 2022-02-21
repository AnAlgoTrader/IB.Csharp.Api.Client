using System;

namespace IB.Api.Client.Examples
{
    public class Common
    {
        public static void NotificationReceived(object sender, Notification notification)
        {
            Console.WriteLine($"Type:{notification.NotificationType} Code:{notification.Code} Id:{notification.Id} Message: {notification.Message}");
        }
        public static void KeepConsoleAlive()
        {
            Console.ReadLine();
        }
    }
}
