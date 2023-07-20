using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetList();
        Task InsertUpdate(OrderModel order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderModel>> GetList()
        {
            return await _orderRepository.GetList();
        }

        public async Task InsertUpdate(OrderModel order)
        {
            await _orderRepository.InsertUpdate(order);
        }
    }
}
