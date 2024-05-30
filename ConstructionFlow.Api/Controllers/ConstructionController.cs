using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
using ConstructionFlow.Domain.Payload.Request;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{

    [ApiController]
    [Route("[controller]/")]
    public class ConstructionController : ControllerBase
    {
        private readonly ConstructionBusiness _constructionBusiness;

        public ConstructionController(ConstructionBusiness constructionBusiness)
        {
            _constructionBusiness = constructionBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<ConstructionResponse>> GetConstructions()
        {
            return await _constructionBusiness.GetConstructions();
        }

        [HttpGet("{constructionId}")]
        public Task<ConstructionResponse> GetConstruction(int constructionId)
        {
            return _constructionBusiness.GetConstruction(constructionId);
        }

        [HttpGet("users/{userId}")]
        public async Task<IEnumerable<ConstructionResponse>> GetConstructionsByUser(int userId)
        {
            return await _constructionBusiness.GetConstructionsByUser(userId);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IEnumerable<ConstructionResponse>> GetConstructionsByCustomer(int customerId)
        {
            return await _constructionBusiness.GetConstructionsByCustomer(customerId);
        }

        [HttpPost]
        public Task<ConstructionResponse> AddConstruction(ConstructionRequest construction)
        {
            return _constructionBusiness.AddConstruction(construction);
        }

        [HttpPut]
        public Task UpdateConstruction(ConstructionRequest construction)
        {
            return _constructionBusiness.UpdateConstruction(construction);
        }

        [HttpDelete("{constructionId}")]
        public Task DeleteConstruction(int constructionId)
        {
            return _constructionBusiness.DeleteConstruction(constructionId);
        }
    }
}
