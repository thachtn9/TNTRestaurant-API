using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetList();
        Task InsertUpdate(ProductModel product);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductModel>> GetList()
        {
            return await _productRepository.GetList();
        }

        public async Task InsertUpdate(ProductModel product)
        {
            await _productRepository.InsertUpdate(product);
        }
    }
}
