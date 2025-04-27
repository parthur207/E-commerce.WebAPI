using Azure.Core;
using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enuns;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextInMemory _dbContextInMemory;

        public ProductRepository(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        // Queries
        public async Task<(bool, string, ProductEntity?)> GetProductByNameAsync(string productName)
        {
            string message = string.Empty;
            try
            {
                var Product = await _dbContextInMemory.Product
                    .Where(x => x.ProductName == productName)
                    .FirstOrDefaultAsync();

                if (Product is null )
                {
                    message = "Nenhum produto encontrado.";
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

        public async Task<(bool, string, List<ProductEntity>?)> GetAllProductsAsync()
        {
            string message = string.Empty;
            try
            {
                var products = await _dbContextInMemory.Product.ToListAsync();
                if (products is null || !products.Any())
                {
                    message = "Não foram encontrados produtos.";
                    return (false, message, null);
                }

                return (true, message, products);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetByProductsCategoryAsync(ProductCategoryEnum category)
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

        public async Task<(bool, string, List<ProductEntity>?)> GetProductsByStatusAsync(ProductStatusEnum status)
        {
            string message = string.Empty;
            try
            {
                var productsStatus = await _dbContextInMemory.Product
                    .Where(x => x.ProductStatus == status)
                    .ToListAsync();
                if (productsStatus is null)
                {
                    message = "Nenhum produto encontrado.";
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

        public async Task<(bool, string, List<ProductEntity>?)> GetProductsByPriceAsync(decimal price)
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

        public async Task<(bool, string, List<ProductEntity>?)> GetProductsNoStockAsync()
        {
            string message = string.Empty;
            try
            {
                var ProductsNoStock = await _dbContextInMemory.Product
                    .Where(x => x.Stock == 0)
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

        public async Task<(bool, string, List<ProductEntity>?)> GetInactiveProductsAsync()
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

        // Consultas de vendas (para o admin)
        public async Task<(bool, string, List<ProductEntity>?)> GetSalesAsync()
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

        public async Task<(bool, string, ProductEntity?)> GetSaleByProductIdAsync(int productId)
        {
            string message = string.Empty;
            try
            {
                var productEntity = await _dbContextInMemory.Product
                   .FirstOrDefaultAsync(p => p.Id == productId);

                if (productEntity is null)
                {
                    return (false, message, null);
                }

                return (true, message, productEntity);
            }
            catch (Exception ex)
            {
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetSalesByPeriodAsync(DateTime from, DateTime to)
        {
            string message = string.Empty;
            try
            {
                var ProductsSales = await _dbContextInMemory.Product
                    .Where(x => x.Sales > 0 && x.CreatedAt >= from && x.CreatedAt <= to)
                    .ToListAsync();

                if (ProductsSales is null)
                {
                    message = $"Não foram encontrados produtos com vendas no período especificado.";
                    return (false, message, null);
                }
                return (true, message, ProductsSales);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetTopFiveSalesByPeriodAsync(DateTime from, DateTime to)
        {
            string message = string.Empty;
            try
            {
                var biggestSale = await _dbContextInMemory.Product
                    .Include(x => x.Sales)
                    .OrderByDescending(x => x.Sales)
                    .Take(5)
                    .ToListAsync();

                if (biggestSale is null)
                {
                    message = "Nenhuma venda encontrada.";
                    return (false, message, null);
                }
                return (true, message, biggestSale);
            }
            catch (Exception ex)
            {
                message = $"";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, ProductEntity?)> GetBiggetSaleAsync()
        {
            string message = string.Empty;
            try
            {
                var BiggestProductSold = await _dbContextInMemory.Product.OrderByDescending(x => x.Sales).FirstOrDefaultAsync();

                if (BiggestProductSold is null)
                {
                    message = "Nenhum produto encontrado.";
                    return (false, message, null);
                }

                return (true, message, BiggestProductSold);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductEntity>?)> GetSalesByCategoryAsync(ProductCategoryEnum category)
        {
            string message = string.Empty;
            try
            {
                var biggestSale = await _dbContextInMemory.Product
                    .Where(x => x.Category == category)
                    .OrderByDescending(x => x.Sales)
                    .ToListAsync();
                if (biggestSale is null)
                {
                    message = "Nenhuma venda encontrada.";
                    return (false, message, null);
                }
                return (true, message, biggestSale);
            }
            catch (Exception ex)
            {
                message = $"";
                return (false, message, null);
            }
        }


        //------------------------------------------------------------------------------------------------------

        // Commands
        public async Task<(bool, string)> AddProductAsync(ProductEntity product)
        {
            string message = string.Empty;
            try
            {
                await _dbContextInMemory.Product.AddAsync(product);
                await _dbContextInMemory.SaveChangesAsync();

                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Erro ao adicionar o produto. Erro: {ex.Message}";
                return (false, message);
            }
        }

        public async Task<(bool, string)> UpdateProductAsync(int ProductId, ProductEntity product)
        {
            try
            {
                if (product is null)
                {
                    return (false, "O produto não pode ser atualizado.");
                }

                var produtoEntity = await _dbContextInMemory.Product
                    .Where(x => x.Id == ProductId)
                    .FirstOrDefaultAsync();

                if (produtoEntity is null)
                {
                    return (false, "Produto não encontrado.");
                }

                await _dbContextInMemory.Product
                    .Where(x => x.Id == ProductId)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(x => x.ProductName, product.ProductName)
                        .SetProperty(x => x.Description, product.Description)
                        .SetProperty(x => x.Price, product.Price)
                        .SetProperty(x => x.Stock, product.Stock)
                        .SetProperty(x => x.ImageUrl, product.ImageUrl));
                await _dbContextInMemory.SaveChangesAsync();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao atualizar o produto: {ex.Message}");
            }
        }

        public async Task<(bool, string)> UpdateProductStatusToInativeAsync(int productId)
        {
            string message = string.Empty;
            try
            {
                var product = await _dbContextInMemory.Product.FindAsync(productId);
                if (product is null)
                {
                    message = "Produto não encontrado.";
                    return (false, message);
                }
                product.SetStatusProductToInative();
                _dbContextInMemory.Product.Update(product);
                await _dbContextInMemory.SaveChangesAsync();

                return (true, message);
            }
            catch (Exception ex)
            {
                message = "Erro ao atualizar o status do produto.";
                return (false, message);
            }
        }
        public async Task<(bool, string)> UpdateProductStatusToAtiveAsync(int productId)
        {
            string message = string.Empty;
            try
            {
                var product = await _dbContextInMemory.Product.FindAsync(productId);
                if (product is null)
                {
                    message = "Produto não encontrado.";
                    return (false, message);
                }
                product.SetStatusProductToActive();
                _dbContextInMemory.Product.Update(product);
                await _dbContextInMemory.SaveChangesAsync();

                return (true, message);
            }
            catch (Exception ex)
            {
                message = "Erro ao atualizar o status do produto.";
                return (false, message);
            }
        }

        public async Task<(bool, string)> UpdateProductStockTotalAdmin(int IdProduct, int newStock)
        {
            string message = string.Empty;
            try
            {
                var ProductEntity = await _dbContextInMemory.Product.FirstOrDefaultAsync(x=>x.Id==IdProduct);

                if (ProductEntity is null)
                {
                    message= "Produto não encontrado.";
                    return (false, message);
                }
                ProductEntity.SetStockProduct(newStock);
                _dbContextInMemory.Product.Update(ProductEntity);
                await _dbContextInMemory.SaveChangesAsync();

                message = "Estoque alterado com sucesso.";
                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }

        public async Task<(bool, string)> UpdateProductCategoryAsync(int productId, ProductCategoryEnum category)
        {
            string message = string.Empty;
            try
            {
                var product = await _dbContextInMemory.Product.FindAsync(productId);
                if (product is null)
                {
                    return (false, "Falha ao atualizar a categoria do produto.");
                }
                product.SetProductCategory(category);
                _dbContextInMemory.Product.Update(product);
                await _dbContextInMemory.SaveChangesAsync();

                return (true, "Categoria do produto atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a categoria do produto.", ex);
            }
        }
    }
}
