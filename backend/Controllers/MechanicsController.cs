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
        public async Task<IActionResult> GetAvailableMechanics(DateTime start, DateTime end)
        {

            var mechanics = await _service.GetMechanics().ToListAsync();
            
            if (mechanics == null || !mechanics.Any())
            {
                return NotFound("No mechanics in the database");
            }

            if(start == default(DateTime) || end == default(DateTime)) {
               var dtoMechanics = mechanics.Select(e => new MechanicGet
                {
                    Name = e.Name,
                    Surname = e.Surname,
                    BookedDates = e.BookedDates
                });

                return Ok(dtoMechanics);
            }

            if(start > end || start < DateTime.Now || end < DateTime.Now)
            {
                return Conflict("Date conflict");
            }

            var dateRange = Enumerable.Range(0, (end - start).Days + 1)
                                        .Select(offset => start.AddDays(offset));

            var availableMechanics = mechanics.Where(mechanic =>
                !dateRange.Any(date => mechanic.BookedDates.Contains(date))
            );

            if (availableMechanics == null || !availableMechanics.Any())
            {
                return NotFound("No available mechanics in the database");
            }

            var dtoAvailableMechanics = availableMechanics.Select(e => new MechanicGet
            {
                Name = e.Name,
                Surname = e.Surname,
                BookedDates = e.BookedDates
            });

            return Ok(dtoAvailableMechanics);
        }

        [HttpPut("{idMechanic}")]
        public async Task<IActionResult> PutMechanic(int idMechanic, MechanicPut body) 
        {
            var mechanic = await _service.GetMechanicByIdAsync(idMechanic);

            if(mechanic == null)
            {
                return NotFound();
            }
            if(mechanic.BookedDates.Any(date => body.BookedDates.Contains(date)))
            {
                return Conflict();
            }

            mechanic.BookedDates.AddRange(body.BookedDates);

            await _service.SaveChangesAsync();

            return Ok(mechanic);
        }
    }
}