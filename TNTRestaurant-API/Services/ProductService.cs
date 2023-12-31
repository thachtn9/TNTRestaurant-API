using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IProductService
    {
        Task<IActionResult> GetList();
        Task<IActionResult> InsertUpdate(ProductModel product);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _productRepository.GetList();
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

        public async Task<IActionResult> InsertUpdate(ProductModel product)
        {
            try
            {
                var result = await _productRepository.InsertUpdate(product);

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
