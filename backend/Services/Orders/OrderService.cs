using Entities.Data;
using Entities.Models;

namespace Services.Orders
{
    public class OrderService : DBService, IOrderService
    {
        private readonly CarServiceContext _context;

        public OrderService(CarServiceContext context) : base (context)
        {
            _context = context;
        }

        public IQueryable<Order> GetUserOrders(Guid idUser)
        {
            return _context.Orders.Where(e => e.IdUser == idUser);
        }
    }
}