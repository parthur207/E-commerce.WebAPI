using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services.Admin
{
    public class AdminUserService : IAdminUserInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public AdminUserService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        //Queries
        public async Task<List<UserEntity>> GetAllUsers()
        {
            var users = await _dbContextInMemory.User.ToListAsync();
            return users;
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            var userEntity = await _dbContextInMemory.User.FirstOrDefaultAsync(x => x.Email == email);
            
            return userEntity;
        }

        //Commands
        public async Task<(bool, string)> PutUserStatusToInactive(string email)
        {
            try
            {
                var userEntity = await _dbContextInMemory.User.FirstOrDefaultAsync(x => x.Email == email);

                if (userEntity is null)
                {
                    return (false, "Usuário não encontrado");
                }

                userEntity.SetUserStatusToInactive();
                _dbContextInMemory.User.Update(userEntity);
                _dbContextInMemory.SaveChanges();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Erro na tentativa de atualizar o status do usuário: {ex.Message}");
            }
        }

        public async Task<(bool, string)> PutUserStatusToActive(string email)
        {
            try
            {
                var userEntity = await _dbContextInMemory.User.FirstOrDefaultAsync(x => x.Email == email);

                if (userEntity is null)
                {
                    return (false, "Usuário não encontrado");
                }

                userEntity.SetUserStatusToActive();
                _dbContextInMemory.User.Update(userEntity);
                _dbContextInMemory.SaveChanges();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Erro na tentativa de atualizar o status do usuário: {ex.Message}");
            }
        }
    }
}
