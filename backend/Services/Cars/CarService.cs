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
        public async Task<CarToRepair?> GetUserCarByIdAsync(Guid idCar)
        {
            return await _context.CarToRepairs.FirstOrDefaultAsync(e => e.IdCar == idCar);
        }
        public async Task<CarToBuy?> GetServiceCarByIdAsync(Guid idCar)
        {
            return await _context.CarToBuys.FirstOrDefaultAsync(e => e.IdCar == idCar);
        }
    }
}