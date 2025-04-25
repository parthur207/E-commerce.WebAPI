using Ecommerce.Application.DTOs.AdminDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.RepositoriesInterface
{
    public interface ITransactionRepository
    {

        //Queries
        Task<(bool, string, List<AdminTransactionDTO>?)> GetAllTransactions();
        Task<(bool, string, AdminTransactionDTO?)> GetTransactionById(int idTransaction);
        Task<(bool, string, List<AdminTransactionDTO>?)> GetTransactionsByUserId(int idUser);

        //Commads
        Task<(bool, string)> PutTransactionStatusToCanceled(int idTransction);

    }
}
