using GameLibrary.Data;
using GameLibrary.Repository;
using GameLibrary.Repository.Pagination;
using NuGet.Protocol.Core.Types;
using static GameLibrary.Services.NotificationService;

namespace GameLibrary.Services
{
    
        public class NotificationService : INotificationService
        {
            public NotificationRepository _notifRepo;
            public NotificationService(NotificationRepository notifRepo) { _notifRepo = notifRepo; }
        public async Task<PaginatedList<Notification>> GetPaginatedNotifications(int page = 1, int pageSize = 10)
        {
            return await _notifRepo.GetPaginatedNotification(page, pageSize);
        }
        public async Task<Notification> GetNotificationById(int id)
            {
                return await _notifRepo.GetNotificationId(id);
            }

            public async Task<IEnumerable<Notification>> GetAllNotifications()
            {
                return await _notifRepo.GetAllNotifications();
            }

            public async Task CreateNotification(Notification notification)
            {
                await _notifRepo.AddNotification(notification);
            }

            public async Task EditNotification(Notification notification)
            {
                await _notifRepo.UpdateNotification(notification);
            }

            public async Task DeleteNotification(int id)
            {
                await _notifRepo.DeleteNotification(id);
            }
        }
}
