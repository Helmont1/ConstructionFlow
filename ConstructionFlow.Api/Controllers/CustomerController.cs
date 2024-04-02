using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
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
        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            return await _customerBusiness.GetCustomers();
        }

        [HttpGet("{customerId}")]
        public CustomerDTO GetCustomer(Guid customerId)
        {
            return _customerBusiness.GetCustomer(customerId);
        }

        [HttpPost]
        public Task AddCustomer(CustomerDTO customer)
        {
            return _customerBusiness.AddCustomer(customer);
        }

        [HttpPut]
        public Task UpdateCustomer(CustomerDTO customer)
        {
            return _customerBusiness.UpdateCustomer(customer);
        }

        [HttpDelete("{customerId}")]
        public Task DeleteCustomer(Guid customerId)
        {
            return _customerBusiness.DeleteCustomer(customerId);
        }
    }
}
