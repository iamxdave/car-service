
using Entities.Data;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DBService : IDBService
    {
        private readonly CarServiceContext _context;
        public DBService(CarServiceContext context)
        {
            _context = context;
        }
        public T Delete<T>(T entity) where T : class
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;

            return entity;
        }
        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}