using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface ICustomerService
    {
        Task<IActionResult> GetList();
        Task<IActionResult> InsertUpdate(CustomerModel customer);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _customerRepository.GetList();
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

        public async Task<IActionResult> InsertUpdate(CustomerModel customer)
        {
           
            try
            {
                var result = await _customerRepository.InsertUpdate(customer);
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
