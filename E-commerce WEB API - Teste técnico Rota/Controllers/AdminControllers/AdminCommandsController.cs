
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Domain.Models.AdminModels;
using Ecommerce.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers.AdminControllers
{
    [Authorize]
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

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("user/status/{idUser}")]
        public async Task<IActionResult> PutUserStatusInactive([FromRoute] int idUser, [FromBody]string Usermail)
        {
            var (status, message) = await _adminUserInterface.PutUserStatusToInactive(Usermail);

            if(status==false)
            {
                return BadRequest(message);
            }
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct([FromBody] AdminCreateProductModel model)
        {
            var (status, message) =await _adminProductInterface.PostProductAdmin(model);

            if (status == false)
            {
                return BadRequest(message);
            }
            return Created();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("product/Change/{idproduct}")]
        public async Task<IActionResult> PutProduct([FromRoute] int idproduct, [FromBody] AdminUpdateProductModel model)//Valor, nome, descrição e quantidade no estoque
        {

            var (status, message)=await _adminProductInterface.PutProductAdmin(idproduct, model);

            if (status == false)
            {
                return BadRequest(message);
            }
            return Ok();
        }


        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("product/status/{idproduct}")]
        public async Task<IActionResult> PutProductStatus([FromRoute]int idproduct, [FromBody] AdminUpdateProductStatusModel statusProduct)
        {

            var productStatus= statusProduct.ProductStatus;
            var (status, message)= await _adminProductInterface.PutProductStatusAdmin(idproduct, productStatus);

            if (status == false)
            {
                return BadRequest(message);
            }

            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("product/category/{idproduct}")]
        public async Task<IActionResult> PutProductCategory([FromRoute]int idproduct, [FromBody] AdminUpdateProductCategoryModel category)
        {
            var CategoryExtracted=category.NewCategory; 
            var (status, message)= await _adminProductInterface.PutProductCategoryAdmin(idproduct, CategoryExtracted);

            if (status == false)
            {
                return BadRequest(message);
            }

            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("product/newStock/{idproduct}}")]
        public async Task<IActionResult> PutProductStockTotal([FromRoute]int idproduct, [FromBody] int newStock)
        {
            return Ok();
        }

        //quando a transação for cancelada
        [Authorize(Roles =UsersRoles.Admin)]
        [HttpPut("product/stock/increase/{idproduct}")]
        public async Task<IActionResult> PutProductStockIncrease([FromRoute] int idproduct, [FromBody] int newStock)
        {
            return Ok();
        }

        //Quando a transação for aprovada/estiver pendente
        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("product/stock/decrease/{idproduct}")]
        public async Task<IActionResult> PutProductStockDecrease([FromRoute] int idproduct, [FromBody] int newStock)
        {
            return Ok();
        }


    } 
}
