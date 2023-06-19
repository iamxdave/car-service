using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Services;

namespace backend.Services.Workshops
{
    public interface IWorkshopService : IDBService
    {
        public IQueryable<Workshop> GetWorkshops();
    }
}