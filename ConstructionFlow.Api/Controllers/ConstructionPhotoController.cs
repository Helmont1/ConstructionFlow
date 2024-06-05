using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ConstructionPhotoController : ControllerBase
    {
        private readonly ConstructionPhotoBusiness _constructionPhotoBusiness;

        public ConstructionPhotoController(ConstructionPhotoBusiness constructionPhotoBusiness)
        {
            _constructionPhotoBusiness = constructionPhotoBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<ConstructionPhotoResponse>> GetConstructionPhotos()
        {
            return await _constructionPhotoBusiness.GetConstructionPhotos();
        }

        [HttpGet("{constructionPhotoId}")]
        public Task<ConstructionPhotoResponse> GetConstructionPhoto(int constructionPhotoId)
        {
            return _constructionPhotoBusiness.GetConstructionPhoto(constructionPhotoId);
        }

        [HttpGet("construction/{constructionId}")]
        public async Task<ConstructionPhotoResponse> GetConstructionPhotoByConstruction(int constructionId)
        {
            return await _constructionPhotoBusiness.GetConstructionPhotoByConstruction(constructionId);
        }

        [HttpPost]
        public Task<ConstructionPhotoResponse> AddConstructionPhoto(ConstructionPhotoRequest constructionPhoto)
        {
            return _constructionPhotoBusiness.AddConstructionPhoto(constructionPhoto);
        }

        [HttpPut]
        public Task UpdateConstructionPhoto(ConstructionPhotoRequest constructionPhoto)
        {
            return _constructionPhotoBusiness.UpdateConstructionPhoto(constructionPhoto);
        }

        [HttpDelete("{constructionPhotoId}")]
        public Task DeleteConstructionPhoto(int constructionPhotoId)
        {
            return _constructionPhotoBusiness.DeleteConstructionPhoto(constructionPhotoId);
        }
    
    }
}
