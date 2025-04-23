using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces
{
    public interface ITransactionInterface
    {

        //Queries
        Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions();

        //Commands
        Task<(bool, string)> PostTransaction(CreateTransactionModel transaction);
        Task<(bool, string)> PutTransactionStatus(int transactionId, TransactionStatusEnum status);
    }
}
