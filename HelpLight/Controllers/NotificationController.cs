using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpLight.Repository.Contracts;
using Microsoft.AspNetCore.Cors;

namespace HelpLight.Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository _notificationRepository)
        {
            this._notificationRepository = _notificationRepository;
        }

        [HttpGet]
        [Route("GetNotificationsByUserId")]
        public IActionResult GetNotificationsByUserId(Guid userId)
        {
            try
            {
                var notifications = _notificationRepository.GetNotifications(userId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("NotifyUser")]
        public IActionResult AddCardToVolunteer([FromBody] Notification notification)
        {
            if (ModelState.IsValid)
            {
                _notificationRepository.AddNotification(notification);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
