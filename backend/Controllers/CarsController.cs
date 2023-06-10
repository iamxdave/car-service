using backend.DTOs;
using backend.Services.Cars;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;
        private readonly IConfiguration _configuration;

        public CarsController(ICarService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCars(Guid userId)
        {
            var cars = _service.GetUserCars(userId);

            if (cars == null || !cars.Any())
            {
                return NotFound();
            }

            var dtoCars = await cars.Select(e => new CarDto
            {
                Model = e.Model,
                RegistrationNumber = e.RegistrationNumber
            }).ToListAsync();

            return Ok(dtoCars);
        }

        [HttpGet(Name = "GetServiceCars")]
        public async Task<IActionResult> GetCars()
        {
            var cars = _service.GetServiceCars();

            if (cars == null || !cars.Any())
            {
                return NotFound();
            }

            var dtoCars = await cars.Select(e => new CarDto
            {
                Model = e.Model,
                Cost = e.Cost,
                Warranty = e.Warranty
            }).ToListAsync();

            return Ok(dtoCars);
        }
    }
}