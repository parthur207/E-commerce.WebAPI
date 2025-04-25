using Ecommerce.Domain.Models;
using Ecommerce.Domain.Enuns;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        //Queries
        Task<(bool, string, ProductEntity?)> GetProductByNameAsync(string productName);
        Task<(bool, string, List<ProductEntity>?)> GetAllProductsAsync();
        Task<(bool, string, List<ProductEntity>?)> GetByProductsCategoryAsync(ProductCategoryEnum category); 
        Task<(bool, string, List<ProductEntity>?)> GetProductsByStatusAsync(ProductStatusEnum status); 
        Task<(bool, string, List<ProductEntity>?)> GetProductsByPriceAsync(decimal price); 
        Task<(bool, string, List<ProductEntity>?)> GetProductsNoStockAsync(); 
        Task<(bool, string, List<ProductEntity>?)> GetInactiveProductsAsync(); 

        // Consultas de vendas (admin)
        Task<(bool, string, List<ProductEntity>?)> GetSalesAsync();
        Task<(bool, string, ProductEntity?)> GetSaleByProductIdAsync(int productId); 
        Task<(bool, string, List<ProductEntity>?)> GetBiggestSaleAsync();

        //Commands
        Task <(bool, string)> AddProductAsync(ProductEntity product); 
        Task<(bool, string)> UpdateProductAsync(int id, ProductEntity product);
        Task<(bool, string)> UpdateProductStatusAsync(int productId, ProductStatusEnum status);
        Task<(bool, string)> UpdateProductCategoryAsync(int productId, ProductCategoryEnum category); 
        Task<(bool, string)> DeleteProductAsync(int productId);
    }
}
