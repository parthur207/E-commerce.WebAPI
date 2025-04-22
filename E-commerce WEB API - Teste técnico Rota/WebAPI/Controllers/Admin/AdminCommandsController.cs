using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class AdminCommandsController : ControllerBase
    {
        //Injeção
        private readonly IAdminProductInterface _adminProductInterface;
        private readonly IAdminTransactionInterface _adminTransactionInterface;
        private readonly IAdminUserInterface _adminUserInterface;

        public AdminCommandsController(IAdminProductInterface adminProductInterface, IAdminTransactionInterface adminTransactionInterface, IAdminUserInterface adminUserInterface)
        {
            _adminProductInterface = adminProductInterface;
            _adminTransactionInterface = adminTransactionInterface;
            _adminUserInterface = adminUserInterface;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("user/status/{idUser}")]
        public async Task<IActionResult> PutUserStatusInactive(string email)
        {
            var (status, message) = await _adminUserInterface.PutUserStatusToInactive(email);

            if(status==false)
            {
                return BadRequest(message);
            }
            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct(CreateProductModel model)
        {
            var (status, message)=await _adminProductInterface.PostProduct(model);

            if (status == false)
            {
                return BadRequest(message);
            }
            return Created();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("product/Change/{idproduct}")]
        public async Task<IActionResult> PutProduct(int idproduct, UpdateProductModel model)//Valor, nome, descrição e quantidade no estoque
        {

            var (status, message)=await _adminProductInterface.PutProduct(idproduct, model);

            if (status == false)
            {
                return BadRequest(message);
            }
            return Ok();
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("product/status/{idproduct}")]
        public async Task<IActionResult> PutProductStatus(int idproduct, ProductStatusEnum statusProduct)
        {
            var (status, message)= await _adminProductInterface.PutProductStatus(idproduct, statusProduct);

            if (status == false)
            {
                return BadRequest(message);
            }

            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("product/category/{idproduct}")]
        public async Task<IActionResult> PutProductCategory(int idproduct, ProductCategoryEnum category)
        {
            var (status, message)= await _adminProductInterface.PutProductCategory(idproduct, category);

            if (status == false)
            {
                return BadRequest(message);
            }

            return Ok();
        }
    } 
}
