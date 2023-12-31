using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Database.EF;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using TNTRestaurant_API.Helpers;
using TNTRestaurant_API.Models;

namespace TNTRestaurant_API.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetList();
        Task<int> InsertUpdate(CustomerModel customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyBDContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(MyBDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerModel>> GetList()
        {
            var data = await _context.Customers!.ToListAsync();
            return _mapper.Map<List<CustomerModel>>(data);
        }

        public async Task<int> InsertUpdate(CustomerModel customerModel)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerModel);

                if (customer.CustomerID == 0)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    _context.Customers.Update(customer);
                }

                await _context.SaveChangesAsync();
                return customer.CustomerID;
            }
            catch (Exception ex) {

                return 0;
            }           

        }
    }
}
