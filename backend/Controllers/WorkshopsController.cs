using backend.DTOs;
using backend.Services.Workshops;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService _service;

        public WorkshopsController(IWorkshopService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetWorkshops")]
        public async Task<IActionResult> GetWorkshops()
        {
            var workshops = _service.GetWorkshops();

            if (workshops == null || !workshops.Any())
            {
                return NotFound();
            }

            var dtoWorkshops = await workshops.Select(e => new WorkshopDto
            {
                IdWorkshop = e.IdWorkshop,
                Name = e.Name,
                Address = e.Address
            }).ToListAsync();

            return Ok(dtoWorkshops);
            
            
        }
    }
}