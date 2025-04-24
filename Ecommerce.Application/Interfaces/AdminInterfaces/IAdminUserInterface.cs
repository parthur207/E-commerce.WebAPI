using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Interfaces.AdminInterfaces
{
    public interface IAdminUserInterface
    {
        //Queries
        Task<(bool, string, List<UserDTO>?)> GetAllUsers();
        Task<(bool, string, UserDTO?)> GetUserByEmail(string email);

        //Commands
        Task<(bool, string)> PutUserStatusToInactive(string email);
        Task<(bool, string)> PutUserStatusToActive(string email);
    }
}
