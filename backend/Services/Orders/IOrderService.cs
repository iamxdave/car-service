using Entities.Models;

namespace Services.Orders
{
    public interface IOrderService
    {
        public IQueryable<Order> GetOrders();
    }
}