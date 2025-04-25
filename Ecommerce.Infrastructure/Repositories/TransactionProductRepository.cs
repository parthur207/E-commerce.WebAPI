using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    internal class TransactionProductRepository : ITransactionProductRepository
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public TransactionProductRepository(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        public async Task<(bool, string, List<TransactionProductEntity>?)> GetTopFiveSalesByDateAsync(DateTime from, DateTime to)
        {
            string message = string.Empty;
            try
            {
                var biggestSalesForDate = await _dbContextInMemory.TransactionProduct
                  .Include(x => x.Product)
                  .ThenInclude(x => x.Sales)
                  .Where(x => x.Transaction.TransactionDate.Date >= from.Date && x.Transaction.TransactionDate.Date <= to.Date)
                  .OrderByDescending(x => x.Product.Sales)
                  .Take(5)
                  .ToListAsync();

                if (biggestSalesForDate is null)
                {
                    message = "Não foram encontradas vendas dentro do período informado.";
                    return (false, message, null);
                }
                return (true, message, biggestSalesForDate);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<TransactionProductEntity>?)> GetSalesByPeriodAsync(DateTime from, DateTime to)
        {
            string message = string.Empty;
            try
            {
                var productsSales = await _dbContextInMemory.TransactionProduct
                     .Include(x => x.Product)
                     .ThenInclude(x => x.Sales)
                     .Where(x => x.Transaction.TransactionDate.Date >= from.Date && x.Transaction.TransactionDate.Date <= to.Date)
                     .ToListAsync();

                if (productsSales is null)
                {
                    message = $"Não foram encontrados produtos com vendas.";
                    return (false, message, null);
                }
                return (true, message, productsSales);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar produtos: {ex.Message}";
                return (false, message, null);
            }
        }
    }
}
