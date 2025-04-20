using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services.Admin
{
    public class AdminTransactionService : IAdminTransactionInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public AdminTransactionService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        public async Task<TransactionEntity> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionEntity> GetTransactionById(int idTransaction)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionEntity> GetTransactionByUserId(int idUser)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionEntity> PutTransactionStatus(TransactionStatusEnum status)
        {
            throw new NotImplementedException();
        }
    }
}
