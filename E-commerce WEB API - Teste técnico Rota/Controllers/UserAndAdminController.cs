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
        public async Task<IActionResult> PutChangePassword(UpdateUserPasswordModel model)//Pensar como estruturar esse 'put', tendo os 3 parametros email/senhaAtual e senhaNova, ou um model so pra update da senha
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
        public IActionResult PutChangeData(UpdateUserDataModel model)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return Ok();
        }

        [Authorize(Roles = UsersRoles.Admin)]
        [HttpPut("inativeAccount/{id}")]
        public async Task<IActionResult> PutInativeAccount(string email)
        {
            var Response = await _userInterface.Put(email);
            return Ok();
        }

    }
}