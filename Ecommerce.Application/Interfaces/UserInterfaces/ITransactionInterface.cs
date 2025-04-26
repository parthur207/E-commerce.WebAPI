using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces.UserInterfaces
{
    public interface ITransactionInterface
    {

        //Queries
        Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions(int IdUser);

        //Commands
        Task<(bool, string)> PostTransaction(CreateTransactionModel transaction, int IdUser);

        Task<(bool, string)> PutTransactionStatusToPaid(int transactionId, int UserId);

        Task<(bool, string)> PutTransactionStatusToCanceled(int transactionId, int UserId);
    }
}
