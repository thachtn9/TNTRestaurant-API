using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Database.EF;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using TNTRestaurant_API.Models;

namespace TNTRestaurant_API.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetList();
        Task<int> InsertUpdate(OrderModel order);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly MyBDContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(MyBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<OrderModel>> GetList()
        {
            var data = await _context.Orders!.ToListAsync();
            return _mapper.Map<List<OrderModel>>(data);
        }

        public async Task<int> InsertUpdate(OrderModel orderModel)
        {
            try
            {
                var order = _mapper.Map<Order>(orderModel);
                if (order.OrderID == 0)
                {
                    _context.Orders.Add(order);
                }
                else
                {
                    _context.Orders.Update(order);
                }

                await _context.SaveChangesAsync();
                return order.OrderID;
            }

            catch (Exception ex)
            {
                return 0;
            }
           
        }
    }
}
