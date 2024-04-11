using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload;
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
            CreateMap<DefaultActivity, DefaultActivityDTO>();
            CreateMap<DefaultActivityDTO, DefaultActivity>();
            CreateMap<Construction, ConstructionResponseDTO>();
            CreateMap<ConstructionDTO, Construction>();
            CreateMap<ConstructionPhoto, ConstructionPhotoDTO>();
            CreateMap<ConstructionPhotoDTO, ConstructionPhoto>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Status, StatusDTO>();
            CreateMap<StatusDTO, Status>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityDTO, Activity>();
            CreateMap<UserLoginDTO, User>();
            
        }
    }
}
