
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Application.Mappers;


namespace Ecommerce.Application.Services.AdminServices
{
    public class AdminUserService : IAdminUserInterface
    {

        private readonly IUserRepository _IuserRepository;
        public AdminUserService(IUserRepository IuserRepository)
        {
            _IuserRepository = IuserRepository;
        }

        //Queries
        public async Task<(bool,string, List<UserDTO>?)> GetAllUsers()
        {
 
                List<UserDTO> ListUsersDTO = new List<UserDTO>();
                string message = string.Empty;
                var Response = await _IuserRepository.GetAllUsersAsync();

                if (Response.Item1 is false)
                {
                    message = "Nenhum usuário foi encontrado.";
                    return (false, message, null);
                }
                foreach (var u in Response.Item3)
                {
                    var userDTO = UserMapper.ToUserDTO(u);
                    ListUsersDTO.Add(userDTO);
                }
                return (true, message, ListUsersDTO);
        }

        public async Task<(bool, string, UserDTO?)> GetUserByEmail(string email)
        {
            string message = string.Empty;

            var Response = await _IuserRepository.GetUserByEmailAsync(email);
            if (Response.Item1 is false)
            {
                message = "Usuário não encontrado.";
                return (false, message, null);
            }

            var userDTO = UserMapper.ToUserDTO(Response.Item3);

            return (true, message, userDTO);
        }

        //Commands
        public async Task<(bool, string)> PutUserStatusToInactive(string email)
        {
            string message = string.Empty;
            var Response = await _IuserRepository.InativeUserByEmailAsync(email);

            if (Response.Item1 is false)
            {
                message = "Usuário não encontrado.";
                return (false, message);
            }
            message= "Usuário inativado com sucesso.";
            return (true, message);
        }

        public async Task<(bool, string)> PutUserStatusToActive(string email)
        {
            string message = string.Empty;
            var Response = await _IuserRepository.ActiveUserByEmailAsync(email);
            if (Response.Item1 is false)
            {
                message = "Usuário não encontrado.";
                return (false, message);
            }
            message = "Usuário ativado com sucesso.";
            return (true, message);
        }
    }
}
