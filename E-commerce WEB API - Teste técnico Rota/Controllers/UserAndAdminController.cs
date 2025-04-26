using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Application.Services.CommomServices;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Roles;
using Ecommerce.Infrastructure.Auth.JwtInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserAndAdminController : ControllerBase
    {

        private readonly IUserInterface _userInterface;

        private readonly IJwtInterface  _jwtInterface;

        public UserAndAdminController(IUserInterface userInterface, IJwtInterface jwtInterface)
        {
            _userInterface = userInterface;
            _jwtInterface = jwtInterface;
        }

        [HttpPost("register")]
        public IActionResult PostRegister(CreateUserModel model)
        {
            //chama o service de login que retorna com o usuário específico
            //chamar o mappeamento do produto para model e retorna-lo
            return Created();
        }

        [HttpPost("login")]
        public async IActionResult GetLogin([FromBody] UserLoginModel model)
        {

            var Response = await _userInterface.LoginUser(model);

            if(Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            var userDatas=_user
            var token = _jwtInterface.GenerateToken(Response.Id, user.Role);

            return Ok(new { Token = token });
      
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpPut("changePassword/{id}")]
        public IActionResult PutChangePassword(UpdateUserPasswordModel model)//Pensar como estruturar esse 'put', tendo os 3 parametros email/senhaAtual e senhaNova, ou um model so pra update da senha
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpPut("changeData")]
        public IActionResult PutChangeData(UpdateUserDataModel model)
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("inativeAccount/{id}")]
        public IActionResult PutInativeAccount(int id)
        {

            return Ok();
        }

    }
}