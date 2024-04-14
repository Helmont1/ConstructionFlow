using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using ConstructionFlow.Domain.Payload.Util;

namespace ConstructionFlow.DAL.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DefaultActivity, DefaultActivityResponse>();
            CreateMap<DefaultActivityRequest, DefaultActivity>();

            CreateMap<Construction, ConstructionResponse>();
            CreateMap<ConstructionRequest, Construction>();

            CreateMap<ConstructionPhoto, ConstructionPhotoResponse>();
            CreateMap<ConstructionPhotoRequest, ConstructionPhoto>();

            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerRequest, Customer>();
            
            CreateMap<Status, StatusResponse>();
            CreateMap<StatusRequest, Status>();

            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<CreateUserDto, User>();

            CreateMap<Activity, ActivityResponse>();
            CreateMap<ActivityRequest, Activity>();
        }
    }
}
