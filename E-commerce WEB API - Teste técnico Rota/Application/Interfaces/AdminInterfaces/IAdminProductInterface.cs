using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models.AdminModels;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminProductInterface
    {

        //Queries
        Task<List<ProductEntity>> GetAllProducts();
        Task<ProductEntity> GetProductById(int idProduct);
        Task<List<ProductEntity>> GetAllProductsByStatus(ProductStatusEnum status);
        Task<List<ProductEntity>> GetProductsByCategory(ProductCategoryEnum category);
        Task<List<ProductEntity>> GetProductsByPrice(decimal price);
        Task<List<ProductEntity>> GetProductsNoStock();
        Task<List<ProductEntity>> GetProductsInactive();

        Task<List<ProductEntity>> GetSales();
        Task<List<ProductEntity>> GetSalesById(int productId);
        Task<ProductEntity> GetBiggestSale();

        //Commands
        Task<(bool, string)> PostProduct(CreateProductModel product);
        Task<(bool,string)> PutProduct(int ProductId, AdminUpdateProductModel model);
        Task<(bool, string)> PutProductStatus(int ProductId, ProductStatusEnum status);
        Task<(bool, string)> PutProductCategory(int ProductId, ProductCategoryEnum category);
    }
}
