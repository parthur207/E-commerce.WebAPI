using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models.AdminModels;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services.Admin
{
    public class AdminProductService : IAdminProductInterface, IAdminTransactionProductInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public AdminProductService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        /*Em métodos de consulta. Os dados não serão convertidos para DTO por serem métodos Admin*/


        //Queries
        public async Task<List<ProductEntity>> GetAllProducts()
        {
            var products = await _dbContextInMemory.Product.ToListAsync();

            return products;
        }

        public async Task<List<ProductEntity>> GetAllProductsByStatus(ProductStatusEnum status)
        {
            var productsStatus = await _dbContextInMemory.Product.Where(x => x.ProductStatus == status).ToListAsync();

            return productsStatus;
        }

        public async Task<ProductEntity> GetBiggestSale()
        {
            var BigSale = await _dbContextInMemory.Product
                .OrderByDescending(x => x.Sales)
                .FirstOrDefaultAsync();

            return BigSale;
        }

        public async Task<ProductEntity> GetProductById(int idProduct)
        {
            var Product = await _dbContextInMemory.Product
                .Where(x => x.Id == idProduct)
                .FirstOrDefaultAsync();

            return Product;
        }

        public async Task<List<ProductEntity>> GetProductsByCategory(ProductCategoryEnum category)
        {
            var ProductsCategory = await _dbContextInMemory.Product.Where(x => x.Category == category)
                .ToListAsync();

            return ProductsCategory;
        }

        public async Task<List<ProductEntity>> GetProductsByPrice(decimal price)
        {
            var ProductsPrice = await _dbContextInMemory.Product
                .Where(x => x.Price <= price)
                .ToListAsync();

            return ProductsPrice;
        }

        public async Task<List<ProductEntity>> GetProductsInactive()
        {
            var ProductsInactive = await _dbContextInMemory.Product.Where(x => x.ProductStatus == ProductStatusEnum.Inactive)
                .ToListAsync();

            return ProductsInactive;
        }

        public async Task<List<ProductEntity>> GetProductsNoStock()
        {
            var ProductsNoStock = await _dbContextInMemory.Product.Where(x => x.Quantity == 0)
                .ToListAsync();

            return ProductsNoStock;
        }

        public async Task<List<ProductEntity>> GetSales()
        {
            var Sales = await _dbContextInMemory.Product
                .Where(x => x.Sales > 0)
                .ToListAsync();

            return Sales;
        }

        public async Task<List<ProductEntity>> GetSalesById(int productIdSales)
        {
            var ProductIdSales = await _dbContextInMemory.Product
                .Where(x => x.Id == productIdSales)
                .ToListAsync();

            return ProductIdSales;
        }

        public async Task<List<TransactionProductEntity>> GetSalesByPeriod(DateTime from, DateTime To)
        {
            var SalesPeriod = await _dbContextInMemory.TransactionProduct
                .Include(x => x.Product)
                .Where(x => x.Transaction.TransactionDate >= from && x.Transaction.TransactionDate <= To).ToListAsync();

            return SalesPeriod;
        }

        public async Task<List<TransactionProductEntity>> GetBiggestSaleForDate(DateTime Date)
        {
            var BiggerSaleForDate = await _dbContextInMemory.TransactionProduct
                .Include(x => x.Product)
                .ThenInclude(x => x.Sales)
                .Where(x => x.Transaction.TransactionDate == Date)
                .ToListAsync();

            return BiggerSaleForDate;
        }

        //Commands
        public async Task<(bool, string)> PostProduct(CreateProductModel product)
        {
            try
            {
                var productEntity = ProductMapper.FromProductModel(product);

                if (productEntity is null)
                {
                    return (false, "Falha no mapeamento. O produto não pode ser criado.");
                }

                await _dbContextInMemory.Product.AddAsync(productEntity);
                await _dbContextInMemory.SaveChangesAsync();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao criar o produto: {ex.Message}");
            }
        }

        public async Task<(bool, string)> PutProduct(int ProductId, AdminUpdateProductModel model)
        {
            try
            {
                var ProductEntity = ProductMapper.FromUpdateProductModel(model);

                if (ProductEntity is null)
                {
                    return (false, "Falha no mapeamento. O produto não pode ser atualizado.");
                }

                var produto = await _dbContextInMemory.Product
                    .Where(x => x.Id == ProductId)
                    .FirstOrDefaultAsync();

                if (produto is null)
                {
                   return (false, "Produto não encontrado.");
                }

                await _dbContextInMemory.Product
                    .Where(x => x.Id == ProductId)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(x => x.ProductName, ProductEntity.ProductName)
                        .SetProperty(x => x.Description, ProductEntity.Description)
                        .SetProperty(x => x.Price, ProductEntity.Price)
                        .SetProperty(x => x.Quantity, ProductEntity.Quantity)
                        .SetProperty(x => x.ImageUrl, ProductEntity.ImageUrl));
                await _dbContextInMemory.SaveChangesAsync();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao atualizar o produto: {ex.Message}");
            }
        }

        public async Task<(bool, string)> PutProductStatus(int idProduct, ProductStatusEnum status)
        {
            try
            {
                var produtoEntity = await _dbContextInMemory.Product
                    .Where(x => x.Id == idProduct)
                    .FirstOrDefaultAsync();

                if (produtoEntity is null)
                {
                    return (false, "Produto não encontrado.");
                }

                produtoEntity.SetProductStatus(status);

                _dbContextInMemory.Product.Update(produtoEntity);
                await _dbContextInMemory.SaveChangesAsync();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao atualizar o status do produto: {ex.Message}");
            }
        }
        public async Task<(bool, string)> PutProductCategory(int idProduct, ProductCategoryEnum category)
        {
            try
            {
                var produtoEntity = await _dbContextInMemory.Product
                    .Where(x => x.Id == idProduct)
                    .FirstOrDefaultAsync();

                if (produtoEntity is null)
                {
                    return (false, "Produto não encontrado.");
                }

                produtoEntity.SetProductCategory(category);

                _dbContextInMemory.Product.Update(produtoEntity);
                await _dbContextInMemory.SaveChangesAsync();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao atualizar a categoria do produto: {ex.Message}");
            }
        }
    }
}
