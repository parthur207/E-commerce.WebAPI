using Ecommerce.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models.AdminModels
{
    public class AdminUpdateProductStatusModel
    {
        [Required]
        public ProductStatusEnum ProductStatus { get; set; }
    }
}
