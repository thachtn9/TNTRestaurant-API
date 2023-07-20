using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNTRestaurant_API.Models;
using TNTRestaurant_API.Services;

namespace TNTRestaurant_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> GetCustomers()
        {
            var customers = await _customerService.GetList();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateCustomer(CustomerModel customer)
        {
            await _customerService.InsertUpdate(customer);
            return Ok();
        }
    }
}
