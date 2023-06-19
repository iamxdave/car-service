using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Services;

namespace backend.Services.Parts
{
    public interface IPartService : IDBService
    {
        public IQueryable<Part> GetParts();
    }
}