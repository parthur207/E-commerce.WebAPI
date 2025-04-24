using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces.AdminInterfaces
{
    public interface IAdminTransactionProductInterface
    {
        Task<(bool, string, List<TransactionProductEntity>?)> GetBiggestSaleForDate(DateTime Date);
        Task<(bool, string, List<TransactionProductEntity>?)> GetSalesByPeriod(DateTime from, DateTime To);
    }
}
