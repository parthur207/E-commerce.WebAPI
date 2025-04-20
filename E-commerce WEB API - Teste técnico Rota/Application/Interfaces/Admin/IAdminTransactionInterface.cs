using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System.Transactions;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminTransactionInterface
    {
        //Queries
        Task<TransactionEntity> GetAllTransactions();
        Task<TransactionEntity> GetTransactionById(int idTransaction);
        Task<TransactionEntity> GetTransactionByUserId(int idUser);

        //Commads
        Task<TransactionEntity> PutTransactionStatus(TransactionStatusEnum status);
    }
}
