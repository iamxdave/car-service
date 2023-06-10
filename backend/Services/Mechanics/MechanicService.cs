

using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Mechanics
{
    public class MechanicService : DBService, IMechanicService
    {
        private readonly CarServiceContext _context;
        public MechanicService(CarServiceContext context) : base (context)
        {
            _context = context;
        }

        public IQueryable<Mechanic> GetMechanics()
        {
            return _context.Mechanics;
        }

        public async Task<Mechanic?> GetMechanicByIdAsync(Guid id)
        {
            return await _context.Mechanics.FirstOrDefaultAsync(e => e.IdPerson == id);
        }
    }
}