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
        public async Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions()
        {
            List<TransactionDTO> ListTransaction=new List<TransactionDTO>();
            string message = string.Empty;


            var Response = await _ItransactionRepository.GetAllTransactions();

            if (Response.Item1 is false)
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
        public async Task<(bool, string)> PostTransaction(CreateTransactionModel transaction)
        {
            try
            {
                var transactionEntity = TransactionMapper.ToTransactionEntity(transaction);

                if (transactionEntity is null)
                {
                    return (false, "Erro ao criar a transação e falha no mapeamento.");
                }
                var Response = await _ItransactionRepository.PostTransaction(transactionEntity);


                return (true, "Compra realizada com sucesso!\nEfetue o pagamento.");
            }
            catch
            {

                return (false, "Ocorreu um erro inesperado.");
            }
        }

        public async Task<(bool, string)> PutTransactionStatusToPaid(int transactionId)
        {
            string message = string.Empty;

            var Response = await _ItransactionRepository.PutTransactionStatusToPaid(transactionId);

            if (Response.Item1 == false)
            {
                message = "Falha na confirmação do pagamento.";
                return (false, message);
            }

            return (true, message);
        }
    }
}
