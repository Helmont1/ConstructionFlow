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
    public class StatusBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatusRequest>> GetStatuses()
        {
            var status =  await _unitOfWork.StatusRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StatusRequest>>(status);
        }

        public StatusRequest GetStatus(string statusName)
        {
            var status =  _unitOfWork.StatusRepository.Get(x => x.StatusName == statusName);
            return _mapper.Map<StatusRequest>(status);
        }

        public Task AddStatus(StatusRequest status)
        {
            _unitOfWork.StatusRepository.Insert(_mapper.Map<Status>(status));
            return _unitOfWork.SaveAsync();
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
