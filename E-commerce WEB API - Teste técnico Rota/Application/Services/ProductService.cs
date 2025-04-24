using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Services
{
    public class ProductService : IProductInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;

        public ProductService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        public async Task<(bool,string, List<ProductDTO>?)> GetAllProducts()
        {   
            string message = string.Empty;
            try
            {
                List<ProductDTO> ListProductsDTO = new List<ProductDTO>();

                var ProductsEntityList = await _dbContextInMemory.Product.ToListAsync();

                if (ProductsEntityList is null)
                {
                    message = "Nenhum produto encontrado.";
                    return (false, message, null);
                }

                foreach (var p in ProductsEntityList)
                {
                    var ProductDTO = ProductMapper.ToProductDTO(p);
                    ListProductsDTO.Add(ProductDTO);
                }
                return (true, message, ListProductsDTO);
            }
            catch(Exception ex)
            {
                //nao acho legal, retornar um erro expection ao meu side-client... talvez seria legal, implementar uma funcionalidade que notifica o admin via email, etc..
                message = "Ocorreu um erro inesperado.";
                return (false, message, null);
            }
        }

        public async Task<(bool,string, ProductDTO?)> GetProductByName(string ProductName)
        {
            string message = string.Empty;
            try
            {

                var productEntity = await _dbContextInMemory.Product.FirstOrDefaultAsync(x => x.ProductName == ProductName);

                if (productEntity is null)
                {
                    message = "Nenhum produto foi encontrado.";
                    return (false, message, null);
                }

                var productDTO = ProductMapper.ToProductDTO(productEntity);
                return (true, message, productDTO);
            }
            catch
            {
                message = "Ocorreu um erro inesperado.";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<ProductDTO>?)> GetProductsByCategory(ProductCategoryEnum category)
        {
            string message = string.Empty;
            List<ProductDTO> ProductsList = new List<ProductDTO>();
            try
            {
                var productsCategoryEntity = await _dbContextInMemory.Product.Where(x => x.Category == category).ToListAsync();

                if(productsCategoryEntity is null)
                {
                    message = $"Nenhum produto da categoria '{category}' foi encontrado.";
                    return (false, message, null);
                }

                foreach (var p in productsCategoryEntity)
                {
                    var productDTO = ProductMapper.ToProductDTO(p);
                    ProductsList.Add(productDTO);
                }
                return (true, message, ProductsList);
            }
            catch
            {
                message = "Ocorreu um erro inesperado.";
                return (false, message, null);
            }
            
        }

        public async Task<(bool,string, List<ProductDTO>?)> GetProductsByPrice(decimal price)
        {
            string message = string.Empty;
            List<ProductDTO> productsList = new List<ProductDTO>();
            try
            {
                var ProductsByPrice= await _dbContextInMemory.Product.Where(x=>x.Price<=price).ToListAsync();

                if(ProductsByPrice is null)
                {
                    message = $"Não foram encontrados produtos com preços menores ou iguais a R$ {price}.";
                    return (false, message, null);
                }

                foreach(var p in ProductsByPrice)
                {
                    var productDTO= ProductMapper.ToProductDTO(p);
                    productsList.Add(productDTO);
                }

                return (true, message, productsList);
            }
            catch (Exception ex) {
                message = "Ocorreu um erro inesperado.";
                return (false, message, null);
            }
        }
    }
}
