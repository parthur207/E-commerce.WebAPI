using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminUserInterface
    {
        //Queries
        Task<List<UserEntity>> GetAllUsers();
        Task<UserEntity> GetUserById(Guid id);

        //Commands
        Task<UserEntity> PutUserStatus(UserStatusEnum status);
        
    }
}
