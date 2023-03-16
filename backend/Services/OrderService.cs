using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly CarServiceContext _context;

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders;
        }

        public OrderService(CarServiceContext context)
        {
            _context = context;
        }

        public void Delete<T>(T entity) where T : class
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}