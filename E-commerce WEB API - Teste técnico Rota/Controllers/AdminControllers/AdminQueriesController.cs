
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminQueriesController : ControllerBase
    {
        //Injeção de dependencia dos serviços do admin. (Todo o processo de administração dos dados ocorrerá por la)
        private readonly IAdminProductInterface _adminProductInterface;
        private readonly IAdminTransactionInterface _adminTransactionInterface;
        private readonly IAdminTransactionProductInterface _adminTransactionProductInterface;
        private readonly IAdminUserInterface _adminUserInterface;

        public AdminQueriesController(IAdminProductInterface adminProductInterface, IAdminTransactionInterface adminTransactionInterface, 
            IAdminTransactionProductInterface adminTransactionProductInterface, IAdminUserInterface adminUserInterface)
        {
            _adminProductInterface = adminProductInterface;
            _adminTransactionInterface = adminTransactionInterface;
            _adminTransactionProductInterface = adminTransactionProductInterface;
            _adminUserInterface = adminUserInterface;
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            

            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("user/{idUser}")]
        public IActionResult GetUserById([FromRoute]int idUser)
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("transactions")]
        public IActionResult GetAllTransactions()
        {
            return Ok();
        }

        [Authorize(Roles =UsersRoles.Admin)]
        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("product/{IdProduct}")]
        public IActionResult GetProductById([FromRoute]int IdProduct)
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/category/{category}")]
        public IActionResult GetProductsByCategory([FromRoute]string category)
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/price/{value}")]
        public IActionResult GetProductsByPrice([FromRoute] decimal price)//produtos de 0 até value
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/NoStock")]
        public IActionResult GetProductsNoStock()
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/inactive")]
        public IActionResult GetProductsInactive()
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("transactions/sales")]
        public IActionResult GetSales()
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("transactions/sales/{productId}")]
        public IActionResult GetSalesById([FromRoute] int productId)
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("transactions/sales/period")]
        public IActionResult GetSalesByPeriod([FromQuery] DateOnly from, [FromQuery] DateOnly to)
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("product/biggestSale")]
        public IActionResult GetBiggestSale()
        {
            return Ok();
        }
    }
}
