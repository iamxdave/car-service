using backend.DTOs;
using backend.Helpers.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Mechanics;

namespace backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MechanicsController : ControllerBase
    {
        private readonly IMechanicService _service;
        private readonly IJwtService _jwtService;

        public MechanicsController(IMechanicService service, IJwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }

        [HttpGet(Name = "GetAvailableMechanics")]
        public async Task<IActionResult> GetAvailableMechanics()
        {

            var mechanics = await _service.GetMechanics().ToListAsync();
            
            if (mechanics == null || !mechanics.Any())
            {
                return NotFound("No mechanics in the database");
            }

            var dtoAvailableMechanics = mechanics.Select(e => new MechanicDto
            {
                IdPerson = e.IdPerson,
                Name = e.Name,
                Surname = e.Surname,
                BookedDates = e.BookedDates
            });

            return Ok(dtoAvailableMechanics);
        }
    }
}