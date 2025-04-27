
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Domain.Enuns;
using Ecommerce.Domain.Models.AdminModels;
using Ecommerce.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers.AdminControllers
{
    [Authorize]
    [ApiController]
    [Route("api/admin")]
    public class AdminQueriesController : ControllerBase
    {
        //Injeção de dependencia dos serviços do admin. (Todo o processo de administração dos dados ocorrerá por la)
        private readonly IAdminProductInterface _adminProductInterface;
        private readonly IAdminTransactionInterface _adminTransactionInterface;

        private readonly IAdminUserInterface _adminUserInterface;

        public AdminQueriesController(IAdminProductInterface adminProductInterface, IAdminTransactionInterface adminTransactionInterface, IAdminUserInterface adminUserInterface)
        {
            _adminProductInterface = adminProductInterface;
            _adminTransactionInterface = adminTransactionInterface;
            _adminUserInterface = adminUserInterface;
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("AllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var Response = await _adminUserInterface.GetAllUsers();
            if (Response.Item1 is false )
            {
                return BadRequest(Response.Item2);
            }

            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("QueryUser/email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string Email)
        {
            var Response = await _adminUserInterface.GetUserByEmail(Email);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("AllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var Response = await _adminTransactionInterface.GetAllTransactionsAdmin();

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Response = await _adminProductInterface.GetAllProductsAdmin();

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("QueryProduct/{ProductName}")]
        public async Task<IActionResult> GetProductByName([FromRoute] string ProductName)
        {

            var Response = await _adminProductInterface.GetProductByNameAdmin(ProductName);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/category/{category}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] ProductCategoryEnum category)
        {

            var Response = await _adminProductInterface.GetProductsByCategoryAdmin(category);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/price/{price}")]
        public async Task<IActionResult> GetProductsByPrice([FromRoute] decimal price)//produtos de 0 até value
        {
            var Response = await _adminProductInterface.GetProductsByPriceAdmin(price);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/NoStock")]
        public async Task<IActionResult> GetProductsNoStock()
        {
            var Response = await _adminProductInterface.GetProductsNoStockAdmin();

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/Inactive")]
        public async Task<IActionResult> GetProductsInactive()
        {
            var Response = await _adminProductInterface.GetProductsInactiveAdmin();

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/AllSales")]
        public async Task<IActionResult> GetSales()
        {
            var Response = await _adminProductInterface.GetSalesAdmin();
            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/sales/{productId}")]
        public async Task<IActionResult> GetSalesById([FromRoute] int productId)
        {
            var Response = await _adminProductInterface.GetSaleByIdAdmin(productId);
            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("products/sales/period")]
        public async Task<IActionResult> GetSalesByPeriod([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            //Formatação: yyyy - MM - dd HH: mm: ss
            var Response = await _adminProductInterface.GetSalesByPeriodAdmin(from, to);
            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);

        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("category/sales")]
        public async Task<IActionResult> GetSalesByCategory([FromQuery] AdminUpdateProductCategoryModel model)
        {
            var CategoryExtrait = model.Category;
            var Response = await _adminProductInterface.GetSalesByCategoryAdmin(CategoryExtrait);
            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);

        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("product/sales/topfive")]
        public async Task<IActionResult> GetTopFiveBiggestSale([FromQuery] AdminUpdateProductCategoryModel model)
        {
            var CategoryExtrait = model.Category;
            var Response = await _adminProductInterface.GetSalesByCategoryAdmin(CategoryExtrait);
            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpGet("product/biggestSale")]
        public async Task<IActionResult> GetBiggestSale()
        {

            var Response = await _adminProductInterface.GetBiggestSaleAdmin();
            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }
    }
}
