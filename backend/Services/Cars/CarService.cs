using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services;

namespace backend.Services.Cars
{
    public class CarService : DBService, ICarService
    {
        private readonly CarServiceContext _context;
        public CarService(CarServiceContext context) : base (context)
        {
            _context = context;
        }
        public IQueryable<CarToRepair>? GetUserCars(Guid idUser)
        {
            return _context.CarToRepairs.Where(e => e.IdUser == idUser);
        }
        public IQueryable<CarToBuy>? GetServiceCars()
        {
            return _context.CarToBuys;
        }
    }
}