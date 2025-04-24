using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Enuns;

namespace Ecommerce.Application.DTOs.AdminDTOs
{
    public class AdminTransactionDTO
    {
        public List<TransactionProductSimpleDTO> ShoppingList { get; set; }
        public int UserId { get; set; }
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalValue { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
    }

}
