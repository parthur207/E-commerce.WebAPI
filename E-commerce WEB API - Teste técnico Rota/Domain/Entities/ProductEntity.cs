using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity(string productName, string description, decimal price, int quantity, ProductCategoryEnum category, string? imageUrl)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            Category = category;
            ImageUrl = imageUrl;
            ProductStatus = ProductStatusEnum.Active;
        }

        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; } 
        public ProductCategoryEnum Category { get; private set; }
        public string? ImageUrl { get; private set; } 
        public ProductStatusEnum ProductStatus { get; private set; }
       
        public void SetStockProduct(int quantity)
        {
            Quantity += quantity;
        }
        public void SetProductCategory(ProductCategoryEnum category)
        {
            this.Category = category;
        }

        public void SetImageUrl(string imageUrl)
        {
            if (imageUrl.Count()>0)
            {
                ImageUrl = imageUrl.Trim();
            }
        }

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
