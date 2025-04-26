using Ecommerce.Application.Interfaces.RepositoriesInterface;
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
        private readonly ITransactionRepository _transactionRepository;
        private readonly INotificationInterface _notificationInterface;
        public TransactionController(ITransactionRepository transactionRepository, INotificationInterface notificationInterface)
        {
            _transactionRepository = transactionRepository;
            _notificationInterface = notificationInterface;
        }


        [Authorize(Roles = UsersRoles.User)]
        [HttpPost("newTransaction")]
        public IActionResult PostTransaction( [FromBody] CreateTransactionModel model)
        {
            var userId = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value);


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
