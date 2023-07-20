using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Database.EF;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using TNTRestaurant_API.Models;

namespace TNTRestaurant_API.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetailModel>> GetList();
        Task InsertUpdate(OrderDetailModel orderDetail);
    }

    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MyBDContext _context;
        private readonly IMapper _mapper;

        public OrderDetailRepository(MyBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailModel>> GetList()
        {
            var data = await _context.OrderDetails!.ToListAsync();
            return _mapper.Map<List<OrderDetailModel>>(data);
        }

        public async Task InsertUpdate(OrderDetailModel orderDetailModel)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

            }
          
        }
    }
}
