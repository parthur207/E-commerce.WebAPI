using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Services;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {

        private readonly IProductInterface _productService;

        public ProductController(IProductInterface productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            //chama o service de get que retorna com a lista de todos os produtos
            return Ok("Lista de produtos");
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("search")]
        public IActionResult GetProductById(string search)
        {
            //chama o service de get que retorna com o produto específico

            /*if(productentity is null)
             {
                return NotFound("Produto não encontrado");
             }
             */

            //chamar o mappeamento do produto para model e retorna-lo
            return Ok("Produto específico");
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("{category}")]
        public IActionResult GetProductsByCategory(string category)
        {

            return Ok();
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("price")]
        public IActionResult GetProductsByPrice(decimal price)//Pegar todos os produtos de 0 a {price}
        {
          //chama o service
            /*if(productentity is null)
             {
                return NotFound("Produto não encontrado");
             }
             */
            //chamar o mappeamento do produto para model e retorna-lo
            return Ok("Produto específico");
        }




    }
}
