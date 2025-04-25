using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Domain.Enuns;
using Ecommerce.Domain.Models.AdminModels;

namespace Ecommerce.Application.Interfaces.AdminInterfaces
{
    public interface IAdminProductInterface
    {

        //Queries
        Task<(bool, string, List<AdminProductDTO>?)> GetAllProducts();
        Task<(bool, string, AdminProductDTO?)> GetProductByName(string productName);
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
