using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminTransactionProductInterface
    {
        Task<List<TransactionProductEntity>> GetBiggestSaleForDate(DateTime Date);
        Task<List<TransactionProductEntity>> GetSalesByPeriod(DateTime from, DateTime To);
    }
}
