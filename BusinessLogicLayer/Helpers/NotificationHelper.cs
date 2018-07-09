﻿using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class NotificationHelper
    {
        public List<Notification> GetNotifications()
        {
            var notifications = new List<Notification>();
            var trucksLink = "/Truck/EditTruck?truckId={0}";
            var workersLink = "/Worker/EditWorker?workerId={0}";
            var trucks = new TruckRepository().GetTrucks();
            var workers = new WorkerRepository().GetWorkers();

            foreach (var truck in trucks)
            {
                var pageLink = string.Format(trucksLink, truck.Id);
                notifications.Add(GetNotificationForDate(NotificationWarnnings.ITPWillExpire, NotificationWarnnings.ITPExpired, truck.ITPExpirationDate,truck.ITPExpirationDateString,truck.RegistrationNumber,pageLink,true));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.InsuranceWillExpire, NotificationWarnnings.InsuranceExpired, truck.InsuranceExpirationDate, truck.InsuranceExpirationDateString, truck.RegistrationNumber, pageLink, true));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.TahografWillExpire, NotificationWarnnings.TahografExpired, truck.TachographExpirationDate, truck.TachographExpirationDateString, truck.RegistrationNumber, pageLink, true));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.ConformCopyWillExpire, NotificationWarnnings.ConformCopyWillExpire, truck.ConformCopyExpirationDate, truck.ConformCopyExpirationDateString, truck.RegistrationNumber, pageLink, true));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.VignetteNLWillExpire, NotificationWarnnings.VignetteNLWillExpire, truck.VignetteExpirationDateNL, truck.VignetteExpirationDateNLString, truck.RegistrationNumber, pageLink, true));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.VignetteUKWillExpire, NotificationWarnnings.VignetteUKExpired, truck.VignetteExpirationDateUK, truck.VignetteExpirationDateUKString, truck.RegistrationNumber, pageLink, true));
            }
            foreach (var worker in workers)
            {
                var pageLink = string.Format(workersLink, worker.Id);
                notifications.Add(GetNotificationForDate(NotificationWarnnings.PermitWillExpire, NotificationWarnnings.PermitExpired, worker.DrivingLicenseExpirationDate, worker.DrivingLicenseExpirationDateString, worker.WorkerName, pageLink, false));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.CertificateWillExpire, NotificationWarnnings.CertificateExpired, worker.CertificateExpirationDate, worker.CertificateExpirationDateString, worker.WorkerName, pageLink, false));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.TahografCardWillExpire, NotificationWarnnings.TahografCardExpired, worker.TachographCardExpirationDate, worker.TachographCardExpirationDateString, worker.WorkerName, pageLink, false));
                notifications.Add(GetNotificationForDate(NotificationWarnnings.MedicalWillExpire, NotificationWarnnings.MedicalExpired, worker.MedicalTestsExpirationDate, worker.MedicalTestsExpirationDateString, worker.WorkerName, pageLink, false));
            }
            notifications = GetNotificationThatAreNotNull(notifications);
            return notifications.OrderByDescending(x => x.NotificationDate).ToList();
        }

        private Notification GetNotificationForDate(string notificationWillExpireText, string notificationEpiredText, DateTime? dateToCheck, string dateToCheckString, string documentOwnerInfo, string pageLink, bool isTruck)
        {
            var daysForWarning = isTruck ? 10 : 30;
            if (dateToCheck.HasValue && dateToCheck.Value <= DateTime.Now)
            {
                return DocumentExpired(notificationEpiredText, dateToCheckString, documentOwnerInfo, pageLink);
            }
            else if (dateToCheck.HasValue && dateToCheck.Value <= DateTime.Now.AddDays(daysForWarning))
            {
                return DocumentWillExpire(notificationWillExpireText, dateToCheckString, documentOwnerInfo, pageLink);
            }

            return null;
        }

        private Notification DocumentWillExpire(string notificationText,string dateToCheckString,string documentOwnerInfo, string pageLink)
        {
            var expirationText = string.Format(notificationText, documentOwnerInfo, dateToCheckString);
            return CreateNotification(expirationText, Commons.NotificationTypes.WarnningNotification, pageLink, DateTime.Parse(dateToCheckString));
        }

        private Notification DocumentExpired(string notificationText, string dateToCheckString, string documentOwnerInfo, string pageLink)
        {
            var expirationText = string.Format(notificationText, documentOwnerInfo, dateToCheckString);
            return CreateNotification(expirationText, Commons.NotificationTypes.ExpiredNotification, pageLink, DateTime.Parse(dateToCheckString));
        }

        private Notification CreateNotification(string notificationText, Commons.NotificationTypes notificationType,string notificationMainPageLink,DateTime date)
        {
            return new Notification()
            {
                Id = Guid.NewGuid(),
                NotificationText = notificationText,
                NotificationType = (int)notificationType,
                NotificationLink = notificationMainPageLink,
                NotificationDate = date
            };
        }

        private List<Notification> GetNotificationThatAreNotNull(List<Notification> notifications)
        {
            return notifications.Where(i => i != null).ToList();
        }
    }
}
