using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        [Authorize(Roles = UsersRoles.User)]
        [HttpPost("newTransaction")]
        public IActionResult PostTransaction([FromBody] CreateTransactionModel model)
        {

            return Created();
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpGet("all")]
        public IActionResult GettAllTransaction()
        {
            return Ok();
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpPut("chanseStatus/{id}")]
        public IActionResult PutTransactionToCanceled(int id)
        {
            return Ok();
        }

    }
}
