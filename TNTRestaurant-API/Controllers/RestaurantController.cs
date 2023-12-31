using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Services;

namespace TNTRestaurant_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            return await _restaurantService.GetList();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateRestaurant(RestaurantModel restaurant)
        {
            return await _restaurantService.InsertUpdate(restaurant);
        }
    }
}
