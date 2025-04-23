using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminUserInterface
    {
        //Queries
        Task<(bool, string, List<UserEntity>?)> GetAllUsers();
        Task<(bool, string, UserEntity?)> GetUserByEmail(string email);

        //Commands
        Task<(bool, string)> PutUserStatusToInactive(string email);
        Task<(bool, string)> PutUserStatusToActive(string email);
    }
}
