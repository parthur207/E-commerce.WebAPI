using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Application.Mappers;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.AdminServices
{
    internal class AdminTransactionProductService : IAdminTransactionProductInterface
    {
        public Task<(bool, string, List<TransactionProductEntity>?)> GetBiggestSaleForDate(DateTime Date)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string, List<TransactionProductEntity>?)> GetSalesByPeriod(DateTime from, DateTime To)
        {
            List<TransactionDTO> ListProducts = new List<TransactionDTO>();
            string message = string.Empty;

            var Response = await _IProductRepository.Get(from, To);

            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = TransactionMapper.ToTransactionDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }


        public async Task<(bool, string, List<TransactionProductEntity>?)> GetBiggestSaleForPeriod(DateTime from, DateTime to)
        {
            List<TransactionProductEntity> ListProducts = new List<TransactionProductEntity>();

        }
    }
}
