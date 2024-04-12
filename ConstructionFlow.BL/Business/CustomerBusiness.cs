using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload.Request;
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

        public async Task<IEnumerable<CustomerRequestDTO>> GetCustomers()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerRequestDTO>>(customers);
        }

        public CustomerRequestDTO GetCustomer(int customerId)
        {
            var customer = _unitOfWork.CustomerRepository.Get(x => x.Id == customerId);
            return _mapper.Map<CustomerRequestDTO>(customer);
        }
        public CustomerRequestDTO GetCustomerByRegister(string customerRegister)
        {
            var customer = _unitOfWork.CustomerRepository.Get(x => (x.CustomerCnpj == customerRegister) || (x.CustomerCpf == customerRegister));
            return _mapper.Map<CustomerRequestDTO>(customer);
        }

        public Task AddCustomer(CustomerRequestDTO customer)
        {
            _unitOfWork.CustomerRepository.Insert(_mapper.Map<Customer>(customer));
            return _unitOfWork.SaveAsync();
        }

        public Task UpdateCustomer(CustomerRequestDTO customer)
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
