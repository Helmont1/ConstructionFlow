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
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<ConstructionResponse>> GetConstructions()
        {
            var construction = await _unitOfWork.ConstructionRepository.GetAllAsync(
                include: query => query.Include(x => x.Customer)
                                        .Include(c => c.User)
                                        .Include(c => c.Status)
            );
            return _mapper.Map<IEnumerable<ConstructionResponse>>(construction);
        }

        public async Task<ConstructionResponse> GetConstruction(int constructionId)
        {
            var construction = await _unitOfWork.ConstructionRepository.Get(
                x => x.Id == constructionId,
                include: query => query.Include(x => x.Customer)
                                        .Include(c => c.User)
                                        .Include(c => c.Status)
            );
            construction.Search = new Guid().ToString();
            return _mapper.Map<ConstructionResponse>(construction);
        }

        public async Task<ConstructionResponse> AddConstruction(ConstructionRequest construction)
        {
            var response = await _unitOfWork.ConstructionRepository.Insert(_mapper.Map<Construction>(construction));
            return _mapper.Map<ConstructionResponse>(response);
        }

        public Task UpdateConstruction(ConstructionRequest construction)
        {
            _unitOfWork.ConstructionRepository.Update(_mapper.Map<Construction>(construction));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteConstruction(int constructionId)
        {
            _unitOfWork.ConstructionRepository.Delete(constructionId);
            return _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ConstructionResponse>> GetConstructionsByUser(int userId)
        {
            var constructions = await _unitOfWork.ConstructionRepository.GetAllAsync(
                x => x.UserId == userId,
                include: query => query.Include(x => x.Customer)
                                            .Include(c => c.User)
                                            .Include(c => c.Status)
            );
            return _mapper.Map<IEnumerable<ConstructionResponse>>(constructions);
        }

        public async Task<IEnumerable<ConstructionResponse>> GetConstructionsByCustomer(int customerId)
        {
            var constructions = await _unitOfWork.ConstructionRepository.GetAllAsync(
                x => x.CustomerId == customerId,
                include: query => query.Include(x => x.Customer)
                                        .Include(c => c.User)
                                        .Include(c => c.Status)
            );
            return _mapper.Map<IEnumerable<ConstructionResponse>>(constructions);
        }
    }
}
