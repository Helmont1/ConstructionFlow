﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using ConstructionFlow.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<ActivityResponse>> GetActivities()
        {
            var activities = await _unitOfWork.ActivityRepository.GetAllAsync(
                include: query => query.Include(x => x.Construction).Include(x => x.DefaultActivity).Include(x => x.Status)
            );
            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<ActivityResponse> GetActivity(int activityId)
        {
            var activity = await _unitOfWork.ActivityRepository.Get(
                x => x.Id == activityId,
                include: query => query.Include(x => x.Construction).Include(x => x.DefaultActivity).Include(x => x.Status)
            );
            return _mapper.Map<ActivityResponse>(activity);
        }

        public async Task<ActivityResponse> AddActivity(ActivityRequest activity)
        {
            if (activity.Order == null)
            {
                var maxOrder = await _unitOfWork.ActivityRepository.GetAllAsync(
                    x => x.ConstructionId == activity.ConstructionId
                );
                maxOrder = maxOrder.OrderByDescending(x => x.Order).ToList();
                activity.Order = maxOrder.Count > 0 ? maxOrder.First().Order + 1 : 1;
            }
            var response = await _unitOfWork.ActivityRepository.Insert(_mapper.Map<Activity>(activity));
            return _mapper.Map<ActivityResponse>(response);
        }

        public Task UpdateActivity(ActivityRequest activity)
        {
            _unitOfWork.ActivityRepository.Update(_mapper.Map<Activity>(activity));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteActivity(int activityId)
        {
            _unitOfWork.ActivityRepository.Delete(activityId);
            return _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ActivityResponse>> GetActivitiesByConstruction(int constructionId)
        {
            var activities = await _unitOfWork.ActivityRepository.GetAllAsync(
                x => x.ConstructionId == constructionId,
                include: query => query.Include(x => x.Construction).Include(x => x.DefaultActivity).Include(x => x.Status)
                );
            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }
    }
}
