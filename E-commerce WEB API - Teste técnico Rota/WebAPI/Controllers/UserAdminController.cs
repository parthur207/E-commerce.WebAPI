using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
   [ApiController]
   [Route("api/user")]
    public class UserAdminController : ControllerBase
    {
        
        [HttpPost("register")]
        public IActionResult PostRegister(CreateUserModel model)
        {
            //chama o service de login que retorna com o usuário específico
            //chamar o mappeamento do produto para model e retorna-lo
            return Created();
        }

        [HttpGet("login")]
        public IActionResult GetLogin(UserLoginModel model)
        {
            return Ok();
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPut("changePassword/{id}")]
        public IActionResult PutChangePassword(int id, UpdateUserPasswordModel model)//Pensar como estruturar esse 'put', tendo os 3 parametros email/senhaAtual e senhaNova, ou um model so pra update da senha
        {
            return Ok();
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPut("changeData")]
        public IActionResult PutChangeData(UpdateUserDataModel model)
        {
            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("inativeAccount/{id}")]
        public IActionResult PutInativeAccount(int id)
        {

            return Ok();
        }

    }
}
