using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Orders;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IConfiguration _configuration;

        public OrdersController(IOrderService service, IConfiguration configuration)
        {
            _service = service;
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

        // [HttpPost(Name = "PostOrder")]
        // public async Task<IActionResult> PostOrder(OrderGet) 
        // {
            
        // }
    }
}