using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.RepositoriesInterface
{
    public interface IUserRepository
    {

        //Queries Admin
        Task<(bool,string,UserEntity?)> GetUserByEmailAsync(string email);

        Task<(bool, string,List<UserEntity>?)> GetAllUsersAsync();

        //Commands
        Task<(bool, string)> AddUserAsync(UserEntity user);

        Task<(bool, string)> UpdateDataUserAsync(UserEntity user, int idUser);

        //admin

       //Task<(bool, string)> UpdatePasswordUserAsync(UserEntity user, int idUser);

        Task<(bool, string)> InativeUserByEmailAsync(string email);

        Task<(bool, string)> ActiveUserByEmailAsync(string email);

    }
}