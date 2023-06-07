

namespace Services
{
    public interface IDBService
    {
        public T Delete<T>(T entity) where T : class;
        public Task<T> CreateAsync<T>(T entity) where T : class;
        public Task SaveChangesAsync();
    }
}