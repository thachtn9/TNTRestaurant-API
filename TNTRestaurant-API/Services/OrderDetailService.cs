using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailModel>> GetList();
        Task InsertUpdate(OrderDetailModel orderDetail);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetailModel>> GetList()
        {
            return await _orderDetailRepository.GetList();
        }

        public async Task InsertUpdate(OrderDetailModel orderDetail)
        {
            await _orderDetailRepository.InsertUpdate(orderDetail);
        }
    }
}
