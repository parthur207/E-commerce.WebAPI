using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers
{
    public class TransactionMapper
    {

        //entity => dto

        //Model => entity

        public static TransactionEntity ToTransactionEntity(CreateTransactionModel model)
        {
            return new TransactionEntity(
                model.UserId,
                model.ShoppingList,
                model.TotalValue
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


