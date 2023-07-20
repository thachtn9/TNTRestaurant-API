using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IRestaurantService
    {
        Task<List<RestaurantModel>> GetList();
        Task InsertUpdate(RestaurantModel restaurant);
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<RestaurantModel>> GetList()
        {
            return await _restaurantRepository.GetList();
        }

        public async Task InsertUpdate(RestaurantModel restaurant)
        {
            await _restaurantRepository.InsertUpdate(restaurant);
        }
    }
}
