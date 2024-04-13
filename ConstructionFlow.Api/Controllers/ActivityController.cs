using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ActivityController: ControllerBase 
    {
        private readonly ActivityBusiness _activityBusiness;

        public ActivityController(ActivityBusiness activityBusiness)
        {
            _activityBusiness = activityBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityResponse>> GetActivities()
        {
            return await _activityBusiness.GetActivities();
        }

        [HttpGet("{activityId}")]

        public Task<ActivityResponse> GetActivity(int activityId)
        {
            return _activityBusiness.GetActivity(activityId);
        }

        [HttpGet("{activityId}/construction/{constructionId}")]

        public async Task<IEnumerable<ActivityRequest>> GetActivitiesByConstruction(int constructionId)
        {
            return await _activityBusiness.GetActivitiesByConstruction(constructionId);
        }

        [HttpPost]
        public Task AddActivity(ActivityRequest activity)
        {
            return _activityBusiness.AddActivity(activity);
        }

        [HttpPut]
        public Task UpdateActivity(ActivityRequest activity)
        {
            return _activityBusiness.UpdateActivity(activity);
        }

        [HttpDelete("{activityId}")]
        public Task DeleteActivity(int activityId)
        {
            return _activityBusiness.DeleteActivity(activityId);
        }
    }
}
