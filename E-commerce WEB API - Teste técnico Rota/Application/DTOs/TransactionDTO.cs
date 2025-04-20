using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs
{
    public class TransactionDTO
    {
        public int ProductId { get; set; }
        public int UserId { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; private set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }
}
