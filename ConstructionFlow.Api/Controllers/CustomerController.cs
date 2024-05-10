using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerBusiness _customerBusiness;

        public CustomerController(CustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerResponse>> GetCustomers()
        {
            return await _customerBusiness.GetCustomers();
        }

        [HttpGet("{customerId}")]
        public Task<CustomerResponse> GetCustomer(int customerId)
        {
            return _customerBusiness.GetCustomer(customerId);
        }

        [HttpGet("register/{customerRegisterNumber}")]
        public Task<CustomerResponse> GetCustomerByRegisterNumber(string customerRegisterNumber)
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
