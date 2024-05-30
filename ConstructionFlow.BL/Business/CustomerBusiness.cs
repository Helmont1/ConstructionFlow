using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using ConstructionFlow.Infrastructure.UnitOfWork;

namespace ConstructionFlow.BL.Business
{
    public class CustomerBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerResponse>> GetCustomers()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerResponse>>(customers);
        }

        public async Task<CustomerResponse> GetCustomer(int customerId)
        {
            var customer = await _unitOfWork.CustomerRepository.Get(x => x.Id == customerId);
            return _mapper.Map<CustomerResponse>(customer);
        }
        public async Task<CustomerResponse> GetCustomerByRegister(string customerRegister)
        {
            var customer = await _unitOfWork.CustomerRepository.Get(x => (x.CustomerCnpj == customerRegister) || (x.CustomerCpf == customerRegister));
            return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task<CustomerResponse> AddCustomer(CustomerRequest customer)
        {
            var response = await _unitOfWork.CustomerRepository.Insert(_mapper.Map<Customer>(customer));
            return _mapper.Map<CustomerResponse>(response);
        }

        public Task UpdateCustomer(CustomerRequest customer)
        {
            _unitOfWork.CustomerRepository.Update(_mapper.Map<Customer>(customer));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteCustomer(int customerId)
        {
            _unitOfWork.CustomerRepository.Delete(customerId);
            return _unitOfWork.SaveAsync();
        }
        

    }
}
