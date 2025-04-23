using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models.AdminModels;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminProductInterface
    {

        //Queries
        Task<(bool, string, List<ProductEntity>?)> GetAllProducts();
        Task<(bool, string, ProductEntity?)> GetProductById(int idProduct);
        Task<(bool, string, List<ProductEntity>?)> GetAllProductsByStatus(ProductStatusEnum status);
        Task<(bool, string, List<ProductEntity>?)> GetProductsByCategory(ProductCategoryEnum category);
        Task<(bool, string, List<ProductEntity>?)> GetProductsByPrice(decimal price);
        Task<(bool, string, List<ProductEntity>?)> GetProductsNoStock();
        Task<(bool, string, List<ProductEntity>?)> GetProductsInactive();

        Task<(bool, string, List<ProductEntity>?)> GetSales();
        Task<(bool, string, ProductEntity?)> GetSaleById(int productId);
        Task<(bool, string, ProductEntity?)> GetBiggestSale();

        //Commands
        Task<(bool, string)> PostProduct(AdminCreateProductModel product);
        Task<(bool,string)> PutProduct(int ProductId, AdminUpdateProductModel model);
        Task<(bool, string)> PutProductStatus(int ProductId, ProductStatusEnum status);
        Task<(bool, string)> PutProductCategory(int ProductId, ProductCategoryEnum category);
    }
}
