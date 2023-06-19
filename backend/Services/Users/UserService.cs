using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services;

namespace backend.Services.Users
{
    public class UserService : DBService, IUserService
    {
        private readonly CarServiceContext _context;
        public UserService(CarServiceContext context) : base (context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid id) 
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.IdPerson == id);
        }

        public IQueryable<User> GetAsync()
        {
            return _context.Users;
        }
    }
}