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
    public class DefaultActivityBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DefaultActivityBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DefaultActivityDTO>> GetDefaultActivities()
        {
            var defaultActivity =  await _unitOfWork.DefaultActivityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DefaultActivityDTO>>(defaultActivity);
        }

        public DefaultActivityDTO GetDefaultActivity(int defaultActivityId)
        {
            var defaultActivity =  _unitOfWork.DefaultActivityRepository.Get(x => x.Id == defaultActivityId);
            return _mapper.Map<DefaultActivityDTO>(defaultActivity);
        }

        public Task AddDefaultActivity(DefaultActivityDTO defaultActivity)
        {
            _unitOfWork.DefaultActivityRepository.Insert(_mapper.Map<DefaultActivity>(defaultActivity));
            return _unitOfWork.SaveAsync();
        }

        public Task UpdateDefaultActivity(DefaultActivityDTO defaultActivity)
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
