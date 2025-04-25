using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Domain.Enuns;
using Ecommerce.Domain.Models.AdminModels;

namespace Ecommerce.Application.Interfaces.AdminInterfaces
{
    public interface IAdminProductInterface
    {

        //Queries
        Task<(bool, string, List<AdminProductDTO>?)> GetAllProductsAdmin();
        Task<(bool, string, AdminProductDTO?)> GetProductByNameAdmin(string productName);
        Task<(bool, string, List<AdminProductDTO>?)> GetAllProductsByStatusAdmin(ProductStatusEnum status);
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsByCategoryAdmin(ProductCategoryEnum category);
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsByPriceAdmin(decimal price);
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsNoStockAdmin();
        Task<(bool, string, List<AdminProductDTO>?)> GetProductsInactiveAdmin();
        //Vendas
        Task<(bool, string, List<AdminProductDTO>?)> GetSalesAdmin();
        Task<(bool, string, AdminProductDTO?)> GetSaleByIdAdmin(int productId);
        Task<(bool, string, List<AdminProductDTO>?)> GetBiggestSaleAdmin();

        //Commands
        Task<(bool,  string)> PostProductAdmin(AdminCreateProductModel product);
        Task<(bool,string)> PutProductAdmin(int ProductId, AdminUpdateProductModel model);
        Task<(bool, string)> PutProductStatusAdmin(int ProductId, ProductStatusEnum status);
        Task<(bool, string)> PutProductCategoryAdmin(int ProductId, ProductCategoryEnum category);
    }
}
