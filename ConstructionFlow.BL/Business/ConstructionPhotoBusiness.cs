using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload;
using ConstructionFlow.Infrastructure.UnitOfWork;

namespace ConstructionFlow.BL.Business
{
    public class ConstructionPhotoBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConstructionPhotoBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConstructionPhotoDTO>> GetConstructionPhotos()
        {
            var constructionPhotos = await _unitOfWork.ConstructionPhotoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConstructionPhotoDTO>>(constructionPhotos);
        }

        public ConstructionPhotoDTO GetConstructionPhoto(int constructionPhotoId)
        {
            var constructionPhoto = _unitOfWork.ConstructionPhotoRepository.Get(x => x.Id == constructionPhotoId);
            return _mapper.Map<ConstructionPhotoDTO>(constructionPhoto);
        }

        public Task AddConstructionPhoto(ConstructionPhotoDTO constructionPhoto)
        {
            _unitOfWork.ConstructionPhotoRepository.Insert(_mapper.Map<ConstructionPhoto>(constructionPhoto));
            return _unitOfWork.SaveAsync();
        }

        public Task UpdateConstructionPhoto(ConstructionPhotoDTO constructionPhoto)
        {
            _unitOfWork.ConstructionPhotoRepository.Update(_mapper.Map<ConstructionPhoto>(constructionPhoto));
            return _unitOfWork.SaveAsync();
        }

        public Task DeleteConstructionPhoto(int constructionPhotoId)
        {
            _unitOfWork.ConstructionPhotoRepository.Delete(constructionPhotoId);
            return _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ConstructionPhotoDTO>> GetConstructionPhotosByConstruction(int constructionId)
        {
            var constructionPhotos = await _unitOfWork.ConstructionPhotoRepository.GetAllAsync(x => x.ConstructionId == constructionId);
            return _mapper.Map<IEnumerable<ConstructionPhotoDTO>>(constructionPhotos);
        }
    }
}
