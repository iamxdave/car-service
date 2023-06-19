using backend.Services.Cars;
using backend.Services.Parts;
using backend.Services.Users;
using DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Mechanics;
using Services.Orders;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IMechanicService _mechanicService;
        private readonly IPartService _partsService;
        private readonly IConfiguration _configuration;

        public OrdersController(IOrderService service, IUserService userService, ICarService carService, IMechanicService mechanicService, IPartService partsService, IConfiguration configuration)
        {
            _service = service;
            _userService = userService;
            _carService = carService;
            _mechanicService = mechanicService;
            _partsService = partsService;
            _configuration = configuration;
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetOrders(Guid idUser)
        {
            var orders = _service.GetUserOrders(idUser);

            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            var dtoOrders = await orders.Select(e => new OrderDto
            {
                DateCreated = e.DateCreated,
                DateCompleted = e.DateCompleted,
                Cost = e.Cost
            }).ToListAsync();

            return Ok(dtoOrders);
        }


        [HttpPost("buyout")]
        public async Task<IActionResult> PostOrderForBuyout(OrderDto body) 
        {
            var user = await _userService.GetByIdAsync(body.IdUser);
            var car = await _carService.GetServiceCarByIdAsync(body.IdCar);
            var mechanic = await _mechanicService.GetMechanicByIdAsync(body.IdMechanic);

            if (user == null || car == null || mechanic == null)
            {
                return NotFound(new{ user = user == null, car = car == null, mechanic = mechanic == null });
            }

            var orderPost = new Buyout
            {
                IdUser = body.IdUser,
                IdMechanic = body.IdMechanic,
                IdCar = body.IdCar,
                DateCreated = DateTime.Now,
                Warranty = body.Warranty?? 5,
                Cost = car.Cost,
                Status = OrderStatus.Accepted
            };
            
            await _service.CreateAsync(orderPost);

            await _service.SaveChangesAsync();

            return Created("success", orderPost);

        }

        [HttpPost("repair")]
        public async Task<IActionResult> PostOrderForRepair(OrderDto body) 
        {
            var user = await _userService.GetByIdAsync(body.IdUser);
            var car = await _carService.GetUserCarByIdAsync(body.IdCar);
            var mechanic = await _mechanicService.GetMechanicByIdAsync(body.IdMechanic);

            if (user == null || car == null || mechanic == null || body.Parts == null)
            {
                return NotFound(new{ user = user == null, car = car == null, mechanic = mechanic == null });
            }

            var parts = _partsService.GetParts();
            bool allPartsExist = body.Parts.All(part => parts.Any(p => p.IdPart == part.IdPart));

            if (!allPartsExist) {
                return BadRequest("Parts not found");
            }

            var orderPost = new Repair
            {
                IdUser = body.IdUser,
                IdMechanic = body.IdMechanic,
                IdCar = body.IdCar,
                DateCreated = DateTime.Now,
                Status = OrderStatus.Accepted
            };

            await _service.CreateAsync(orderPost);
            await _service.SaveChangesAsync();

            decimal totalCost = 0;

            Random random = new Random();
            foreach(var part in body.Parts){
                decimal cost = random.Next(2, 11) * 100;
                totalCost += cost;

                await _service.CreateAsync(new RepairPart
                {
                    IdRepair = orderPost.IdOrder,
                    IdPart = part.IdPart,
                    Cost = cost
                });
            }
            orderPost.Cost = totalCost;

            await _service.SaveChangesAsync();

            return Created("success", orderPost);
        }
    }
}