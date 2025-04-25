using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.AdminInterfaces;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Application.Mappers;


namespace Ecommerce.Application.Services.AdminServices
{
    public class AdminTransactionService : IAdminTransactionInterface
    {

        private readonly ITransactionRepository _ItransactionRepository;
        public AdminTransactionService(ITransactionRepository ItransactionRepository)
        {
            _ItransactionRepository = ItransactionRepository;
        }

        public async Task<(bool, string, List<AdminTransactionDTO>?)> GetAllTransactionsAdmin()
        {
            List<AdminTransactionDTO> ListTransactions = new List<AdminTransactionDTO>();

            var Response = await _ItransactionRepository.GetAllTransactionsAdminAsync();

            if(Response.Item1 is false)
            {
                return (false, Response.Item2, null);
            }

            foreach (var t in Response.Item3) 
            {
                var TransactionMapped = TransactionMapper.ToTransactionAdminDTO(t);
                ListTransactions.Add(TransactionMapped);
            }

            return (true, Response.Item2, ListTransactions);
        }

        public async Task<(bool, string, AdminTransactionDTO?)> GetTransactionByIdAdmin(int idTransaction)
        {
            var Response= await _ItransactionRepository.GetTransactionByIdAdminAsync(idTransaction);

            if(Response.Item1 is false)
            {
                return (false, Response.Item2, null);
            }

            var TransactionMapped = TransactionMapper.ToTransactionAdminDTO(Response.Item3);

            return (true, Response.Item2, TransactionMapped);
        }

        public async Task<(bool, string, List<AdminTransactionDTO>?)> GetTransactionsByUserIdAdmin(int idUser)
        {
            List<AdminTransactionDTO> ListTransactions = new List<AdminTransactionDTO>();
             var Response= await _ItransactionRepository.GetAllTransactionsUserAsync(idUser);

            if(Response.Item1 is false)
            {
                return (false, Response.Item2 ,null);
            }

            foreach(var t in Response.Item3)
            {
                var TransactionMapped= TransactionMapper.ToTransactionAdminDTO(t);
                ListTransactions.Add(TransactionMapped);
            }
            return (true, Response.Item2, ListTransactions);
        }

        public async Task<(bool, string)> PutTransactionStatusToCanceledAdmin(int idTransction)
        {
           var Response= await _ItransactionRepository.PutTransactionStatusToCanceledAsync(idTransction);

            if (Response.Item1 is false)
            {
                return (false, Response.Item2);
            }
            return (true, Response.Item2);    
        }

        public async Task<(bool, string)> PutTransactionStatusToSentAdmin(int idTransction)
        {


            
        }
    }
}
