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

        public async Task<List<TransactionEntity>> GetAllTransactions()
        {
            var transactions = _dbContextInMemory.Transaction.ToList();

            return transactions;
        }

        public async Task<TransactionEntity> GetTransactionById(int idTransaction)
        {
            var TransactionId = _dbContextInMemory.Transaction.FirstOrDefault(x => x.Id == idTransaction);
            return TransactionId;
        }

        public async Task<List<TransactionEntity>> GetTransactionsByUserId(int idUser)
        {
            var TransactionsUser = _dbContextInMemory.Transaction.Where(x => x.UserId == idUser).ToList();

            return TransactionsUser;
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
