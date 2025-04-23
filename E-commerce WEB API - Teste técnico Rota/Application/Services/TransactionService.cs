using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services
{
    public class TransactionService : ITransactionInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;

        public TransactionService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        //Queries
        public async Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions()
        {
            List<TransactionDTO> ListProducts=new List<TransactionDTO>();
            string message = string.Empty;
            try
            {
                var transactionsE = await _dbContextInMemory.Transaction.ToListAsync();

                if(transactionsE is null)
                {
                    message = "Transações não encontradas.";
                    return (false, message, null);
                }

                foreach (var transactionEntity in transactionsE)
                {
                    var transactionMapped= TransactionMapper.ToTransactionDTO(transactionEntity);
                    ListProducts.Add(transactionMapped);
                }
                return (true, message, ListProducts);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar as transações: {ex.Message}";
                return (false, message , null);
            }
        }


        //Commands
        public async Task<(bool, string)> PostTransaction(CreateTransactionModel transaction)
        {
            var transactionEntity= TransactionMapper.FromTransactionModel(transaction);

            if(transactionEntity is null)
            {
                return (false, "Erro ao criar a transação e falha no mapeamento.");
            }

            await _dbContextInMemory.Transaction.AddAsync(transactionEntity);
            await _dbContextInMemory.SaveChangesAsync();  
           
            return (true, "Compra realizada com sucesso!\nEfetue o pagamento.");
        }

        public Task<(bool, string)> PutTransactionStatus(int transactionId, TransactionStatusEnum status)
        {
            throw new NotImplementedException();
        }
    }
}
