using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models
{
    public class CreateTransactionModel
    {

        [Required]
        public List<TransactionProductEntity> ShoppingList { get; set; }

        /*public string PaymentMethod { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryStatus { get; set; } = string.Empty;*/
    }
}
