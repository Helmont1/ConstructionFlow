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
    public class ActivityBusiness
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ActivityRequestDTO>> GetActivities()
        {
            var activities = await _unitOfWork.ActivityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActivityRequestDTO>>(activities);
        }

        public ActivityRequestDTO GetActivity(int activityId)
        {
            var activity = _unitOfWork.ActivityRepository.Get(x => x.Id == activityId);
            return _mapper.Map<ActivityRequestDTO>(activity);
        }

        public Task AddActivity(ActivityRequestDTO activity)
        {
            _unitOfWork.ActivityRepository.Insert(_mapper.Map<Activity>(activity));
            return _unitOfWork.SaveAsync();
        }

        public Task UpdateActivity(ActivityRequestDTO activity)
        {
            _unitOfWork.ActivityRepository.Update(_mapper.Map<Activity>(activity));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteActivity(int activityId)
        {
            _unitOfWork.ActivityRepository.Delete(activityId);
            return _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ActivityRequestDTO>> GetActivitiesByConstruction(int constructionId)
        {
            var activities = await _unitOfWork.ActivityRepository.GetAllAsync(x => x.ConstructionId == constructionId);
            return _mapper.Map<IEnumerable<ActivityRequestDTO>>(activities);
            
        }
    }
}
