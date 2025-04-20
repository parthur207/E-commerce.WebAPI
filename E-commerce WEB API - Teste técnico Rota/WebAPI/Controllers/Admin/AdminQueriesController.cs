using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class AdminQueriesController : Controller
    {
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            return Ok();
        }

        [HttpGet("user/{idUser}")]
        public IActionResult GetUserById(int idUser)
        {
            return Ok();
        }

        [HttpGet("transactions")]
        public IActionResult GetAllTransactions()
        {
            return Ok();
        }

        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            return Ok();
        }

        [HttpGet("product/{IdProduct}")]
        public IActionResult GetProductById(int IdProduct)
        {
            return Ok();
        }

        [HttpGet("products/category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            return Ok();
        }

        [HttpGet("products/price/{value}")]
        public IActionResult GetProductsByValue(decimal value)//produtos de 0 até value
        {
            return Ok();
        }
        [HttpGet("products/NoStock")]
        public IActionResult GetProductsByStock()
        {
            return Ok();
        }

        [HttpGet("products/inactive")]
        public IActionResult GetProductsInactive()
        {
            return Ok();
        }


        /*
        HTTP GET: Vendas totais (Número de vendas e o rendimento pelas vendas).
        HTTP GET{id}: Venda de determinado produto (Número de vendas e o rendimento pelas vendas).
        HTTP GET{periodo}: Vendas filtradas por periodos
        HTTP GET: Produto com maior venda*/
    }
}
