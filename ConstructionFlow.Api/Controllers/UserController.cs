using ConstructionFlow.BL.Business;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using ConstructionFlow.Domain.Payload.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ConstructionFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            return await _userBusiness.GetUsers();
        }


        [HttpGet("{userId}")]
        public Task<UserResponse> GetUser(int userId)
        {
            return _userBusiness.GetUser(userId);
        }

        [HttpGet("/CNPJ/{userCNPJ}")]
        public Task<UserResponse> GetUsersByCNPJ(string userCNPJ)
        {
            return _userBusiness.GetUsersByCNPJ(userCNPJ);
        }

        [HttpPost]
        public Task AddUser(CreateUserDto user)
        {
            return _userBusiness.AddUser(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult>Login(LoginDto login)
        {
            try
            {
                var result = await _userBusiness.Login(login);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(Task.FromResult(e.Message));
            }
        }

        [HttpPut]
        public Task UpdateUser(UserRequest user)
        {
            return _userBusiness.UpdateUser(user);
        }

        [HttpDelete("{userId}")]
        public Task DeleteUser(int userId)
        {
            return _userBusiness.DeleteUser(userId);
        }
    }
}
