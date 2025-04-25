using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.RepositoriesInterface
{
    public interface IUserRepository
    {

        Task<(bool, string)> AddUserAsync(UserEntity user);

        Task<(bool, string)> UpdateDataUserAsync(UserEntity user);

        Task<bool> DeleteUserAsync(UserEntity user);
        Task<UserEntity> GetUserByEmailAsync();
        Task<UserEntity> GetAllUsers();
    }
}
