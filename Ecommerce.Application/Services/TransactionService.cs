
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Application.Services
{
    public class TransactionService : ITransactionInterface
    {

        private readonly DbContextInMemory _dbContextInMemory;

        public TransactionService(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }

        //Queries
        public async Task<(bool, string, List<TransactionDTO>?)> GetAllTransactions()
        {
            List<TransactionDTO> ListProducts=new List<TransactionDTO>();
            string message = string.Empty;
            try
            {
                var transactionsE = await _dbContextInMemory.Transaction.ToListAsync();

                if(transactionsE is null)
                {
                    message = "Transações não encontradas.";
                    return (false, message, null);
                }

                foreach (var transactionEntity in transactionsE)
                {
                    var transactionMapped= TransactionMapper.ToTransactionDTO(transactionEntity);
                    ListProducts.Add(transactionMapped);
                }
                return (true, message, ListProducts);
            }
            catch 
            {
                message = "Ocorreu um erro inesperado.";
                return (false, message , null);
            }
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

                await _dbContextInMemory.Transaction.AddAsync(transactionEntity);
                await _dbContextInMemory.SaveChangesAsync();

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
