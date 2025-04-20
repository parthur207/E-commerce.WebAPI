using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Services;
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

        [HttpPost]
        public IActionResult PostProduct()
        {
            return Created();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            //chama o service de get que retorna com a lista de todos os produtos
            return Ok("Lista de produtos");
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
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

        [HttpGet]
        public IActionResult GetProductsByCategory(string Category)
        {

            return Ok();
        }



    }
}
