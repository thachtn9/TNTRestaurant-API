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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetailModel>>> GetOrderDetails()
        {
            var orderDetails = await _orderDetailService.GetList();
            return Ok(orderDetails);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateOrderDetail(OrderDetailModel orderDetail)
        {
            await _orderDetailService.InsertUpdate(orderDetail);
            return Ok();
        }
    }
}
