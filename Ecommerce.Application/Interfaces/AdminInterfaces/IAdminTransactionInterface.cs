using Ecommerce.Application.DTOs.AdminDTOs;
using System.Transactions;

namespace Ecommerce.Application.Interfaces.AdminInterfaces
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
