using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Application.Interfaces.RepositoriesInterface;
using Ecommerce.Application.Mappers;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.ExternalService.InterfaceNotification;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly DbContextInMemory _dbContextinInMemory;
        private readonly INotificationInterface _InotificationInterface;

        public TransactionRepository(DbContextInMemory dbcontext, INotificationInterface notificationInterface)
        {
            _dbContextinInMemory = dbcontext;
            _InotificationInterface = notificationInterface;
        }


        public async Task<(bool, string, List<TransactionEntity>?)> GetAllTransactionsAdminAsync()
        {
            string message = string.Empty;
            try
            {
                var TransactionsEntity = await _dbContextinInMemory.Transaction.ToListAsync();
                foreach (var t in TransactionsEntity) {
                    Console.WriteLine($"Transação: {t}");
                }
                if (TransactionsEntity is null || !TransactionsEntity.Any())
                {
                    message = "Nenhuma transação foi encontrada.";

                    return (false, message, null);
                }

                Console.WriteLine($"GettAlltransationsAdmin: {TransactionsEntity}");
                return (true, message, TransactionsEntity);
               
            }
            catch (Exception ex)
            {
                message = $"Erro ao carregar transações: {ex.Message}";
                return (false, message, null);
            }
            
        }

        //USER E ADMIN
        public async Task<(bool, string, List<TransactionEntity>?)> GetAllTransactionsUserAsync(int idUser)
        {
            string message = string.Empty;
            try
            {
                var TransactionsUserEntity = await _dbContextinInMemory.Transaction.Where(x => x.UserId == idUser).ToListAsync();

                if (TransactionsUserEntity is null || !TransactionsUserEntity.Any())
                {
                    message = "Nenhuma transação encontrada.";
                    return (false, message, null);
                }
                return (true, message, TransactionsUserEntity);
            }
            catch (Exception ex)
            {
                message = $"Erro ao carregar transações: {ex.Message}";
                return (false, message, null);
            }
        }

        public async Task<(bool, string, TransactionEntity?)> GetTransactionByIdAdminAsync(int idTransaction)
        {
            string message = string.Empty;
            try
            {

                var TransactionEntity = await _dbContextinInMemory.Transaction.FirstOrDefaultAsync(x => x.Id == idTransaction);

                if (TransactionEntity is null)
                {
                    message = "A transação não foi encontrada.";
                    return (false, message, null);
                }

                return (true, message, TransactionEntity);
            }
            catch (Exception ex)
            {
                message = $"Erro ao carregar transação: {ex.Message}";
                return (false, message, null);
            }
        }


        public async Task<(bool, string)> PostTransactionAsync(TransactionEntity transaction)
        {
            string message = string.Empty;
            try
            {
                if (transaction is null || await _dbContextinInMemory.Product.AnyAsync() is false)
                {
                    message = "Falha ao efetuar compra. Tente novamente.";
                    return (false, message);
                }

                foreach (var item in transaction.TransactionProductsList)
                {
                    var product = await _dbContextinInMemory.Product
                        .Where(x => x.Id == item.ProductId)
                        .FirstOrDefaultAsync();

                    if (product == null)
                    {
                        return (false, $"Produto com ID {item.ProductId} não encontrado.");
                    }

                    item.Product = product;
                }

                transaction.CalculateTotalValue();

                var ProductsShopping = transaction.TransactionProductsList;
                foreach (var p in ProductsShopping)
                {
                    p.Product.SetSalesProduct(p.Quantity);
                    p.Product.SetStockProduct(-p.Quantity);
                    _dbContextinInMemory.Product.Update(p.Product);
                }

                await _dbContextinInMemory.SaveChangesAsync();

                await _dbContextinInMemory.Transaction.AddAsync(transaction);
                await _dbContextinInMemory.SaveChangesAsync();

                var UserEmail = await _dbContextinInMemory.User.Where(x => x.Id == transaction.UserId)
                    .Select(x => x.Email)
                    .FirstOrDefaultAsync();

                Console.WriteLine($"Trasação Id:{transaction.Id} | User Id: {transaction.UserId} | Data da transação: {transaction.TransactionDate} | Lista de compras: {transaction.TransactionProductsList}");

                var TransactionMapped = TransactionMapper.ToTransactionEmailDTO(transaction);

                //_InotificationInterface.SendConfirmationEmail(TransactionMapped.UserEmail, TransactionMapped, TransactionMapped.UserName);

                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }


        public async Task<(bool, string)> PutTransactionStatusToCanceledAsync(int idTransaction)
        {
            string message = string.Empty;
            try
            {
              
                if (await _dbContextinInMemory.User.AnyAsync(x=>x.TransactionsList.Any(x=>x.Id==idTransaction)) is false)
                {
                    message = $"O usuário informado não possui a transação n° {idTransaction}.";
                    return (false, message);
                }

                var transactionById = await _dbContextinInMemory.Transaction.Where(x => x.Id == idTransaction).FirstOrDefaultAsync();
                
                if (transactionById is null)
                {
                    message = "Nenhuma transação encontrada. Verifique se o Id está correto.";
                    return (false, message);
                }


                var ProductsShopping = transactionById.TransactionProductsList;
                foreach (var p in ProductsShopping)
                {
                    p.Product.SetSalesProduct(-p.Quantity);
                    p.Product.SetStockProduct(p.Quantity);
                    _dbContextinInMemory.Product.Update(p.Product);
                }

                transactionById.SetTransactionStatusToCanceled();
                _dbContextinInMemory.Update(transactionById);
                await _dbContextinInMemory.SaveChangesAsync();
                message = $"Transação n° {transactionById.Id} cancelada com sucesso.";

                var TransactionMapped = TransactionMapper.ToTransactionEmailDTO(transactionById);
                _InotificationInterface.SendCanceledEmail(TransactionMapped.UserEmail, TransactionMapped, TransactionMapped.UserEmail);

                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }

        public async Task<(bool, string)> PutTransactionStatusToPaidAsync(int transactionId, int userId)
        {
            string message = string.Empty;

            try
            {
                var TransactionUserEntity = await _dbContextinInMemory.Transaction.Where(x => x.Id == transactionId && x.UserId == userId)
                    .FirstOrDefaultAsync();

                if (TransactionUserEntity is null)
                {
                    message = "Nenhuma transação foi encontrada.";
                    return (false, message);
                }

                TransactionUserEntity.SetTransactionStatusToPaid();
                _dbContextinInMemory.Update(TransactionUserEntity);
                await _dbContextinInMemory.SaveChangesAsync();

                message = $"Transação n° {transactionId} paga com sucesso.";
                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }

        public async Task <(bool, string)> PutTransactionStatusToSentAdminAsync(int transactionId)
        {
            string message = string.Empty;
            try
            {
                var TransactionUserEntity = await _dbContextinInMemory.Transaction.Where(x => x.Id == transactionId)
                    .FirstOrDefaultAsync();

                if (TransactionUserEntity is null)
                {
                    message = "Nenhuma transação foi encontrada.";
                    return (false, message);
                }

                TransactionUserEntity.SetTransactionStatusToSent();
                _dbContextinInMemory.Update(TransactionUserEntity);
                await _dbContextinInMemory.SaveChangesAsync();

                var transactionMapped = TransactionMapper.ToTransactionEmailDTO(TransactionUserEntity);

                _InotificationInterface.SendShippingConfirmationEmail(transactionMapped.UserEmail, transactionMapped, transactionMapped.UserName);
                return (true, message);
            }
            catch (Exception ex)
            {
                message = $"Ocorreu um erro inesperado: {ex.Message}";
                return (false, message);
            }
        }
    }
}
