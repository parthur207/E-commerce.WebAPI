namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class TransactionProductEntity
    {
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
