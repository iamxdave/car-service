using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Data;
using Entities.Models;
using Services;

namespace backend.Services.Workshops
{
    public class WorkshopService : DBService, IWorkshopService
    {
        private readonly CarServiceContext _context;
        public WorkshopService(CarServiceContext context) : base (context)
        {
            _context = context;
        }

        public IQueryable<Workshop> GetWorkshops()
        {
            return _context.Workshops;
        }
    }
}