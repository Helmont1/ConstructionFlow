using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class StatusController : ControllerBase
    {
        private readonly StatusBusiness _statusBusiness;

        public StatusController(StatusBusiness statusBusiness)
        {
            _statusBusiness = statusBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<StatusResponse>> GetStatuses()
        {
            return await _statusBusiness.GetStatuses();
        }

        [HttpGet("{statusName}")]
        public Task<StatusResponse> GetStatus(string statusName)
        {
            return _statusBusiness.GetStatus(statusName);
        }

        [HttpPost]
        public Task<StatusResponse> AddStatus(StatusRequest status)
        {
            return _statusBusiness.AddStatus(status);
        }

        [HttpPut]
        public Task UpdateStatus(StatusRequest status)
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
