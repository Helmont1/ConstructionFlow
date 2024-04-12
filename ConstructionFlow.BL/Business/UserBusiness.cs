using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Util;
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

        public UserBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserRequestDTO>> GetUsers()
        {
            var users = await unitOfWork.UserRepository.GetAllAsync();
            return mapper.Map<IEnumerable<UserRequestDTO>>(users);
        }

        public UserRequestDTO GetUser(int userId)
        {
            var user = unitOfWork.UserRepository.Get(x => x.Id == userId);
            return mapper.Map<UserRequestDTO>(user);
        }
        
        public Task AddUser(UserLoginDTO user)
        {
            unitOfWork.UserRepository.Insert(mapper.Map<User>(user));
            return unitOfWork.SaveAsync();
        }

        public Task UpdateUser(UserRequestDTO user)
        {
            unitOfWork.UserRepository.Update(mapper.Map<User>(user));
            return unitOfWork.SaveAsync();
        }

        public Task DeleteUser(int userId)
        {
            unitOfWork.UserRepository.Delete(userId);
            return unitOfWork.SaveAsync();
        }

        public UserRequestDTO GetUsersByCNPJ(string userCNPJ)
        {
            var user = unitOfWork.UserRepository.Get(x => x.UserCnpj == userCNPJ);
            return mapper.Map<UserRequestDTO>(user);
        }
    }
}
