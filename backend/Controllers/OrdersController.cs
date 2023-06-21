using backend.DTOs;
using backend.Services.Cars;
using backend.Services.Parts;
using backend.Services.Users;
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

        [HttpGet("repair/{idUser}")]
        public async Task<IActionResult> GetRepairOrders(Guid idUser)
        {
            var orders = await _service.GetUserRepairs(idUser).ToListAsync();

            if (orders == null || !orders.Any())
            {
                return Ok();
            }

            var dtoOrders = orders.Select(async e =>
            {
                var repairCar = await _carService.GetUserCarByIdAsync(e.Car.IdCar);
                var carDto = new CarDto
                {
                    IdCar = e.Car.IdCar,
                    Brand = e.Car.Brand,
                    Model = e.Car.Model,
                    RegistrationNumber = repairCar?.RegistrationNumber
                };

                var mechanicDto = new MechanicDto
                {
                    IdPerson = e.Mechanic.IdPerson,
                    Name = e.Mechanic.Name,
                    Surname = e.Mechanic.Surname,
                    BookedDates = e.Mechanic.BookedDates
                };

                var parts = e.RepairParts.Select(rp => 
                    new PartDto
                    {
                        IdPart = rp.IdPart,
                        Name = rp.Part.Name
                    }
                ).ToArray();

                return new OrderResultDto
                {
                    IdOrder = e.IdOrder,
                    Car = carDto,
                    Mechanic = mechanicDto,
                    DateStarted = e.DateStarted,
                    DateCompleted = e.DateCompleted,
                    Parts = parts,
                    Cost = e.Cost,
                    Status = e.Status
                };
            });

            return Ok(dtoOrders);
        }

        [HttpGet("buyout/{idUser}")]
        public async Task<IActionResult> GetBuyoutOrders(Guid idUser)
        {
        var orders = await _service.GetUserBuyouts(idUser).ToListAsync();

            if (orders == null || !orders.Any())
            {
                return Ok();
            }

            var dtoOrders = orders.Select(async e =>
            {
                var serviceCar = await _carService.GetServiceCarByIdAsync(e.Car.IdCar);
                var carDto = new CarDto
                {
                    IdCar = e.Car.IdCar,
                    Brand = e.Car.Brand,
                    Model = e.Car.Model,
                    Cost = serviceCar?.Cost,
                    Warranty = serviceCar?.Warranty
                };

                var mechanicDto = new MechanicDto
                {
                    IdPerson = e.Mechanic.IdPerson,
                    Name = e.Mechanic.Name,
                    Surname = e.Mechanic.Surname,
                    BookedDates = e.Mechanic.BookedDates
                };

                return new OrderResultDto
                {
                    IdOrder = e.IdOrder,
                    Car = carDto,
                    Mechanic = mechanicDto,
                    DateStarted = e.DateStarted,
                    DateCompleted = e.DateCompleted,
                    Warranty = e.Warranty,
                    Cost = e.Cost,
                    Status = e.Status
                };
            });


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
                return NotFound();
            }
            
            var warranty = body.Warranty?? 0;

            var orderPost = new Buyout
            {
                IdUser = body.IdUser,
                IdMechanic = body.IdMechanic,
                IdCar = body.IdCar,
                DateStarted = body.DateStarted,
                Warranty =  warranty + 5,
                Cost = car.Cost + (Decimal)(warranty * 100),
                Status = OrderStatus.Accepted
            };
            
            await _service.CreateAsync(orderPost);

            await _service.SaveChangesAsync();


            DateTime startDate = body.DateStarted;
            DateTime endDate = startDate.AddDays(6);

            mechanic.BookedDates.Add(new Reservation{ Start = startDate, End = endDate });

            await _mechanicService.SaveChangesAsync();

            var order = await _service.GetUserBuyout(body.IdUser, orderPost.IdOrder);

            if(order == null)
                return NotFound("Couldn't find an order after adding it to db");

            var serviceCar = await _carService.GetServiceCarByIdAsync(order.Car.IdCar);
            
            var carDto = new CarDto
            {
                IdCar = order.Car.IdCar,
                Brand = order.Car.Brand,
                Model = order.Car.Model,
                Cost = serviceCar?.Cost,
                Warranty = serviceCar?.Warranty
            };

            var mechanicDto = new MechanicDto
            {
                IdPerson = order.Mechanic.IdPerson,
                Name = order.Mechanic.Name,
                Surname = order.Mechanic.Surname,
                BookedDates = order.Mechanic.BookedDates
            };

            return Created("success", 
                new OrderResultDto
                {
                    IdOrder = order.IdOrder,
                    Car = carDto,
                    Mechanic = mechanicDto,
                    DateStarted = order.DateStarted,
                    DateCompleted = order.DateCompleted,
                    Cost = order.Cost,
                    Status = order.Status
                }
            );

        }

        [HttpPost("repair")]
        public async Task<IActionResult> PostOrderForRepair(OrderDto body) 
        {
            var user = await _userService.GetByIdAsync(body.IdUser);
            var car = await _carService.GetUserCarByIdAsync(body.IdCar);
            var mechanic = await _mechanicService.GetMechanicByIdAsync(body.IdMechanic);

            var parts = _partsService.GetParts();

            bool allPartsExist = body.IdParts!.All(idParts => parts.Any(p => p.IdPart == idParts));

            if (user == null || car == null || mechanic == null || body.IdParts == null || !allPartsExist)
            {
                return NotFound();
            }

            var orderPost = new Repair
            {
                IdUser = body.IdUser,
                IdMechanic = body.IdMechanic,
                IdCar = body.IdCar,
                DateStarted = body.DateStarted,
                Status = OrderStatus.Accepted
            };

            await _service.CreateAsync(orderPost);
            await _service.SaveChangesAsync();

            decimal totalCost = 0;

            Random random = new Random();
            foreach(var idPart in body.IdParts){
                decimal cost = random.Next(2, 11) * 100;
                totalCost += cost;

                await _service.CreateAsync(new RepairPart
                {
                    IdRepair = orderPost.IdOrder,
                    IdPart = idPart,
                    Cost = cost
                });
            }
            orderPost.Cost = totalCost;
            orderPost.TotalPartCost = totalCost;

            await _service.SaveChangesAsync();

            DateTime startDate = body.DateStarted;
            DateTime endDate = startDate.AddDays(6);

            mechanic.BookedDates.Add(new Reservation{ Start = startDate, End = endDate });

            await _mechanicService.SaveChangesAsync();

            var order = await _service.GetUserRepair(body.IdUser, orderPost.IdOrder);

            if(order == null)
                return NotFound("Couldn't find an order after adding it to db");

            var repairCar = await _carService.GetUserCarByIdAsync(order.Car.IdCar);
            
            var carDto = new CarDto
            {
                IdCar = order.Car.IdCar,
                Brand = order.Car.Brand,
                Model = order.Car.Model,
                RegistrationNumber = repairCar?.RegistrationNumber
            };

            var mechanicDto = new MechanicDto
            {
                IdPerson = order.Mechanic.IdPerson,
                Name = order.Mechanic.Name,
                Surname = order.Mechanic.Surname,
                BookedDates = order.Mechanic.BookedDates
            };

            var partsDto = order.RepairParts.Select(rp => 
                new PartDto
                {
                    IdPart = rp.IdPart,
                    Name = rp.Part.Name
                }
            ).ToArray();

            return Created("success", 
                new OrderResultDto
                {
                    IdOrder = order.IdOrder,
                    Car = carDto,
                    Mechanic = mechanicDto,
                    DateStarted = order.DateStarted,
                    DateCompleted = order.DateCompleted,
                    Parts = partsDto,
                    Cost = order.Cost,
                    Status = order.Status
                }
            );
        }
    }
}