using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services
{
    public class ProductService : IProductInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;

        public TransactionService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        public Task<List<ProductEntity>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> GetProductByName(string ProductName)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductEntity>> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductEntity>> GetProductsByPrice(decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
