using Entities.Models;
using Services;

namespace backend.Services.Cars
{
    public interface ICarService : IDBService
    {
         public IQueryable<CarToRepair>? GetUserCars(Guid idUser);
         public IQueryable<CarToBuy>? GetServiceCars();
         public Task<CarToRepair?> GetUserCarByIdAsync(Guid idCar);
         public Task<CarToBuy?> GetServiceCarByIdAsync(Guid idCar);
    }
}