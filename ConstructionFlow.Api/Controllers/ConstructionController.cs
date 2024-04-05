using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{

    [ApiController]
    [Route("[controller]/")]
    public class ConstructionController
    {
        private readonly ConstructionBusiness _constructionBusiness;

        public ConstructionController(ConstructionBusiness constructionBusiness)
        {
            _constructionBusiness = constructionBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<ConstructionDTO>> GetConstructions()
        {
            return await _constructionBusiness.GetConstructions();
        }

        [HttpGet("{constructionId}")]
        public ConstructionDTO GetConstruction(int constructionId)
        {
            return _constructionBusiness.GetConstruction(constructionId);
        }

        [HttpPost]
        public Task AddConstruction(ConstructionDTO construction)
        {
            return _constructionBusiness.AddConstruction(construction);
        }

        [HttpPut]
        public Task UpdateConstruction(ConstructionDTO construction)
        {
            return _constructionBusiness.UpdateConstruction(construction);
        }

        [HttpDelete("{constructionId}")]
        public Task DeleteConstruction(int constructionId)
        {
            return _constructionBusiness.DeleteConstruction(constructionId);
        }

        [HttpGet("{constructionId}/user/{userId}")]
        public async Task<IEnumerable<ConstructionDTO>> GetConstructionsByUser(int userId)
        {
            return await _constructionBusiness.GetConstructionsByUser(userId);
        }

        [HttpGet("{constructionId}/customer/{customerId}")]
        public async Task<IEnumerable<ConstructionDTO>> GetConstructionsByCustomer(int customerId)
        {
            return await _constructionBusiness.GetConstructionsByCustomer(customerId);
        }

    }
}
