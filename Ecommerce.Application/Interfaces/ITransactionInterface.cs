
using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces
{
    public interface ITransactionInterface
    {

        //Queries
        Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions();

        //Commands
        Task<(bool, string)> PostTransaction(CreateTransactionModel transaction);

        Task<(bool, string)> PutTransactionStatusToPaid(int transactionId);
    }
}
