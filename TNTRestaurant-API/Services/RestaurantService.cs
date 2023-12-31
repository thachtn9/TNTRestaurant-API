using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IRestaurantService
    {
        Task<IActionResult> GetList();
        Task<IActionResult> InsertUpdate(RestaurantModel restaurant);
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _restaurantRepository.GetList();
                return new ObjectResult(new BaseResponseModel()
                {
                    Code = (int)HttpStatusCode.OK,
                    Message = "Api Success",
                    Data = result,
                    Status = "OK"
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new BaseResponseModel()
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = "API ERROR",
                    Data = ex.ToString(),
                    Status = "NOTOK"
                });
            }
        }

        public async Task<IActionResult> InsertUpdate(RestaurantModel restaurant)
        {
            try
            {
                var result = await _restaurantRepository.InsertUpdate(restaurant);
                
                return new ObjectResult(new BaseResponseModel()
                {
                    Code = (int)HttpStatusCode.OK,
                    Message = "Api Success",
                    Data = result,
                    Status = "OK"
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new BaseResponseModel()
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Message = "API ERROR",
                    Data = ex.ToString(),
                    Status = "NOTOK"
                });
            }
        }
    }
}
