using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class UserController
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return await _userBusiness.GetUsers();
        }

        [HttpGet("{userId}")]
        public UserDTO GetUser(Guid userId)
        {
            return _userBusiness.GetUser(userId);
        }

        [HttpPost]
        public Task AddUser(UserLoginDTO user)
        {
            return _userBusiness.AddUser(user);
        }

        [HttpPut]
        public Task UpdateUser(UserDTO user)
        {
            return _userBusiness.UpdateUser(user);
        }

        [HttpDelete("{userId}")]
        public Task DeleteUser(Guid userId)
        {
            return _userBusiness.DeleteUser(userId);
        }

        [HttpGet("/CNPJ/{userCNPJ}")]
        public UserDTO GetUsersByCNPJ(string userCNPJ)
        {
            return _userBusiness.GetUsersByCNPJ(userCNPJ);
        }
    }
}
