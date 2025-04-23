using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services.Admin
{
    public class AdminTransactionService : IAdminTransactionInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public AdminTransactionService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        public async Task<(bool, string, List<TransactionEntity>?)> GetAllTransactions()
        {
            string message=string.Empty;
            try
            {
                var transactions = await _dbContextInMemory.Transaction.ToListAsync();



                return (true, message, transactions);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar as transações: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, TransactionEntity?)> GetTransactionById(int idTransaction)
        {
            string message = string.Empty;
            try
            {
                var transaction = await _dbContextInMemory.Transaction
                    .Where(x => x.Id == idTransaction)
                    .FirstOrDefaultAsync();

                if (transaction is null)
                {
                    message = "Transação não encontrada.";
                    return (false, message, null);
                }

                return (true, message, transaction);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar a transação: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<TransactionEntity>?)> GetTransactionsByUserId(int idUser)
        {
            string message = string.Empty;
            try
            {
                var transactions = await _dbContextInMemory.Transaction
                    .Where(x => x.UserId == idUser)
                    .ToListAsync();

                if(transactions is null)
                {
                    message = "Transações não encontradas.";
                    return (false, message, null);
                }

                return (true, message, transactions);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar as transações: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string)> PutTransactionStatus(int idTransction, TransactionStatusEnum status)
        {
            try
            {
                var TransactionEntity = await _dbContextInMemory.Transaction
                 .Where(x => x.Id == idTransction)
                 .FirstOrDefaultAsync();

                if(TransactionEntity is null)
                {
                    return (false, "Transação não encontrada.");
                }

                await _dbContextInMemory.Transaction.Where(x => x.Id == idTransction)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.TransactionStatus, status));

                return (true, "O status da transação foi atualzado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao alterar o status da transação: {ex.Message}");
            }
        }
    }
}
