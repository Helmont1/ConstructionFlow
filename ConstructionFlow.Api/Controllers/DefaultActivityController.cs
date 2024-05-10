using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class DefaultActivityController : ControllerBase
    {
        private readonly DefaultActivityBusiness _defaultActivityBusiness;

        public DefaultActivityController(DefaultActivityBusiness defaultActivityBusiness)
        {
            _defaultActivityBusiness = defaultActivityBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<DefaultActivityResponse>> GetDefaultActivities()
        {
            return await _defaultActivityBusiness.GetDefaultActivities();
        }

        [HttpGet("{defaultActivityId}")]
        public Task<DefaultActivityResponse> GetDefaultActivity(int defaultActivityId)
        {
            return _defaultActivityBusiness.GetDefaultActivity(defaultActivityId);
        }

        [HttpPost]
        public Task AddDefaultActivity(DefaultActivityRequest defaultActivity)
        {
            return _defaultActivityBusiness.AddDefaultActivity(defaultActivity);
        }

        [HttpPut]
        public Task UpdateDefaultActivity(DefaultActivityRequest defaultActivity)
        {
            return _defaultActivityBusiness.UpdateDefaultActivity(defaultActivity);
        }

        [HttpDelete("{defaultActivityId}")]
        public Task DeleteDefaultActivity(int defaultActivityId)
        {
            return _defaultActivityBusiness.DeleteDefaultActivity(defaultActivityId);
        }
    }
}
