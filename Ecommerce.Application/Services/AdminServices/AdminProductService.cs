using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enuns;
using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Microsoft.VisualBasic;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Domain.Models.AdminModels;
using System.Collections.Generic;
using Ecommerce.Application.Mappers;
using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services.AdminServices
{
    public class AdminProductService : IAdminProductInterface, IAdminTransactionProductInterface
    {

        private readonly IProductRepository _IProductRepository;
        public AdminProductService(IProductRepository IproductRepository)
        {
            _IProductRepository = IproductRepository;
        }

        //Queries
        public async Task<(bool, string, List<AdminProductDTO>?)> GetAllProducts()
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            string message = string.Empty;

            var Response= await _IProductRepository.GetAllProductsAsync();
            if(Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO=ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }

        public async Task<(bool, string, List<AdminProductDTO>?)> GetAllProductsByStatus(ProductStatusEnum status)
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            string message = string.Empty;
            var Response = await _IProductRepository.GetProductsByStatusAsync(status);

            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }

        public async Task<(bool, string, List<AdminProductDTO>?)> GetBiggestSale()
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();   
            string message = string.Empty;
            var Response = await _IProductRepository.GetBiggestSaleAsync();

            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }

        public async Task<(bool, string, AdminProductDTO?)> GetProductByName(string productName)
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            string message = "Produto criado com sucesso.";

            var Response = await _IProductRepository.GetProductByNameAsync(productName);

            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            var productMapped = ProductMapper.ToProductAdminDTO(Response.Item3);

            return (true, message, productMapped);
        }

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsByCategory(ProductCategoryEnum category)
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            var message = string.Empty;
            var Response = await _IProductRepository.GetByProductsCategoryAsync(category);
            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsByPrice(decimal price)
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            var message = string.Empty;
            var Response = await _IProductRepository.GetProductsByPriceAsync(price);
            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsInactive()
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            string message = string.Empty;
            var Response = await _IProductRepository.GetProductsByStatusAsync(ProductStatusEnum.Inactive);
            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);

        }

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsNoStock()
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            string message = string.Empty;

            var Response = await _IProductRepository.GetProductsNoStockAsync();
            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }

        public async Task<(bool, string, List<AdminProductDTO>?)> GetSales()
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            string message = string.Empty;
            var Response = await _IProductRepository.GetSalesAsync();
            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductAdminDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }

        public async Task<(bool, string, AdminProductDTO?)> GetSaleById(int productIdSales)
        {
            string message=string.Empty;
            var Response = await _IProductRepository.GetSaleByIdAsync(productIdSales);

            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }

            var productMapped = ProductMapper.ToProductAdminDTO(Response.Item3);
            return (true, message, productMapped);
        }

        public async Task<(bool, string, List<TransactionDTO>?)> GetSalesByPeriod(DateTime from, DateTime To)
        {
            List<TransactionDTO> ListProducts = new List<TransactionDTO>();
            string message = string.Empty;

            var Response = await _IProductRepository.GetSalesByPeriodAsync(from, To);

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

        //Commands
        public async Task<(bool, string)> PostProduct(AdminCreateProductModel product)
        {
            
        }

        public async Task<(bool, string)> PutProduct(int ProductId, AdminUpdateProductModel model)
        {
          
        }

        public async Task<(bool, string)> PutProductStatus(int idProduct, ProductStatusEnum status)
        {
          
        }
        public async Task<(bool, string)> PutProductCategory(int idProduct, ProductCategoryEnum category)
        {
           
        }

        public Task<(bool, string, List<TransactionProductEntity>?)> GetBiggestSaleForDate(DateTime Date)
        {
            throw new NotImplementedException();
        }
    }
}
