using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs
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
