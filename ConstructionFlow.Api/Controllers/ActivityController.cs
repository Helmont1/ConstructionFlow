using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
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
        public async Task<IEnumerable<ActivityRequestDTO>> GetActivities()
        {
            return await _activityBusiness.GetActivities();
        }

        [HttpGet("{activityId}")]

        public ActivityRequestDTO GetActivity(int activityId)
        {
            return _activityBusiness.GetActivity(activityId);
        }

        [HttpPost]
        public Task AddActivity(ActivityRequestDTO activity)
        {
            return _activityBusiness.AddActivity(activity);
        }

        [HttpPut]
        public Task UpdateActivity(ActivityRequestDTO activity)
        {
            return _activityBusiness.UpdateActivity(activity);
        }

        [HttpDelete("{activityId}")]
        public Task DeleteActivity(int activityId)
        {
            return _activityBusiness.DeleteActivity(activityId);
        }

        [HttpGet("{activityId}/construction/{constructionId}")]

        public async Task<IEnumerable<ActivityRequestDTO>> GetActivitiesByConstruction(int constructionId)
        {
            return await _activityBusiness.GetActivitiesByConstruction(constructionId);
        }
    }
}
