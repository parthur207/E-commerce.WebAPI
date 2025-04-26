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

        //Queries Admin
        Task<UserEntity> GetUserByEmailAsync();

        Task<UserEntity> GetAllUsers();

        //Commands
        Task<(bool, string)> AddUserAsync(UserEntity user);

        Task<(bool, string)> UpdateDataUserAsync(UserEntity user);

        //admin

        Task<(bool, string)> UpdatePasswordUser(UserEntity user);

        Task<(bool, string)> InativeUserAsync(UserEntity user);

        Task<(bool, string)> ActiveUserAsync(UserEntity user);

    }
}