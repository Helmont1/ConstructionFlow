using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
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
        public async Task<IEnumerable<ConstructionPhotoDTO>> GetConstructionPhotos()
        {
            return await _constructionPhotoBusiness.GetConstructionPhotos();
        }

        [HttpGet("{constructionPhotoId}")]
        public ConstructionPhotoDTO GetConstructionPhoto(Guid constructionPhotoId)
        {
            return _constructionPhotoBusiness.GetConstructionPhoto(constructionPhotoId);
        }

        [HttpPost]
        public Task AddConstructionPhoto(ConstructionPhotoDTO constructionPhoto)
        {
            return _constructionPhotoBusiness.AddConstructionPhoto(constructionPhoto);
        }

        [HttpPut]
        public Task UpdateConstructionPhoto(ConstructionPhotoDTO constructionPhoto)
        {
            return _constructionPhotoBusiness.UpdateConstructionPhoto(constructionPhoto);
        }

        [HttpDelete("{constructionPhotoId}")]
        public Task DeleteConstructionPhoto(Guid constructionPhotoId)
        {
            return _constructionPhotoBusiness.DeleteConstructionPhoto(constructionPhotoId);
        }

        [HttpGet("{constructionPhotoId}/construction/{constructionId}")]
        public async Task<IEnumerable<ConstructionPhotoDTO>> GetConstructionPhotosByConstruction(Guid constructionId)
        {
            return await _constructionPhotoBusiness.GetConstructionPhotosByConstruction(constructionId);
        }
    
    }
}
