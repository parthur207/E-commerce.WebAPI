using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.RepositoriesInterface
{
    public interface ITransactionRepository
    {
        //admin
        //queries
        Task<(bool, string, List<TransactionEntity>?)> GetAllTransactionsAdmin();
        Task<(bool, string, TransactionEntity?)> GetTransactionByIdAdmin(int idTransaction);
        Task<(bool, string, List<TransactionEntity>?)> GetTransactionsByUserIdAdmin(int idUser);

        //Commads
        //user e admin
        Task<(bool, string)> PutTransactionStatusToCanceled(int idTransaction);

        //user
        //Queries

        Task<(bool, string, List<TransactionEntity>?)> GetAllTransactions();

        //Commands
        Task<(bool, string)> PostTransaction(TransactionEntity transaction);

        Task<(bool, string)> PutTransactionStatusToPaid(int transactionId);
    }
}
