using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
   [ApiController]
   [Route("api/user")]
    public class UserController : Controller
    {
        [HttpPost("register")]
        public IActionResult PostRegister(CreateUserModel model)
        {
            //chama o service de login que retorna com o usuário específico
            //chamar o mappeamento do produto para model e retorna-lo
            return Created();
        }

        [HttpGet("login")]
        public IActionResult GetLogin(string email, string password)
        {
            return Ok();
        }

        [HttpPut("changePassword/{id}")]
        public IActionResult PutChangePassword(int id, UserUpdatePasswordModel model)//Pensar como estruturar esse 'put', tendo os 3 parametros email/senhaAtual e senhaNova, ou um model so pra update da senha
        {
            return Ok();
        }


        [HttpPut("changeData")]
        public IActionResult PutChangeData(UserUpdateDataModel model)
        {
            return Ok();
        }

        [HttpPut("inativeAccount/{id}")]
        public IActionResult PutInativeAccount(int id)
        {

            return Ok();
        }

    }
}
