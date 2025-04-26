using Ecommerce.Domain.Enuns;

namespace Ecommerce.Domain.Models.AdminModels
{
    public class AdminUpdateProductModel
    {
       public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public ProductCategoryEnum Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
