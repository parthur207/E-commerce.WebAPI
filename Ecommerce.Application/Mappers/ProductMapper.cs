
using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models.AdminModels;

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