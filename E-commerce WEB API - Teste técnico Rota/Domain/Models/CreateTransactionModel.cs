using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class CreateTransactionModel
    {
        public int UserId { get; set; }
        public List<TransactionProductEntity> ShoppingList { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalValue { get; set; }


        /*public string PaymentMethod { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryStatus { get; set; } = string.Empty;*/
    }
}
