using Ecommerce.Domain.Models;
using Ecommerce.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        [Authorize(Roles = UsersRoles.User)]
        [HttpPost("newTransaction")]
        public IActionResult PostTransaction(int iduser, [FromBody] CreateTransactionModel model)
        {

            return Created();
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpGet("all")]
        public IActionResult GettAllTransaction(int iduser)
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
