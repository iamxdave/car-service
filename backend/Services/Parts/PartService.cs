using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Data;
using Entities.Models;
using Services;

namespace backend.Services.Parts
{
    public class PartService : DBService, IPartService
    {
        private readonly CarServiceContext _context;
        public PartService(CarServiceContext context) : base (context)
        {
            _context = context;
        }

        public IQueryable<Part> GetParts()
        {
            return _context.Parts;
        }

    }
}