using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Persistence;
using Microsoft.VisualBasic;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers
{
    public class ProductMapper
    {

        public static ProductDTO ToProductDTO(ProductEntity product)//Um pra exibir ao cliente
        {
            return new ProductDTO
            (
                product.ProductName,
                product.Description,
                product.Price,
                product.Category
            );
        }

        public static AdminProductDTO ToProductAdminDTO(ProductEntity product)//Outro pra exibir ao Admin
        {
            return new AdminProductDTO
            (
                product.ProductName,
                product.Description,
                product.Price,
                product.Quantity,
                product.Category
            );
        }

        public static ProductEntity FromProductModel(CreateProductModel productModel)//Criação de um NOVO produto
        {
            return new ProductEntity(productModel.ProductName,
                productModel.Description,
                productModel.Price,
                productModel.Quantity,
                productModel.Category,
                productModel.ImageUrl);
        }

        public static ProductEntity FromUpdateProductModel(UpdateProductModel model)
        {
            return new ProductEntity(model.ProductName,
              model.Description,
              model.Price,
              model.Quantity,
              model.ImageUrl);
        }

        //criar mappers do update model
    }
}
    
