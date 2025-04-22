using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services
{
    public class ProductService : IProductInterface
    {
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
