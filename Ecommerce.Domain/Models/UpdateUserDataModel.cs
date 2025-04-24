using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models
{
    public class UpdateUserDataModel
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public int? Phone { get; set; }

    }
}
