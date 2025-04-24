using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services
{
    public class ProductService : IProductInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;

        public ProductService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        public Task<(bool, List<ProductDTO>?)> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<(bool, ProductDTO?)> GetProductByName(string ProductName)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, List<ProductDTO?>)> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, List<ProductDTO?>)> GetProductsByPrice(decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
