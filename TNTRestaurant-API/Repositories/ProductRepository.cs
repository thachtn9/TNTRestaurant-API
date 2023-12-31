using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Database.EF;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using TNTRestaurant_API.Models;

namespace TNTRestaurant_API.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetList();
        Task<int> InsertUpdate(ProductModel product);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly MyBDContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MyBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetList()
        {
            var data = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(data);
        }

        public async Task<int> InsertUpdate(ProductModel productModel)
        {
            try
            {
                var product = _mapper.Map<Product>(productModel);
                if (product.ProductID == 0)
                {
                    _context.Products.Add(product);
                }
                else
                {
                    _context.Products.Update(product);
                }

                await _context.SaveChangesAsync();
                return product.ProductID;
            }
            catch (Exception ex) {
                return 0;
            }
           
        }
    }
}
