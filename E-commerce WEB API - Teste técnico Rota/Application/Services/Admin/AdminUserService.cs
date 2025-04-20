using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services.Admin
{
    public class AdminUserService : IAdminUserInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public AdminUserService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        public async Task<UserEntity> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> PutUserStatus(UserStatusEnum status)
        {
            throw new NotImplementedException();
        }
    }
}
