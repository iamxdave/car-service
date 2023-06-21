using Entities.Models;

namespace Services.Orders
{
    public interface IOrderService : IDBService
    {
        public Task<Repair?> GetUserRepair(Guid idUser, Guid idOrder);
        public Task<Buyout?> GetUserBuyout(Guid idUser, Guid idOrder);
        public IQueryable<Repair> GetUserRepairs(Guid idUser);
        public IQueryable<Buyout> GetUserBuyouts(Guid idUser);
    }
}