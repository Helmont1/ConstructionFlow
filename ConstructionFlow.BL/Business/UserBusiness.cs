using AutoMapper;
using ConstructionFlow.Domain.Model;
using ConstructionFlow.Domain.Payload.Request;
using ConstructionFlow.Domain.Payload.Response;
using ConstructionFlow.Domain.Payload.Util;
using ConstructionFlow.Infrastructure.UnitOfWork;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ConstructionFlow.BL.Business
{
    public class UserBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public IConfiguration _configuration;

        public UserBusiness(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            var users = await unitOfWork.UserRepository.GetAllAsync();
            return mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<UserResponse> GetUser(int userId)
        {
            var user = await unitOfWork.UserRepository.Get(x => x.Id == userId);
            return mapper.Map<UserResponse>(user);
        }

        public Task AddUser(CreateUserDto user)
        {
            byte[] data = Encoding.ASCII.GetBytes(user.UserPassword);
            data = System.Security.Cryptography.SHA256.HashData(data);
            user.UserPassword = Encoding.ASCII.GetString(data);

            unitOfWork.UserRepository.Insert(mapper.Map<User>(user));
            return unitOfWork.SaveAsync();
        }

        public Task UpdateUser(UserRequest user)
        {
            unitOfWork.UserRepository.Update(mapper.Map<User>(user));
            return unitOfWork.SaveAsync();
        }

        public Task DeleteUser(int userId)
        {
            unitOfWork.UserRepository.Delete(userId);
            return unitOfWork.SaveAsync();
        }

        public async Task<UserResponse> GetUsersByCNPJ(string userCNPJ)
        {
            var user = await unitOfWork.UserRepository.Get(x => x.UserCnpj == userCNPJ);
            return mapper.Map<UserResponse>(user);
        }

        public async Task<string> Login(LoginDto user)
        {

            byte[] data = Encoding.ASCII.GetBytes(user.UserPassword);
            data = System.Security.Cryptography.SHA256.HashData(data);
            user.UserPassword = Encoding.ASCII.GetString(data);

            var userLogin = await unitOfWork.UserRepository.Get(x => x.UserEmail == user.UserEmail && x.UserPassword == user.UserPassword);

            if (userLogin is not null)
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, userLogin.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserCnpj", userLogin.UserCnpj),
                        new Claim("UserName", userLogin.UserName),
                        new Claim("Email", userLogin.UserEmail)
                    };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signIn);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            throw new Exception("UserName or Password is incorrect.");
        }
    }
}
