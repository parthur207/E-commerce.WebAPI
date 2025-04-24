using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models.AdminModels
{
    public class AdminUpdateProductModel
    {
       public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductCategoryEnum Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
