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
    public class AdminProductService : IAdminProductInterface
    {

        private readonly IProductRepository _IProductRepository;
        public AdminProductService(IProductRepository IproductRepository)
        {
            _IProductRepository = IproductRepository;
        }

        //Queries
        public async Task<(bool, string, List<AdminProductDTO>?)> GetAllProductsAdmin()
        {
            List<AdminProductDTO> ListProducts = new List<AdminProductDTO>();
            string message = string.Empty;

            var Response = await _IProductRepository.GetAllProductsAsync();
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

        public async Task<(bool, string, List<AdminProductDTO>?)> GetAllProductsByStatusAdmin(ProductStatusEnum status)
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

        public async Task<(bool, string, AdminProductDTO?)> GetBiggestSaleAdmin()
        {
         
            string message = string.Empty;
            var Response = await _IProductRepository.GetBiggetSaleAsync();

            if (Response.Item1 is false)
            {
                message = Response.Item2;
                return (false, message, null);
            }
        
                var pDTO = ProductMapper.ToProductAdminDTO(Response.Item3);
   
            
            return (true, message, pDTO);
        }

        public async Task<(bool, string, AdminProductDTO?)> GetProductByNameAdmin(string productName)
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

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsByCategoryAdmin(ProductCategoryEnum category)
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

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsByPriceAdmin(decimal price)
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

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsInactiveAdmin()
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

        public async Task<(bool, string, List<AdminProductDTO>?)> GetProductsNoStockAdmin()
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

        public async Task<(bool, string, List<AdminProductDTO>?)> GetSalesAdmin()
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

        public async Task<(bool, string, AdminProductDTO?)> GetSaleByIdAdmin(int productIdSales)
        {
            string message = string.Empty;
            var Response = await _IProductRepository.GetSaleByProductIdAsync(productIdSales);

            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }

            var productMapped = ProductMapper.ToProductAdminDTO(Response.Item3);
            return (true, message, productMapped);
        }



        //Commands
        public async Task<(bool, string)> PostProductAdmin(AdminCreateProductModel product)
        {
            string message = string.Empty;
            var productEntity = ProductMapper.ToCreateProductEntity(product);

            if (productEntity is null)
            {
                message = "Erro ao criar o produto e falha no mapeamento.";
                return (false, message);
            }
            var Response = await _IProductRepository.AddProductAsync(productEntity);

            if (Response.Item1 is false)
            {
                message = Response.Item2;
                return (false, message);
            }
            message = "Produto criado com sucesso.";
            return (true, message);
        }

        public async Task<(bool, string)> PutProductAdmin(int ProductId, AdminUpdateProductModel model)
        {
            string message = string.Empty;

            var productEntity = ProductMapper.ToAdminUpdateProductEntity(model);

            if (productEntity is null)
            {
                message = "Erro ao atualizar o produto e falha no mapeamento.";
                return (false, message);
            }
            var Response = await _IProductRepository.UpdateProductAsync(ProductId, productEntity);

            if (Response.Item1 is false)
            {
                message = Response.Item2;
                return (false, message);
            }
            message = "Produto atualizado com sucesso.";
            return (true, message);
        }

        public async Task<(bool, string)> PutProductStatusAdmin(int idProduct, ProductStatusEnum status)
        {
            string message = string.Empty;
            var Response = await _IProductRepository.UpdateProductStatusAsync(idProduct, status);

            if (Response.Item1 is false)
            {
                message = Response.Item2;
                return (false, message);
            }
            message = "Produto atualizado com sucesso.";
            return (true, message);
        }
        public async Task<(bool, string)> PutProductCategoryAdmin(int idProduct, ProductCategoryEnum category)
        {
            string message = string.Empty;
            var Response = await _IProductRepository.UpdateProductCategoryAsync(idProduct, category);

            if (Response.Item1 is false)
            {
                message = Response.Item2;
                return (false, message);
            }

            message = "Produto atualizado com sucesso.";
            return (true, message);

        }
    }
}
