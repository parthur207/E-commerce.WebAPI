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
        Task<(bool, string, List<AdminProductDTO>?)> GetAllProducts();
        Task<(bool, string, AdminProductDTO?)> GetProductById(int idProduct);
        Task<(bool, string, List<AdminProductDTO>?)> GetAllProductsByStatus(ProductStatusEnum status);
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsByCategory(ProductCategoryEnum category);
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsByPrice(decimal price);
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsNoStock();
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsInactive();

        Task<(bool, string, List<AdminProductDTO>?)> GetSales();
        Task<(bool, string, AdminProductDTO?)> GetSaleById(int productId);
        Task<(bool, string, List<AdminProductDTO>?)> GetBiggestSale();

        //Commands
        Task<(bool,  string)> PostProduct(AdminCreateProductModel product);
        Task<(bool,string)> PutProduct(int ProductId, AdminUpdateProductModel model);
        Task<(bool, string)> PutProductStatus(int ProductId, ProductStatusEnum status);
        Task<(bool, string)> PutProductCategory(int ProductId, ProductCategoryEnum category);
    }
}
