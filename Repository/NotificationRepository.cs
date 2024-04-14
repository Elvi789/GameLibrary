using GameLibrary.Data;
using GameLibrary.Repository.Pagination;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Repository
{
    public class NotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddNotification(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }
        public async Task<Notification> GetNotificationId(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }
        public async Task UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteNotification(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }
        public async Task<PaginatedList<Notification>> GetPaginatedNotification(int page = 1, int pageSize = 10)
        {
            var notResult = _context.Notifications.OrderByDescending(x => x.Id).AsQueryable();
            var notification = await PaginatedList<Notification>.CreateAsync(notResult, page, pageSize);
            return notification;
        }
    }
}
