using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class AdminCommandsController : Controller
    {
    
        [HttpPut("user/status")]
        public IActionResult UpdateUserStatus()
        {
            return Ok();
        }

        [HttpDelete("user")]
        public IActionResult DeleteUser()
        {
            return Ok();
        }

        [HttpPost("product")]
        public IActionResult CreateProduct()
        {
            return Created();
        }

        [HttpPut("product/{idproduct}/{status}")]
        public IActionResult UpdateProductStatus(int idproduct, string status)
        {
            return Ok();
        }



        /*HTTP PUT: Modificar atributo do produto (Valor, nome, quantidade no estoque).

        HTTP DELETE: Deletar produto

       */
    }
}
