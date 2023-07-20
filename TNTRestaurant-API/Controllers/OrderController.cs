using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Services;

namespace TNTRestaurant_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetOrders()
        {
            var orders = await _orderService.GetList();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateOrder(OrderModel order)
        {
            await _orderService.InsertUpdate(order);
            return Ok();
        }
    }
}
