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
        public async Task<ActionResult<List<RestaurantModel>>> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetList();
            return Ok(restaurants);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateRestaurant(RestaurantModel restaurant)
        {
            await _restaurantService.InsertUpdate(restaurant);
            return Ok();
        }
    }
}
