namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class TransactionProductEntity : BaseEntity
    {
        public TransactionProductEntity(int transactionId, int productId, int quantity)
        {
            TransactionId = transactionId;
            ProductId = productId;
            Quantity = quantity;
        }
        public int TransactionId { get; private set; }
        public TransactionEntity Transaction { get; private set; }

        public int ProductId { get; private set; }
        public ProductEntity Product { get; private set; }

        public int Quantity { get; private set; }

       
    }
}
