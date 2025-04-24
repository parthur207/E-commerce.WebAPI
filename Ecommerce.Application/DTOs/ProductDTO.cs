using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Enuns;

namespace Ecommerce.Application.DTOs
{
    public class ProductDTO
    {
        public ProductDTO(string productName, string description, decimal price, ProductCategoryEnum category)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Category = category;
        }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryEnum Category { get; set; }

    }
}
