namespace Ecommerce.Domain.Entities
{
    public class TransactionProductEntity
    {
        public TransactionProductEntity(int transactionId, int productId, int quantiy)
        {
            TransactionId = transactionId;
            ProductId = productId;
            Quantity = quantiy;
        }
        public int TransactionId { get; set; }
        public TransactionEntity Transaction { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public int Quantity { get; set; }

        public TransactionProductEntity() { }

        public TransactionProductEntity(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
