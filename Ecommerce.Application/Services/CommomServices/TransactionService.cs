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
            try
            {
                var TransactionEntity = await _dbContextInMemory.Transaction.Where(x=>x.TransactionStatus==TransactionStatusEnum.Paid).FirstOrDefaultAsync();

                
                if(TransactionEntity is null)
                {
                    message = "Tranação não encontrada.";
                    return (false, message);
                }

                await _dbContextInMemory.Transaction.Where(x => x.Id == transactionId)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.TransactionStatus, TransactionStatusEnum.Paid));
                await _dbContextInMemory.SaveChangesAsync();

                message= "Pagamento confirmado com sucesso!\nAguarde enquanto o vendedor providencia o envio.";
                return (true, message);
            }
            catch
            {
                message = "Ocorreu um erro inesperado.";
                return (false,message);
            }
        }
    }
}
