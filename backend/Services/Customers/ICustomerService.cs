using Entities.Models;
using Services;

namespace backend.Services.Customers
{
    public interface ICustomerService : IDBService
    {
        public Task<Customer?> GetByEmail(string email);
        public Task<Customer?> GetById(int id);
        public Task<List<Customer>> GetAsync();
    }
}