using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Database.EF;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using TNTRestaurant_API.Models;

namespace TNTRestaurant_API.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<RestaurantModel>> GetList();
        Task<int> InsertUpdate(RestaurantModel restaurant);
    }

    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly MyBDContext _context;
        private readonly IMapper _mapper;

        public RestaurantRepository(MyBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RestaurantModel>> GetList()
        {
            var data = await _context.Restaurants!.ToListAsync();
            return _mapper.Map<List<RestaurantModel>>(data);
        }

        public async Task<int> InsertUpdate(RestaurantModel restaurantModel)
        {
            try
            {
                var restaurant = _mapper.Map<Restaurant>(restaurantModel);

                if (restaurant.RestaurantID == 0)
                {
                    _context.Restaurants.Add(restaurant);
                }
                else
                {
                    _context.Restaurants.Update(restaurant);
                }

                await _context.SaveChangesAsync();
                return restaurant.RestaurantID;
            }
            catch (Exception ex) {
                return 0;
            }
           
        }
    }
}
