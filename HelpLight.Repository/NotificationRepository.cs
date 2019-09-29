using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly HelpLightDbContext _VaODbContext;

        public NotificationRepository(HelpLightDbContext _VaODbContext)
        {
            this._VaODbContext = _VaODbContext;
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

        public Guid GetUserIdByEventId(Guid eventId)
        {
            try
            {
                var userID = _VaODbContext.Events.Where(e => e.IdEvent == eventId).Include(r => r.Organization).ThenInclude(o => o.User).FirstOrDefault();
                return userID.Organization.User.IdUser;
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
