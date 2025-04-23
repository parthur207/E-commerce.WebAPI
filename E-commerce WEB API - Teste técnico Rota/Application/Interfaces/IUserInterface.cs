using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces
{
    public interface IUserInterface
    {

        Task<(bool, string)> PutPassword(UpdateUserPasswordModel model);

        Task<(bool, string)> PutUserData(UpdateUserDataModel model);
    }
}
