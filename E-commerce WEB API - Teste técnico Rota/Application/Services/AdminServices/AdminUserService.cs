using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers;
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
        public async Task<(bool,string, List<UserDTO>?)> GetAllUsers()
        {
            try
            {
                List<UserDTO> ListUsersDTO = new List<UserDTO>();
                string message = string.Empty;
                var usersEntity = await _dbContextInMemory.User.ToListAsync();

                if (usersEntity is null)
                {
                    message = "";
                    return (false, message, null);
                }
                foreach (var u in usersEntity)
                {
                    var userDTO = UserMapper.ToUserDTO(u);
                    ListUsersDTO.Add(userDTO);
                }
                return (true, message, ListUsersDTO);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao buscar os usuários: {ex.Message}", null);
            }
        }

        public async Task<(bool, string, UserDTO?)> GetUserByEmail(string email)
        {
            string message = string.Empty;
            try
            {
                var userEntity = await _dbContextInMemory.User.FirstOrDefaultAsync(x => x.Email == email);

                if(userEntity is null)
                {
                    message= "Usuário não encontrado.";
                    return (false, message, null);
                }

                var userMappedDTO = UserMapper.ToUserDTO(userEntity);
                return (true, message, userMappedDTO);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar o usuário: {ex.Message}");
            }
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
