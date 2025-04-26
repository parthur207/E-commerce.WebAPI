using Ecommerce.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Domain.Entities
{
    public class ProductEntity
    {
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
            TransactionProductsList = new List<TransactionProductEntity>();
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public int Sales { get; private set; }
        public ProductCategoryEnum Category { get; private set; }
        public string? ImageUrl { get; private set; }
        public ProductStatusEnum ProductStatus { get; private set; }
        public List<TransactionProductEntity> TransactionProductsList { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public void SetSalesProduct(int n)
        {
            if (n > 0)
            {
                Sales += n;
            }
        }

        public void SetStockProduct(int unit)
        {
            Stock += unit;
        }

        public void SetProductCategory(ProductCategoryEnum category)
        {
            Category = category;
        }

        public void SetImageUrl(string imageUrl)
        {
            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                ImageUrl = imageUrl.Trim();
            }
        }

        public void SetStatusProductToInative()
        {
                ProductStatus = ProductStatusEnum.Inactive;
        }

        public void SetStatusProductToActive()
        {
            ProductStatus = ProductStatusEnum.Active;
        }

        public void SetStatusProductToNoStock()
        {
            ProductStatus = ProductStatusEnum.OutOfStock;
        }
    }
}
