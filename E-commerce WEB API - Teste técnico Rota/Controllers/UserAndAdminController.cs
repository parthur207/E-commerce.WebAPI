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

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult PostRegister(CreateUserModel model)
        {
            //chama o service de login que retorna com o usuário específico
            //chamar o mappeamento do produto para model e retorna-lo
            return Created();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> GetLogin([FromBody] UserLoginModel model)
        {

            if (model.Email == "admin@teste.com" && model.Password == "12345")
            {
                
                var tokenAdmin =_jwtInterface.GenerateToken(1, UsersRoles.Admin);
                return Ok(new { Token = tokenAdmin });
            }

            if(model.Email=="user@teste.com" && model.Password == "12345")
            {
                var tokenUser = _jwtInterface.GenerateToken(2, UsersRoles.User);
                return Ok(new { Token = tokenUser });
            }

                var Response = await  _userInterface.LoginUser(model);

            if(Response.Item1 is false)
            {
                return BadRequest();
            }
            var userDatas = await _userInterface.GetDataUserByEmail(model.Email);


            var token =  _jwtInterface.GenerateToken(userDatas.Item2.Id, userDatas.Item2.Role);

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