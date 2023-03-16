using Entities.Models;

namespace Services
{
    public interface IOrderService
    {
        public IQueryable<Order> GetOrders();
        public void Delete<T>(T entity) where T : class;
        public Task CreateAsync<T>(T entity) where T : class;
        public Task SaveChangesAsync();
    }
}