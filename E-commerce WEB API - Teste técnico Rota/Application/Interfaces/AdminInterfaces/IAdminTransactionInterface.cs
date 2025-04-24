using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System.Transactions;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminTransactionInterface
    {
        //Queries
        Task<(bool, string, List<AdminTransactionDTO>?)> GetAllTransactions();
        Task<(bool, string, AdminTransactionDTO?)> GetTransactionById(int idTransaction);
        Task<(bool, string, List<AdminTransactionDTO>?)> GetTransactionsByUserId(int idUser);

        //Commads
        Task<(bool, string)> PutTransactionStatusToCanceled(int idTransction);
    }
}
