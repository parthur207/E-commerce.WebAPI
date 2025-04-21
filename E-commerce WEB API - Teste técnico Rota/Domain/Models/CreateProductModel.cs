using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class CreateProductModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public ProductCategoryEnum Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
