using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CustomerController
    {
        private readonly CustomerBusiness _customerBusiness;

        public CustomerController(CustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerRequest>> GetCustomers()
        {
            return await _customerBusiness.GetCustomers();
        }

        [HttpGet("{customerId}")]
        public CustomerRequest GetCustomer(int customerId)
        {
            return _customerBusiness.GetCustomer(customerId);
        }

        [HttpGet("register/{customerRegisterNumber}")]
        public CustomerRequest GetCustomerByRegisterNumber(string customerRegisterNumber)
        {
            return _customerBusiness.GetCustomerByRegister(customerRegisterNumber);
        }

        [HttpPost]
        public Task AddCustomer(CustomerRequest customer)
        {
            return _customerBusiness.AddCustomer(customer);
        }

        [HttpPut]
        public Task UpdateCustomer(CustomerRequest customer)
        {
            return _customerBusiness.UpdateCustomer(customer);
        }

        [HttpDelete("{customerId}")]
        public Task DeleteCustomer(int customerId)
        {
            return _customerBusiness.DeleteCustomer(customerId);
        }
    }
}
