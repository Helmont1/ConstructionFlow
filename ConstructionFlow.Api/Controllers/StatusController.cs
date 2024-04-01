using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/status/")]
    public class StatusController
    {
        private readonly StatusBusiness _statusBusiness;

        public StatusController(StatusBusiness statusBusiness)
        {
            _statusBusiness = statusBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<StatusDTO>> GetStatuses()
        {
            return await _statusBusiness.GetStatuses();
        }

        [HttpGet("{statusId}")]
        public StatusDTO GetStatus(Guid statusId)
        {
            return _statusBusiness.GetStatus(statusId);
        }

        [HttpPost]
        public Task AddStatus(StatusDTO status)
        {
            return _statusBusiness.AddStatus(status);
        }

        [HttpPut]
        public Task UpdateStatus(StatusDTO status)
        {
            return _statusBusiness.UpdateStatus(status);
        }

        [HttpDelete("{statusId}")]
        public Task DeleteStatus(Guid statusId)
        {
            return _statusBusiness.DeleteStatus(statusId);
        }
    }
}
