using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminProductInterface
    {

        //Queries
        Task<ProductEntity> GetAllProducts();
        Task<ProductEntity> GetProductById(int idProduct);
        Task<ProductEntity> GetAllProductsByStatus(ProductStatusEnum status);
        Task<ProductEntity> GetProductsByCategory(ProductCategoryEnum category);
        Task<ProductEntity> GetProductsByPrice(decimal price);
        Task<ProductEntity> GetProductsNoStock();
        Task<ProductEntity> GetProductsInactive();

        Task<ProductEntity> GetSales();
        Task<ProductEntity> GetSalesById(int productId);
        Task<ProductEntity> GetSalesByPeriod(DateOnly from, DateOnly To);
        Task<ProductEntity> GetBiggestSale();

        //Commands
        Task<ProductEntity> PostProduct(AdminProductDTO product);
        Task<ProductEntity> PutProduct(UpdateProductModel model);
        Task<ProductEntity> PutProductStatus(int idProduct, ProductStatusEnum status);
    }
}
