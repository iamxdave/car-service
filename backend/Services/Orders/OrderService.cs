using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Orders
{
    public class OrderService : DBService, IOrderService
    {
        private readonly CarServiceContext _context;

        public OrderService(CarServiceContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Repair?> GetUserRepair(Guid idUser, Guid idOrder)
        {
            return await _context.Repairs.Where(e => e.IdUser == idUser && e.IdOrder == idOrder)
                .Include(e => e.Car)
                .ThenInclude(e => e.Workshop)
                .Include(e => e.Mechanic)
                .Include(e => e.RepairParts)
                .ThenInclude(e => e.Part).FirstOrDefaultAsync();
        }
        public async Task<Buyout?> GetUserBuyout(Guid idUser, Guid idOrder)
        {
            return await _context.Buyouts.Where(e => e.IdUser == idUser && e.IdOrder == idOrder)
                .Include(e => e.Car)
                .ThenInclude(e => e.Workshop)
                .Include(e => e.Mechanic).FirstOrDefaultAsync();
        }

        public IQueryable<Repair> GetUserRepairs(Guid idUser)
        {
            return _context.Repairs.Where(e => e.IdUser == idUser)
                .Include(e => e.Car)
                .ThenInclude(e => e.Workshop)
                .Include(e => e.Mechanic)
                .Include(e => e.RepairParts)
                .ThenInclude(e => e.Part);
        }

         public IQueryable<Buyout> GetUserBuyouts(Guid idUser)
        {
            return _context.Buyouts.Where(e => e.IdUser == idUser)
                .Include(e => e.Car)
                .ThenInclude(e => e.Workshop)
                .Include(e => e.Mechanic);
        }
    }
}