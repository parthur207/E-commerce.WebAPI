using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.AdminInterfaces
{
    public interface IAdminTransactionProductInterface
    {
        Task<(bool, string, List<TransactionDTO>?)> GetBiggestSalesByPeriod(DateTime from, DateTime to);
        Task<(bool, string, List<TransactionDTO>?)> GetSalesByPeriod(DateTime from, DateTime To);
    }
}
