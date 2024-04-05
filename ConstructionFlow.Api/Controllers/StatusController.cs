using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
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

        [HttpGet("{statusName}")]
        public StatusDTO GetStatus(string statusName)
        {
            return _statusBusiness.GetStatus(statusName);
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
        public Task DeleteStatus(int statusId)
        {
            return _statusBusiness.DeleteStatus(statusId);
        }
    }
}
