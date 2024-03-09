using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Repository;
using GameLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers
{
    public class NotificationController : Controller
    {
        public readonly INotificationService _notifServices;
        public NotificationController(INotificationService notification)
        {
            _notifServices = notification;
        }
        public async Task<IActionResult> Index()
        {
            var notifications = await _notifServices.GetAllNotifications();
            return View(notifications);
        }

        public async Task<IActionResult> Details(int id)
        {
            var itemToShowDetails = await _notifServices.GetNotificationById(id);
            return View(itemToShowDetails);
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _notifServices.DeleteNotification(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            NotificationForCreationDto dto = new NotificationForCreationDto();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(NotificationForCreationDto dto)
        {
            Notification notification = new Notification();
            notification.Name = dto.Name;
            notification.Description = dto.Description;
            await _notifServices.CreateNotification(notification);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var notification = await _notifServices.GetNotificationById(id);
            return View(notification);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Notification notification)
        {
            await _notifServices.EditNotification(notification);
            return RedirectToAction("Index");
        }
    }
}
