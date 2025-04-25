using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.RepositoriesInterface
{
    internal interface ITransactionProductRepository
    {
        Task<(bool, string, List<TransactionProductEntity>?)> GetTopThreeSalesByDateAsync(DateTime from, DateTime to);
        Task<(bool, string, List<TransactionProductEntity>?)> GetSalesByPeriodAsync(DateTime from, DateTime to);
    }
}
