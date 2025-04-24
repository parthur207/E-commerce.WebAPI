using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services
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
