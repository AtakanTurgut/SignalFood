using BusinessLayer.Abstract;
using DtoLater.NotificationDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByStatusFalse")]
        public IActionResult GetAllNotificationByStatusFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByStatusFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification()
            {
                Description = createNotificationDto.Description,
                Icon = createNotificationDto.Icon,
                Status = false,
                Type = createNotificationDto.Type,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };

            _notificationService.TAdd(notification);

            return Ok("Bildirim Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);

            return Ok("Bildirim Kaldırıldı!");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationId = updateNotificationDto.NotificationId,
                Description = updateNotificationDto.Description,
                Icon = updateNotificationDto.Icon,
                Status = updateNotificationDto.Status,
                Type = updateNotificationDto.Type,
                Date = updateNotificationDto.Date
            };

            _notificationService.TUpdate(notification);

            return Ok("Bildirim Güncellendi!");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);

            return Ok("Güncelleme Yapıldı!");
        }

		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);

            return Ok("Güncelleme Yapıldı!");

		}

	}
}
