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
    public class StatusBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatusResponse>> GetStatuses()
        {
            var status =  await _unitOfWork.StatusRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StatusResponse>>(status);
        }

        public async Task<StatusResponse> GetStatus(string statusName)
        {
            var status =  await _unitOfWork.StatusRepository.Get(x => x.StatusName == statusName);
            return _mapper.Map<StatusResponse>(status);
        }

        public async Task<StatusResponse> AddStatus(StatusRequest status)
        {
            var response = await _unitOfWork.StatusRepository.Insert(_mapper.Map<Status>(status));
            return _mapper.Map<StatusResponse>(response);
        }

        public Task UpdateStatus(StatusRequest status)
        {
            _unitOfWork.StatusRepository.Update(_mapper.Map<Status>(status));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteStatus(int statusId)
        {
            _unitOfWork.StatusRepository.Delete(statusId);
            return _unitOfWork.SaveAsync();
        }
    }
}
