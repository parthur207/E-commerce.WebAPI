using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs
{
    public class TransactionDTO
    {
        public List<TransactionProductSimpleDTO> ShoppingList { get; set; }
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalValue { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }

}
