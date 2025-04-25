using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Application.Mappers;


namespace Ecommerce.Application.Services.AdminServices
{
    public class AdminTransactionService : IAdminTransactionInterface
    {

        private readonly IProductRepository _IproductRepository;
        public AdminTransactionService(IProductRepository IproductRepository)
        {
            _IproductRepository = IproductRepository;
        }

        public async Task<(bool, string, List<AdminTransactionDTO>?)> GetAllTransactions()
        {
            string message=string.Empty;
            List<AdminTransactionDTO> ListTransactions = new List<AdminTransactionDTO>();
            try
            {
                var transactions = await _IproductRepository.GetAllProductsAsync();

                if(transactions is null)
                {
                    message = "Transações não encontradas.";
                    return (false, message, null);
                }

                foreach (var t in transactions)
                {
                    var transactionsDto= TransactionMapper.ToTransactionAdminDTO(t);
                    ListTransactions.Add(transactionsDto);
                }

                return (true, message, ListTransactions);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar as transações: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, AdminTransactionDTO?)> GetTransactionById(int idTransaction)
        {
            string message = string.Empty;
            try
            {
                var transaction = await _dbContextInMemory.Transaction
                    .Where(x => x.Id == idTransaction)
                    .FirstOrDefaultAsync();

                if (transaction is null)
                {
                    message = "Transação não encontrada.";
                    return (false, message, null);
                }

                var transactionDto = TransactionMapper.ToTransactionAdminDTO(transaction);

                return (true, message, transactionDto);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar a transação: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, List<AdminTransactionDTO>?)> GetTransactionsByUserId(int idUser)
        {
            string message = string.Empty;
            List<AdminTransactionDTO> ListTransactions = new List<AdminTransactionDTO>();
            try
            {
                var transactions = await _IproductRepository.Transaction
                    .Where(x => x.UserId == idUser)
                    .ToListAsync();

                if(transactions is null)
                {
                    message = "Transações não encontradas.";
                    return (false, message, null);
                }

                foreach(var t in transactions)
                {
                    var transactionDto = TransactionMapper.ToTransactionAdminDTO(t);
                    ListTransactions.Add(transactionDto);
                }

                return (true, message, ListTransactions);
            }
            catch (Exception ex)
            {
                message = $"Erro ao buscar as transações: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string)> PutTransactionStatusToCanceled(int idTransction)
        {
            try
            {
                var TransactionEntity = await _dbContextInMemory.Transaction
                 .Where(x => x.Id == idTransction)
                 .FirstOrDefaultAsync();

                if(TransactionEntity is null)
                {
                    return (false, "Transação não encontrada.");
                }

                await _dbContextInMemory.Transaction.Where(x => x.Id == idTransction)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.TransactionStatus, TransactionStatusEnum.Canceled));

                return (true, "O status da transação foi atualzado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao alterar o status da transação: {ex.Message}");
            }
        }

        public async Task<(bool, string)> PutTransactionStatusToSent(int idTransction)
        {
            try
            {
                var TransactionEntity = await _dbContextInMemory.Transaction
                 .Where(x => x.Id == idTransction)
                 .FirstOrDefaultAsync();

                if (TransactionEntity is null)
                {
                    return (false, "Transação não encontrada.");
                }

                await _dbContextInMemory.Transaction.Where(x => x.Id == idTransction)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.TransactionStatus, TransactionStatusEnum.Canceled));

                return (true, "O status da transação foi atualzado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao alterar o status da transação: {ex.Message}");
            }
        }
    }
}
