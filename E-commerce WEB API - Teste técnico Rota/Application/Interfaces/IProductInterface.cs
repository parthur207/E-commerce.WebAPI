using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces
{
    public interface IProductInterface
    {
        
        //Queries
        Task<(bool, List<ProductDTO?>)> GetAllProducts();

        Task<(bool, ProductDTO?)> GetProductByName(string ProductName);

        Task<(bool, List<ProductDTO?>)> GetProductsByCategory(string category);

        Task<(bool, List<ProductDTO?>)> GetProductsByPrice(decimal price);

        //Commands
    }
}
