using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Application.Mappers;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using System.Runtime.CompilerServices;

namespace Ecommerce.Application.Services.CommomServices
{
    public class UserService : IUserInterface
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool, string)> AddUser(CreateUserModel model)
        {
            string message = string.Empty;

            var UserMapped=UserMapper.ToCreateUserEntity(model);

            var Response = await _userRepository.AddUserAsync(UserMapped);

            if(Response.Item1 is false)
            {
                return (false, Response.Item2);
            }

            return (true, Response.Item2);
        }


        /*public Task<(bool, string)> PutPassword(UpdateUserPasswordModel model, int UserId)
        {
            throw new NotImplementedException();
        }*/


        public Task<(bool, string)> PutUserData(UpdateUserDataModel model, int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task <(bool, UserDataTokenDTO?)> GetDataUserByEmail(string email)
        {
            var Response= await _userRepository.GetUserByEmailAsync(email);

            if (Response.Item1 is false)
            {
                return (false, null);
            }

            var UserDataMappedDTO = UserMapper.ToUserTokenDTO(Response.Item3);

            return (true, UserDataMappedDTO);
        }

        public async Task<(bool, string)> LoginUser(UserLoginModel model) 
        {
            string message = string.Empty;
            var UserMapped = UserMapper.ToUserLoginEntity(model);
            var Response = await _userRepository.LoginUserAsync(UserMapped);
            if (Response.Item1 is false)
            {
                return (false, Response.Item2);
            }
            return (true, Response.Item2);
        }
    }
}
