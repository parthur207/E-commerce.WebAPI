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
        Task<(bool, string, List<ProductEntity>?)> GetTopFiveSalesByPeriodAsync(DateTime from, DateTime to);
        Task<(bool, string, ProductEntity?)> GetBiggetSaleAsync();

        //Commands
        Task <(bool, string)> AddProductAsync(ProductEntity product); 
        Task<(bool, string)> UpdateProductAsync(int id, ProductEntity product);
        Task<(bool, string)> UpdateProductStockTotalAdmin(int ProductId, int newStock);
        Task<(bool, string)> UpdateProductStatusToInativeAsync(int productId);
        Task<(bool, string)> UpdateProductStatusToAtiveAsync(int productId);
        Task<(bool, string)> UpdateProductCategoryAsync(int productId, ProductCategoryEnum category); 

    }
}
