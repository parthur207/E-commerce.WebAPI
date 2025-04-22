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
        [Authorize(Roles = UserRoles.User)]
        [HttpPost("newTransaction")]
        public IActionResult PostTransaction(CreateTransactionModel model)
        {

            return Created();
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("all")]
        public IActionResult GettAllTransaction()
        {
            return Ok();
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPut]
        public IActionResult PutTransactionToCanceled(int id)
        {
            return Ok();
        }

    }
}
