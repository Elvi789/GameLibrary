using GameLibrary.Data;
using GameLibrary.Repository.Pagination;

namespace GameLibrary.Services
{
    public interface INotificationService
    {
        Task<PaginatedList<Notification>> GetPaginatedNotifications(int page = 1, int pageSize = 10);
        Task<Notification> GetNotificationById(int id);
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task CreateNotification(Notification notification);
        Task EditNotification(Notification notification);
        Task DeleteNotification(int id);
    }
}
