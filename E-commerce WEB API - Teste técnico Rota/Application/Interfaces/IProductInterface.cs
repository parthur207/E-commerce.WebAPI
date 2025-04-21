using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces
{
    public interface IProductInterface
    {
        
        //Queries
        Task<List<ProductEntity>> GetAllProducts();

        Task<ProductEntity> GetProductByName(string ProductName);

        Task<List<ProductEntity>> GetProductsByCategory(string category);

        Task<List<ProductEntity>> GetProductsByPrice(decimal price);

        //Commands

        Task<  >
    }
}
