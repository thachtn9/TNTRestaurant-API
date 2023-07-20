using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IOrderService
    {
        Task<IActionResult> GetList();
        Task<IActionResult> InsertUpdate(OrderModel order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> GetList()
        {
            var result = await _orderRepository.GetList();
            return new ObjectResult(new BaseResponseModel()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Inserted customer",
                Data = result,
                Status = "OK"
            });
        }

        public async Task<IActionResult> InsertUpdate(OrderModel order)
        {
           var result =  await _orderRepository.InsertUpdate(order);
            return new ObjectResult(new BaseResponseModel()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Inserted customer",
                Data = result,
                Status = "OK"
            });
        }
    }
}
