using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity(string productName, string description, decimal price, int stock, string imageUrl) 
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Stock = stock;
            ImageUrl = imageUrl;
        }

        public ProductEntity(string productName, string description, decimal price, int stock, ProductCategoryEnum category, string? imageUrl)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Stock = stock;
            Sales = 0;
            Category = category;
            ImageUrl = imageUrl;
            ProductStatus = ProductStatusEnum.Active;
            TransactionProducts = new List<TransactionProductEntity>();
        }

        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; } 
        public int Sales { get; private set; }

        public List<TransactionProductEntity> TransactionProducts { get; private set; }
        public ProductCategoryEnum Category { get; private set; }
        public string? ImageUrl { get; private set; }
        public ProductStatusEnum ProductStatus { get; private set; }
       
        public void SetSalesProduct(int n)
        {
            if (n > 0)
            {
                Sales += n;
            }
        }
        public void SetStockProduct(int Unit)
        {
            Stock += Unit;
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

        public void SetProductStatus(ProductStatusEnum status)
        {
            ProductStatus = status;
        }
    }
}
