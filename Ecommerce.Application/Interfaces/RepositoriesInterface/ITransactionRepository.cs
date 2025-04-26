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
        Task<(bool, string, List<TransactionEntity>?)> GetAllTransactionsAdminAsync();
        
        Task<(bool, string, TransactionEntity?)> GetTransactionByIdAdminAsync(int idTransaction);

        //Commads e queries
        //user e admin
        Task<(bool, string)> PutTransactionStatusToCanceledAsync(int idTransaction);
        Task<(bool, string, List<TransactionEntity>?)> GetAllTransactionsUserAsync(int UserId);

        
        //user
        //Commands
        Task<(bool, string)> PostTransactionAsync(TransactionEntity transaction);

        Task<(bool, string)> PutTransactionStatusToPaidAsync(int transactionId, int UserId);

        Task<(bool, string)> PutTransactionStatusToSentAdminAsync(int idTransaction);
    }
}
