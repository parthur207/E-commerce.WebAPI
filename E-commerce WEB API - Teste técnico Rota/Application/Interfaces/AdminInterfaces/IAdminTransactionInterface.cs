using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System.Transactions;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminTransactionInterface
    {
        //Queries
        Task<(bool, string, List<TransactionEntity>?)> GetAllTransactions();
        Task<(bool, string, TransactionEntity?)> GetTransactionById(int idTransaction);
        Task<(bool, string, List<TransactionEntity>?)> GetTransactionsByUserId(int idUser);

        //Commads
        Task<(bool, string)> PutTransactionStatus(int idTransction, TransactionStatusEnum status);
    }
}
