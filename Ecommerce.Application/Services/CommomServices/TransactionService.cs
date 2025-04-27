using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Application.Interfaces.UserInterfaces;
using Ecommerce.Application.Mappers;
using Ecommerce.Domain.Models;
using System.Linq.Expressions;

namespace Ecommerce.Application.Services.CommomServices
{
    public class TransactionService : ITransactionInterface
    {

        private readonly ITransactionRepository _ItransactionRepository;

        public TransactionService(ITransactionRepository ItransactionRepository)
        {
            _ItransactionRepository = ItransactionRepository;
        }

        //Queries
        public async Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions(int IdUser)
        {
            List<TransactionDTO> ListTransaction=new List<TransactionDTO>();
            string message = string.Empty;

            int iduser=0;
            
            var Response = await _ItransactionRepository.GetAllTransactionsUserAsync(iduser);

            if (Response.Item1 is false || Response.Item3 is null || !Response.Item3.Any())
            {
                message = "Nenhuma transação encontrada.";
                return (false, message, null);
            }


            foreach (var t in Response.Item3)
            {
                var TMappedDTO = TransactionMapper.ToTransactionDTO(t);
                ListTransaction.Add(TMappedDTO);
            }

            return (true, message, ListTransaction);
        }


        //Commands
        public async Task<(bool, string)> PostTransaction(CreateTransactionModel transaction, int IdUser)
        {

            var transactionEntity = TransactionMapper.ToTransactionEntity(transaction, IdUser);

            if (transactionEntity is null)
            {
                return (false, "Erro ao criar a transação e falha no mapeamento.");
            }
            var Response = await _ItransactionRepository.PostTransactionAsync(transactionEntity);

            if (Response.Item1 is false)
            {
                return (false, Response.Item2);
            }

            return (true, "Pedido confirmado com sucesso!\nEfetue o pagamento.");
        }

        public async Task<(bool, string)> PutTransactionStatusToPaid(int transactionId, int IdUser)
        {
            string message = string.Empty;

            var Response = await _ItransactionRepository.PutTransactionStatusToPaidAsync(transactionId, IdUser);

            if (Response.Item1 == false)
            {
                message = "Falha na confirmação do pagamento.";
                return (false, message);
            }

            return (true, message);
        }

        public async Task<(bool, string)> PutTransactionStatusToCanceled(int transactionId, int IdUser)
        {
            string message = string.Empty;
            var Response = await _ItransactionRepository.PutTransactionStatusToCanceledAsync(transactionId);
            if (Response.Item1 == false)
            {
                message = "Falha na confirmação do cancelamento.";
                return (false, message);
            }
            return (true, message);
        }
    }
}
