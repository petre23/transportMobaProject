using System;

namespace DataLayer.PersistanceLayer
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string NotificationText { get; set; }
        public int NotificationType { get; set; }
        public string NotificationLink { get; set; }
    }
}
