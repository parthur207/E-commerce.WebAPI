using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class SaleEntity : BaseEntity
    {
        public SaleEntity(int productId, ProductEntity product, int userId, UserEntity user, int quantity, decimal totalValue)
        {
            ProductId = productId;
            Product = product;
            UserId = userId;
            User = user;
            SaleDate = DateTime.Now;
            Quantity = quantity;
            TotalValue = totalValue;
        }

        public int ProductId { get; set; }
        public ProductEntity Product { get; private set; }
        public int UserId { get; private set; }
        public UserEntity User { get; private set; }
        public DateTime SaleDate { get; private set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; private set; }


 
    }
}
