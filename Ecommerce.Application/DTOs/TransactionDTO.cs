
using Ecommerce.Domain.Enuns;

namespace Ecommerce.Application.DTOs
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
