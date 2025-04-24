using Ecommerce.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models.AdminModels
{
    public class AdminCreateProductModel
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
        public string? ImageUrl { get; set; }
    }
}
