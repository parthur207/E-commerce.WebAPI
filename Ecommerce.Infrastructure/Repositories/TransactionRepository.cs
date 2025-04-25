using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {

        private readonly DbContextInMemory _dbContextinInMemory;
        public TransactionRepository(DbContextInMemory dbcontext)
        {
            _dbContextinInMemory = dbcontext;
        }


        public async Task<(bool, string, List<TransactionEntity>?)> GetAllTransactionsAdmin()
        {
            string message = string.Empty;
            try
            {
                var TransactionEntity = await _dbContextinInMemory.Transaction.ToListAsync();

                if(TransactionEntity is null)
                {
                    message = "Nenhuma transação foi encontrada.";

                    return (false, message, null);
                }
                return (true, message, TransactionEntity);
            }
            catch (Exception ex)
            {
                message = $"Erro ao carregar transações: {ex.Message}";
                return (false, message, null);
            }
        }

        public Task<(bool, string, AdminTransactionDTO?)> GetTransactionByIdAdmin(int idTransaction)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string, List<AdminTransactionDTO>?)> GetTransactionsByUserId(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string)> PostTransaction(TransactionEntity transaction)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string)> PutTransactionStatusToCanceled(int idTransction)
        {
            throw new NotImplementedException();
        }
    }

}
