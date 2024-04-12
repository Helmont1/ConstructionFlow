using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload;
using ConstructionFlow.Domain.Payload.Request;
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

        public async Task<IEnumerable<ConstructionResponseDTO>> GetConstructions()
        {
            var construction =  await _unitOfWork.ConstructionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConstructionResponseDTO>>(construction);
        }

        public ConstructionResponseDTO GetConstruction(int constructionId)
        {
            var construction =  _unitOfWork.ConstructionRepository.Get(x => x.Id == constructionId);
            return _mapper.Map<ConstructionResponseDTO>(construction);
        }

        public Task AddConstruction(ConstructionRequestDTO construction)
        {
            _unitOfWork.ConstructionRepository.Insert(_mapper.Map<Construction>(construction));
            return _unitOfWork.SaveAsync();
        }

        public Task UpdateConstruction(ConstructionRequestDTO construction)
        {
            _unitOfWork.ConstructionRepository.Update(_mapper.Map<Construction>(construction));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteConstruction(int constructionId)
        {
            _unitOfWork.ConstructionRepository.Delete(constructionId);
            return _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ConstructionResponseDTO>> GetConstructionsByUser(int userId)
        {
            var constructions = await _unitOfWork.ConstructionRepository.GetAllAsync(x => x.UserId == userId);
            return _mapper.Map<IEnumerable<ConstructionResponseDTO>>(constructions);
        }

        public async Task<IEnumerable<ConstructionResponseDTO>> GetConstructionsByCustomer(int customerId)
        {
            var constructions = await _unitOfWork.ConstructionRepository.GetAllAsync(x => x.CustomerId == customerId);
            return _mapper.Map<IEnumerable<ConstructionResponseDTO>>(constructions);
        }
    }
}
