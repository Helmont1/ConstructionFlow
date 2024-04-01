using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload;
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

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public CustomerDTO GetCustomer(Guid customerId)
        {
            var customer = _unitOfWork.CustomerRepository.Get(x => x.CustomerId == customerId);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public Task AddCustomer(CustomerDTO customer)
        {
            _unitOfWork.CustomerRepository.Insert(_mapper.Map<Customer>(customer));
            return _unitOfWork.SaveAsync();
        }

        public Task UpdateCustomer(CustomerDTO customer)
        {
            _unitOfWork.CustomerRepository.Update(_mapper.Map<Customer>(customer));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteCustomer(Guid customerId)
        {
            _unitOfWork.CustomerRepository.Delete(customerId);
            return _unitOfWork.SaveAsync();
        }
        

    }
}
