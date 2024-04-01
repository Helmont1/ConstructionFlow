using AutoMapper;
using ConstructionFlow.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.BL.Business
{
    public class UserBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
    }
}
