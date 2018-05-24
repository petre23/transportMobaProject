using BusinessLogicLayer.Helpers;
using DataLayer.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Logic
{
    public class NotificationBL
    {
        NotificationHelper _notificationHelper = new NotificationHelper();
        public List<Notification> GetNotifications()
        {
            return _notificationHelper.GetNotifications();
        }
    }
}
