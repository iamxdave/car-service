using Entities.Models;

namespace backend.Services.Cars
{
    public interface ICarService
    {
         public IQueryable<CarToRepair>? GetUserCars(Guid idUser);
         public IQueryable<CarToBuy>? GetServiceCars();
    }
}