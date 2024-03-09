using GameLibrary.Data;

namespace GameLibrary.Services
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationById(int id);
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task CreateNotification(Notification notification);
        Task EditNotification(Notification notification);
        Task DeleteNotification(int id);
    }
}
