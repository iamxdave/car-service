using Entities.Models;
using Services;

namespace backend.Services.Users
{
    public interface IUserService : IDBService
    {
        public Task<User?> GetByEmail(string email);
        public Task<User?> GetByIdAsync(Guid id);
        public IQueryable<User> GetAsync();
    }
}