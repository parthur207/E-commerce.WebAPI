namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin
{
    public class AdminProductDTO
    {
        public AdminProductDTO(string productName, string description, decimal price, int quantity, string category)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }

    }
}
