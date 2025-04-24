using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces
{
    public interface IProductInterface
    {
        
        //Queries
        Task<(bool, string, List<ProductDTO>?)> GetAllProducts();

        Task<(bool,string, ProductDTO?)> GetProductByName(string ProductName);

        Task<(bool, string, List<ProductDTO>?)> GetProductsByCategory(ProductCategoryEnum category);

        Task<(bool,string,  List<ProductDTO>?)> GetProductsByPrice(decimal price);

        //Commands
    }
}
