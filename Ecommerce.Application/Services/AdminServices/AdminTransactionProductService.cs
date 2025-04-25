using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
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
        private readonly ITransactionProductRepository _transactionProductRepository;

        public AdminTransactionProductService(ITransactionProductRepository transactionProductRepository)
        {
            _transactionProductRepository = transactionProductRepository;
        }

        public  async Task<(bool, string, List<AdminProductDTO>?)> GetSalesByPeriod(DateTime from, DateTime To)
        {
            List<AdminProductDTO> ListProducts = new List<TransactionProductEntity>();
            string message = string.Empty;

            var Response = await _transactionProductRepository.GetSalesByPeriodAsync(from, To);

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


        public async Task<(bool, string, List<TransactionProductEntity>?)> GetBiggestSalesByPeriod(DateTime from, DateTime to)
        {
            List<TransactionProductEntity> ListProducts = new List<TransactionProductEntity>();

        }
    }
}
