using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models.AdminModels;

public static class ProductMapper
{
    public static ProductDTO ToProductDTO(ProductEntity product)
    {
        return new ProductDTO(
            product.ProductName,
            product.Description,
            product.Price,
            product.Category
        );
    }

    public static AdminProductDTO ToProductAdminDTO(ProductEntity product)
    {
        return new AdminProductDTO(
            product.ProductName,
            product.Description,
            product.Price,
            product.Stock,
            product.Sales,
            product.Category,
            product.ImageUrl,
            product.ProductStatus
        );
    }

    public static ProductEntity ToCreateProductEntity(AdminCreateProductModel model)
    {
        return new ProductEntity(
            model.ProductName,
            model.Description,
            model.Price,
            model.Quantity,
            model.Category,
            model.ImageUrl
        );
    }

    public static ProductEntity ToAdminUpdateProductEntity(AdminUpdateProductModel model)
    {
        return new ProductEntity(
            model.ProductName,
            model.Description,
            model.Price,
            model.Quantity,
            model.Category,
            model.ImageUrl
        );
    }
}