using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Enuns;

namespace Ecommerce.Application.Interfaces
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
