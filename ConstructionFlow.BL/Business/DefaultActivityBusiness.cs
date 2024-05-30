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
    public class DefaultActivityBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DefaultActivityBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DefaultActivityResponse>> GetDefaultActivities()
        {
            var defaultActivity =  await _unitOfWork.DefaultActivityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DefaultActivityResponse>>(defaultActivity);
        }

        public async Task<DefaultActivityResponse> GetDefaultActivity(int defaultActivityId)
        {
            var defaultActivity = await _unitOfWork.DefaultActivityRepository.Get(x => x.Id == defaultActivityId);
            return _mapper.Map<DefaultActivityResponse>(defaultActivity);
        }

        public async Task<DefaultActivityResponse> AddDefaultActivity(DefaultActivityRequest defaultActivity)
        {
            var response = await _unitOfWork.DefaultActivityRepository.Insert(_mapper.Map<DefaultActivity>(defaultActivity));
            return _mapper.Map<DefaultActivityResponse>(response);
        }

        public Task UpdateDefaultActivity(DefaultActivityRequest defaultActivity)
        {
            _unitOfWork.DefaultActivityRepository.Update(_mapper.Map<DefaultActivity>(defaultActivity));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteDefaultActivity(int defaultActivityId)
        {
            _unitOfWork.DefaultActivityRepository.Delete(defaultActivityId);
            return _unitOfWork.SaveAsync();
        }

    }
}
