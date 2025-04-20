using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity(string productName, string description, decimal price, int quantity, string category)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            Category = category;
            ProductStatus = ProductStatusEnum.Active;
        }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public ProductStatusEnum ProductStatus { get; set; }


        public void SetProductStatusInactive()
        {
            if (ProductStatus == ProductStatusEnum.Active || ProductStatus== ProductStatusEnum.OutOfStock)
            {
                ProductStatus = ProductStatusEnum.Inactive;
            }
        }

        public void SetProductStatusOutOfStock()
        {
            if (ProductStatus == ProductStatusEnum.Active)
            {
                ProductStatus = ProductStatusEnum.OutOfStock;
            }
        }

        public void SetProductStatusActive()
        {
            if (ProductStatus == ProductStatusEnum.Inactive || ProductStatus == ProductStatusEnum.OutOfStock)
            {
                ProductStatus = ProductStatusEnum.Active;
            }
        }   
    }
}
