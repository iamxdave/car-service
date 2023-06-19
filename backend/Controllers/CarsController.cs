using backend.DTOs;
using backend.Services.Cars;
using Entities.Models;
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
                return Ok();
            }

            var dtoCars = await cars.Select(e => new CarDto
            {
                IdCar = e.IdCar,
                Brand = e.Brand,
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
                IdCar = e.IdCar,
                Brand = e.Brand,
                Model = e.Model,
                Cost = e.Cost,
                Description = e.Description
            }).ToListAsync();

            return Ok(dtoCars);
        }
        [Authorize]
        [HttpPost("{userId}")]
        public async Task<IActionResult> PostUserCar(CarDto body, Guid userId)
        {
            if (body.RegistrationNumber == null)
                return Conflict(new { message = "No registration number" });

            var car = _service.GetUserCars(userId)?.Where(e => e.RegistrationNumber == body.RegistrationNumber);
            
            if(car != null && car.Any())
            {
                return Conflict(new { message = "Registration number already exists" });
            }

            var carPost = new CarToRepair
            {
                IdUser = userId,
                Brand = body.Brand,
                Model = body.Model,
                IdWorkshop = body.IdWorkshop,
                RegistrationNumber = body.RegistrationNumber
            };      
            
            await _service.CreateAsync(carPost);

            await _service.SaveChangesAsync();

            return Created("success", carPost);
        }

        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserCar(Guid carId, Guid userId)
        {
            var car = _service.GetUserCars(userId)?.Where(e => e.IdCar == carId);

            if (car != null && car.Any())
            {
                _service.Delete(car);

                await _service.SaveChangesAsync();
            }

            return Ok();
        }
    }
}