using Entities.Models;
using Services;

namespace backend.Services.Workshops
{
    public interface IWorkshopService : IDBService
    {
        public IQueryable<Workshop> GetWorkshops();
    }
}