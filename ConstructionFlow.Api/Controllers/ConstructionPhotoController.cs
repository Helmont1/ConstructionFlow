using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ConstructionPhotoController
    {
        private readonly ConstructionPhotoBusiness _constructionPhotoBusiness;

        public ConstructionPhotoController(ConstructionPhotoBusiness constructionPhotoBusiness)
        {
            _constructionPhotoBusiness = constructionPhotoBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<ConstructionPhotoRequest>> GetConstructionPhotos()
        {
            return await _constructionPhotoBusiness.GetConstructionPhotos();
        }

        [HttpGet("{constructionPhotoId}")]
        public ConstructionPhotoRequest GetConstructionPhoto(int constructionPhotoId)
        {
            return _constructionPhotoBusiness.GetConstructionPhoto(constructionPhotoId);
        }

        [HttpPost]
        public Task AddConstructionPhoto(ConstructionPhotoRequest constructionPhoto)
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

        [HttpGet("{constructionPhotoId}/construction/{constructionId}")]
        public async Task<IEnumerable<ConstructionPhotoRequest>> GetConstructionPhotosByConstruction(int constructionId)
        {
            return await _constructionPhotoBusiness.GetConstructionPhotosByConstruction(constructionId);
        }
    
    }
}
