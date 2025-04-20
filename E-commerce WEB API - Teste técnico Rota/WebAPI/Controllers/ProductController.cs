using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {

        //injeção de dependência do service:
        /*private readonly _productService;
         
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
         */


        [HttpPost]
        public IActionResult Post

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
