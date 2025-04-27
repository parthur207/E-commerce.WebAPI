using Ecommerce.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.AdminDTOs
{
    public class AdminProductSalesDTO
    {

        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Sales { get; private set; }
        public ProductCategoryEnum Category { get; private set; }
        public string? ImageUrl { get; private set; }
        public ProductStatusEnum ProductStatus { get; private set; }
    }
}
