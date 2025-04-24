using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces.UserInterfaces
{
    public interface IUserInterface
    {

        Task<(bool, string)> PutPassword(UpdateUserPasswordModel model);

        Task<(bool, string)> PutUserData(UpdateUserDataModel model);
    }
}
