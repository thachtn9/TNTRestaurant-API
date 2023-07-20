using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Repositories;

namespace TNTRestaurant_API.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetList();
        Task InsertUpdate(CustomerModel customer);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerModel>> GetList()
        {
            return await _customerRepository.GetList();
        }

        public async Task InsertUpdate(CustomerModel customer)
        {
            await _customerRepository.InsertUpdate(customer);
        }
    }
}
