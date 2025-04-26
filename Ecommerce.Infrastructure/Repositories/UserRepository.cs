using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using Ecommerce.Infrastructure.Persistence;
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
            throw new NotImplementedException();
        }

        public async Task<(bool, string)> UpdatePasswordUser(UserEntity user, int userId)
        {
            string message = string.Empty;
            try
            {

            }
            catch(Exception ex)
            {
                message = "Ocorreu um erro inesperado.";
                return (false, ex.Message);
            }
        }

        //Admin
        public async Task<(bool, string)> InativeUserAsync(UserEntity user)
        {
            string message = string.Empty;
            try
            {
                user.SetAsDeleted();
                _dbContextInMemory.Update(user);
                await _dbContextInMemory.SaveChangesAsync();

                message= "Usuário inativado com sucesso.";
                return (true, message);
            }
            catch(Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }

        public async Task<(bool, string)> ActiveUserAsync(UserEntity user)
        {
            string message = string.Empty;
            try
            {
                user.SetAsDeleted();
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }
        //Admin
        public Task<UserEntity> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        //Admin
        public Task<UserEntity> GetUserByEmailAsync()
        {
            throw new NotImplementedException();
        }

        //User
        public Task<(bool, string)> UpdateDataUserAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
