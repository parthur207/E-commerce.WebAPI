using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Roles;
using Ecommerce.Infrastructure.ExternalService.InterfaceNotification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/transaction")]
   
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionInterface _transactionInterface;
        private readonly INotificationInterface _notificationInterface;
        public TransactionController(ITransactionInterface transactionInterface, INotificationInterface notificationInterface)
        {
            _transactionInterface = transactionInterface;
            _notificationInterface = notificationInterface;
        }


        [Authorize(Roles = UsersRoles.User)]
        [HttpPost("newTransaction")]
        public async Task<IActionResult> PostTransaction( [FromBody] CreateTransactionModel model)
        {
            var userId = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value);

            var Response = await _transactionInterface.PostTransaction(model, userId);

            if (Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }

            return Ok(Response.Item2);
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpGet("user/all")]
        public async Task<IActionResult> GettAllTransaction()
        {
            var userId = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value);
            var Response = await _transactionInterface.GetAllTransactions(userId);

            if(Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }
            return Ok(Response.Item3);
        }

        [Authorize(Roles = UsersRoles.User)]
        [HttpPut("chanseStatus/{id}")]
        public async Task <IActionResult> PutTransactionToCanceled(int idTransaction)
        {
            var userId = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value);
            var Response= await _transactionInterface.PutTransactionStatusToCanceled(idTransaction, userId);

            if(Response.Item1 is false)
            {
                return BadRequest(Response.Item2);
            }

            return Ok(Response.Item2);
        }

    }
}
