using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs
{
    public class UserTransactionSummaryDTO
    {
        public int TransactionId { get; set; }
        public string ProductName { get; set; }
        public ProductCategoryEnum Category { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPaid { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }
}
