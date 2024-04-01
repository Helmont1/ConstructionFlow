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
    public class ConstructionBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConstructionBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConstructionDTO>> GetConstructions()
        {
            var construction =  await _unitOfWork.ConstructionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConstructionDTO>>(construction);
        }

        public ConstructionDTO GetConstruction(Guid constructionId)
        {
            var construction =  _unitOfWork.ConstructionRepository.Get(x => x.ConstructionId == constructionId);
            return _mapper.Map<ConstructionDTO>(construction);
        }

        public Task AddConstruction(ConstructionDTO construction)
        {
            _unitOfWork.ConstructionRepository.Insert(_mapper.Map<Construction>(construction));
            return _unitOfWork.SaveAsync();
        }

        public Task UpdateConstruction(ConstructionDTO construction)
        {
            _unitOfWork.ConstructionRepository.Update(_mapper.Map<Construction>(construction));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteConstruction(Guid constructionId)
        {
            _unitOfWork.ConstructionRepository.Delete(constructionId);
            return _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ConstructionDTO>> GetConstructionsByUser(Guid userId)
        {
            var constructions = await _unitOfWork.ConstructionRepository.GetAllAsync(x => x.User.UserId == userId);
            return _mapper.Map<IEnumerable<ConstructionDTO>>(constructions);
        }

        public async Task<IEnumerable<ConstructionDTO>> GetConstructionsByCustomer(Guid customerId)
        {
            var constructions = await _unitOfWork.ConstructionRepository.GetAllAsync(x => x.Customer.CustomerId == customerId);
            return _mapper.Map<IEnumerable<ConstructionDTO>>(constructions);
        }
    }
}
