using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Domain.Enuns;

namespace Ecommerce.Application.Services.CommomServices
{
    public class ProductService : IProductInterface
    {

        private readonly IProductRepository _IproductRepository;

        public ProductService(IProductRepository IProductRepository)
        {
            _IproductRepository = IProductRepository;
        }

        public async Task<(bool,string, List<ProductDTO>?)> GetAllProducts()
        {   
            string message = string.Empty;
            List<ProductDTO> ProductsAllDTO = new List<ProductDTO>();
            try
            {
                var Response = await _IproductRepository.GetAllProductsAsync();

                if (Response.Item1 is false)
                {
                    message = "Nenhum produto encontrado.";
                    return (false, message, null);
                }

                foreach (var p in Response.Item3)
                {
                    var ProductDTO = ProductMapper.ToProductDTO(p);
                    ProductsAllDTO.Add(ProductDTO);
                }
                return (true, message, ProductsAllDTO);
            }
            catch
            {
                //nao acho legal, retornar um erro expection ao meu side-client... talvez seria legal, implementar uma funcionalidade que notifica o admin via email, etc..
                message = "Ocorreu um erro inesperado.";
                return (false, message, null);
            }
        }

        public async Task<(bool,string, ProductDTO?)> GetProductByName(string productName)
        {
            string message = string.Empty;
            try
            {
                var Response= await _IproductRepository.GetProductByNameAsync(productName);

                if (Response.Item1 is false)
                {
                    message = $"Nenhum produto com o nome '{productName}' foi encontrado.";
                    return (false, message, null);
                }

                var productDTO = ProductMapper.ToProductDTO(Response.Item3);
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
            List<ProductDTO> ListProducts = new List<ProductDTO>();
            var message = string.Empty;
            var Response = await _IproductRepository.GetByProductsCategoryAsync(category);
            if (Response.Item3 is null)
            {
                message = Response.Item2;
                return (false, message, null);
            }
            foreach (var p in Response.Item3)
            {
                var pDTO = ProductMapper.ToProductDTO(p);
                ListProducts.Add(pDTO);
            }
            return (true, message, ListProducts);
        }
            
        

        public async Task<(bool, string, List<ProductDTO>?)> GetProductsByPrice(decimal price)
        {
            string message = string.Empty;
            List<ProductDTO> productsList = new List<ProductDTO>();

            var Response = await _IproductRepository.GetProductsByPriceAsync(price);

            if (Response.Item1 is false)
            {
                message = $"Nenhum produto dentro do valor estipulado (R$ 0.00 a R$ {price}).";
                return (false, message, null);
            }

            foreach (var p in Response.Item3)
            {
                var productMappedDTO = ProductMapper.ToProductDTO(p);
                productsList.Add(productMappedDTO);
            }

            return (true, message, productsList);
        }
    }
}
