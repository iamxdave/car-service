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

        [HttpPut("{idMechanic}")]
        public async Task<IActionResult> PutMechanic(Guid idMechanic, DateTime date) 
        {
            var mechanic = await _service.GetMechanicByIdAsync(idMechanic);

            if(mechanic == null)
            {
                return NotFound();
            }
            if(mechanic.BookedDates.Any(d => d.Date == date.Date) || date < DateTime.Now)
            {
                return Conflict(new{date1 = mechanic.BookedDates.FirstOrDefault(), date2= date});
            }

            mechanic.BookedDates.Add(date);

            await _service.SaveChangesAsync();

            return Ok(mechanic);
        }
    }
}