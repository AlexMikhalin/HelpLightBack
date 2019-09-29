using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface INotificationRepository : IWorkUnit
    {
        void AddNotification(Notification notification);
        List<Notification> GetNotifications(Guid userId);
        Guid GetUserIdByEventId(Guid eventId);
    }
}
