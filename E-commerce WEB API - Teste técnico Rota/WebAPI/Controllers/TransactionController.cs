using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        [HttpPost("newTransaction")]
        public IActionResult PostTransaction(CreateTransactionModel model)
        {

            return Created();
        }

        [HttpGet("all")]
        public IActionResult GettAllTransaction()
        {
            return Ok();
        }


        [HttpPut]
        public IActionResult PutTransactionToCanceled(int id)
        {
            return Ok();
        }

    }
}
