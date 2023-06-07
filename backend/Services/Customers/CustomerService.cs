using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services;

namespace backend.Services.Customers
{
    public class CustomerService : DBService, ICustomerService
    {
        private readonly CarServiceContext _context;
        public CustomerService(CarServiceContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Customer?> GetById(int id) 
        {
            return await _context.Customers.FirstOrDefaultAsync(e => e.IdPerson == id);
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}