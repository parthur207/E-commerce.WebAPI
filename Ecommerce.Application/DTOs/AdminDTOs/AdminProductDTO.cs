using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Enuns;   

namespace Ecommerce.Application.DTOs.AdminDTOs
{
    public class AdminProductDTO
    {
        public AdminProductDTO(string productName, string description, decimal price, int quantity, int sales, ProductCategoryEnum category, string imagemUrl, ProductStatusEnum productStatus)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            Sales = sales;
            Category = category;
            ImageUrl=imagemUrl;
            ProductStatus = productStatus;
        }


        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public int Sales { get; private set; }
        public ProductCategoryEnum Category { get; private set; }
        public string? ImageUrl { get; private set; }
        public ProductStatusEnum ProductStatus { get; private set; }

    }
}
