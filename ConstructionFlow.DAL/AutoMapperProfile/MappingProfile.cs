using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.DAL.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DefaultActivity, DefaultActivityRequestDTO>();
            CreateMap<DefaultActivityRequestDTO, DefaultActivity>();
            CreateMap<Construction, ConstructionResponseDTO>();
            CreateMap<ConstructionRequestDTO, Construction>();
            CreateMap<ConstructionPhoto, ConstructionPhotoRequestDTO>();
            CreateMap<ConstructionPhotoRequestDTO, ConstructionPhoto>();
            CreateMap<Customer, CustomerRequestDTO>();
            CreateMap<CustomerRequestDTO, Customer>();
            CreateMap<Status, StatusRequestDTO>();
            CreateMap<StatusRequestDTO, Status>();
            CreateMap<User, UserRequestDTO>();
            CreateMap<UserRequestDTO, User>();
            CreateMap<Activity, ActivityRequestDTO>();
            CreateMap<ActivityRequestDTO, Activity>();
            CreateMap<UserLoginDTO, User>();
            
        }
    }
}
