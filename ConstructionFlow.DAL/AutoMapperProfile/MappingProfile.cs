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

            CreateMap<>(Activity, );
        }
    }
}
