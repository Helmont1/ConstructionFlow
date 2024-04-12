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
        public async Task<IEnumerable<ConstructionPhotoRequestDTO>> GetConstructionPhotos()
        {
            return await _constructionPhotoBusiness.GetConstructionPhotos();
        }

        [HttpGet("{constructionPhotoId}")]
        public ConstructionPhotoRequestDTO GetConstructionPhoto(int constructionPhotoId)
        {
            return _constructionPhotoBusiness.GetConstructionPhoto(constructionPhotoId);
        }

        [HttpPost]
        public Task AddConstructionPhoto(ConstructionPhotoRequestDTO constructionPhoto)
        {
            return _constructionPhotoBusiness.AddConstructionPhoto(constructionPhoto);
        }

        [HttpPut]
        public Task UpdateConstructionPhoto(ConstructionPhotoRequestDTO constructionPhoto)
        {
            return _constructionPhotoBusiness.UpdateConstructionPhoto(constructionPhoto);
        }

        [HttpDelete("{constructionPhotoId}")]
        public Task DeleteConstructionPhoto(int constructionPhotoId)
        {
            return _constructionPhotoBusiness.DeleteConstructionPhoto(constructionPhotoId);
        }

        [HttpGet("{constructionPhotoId}/construction/{constructionId}")]
        public async Task<IEnumerable<ConstructionPhotoRequestDTO>> GetConstructionPhotosByConstruction(int constructionId)
        {
            return await _constructionPhotoBusiness.GetConstructionPhotosByConstruction(constructionId);
        }
    
    }
}
