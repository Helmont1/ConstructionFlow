using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
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
        public async Task<IEnumerable<StatusRequestDTO>> GetStatuses()
        {
            return await _statusBusiness.GetStatuses();
        }

        [HttpGet("{statusName}")]
        public StatusRequestDTO GetStatus(string statusName)
        {
            return _statusBusiness.GetStatus(statusName);
        }

        [HttpPost]
        public Task AddStatus(StatusRequestDTO status)
        {
            return _statusBusiness.AddStatus(status);
        }

        [HttpPut]
        public Task UpdateStatus(StatusRequestDTO status)
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
