using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace HelpLight.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public NotificationRepository(HelpLightDbContext OrganizationsAndVolunteersDbContext)
        {
            this._VaODbContext = OrganizationsAndVolunteersDbContext;
        }

        public void AddNotification(Notification notification)
        {
            try
            {
                var notificationEntity = Mapper.Map<Contracts.Notification, Data.Models.Notification>(notification);
                _VaODbContext.Notifications.Add(notificationEntity);
                SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Notification> GetNotifications(Guid userId)
        {
            try
            {
                var notifications = _VaODbContext.Notifications.Where(n => n.IdUser == userId);
                return Mapper.Map<List<Contracts.Notification>>(notifications);
            }
            catch
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _VaODbContext.SaveChanges();
        }
    }
}
