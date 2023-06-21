using backend.DTOs;
using backend.Services.Parts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartsController : ControllerBase
    {
        private readonly IPartService _service;

        public PartsController(IPartService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetParts")]
        public async Task<IActionResult> GetParts()
        {
            var parts = _service.GetParts();

            if (parts == null || !parts.Any())
            {
                return NotFound();
            }

            var dtoParts = await parts.Select(e => new PartDto{
                IdPart = e.IdPart,
                Name = e.Name
            }).ToListAsync();

            return Ok(dtoParts);
        }
    }
}