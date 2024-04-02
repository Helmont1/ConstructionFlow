using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class DefaultActivityController
    {
        private readonly DefaultActivityBusiness _defaultActivityBusiness;

        public DefaultActivityController(DefaultActivityBusiness defaultActivityBusiness)
        {
            _defaultActivityBusiness = defaultActivityBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<DefaultActivityDTO>> GetDefaultActivities()
        {
            return await _defaultActivityBusiness.GetDefaultActivities();
        }

        [HttpGet("{defaultActivityId}")]
        public DefaultActivityDTO GetDefaultActivity(Guid defaultActivityId)
        {
            return _defaultActivityBusiness.GetDefaultActivity(defaultActivityId);
        }

        [HttpPost]
        public Task AddDefaultActivity(DefaultActivityDTO defaultActivity)
        {
            return _defaultActivityBusiness.AddDefaultActivity(defaultActivity);
        }

        [HttpPut]
        public Task UpdateDefaultActivity(DefaultActivityDTO defaultActivity)
        {
            return _defaultActivityBusiness.UpdateDefaultActivity(defaultActivity);
        }

        [HttpDelete("{defaultActivityId}")]
        public Task DeleteDefaultActivity(Guid defaultActivityId)
        {
            return _defaultActivityBusiness.DeleteDefaultActivity(defaultActivityId);
        }
    }
}
