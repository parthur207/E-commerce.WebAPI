using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces.UserInterfaces
{
    public interface ITransactionInterface
    {

        //Queries
        Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions();

        //Commands
        Task<(bool, string)> PostTransaction(CreateTransactionModel transaction, int UserId);

        Task<(bool, string)> PutTransactionStatusToPaid(int transactionId);
    }
}
