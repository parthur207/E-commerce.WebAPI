using Ecommerce.Application.DTOs;
using Ecommerce.Application.DTOs.AdminDTOs;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Mappers
{
    public class TransactionMapper
    {

        //entity => dto

        //Model => entity

        public static TransactionEntity ToTransactionEntity(CreateTransactionModel model, int IdUser)
        {
            return new TransactionEntity(
                IdUser,
               model.ShoppingList.Select(item => new TransactionProductEntity
               {
                   ProductId = item.ProductId,
                   Quantity = item.Quantity
               }).ToList()
            );
        }

        public static TransactionDTO ToTransactionDTO(TransactionEntity entity)
        {
            return new TransactionDTO
            {
                UserId = entity.UserId,
                TransactionDate = entity.TransactionDate,
                TotalValue = entity.TotalValue,
                TransactionStatus = entity.TransactionStatus,
                ShoppingList = entity.TransactionProductsList
                    .Select(tp => new TransactionProductSimpleDTO
                    {
                        ProductName = tp.Product.ProductName,
                        Quantity = tp.Quantity
                    }).ToList()
            };
        }

        public static TransactionInformationToEmailDTO ToTransactionEmailDTO(TransactionEntity entity)
        {
            return new TransactionInformationToEmailDTO
            {
                UserName = entity.User?.Name ?? "Nome desconhecido",
                UserEmail = entity.User?.Email ?? "Email desconhecido",
                TransactionId = entity.Id,
                TransactionDate = entity.TransactionDate,
                TotalValue = entity.TotalValue,
                ShoppingList = entity.TransactionProductsList
                    .Select(tp => new TransactionProductSimpleDTO
                    {
                        ProductName = tp.Product.ProductName,
                        Quantity = tp.Quantity
                    }).ToList()
            };
        }

        public static AdminTransactionDTO ToTransactionAdminDTO(TransactionEntity entity)
        {
            return new AdminTransactionDTO
            {
                UserId = entity.UserId,
                TransactionId = entity.Id,
                TransactionDate = entity.TransactionDate,
                TotalValue = entity.TotalValue,
                TransactionStatus = entity.TransactionStatus,
                ShoppingList = entity.TransactionProductsList
                    .Select(tp => new TransactionProductSimpleDTO
                    {
                        ProductName = tp.Product.ProductName,
                        Quantity = tp.Quantity
                    }).ToList()
            };
        }
    }

}


