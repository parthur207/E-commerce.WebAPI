using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models.AdminModels
{
    public class AdminBiggestProductSalesModel
    {
        [DataType(DataType.Date)]
        [Required]
        public DateOnly From { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateOnly To { get; set; }
    }
}
