using Entities.Models;

namespace Services.Orders
{
    public interface IOrderService : IDBService
    {
        public IQueryable<Order> GetUserOrders(Guid idUser);
    }
}