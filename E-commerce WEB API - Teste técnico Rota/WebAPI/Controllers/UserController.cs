using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
   [ApiController]
   [Route("api/user")]
    public class UserController : Controller
    {
        [HttpPost("register")]
        public IActionResult PostRegister(UserModel model)
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

        [HttpPut("changePassword")]
        public IActionResult PutChangePassword(string email, string passwordCurrent, string newPassword)//Pensar como estruturar esse 'put', tendo os 3 parametros atuais, ou um model so pra update da senha
        {

            return Ok();
        }


        [HttpPut("changeData")]
        public IActionResult PutChangeData(string name, DateTime birthDate, string phone, string address)
        {
            return Ok();
        }

    }
}
