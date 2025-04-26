using Ecommerce.Application.DTOs.AdminDTOs;
using System.Transactions;

namespace Ecommerce.Application.Interfaces.AdminInterfaces
{
    public interface IAdminTransactionInterface
    {
        //Queries
        Task<(bool, string, List<AdminTransactionDTO>?)> GetAllTransactionsAdmin();
        Task<(bool, string, AdminTransactionDTO?)> GetTransactionByIdAdmin(int idTransaction);
        Task<(bool, string, List<AdminTransactionDTO>?)> GetTransactionsByUserIdAdmin(int idUser);

        //Commads
        Task<(bool, string)> PutTransactionStatusToCanceledAdmin(int idTransction);

        Task<(bool, string)> PutTransactionStatusToSentAdmin(int idTransction);
    }
}
