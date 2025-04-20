using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services.Admin
{
    public class AdminProductService : IAdminProductInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public AdminProductService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }
        public async Task<ProductEntity> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetAllProductsByStatus(ProductStatusEnum status)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetBiggestSale()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetProductById(int idProduct)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetProductsByCategory(ProductCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetProductsByPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetProductsInactive()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetProductsNoStock()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetSales()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetSalesById(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetSalesByPeriod(DateOnly from, DateOnly To)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> PostProduct(AdminProductDTO product)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> PutProduct(UpdateProductModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> PutProductStatus(int idProduct, ProductStatusEnum status)
        {
            throw new NotImplementedException();
        }
    }
}
