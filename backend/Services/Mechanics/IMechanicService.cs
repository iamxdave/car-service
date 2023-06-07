using Entities.Models;

namespace Services.Mechanics
{
    public interface IMechanicService : IDBService
    {
        public IQueryable<Mechanic> GetMechanics();
        public Task<Mechanic?> GetMechanicByIdAsync(int id);
    }
}