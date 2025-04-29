using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enuns;
using Ecommerce.Domain.Models;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DbContextInMemory _dbContextInMemory;

        public UserRepository(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }
        //User
        public async Task<(bool, string)> AddUserAsync(UserEntity user)
        {
            string message = string.Empty;
            try
            {
                var userExists = await _dbContextInMemory.User
                    .FirstOrDefaultAsync(u => u.Email == user.Email);
                if (userExists != null)
                {
                    message = "Email já cadastrado.";
                    return (false, message);
                }
                await _dbContextInMemory.User.AddAsync(user);
                await _dbContextInMemory.SaveChangesAsync();
                message = "Cadastro realizado com sucesso.";
                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }

        public async Task<(bool, string)> UpdatePasswordUserAsync(UserEntity user, string NewPassword, int UserId)
        {
            string message = string.Empty;
            try
            {
                var UserExist = await _dbContextInMemory.User.AnyAsync(x=>x.Email==user.Email && x.Password==user.Password);

                if (UserExist is false)
                {
                    message = "Credenciais inválidas.";
                    return (false, message);
                }

                var UserEntity = await _dbContextInMemory.User.FirstOrDefaultAsync(x=>x.Email==user.Email && x.Password==user.Password);

                UserEntity.ChangePassword(NewPassword);
                _dbContextInMemory.Update(UserEntity);
                await _dbContextInMemory.SaveChangesAsync();
                message = "Senha atualizada com sucesso.";
                return (true, message);
            }
            catch (Exception ex)
            {
                message = "Ocorreu um erro inesperado.";
                return (false, ex.Message);
            }
        }

        //Admin
        public async Task<(bool, string)> InativeUserByEmailAsync(string email)
        {
            string message = string.Empty;
            try
            {
                var UserEntity = await _dbContextInMemory.User
                      .AsNoTracking()
                      .FirstOrDefaultAsync(u => u.Email == email);

                if (UserEntity == null)
                {
                    message = "Usuário não encontrado.";
                    return (false, message);
                }
                UserEntity.SetUserStatusToInactive();
                _dbContextInMemory.User.Update(UserEntity);
                await _dbContextInMemory.SaveChangesAsync();
                message = "Usuário inativado com sucesso.";
                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }

        public async Task<(bool, string)> ActiveUserByEmailAsync(string Email)
        {
            string message = string.Empty;
            try
            {

                var userToActivate = await _dbContextInMemory.User
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == Email);
                if (userToActivate == null)
                {
                    message = "Usuário não encontrado.";
                    return (false, message);
                }
                userToActivate.SetUserStatusToActive();
                _dbContextInMemory.User.Update(userToActivate);
                await _dbContextInMemory.SaveChangesAsync();

                message = "Usuário ativado com sucesso.";
                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }
        //Admin
        public async Task<(bool, string, List<UserEntity>?)> GetAllUsersAsync()
        {
            string message = string.Empty;
            try
            {
                var ListUsers = await _dbContextInMemory.User.Include(x => x.TransactionsList)
                    .ToListAsync();

                if (ListUsers == null || ListUsers.Count == 0)
                {
                    message = "Nenhum usuário encontrado.";
                    return (false, message, null);
                }

                return (true, message, ListUsers);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message, null);
            }
        }

        //Admin
        public async Task<(bool, string, UserEntity?)> GetUserByEmailAsync(string Email)
        {
            string message = string.Empty;
            try
            {
                var user = await _dbContextInMemory.User
                    .AsNoTracking()
                    .Include(x=>x.TransactionsList)
                    .FirstOrDefaultAsync(u => u.Email == Email);

                if (user == null)
                {
                    message = "Usuário não encontrado.";
                    return (false, message, null);
                }
                return (true, message, user);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message, null);
            }
        }

        //User
        public async Task<(bool, string)> UpdateDataUserAsync(UserEntity user, int idUser)
        {
            string message = string.Empty;
            try
            {
                var userToUpdate = await _dbContextInMemory.User
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == idUser);
                if (userToUpdate == null)
                {
                    message = "Usuário não encontrado.";
                    return (false, message);
                }
                _dbContextInMemory.User.Update(user);
                await _dbContextInMemory.SaveChangesAsync();
                message = "Dados do usuário atualizados com sucesso.";
                return (true, message);

            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }

        public async Task<(bool, string)> LoginUserAsync(UserEntity user)
        {
            string message = string.Empty;
            try
            {

                if (await _dbContextInMemory.User.AnyAsync(x => x.UserStatus ==UserStatusEnum.Inactive))
                {
                    message = "Acesso bloqueado.";
                    return (false, message);
                }

                var userToLogin = await _dbContextInMemory.User
                    .AsNoTracking()
                    .AnyAsync(u => u.Email == user.Email && u.Password == user.Password);

                if (userToLogin is false)
                {
                    message = "Credenciais inválidas";
                    return (false, message);
                }



                message = "Login realizado com sucesso.";
                return (true, message);
            }
            catch 
            {
                return (false, "Ocorreu um erro inesperado.");
            }
        }
            

        public async Task<(bool, string)> UpdatePasswordUser(UserEntity user, int IdUser)
        {
            string message = string.Empty;
            try
            {

                var UserEntity = await _dbContextInMemory.User.FirstOrDefaultAsync(x=>x.Id==IdUser);
                UserEntity.ChangePassword(user.Password);
                _dbContextInMemory.Update(UserEntity);
                await _dbContextInMemory.SaveChangesAsync();
                message = "Senha atualizada com sucesso.";

                return (true, message);

            }
            catch (Exception ex)
            {
                message = "Ocorreu um erro inesperado.";
                return (false, message);
            }
        }
    }
}
