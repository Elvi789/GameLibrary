using GameLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameLibrary.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
      

        public async Task Delete(TEntity entity)
        {
            
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        //public async Task<IEnumerable<TEntity>> FindEntityAsync(Expression<Func<TEntity, bool>> expression)
        //{
        //    return await _context.Set<TEntity>().Where(expression).ToListAsync();

        //}
    }
}
