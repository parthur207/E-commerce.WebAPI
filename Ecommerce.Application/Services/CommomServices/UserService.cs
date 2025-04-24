using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Services.CommomServices
{
    public class UserService : IUserInterface
    {
        public Task<(bool, string)> PutPassword(UpdateUserPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string)> PutUserData(UpdateUserDataModel model)
        {
            throw new NotImplementedException();
        }
    }
}
