using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
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
        public async Task<(bool, string, List<ProductEntity>?)> GetAllProducts()
        {
            string message=string.Empty;
            try
            {
                var products = await _dbContextInMemory.Product.ToListAsync();
                if(products is null)
                {
                    message= "Não foram encontrados produtos.";
                    return (false, message, null);
                }
                return (true, message, products);
            }
            catch(Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetAllProductsByStatus(ProductStatusEnum status)
        {
            string message = string.Empty;
            try
            {
                var productsStatus = await _dbContextInMemory.Product
                    .Where(x => x.ProductStatus == status)
                    .ToListAsync();
                if (productsStatus is null)
                {
                    message = "Não foram encontrados produtos.";
                    return (false, message, null);
                }
                return (true, message, productsStatus);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, ProductEntity?)> GetBiggestSale()
        {
            string message = string.Empty;
            try
            {
                var BigSale = await _dbContextInMemory.Product
                    .OrderByDescending(x => x.Sales)
                    .FirstOrDefaultAsync();

                if (BigSale is null)
                {
                    message = "Não foram encontrados produtos.";
                    return (false, message, null);
                }
                return (true, message, BigSale);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, ProductEntity?)> GetProductById(int idProduct)
        {
            string message = string.Empty;

            try
            {
                var Product = await _dbContextInMemory.Product
                    .Where(x => x.Id == idProduct)
                    .FirstOrDefaultAsync();

                if(Product is null)
                {
                    message = "Não foram encontrados produtos.";
                    return (false, message, null);
                }

                return (true, message, Product);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produto: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetProductsByCategory(ProductCategoryEnum category)
        {
            string message = string.Empty;
            try
            {
                var ProductsCategory = await _dbContextInMemory.Product
                    .Where(x => x.Category == category)
                    .ToListAsync();

                if (ProductsCategory is null)
                {
                    message = $"Não foram encontrados produtos da categoria '{category}'.";
                    return (false, message, null);
                }

                return (true, message, ProductsCategory);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetProductsByPrice(decimal price)
        {
            string message = string.Empty;
            try
            {
                var ProductsPrice = await _dbContextInMemory.Product
                    .Where(x => x.Price <= price)
                    .ToListAsync();

                if (ProductsPrice is null)
                {
                    message = $"Não foram encontrados produtos com preço menor ou igual a '{price}'.";
                    return (false, message, null);
                }

                return (true, message, ProductsPrice);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetProductsInactive()
        {
            string message = string.Empty;

            try
            {
                var ProductsInactive = await _dbContextInMemory.Product
                    .Where(x => x.ProductStatus == ProductStatusEnum.Inactive)
                    .ToListAsync();

                if (ProductsInactive is null)
                {
                    message = $"Não foram encontrados produtos inativos.";
                    return (false, message, null);
                }

                return (true, message, ProductsInactive);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetProductsNoStock()
        {
            string message = string.Empty;
            try
            {
                var ProductsNoStock = await _dbContextInMemory.Product
                    .Where(x => x.Quantity == 0)
                    .ToListAsync();
                if (ProductsNoStock is null)
                {
                    message = $"Não foram encontrados produtos sem estoque.";
                    return (false, message, null);
                }
                return (true, message, ProductsNoStock);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetSales()
        {
            string message = string.Empty;
            try
            {
                var ProductSales = await _dbContextInMemory.Product
                    .Where(x => x.Sales > 0)
                    .ToListAsync();
                if (ProductSales is null)
                {
                    message = $"Não foram encontrados produtos com vendas.";
                    return (false, message, null);
                }

                return (true, message, ProductSales);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, ProductEntity?)> GetSaleById(int productIdSales)
        {
            string message = string.Empty;
            try
            {
                var ProductIdSales = await _dbContextInMemory.Product
                    .Where(x => x.Id == productIdSales)
                    .FirstOrDefaultAsync();

                if (ProductIdSales is null)
                {
                    message = $"Não foram encontradas vendas vinculadas ao produto.";
                    return (false, message, null);
                }
                return (true, message, ProductIdSales);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<TransactionProductEntity>?)> GetSalesByPeriod(DateTime from, DateTime To)
        {
            string message = string.Empty;

            try
            {
                var SalesPeriod = await _dbContextInMemory.TransactionProduct
                    .Include(x => x.Product)
                    .Where(x => x.Transaction.TransactionDate.Date >= from.Date && x.Transaction.TransactionDate.Date <= To.Date)
                    .ToListAsync();

                if (SalesPeriod is null)
                {
                    message = $"Não foram encontradas vendas no período de: {from.Date} até: {To.Date}";
                    return (false, message, null);
                }

                return (true, message, SalesPeriod);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<TransactionProductEntity>?)> GetBiggestSaleForDate(DateTime Date)
        {
            string message = string.Empty;

            try
            {
                var BiggestsSalesForDate = await _dbContextInMemory.TransactionProduct
                    .Include(x => x.Product)
                    .ThenInclude(x => x.Sales)
                    .OrderByDescending(x => x.Product.Sales)
                    .Where(x => x.Transaction.TransactionDate.Date == Date.Date)
                    .ToListAsync();

                if (BiggestsSalesForDate is null)
                {
                    message = $"Não foram encontradas vendas na data: {Date.Date}";
                    return (false, message, null);
                }
                return (true, message, BiggestsSalesForDate);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }        
        }

        //Commands
        public async Task<(bool, string)> PostProduct(AdminCreateProductModel product)
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
