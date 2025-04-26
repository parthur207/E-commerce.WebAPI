using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces.UserInterfaces
{
    public interface IUserInterface
    {
        Task<(bool, string)> AddUserAssync(CreateUserModel model);
        Task<(bool, string)> PutPassword(UpdateUserPasswordModel model, int UserId);

        Task<(bool, string)> PutUserData(UpdateUserDataModel model, int UserId);
    }
}
