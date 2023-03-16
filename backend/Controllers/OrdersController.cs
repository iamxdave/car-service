using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;

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

        [HttpGet(Name = "GetAllOrders")]
        public IEnumerable<OrderGet> GetOrders()
        {
            var orders = _service.GetOrders();

            if (orders == null || !orders.Any())
            {
                return Enumerable.Empty<OrderGet>();
            }

            return orders.Select(e => new OrderGet
            {
                DateCreated = e.DateCreated,
                DateCompleted = e.DateCompleted,
                Cost = e.Cost
            }).ToList();
        }
    }
}