
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Services
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
