using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Application.Services.CommomServices;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Roles;
using Ecommerce.Infrastructure.Auth.JwtInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly IUserInterface _userInterface;

        private readonly IJwtInterface  _jwtInterface;

        public UserController(IUserInterface userInterface, IJwtInterface jwtInterface)
        {
            _userInterface = userInterface;
            _jwtInterface = jwtInterface;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task <IActionResult> PostRegister(CreateUserModel model)
        {
            if (model is null)
            {
                return BadRequest("Falha no cadastro. Dados ausentes.");
            }
            var Response = await _userInterface.AddUser(model);
            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }

            return Ok(Response.Item2);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> GetLogin([FromBody] UserLoginModel model)
        {

            if (model.Email == "admin@teste.com" && model.Password == "12345")
            {
                
                var tokenAdmin =_jwtInterface.GenerateToken(100, UsersRoles.Admin);
                return Ok(new {Resposta="Login efetuado com sucesso", Token = tokenAdmin });
            }
           

                var Response = await  _userInterface.LoginUser(model);

            if(Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            var userDatas = await _userInterface.GetDataUserByEmail(model.Email);


            var token =  _jwtInterface.GenerateToken(userDatas.Item2.Id, userDatas.Item2.Role);

            return Ok( new { Resposta="Login efetuado com sucesso.", 
                Token = token });
      
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpPut("changePassword")]
        public async Task<IActionResult> PutChangePassword([FromBody]UpdateUserPasswordModel model)//Pensar como estruturar esse 'put', tendo os 3 parametros email/senhaAtual e senhaNova, ou um model so pra update da senha
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var Response = await _userInterface.UpdatePasswordUser(model, userId);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item2);
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpPut("changeData")]
        public async Task<IActionResult> PutChangeData(UpdateUserDataModel model)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var Response = await _userInterface.PutUserData(model, userId);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item2);
        }
    }
}