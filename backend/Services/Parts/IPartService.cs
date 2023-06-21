using Entities.Models;
using Services;

namespace backend.Services.Parts
{
    public interface IPartService : IDBService
    {
        public IQueryable<Part> GetParts();
    }
}