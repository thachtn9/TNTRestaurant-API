using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IOrderDetailService
    {
        Task<IActionResult> GetList();
        Task<IActionResult> InsertUpdate(OrderDetailModel orderDetail);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _orderDetailRepository.GetList();
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

        public async Task<IActionResult> InsertUpdate(OrderDetailModel orderDetail)
        {
            try
            {
                var result = await _orderDetailRepository.InsertUpdate(orderDetail);

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
