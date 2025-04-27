using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models.AdminModels
{
    public class TransactionProductModel
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
