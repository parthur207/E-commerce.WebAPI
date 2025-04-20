using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin
{
    public interface IAdminProductInterface
    {
        ProductDTO GetAllProducts();
        //admin
        ProductDTO GetAllProductsByStatus();


    }
}
