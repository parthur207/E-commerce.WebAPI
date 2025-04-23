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
            return new TransactionEntity
            (
                model.UserId,
                model.ShoppingList,
                model.TotalValue
            );
        }

        public static TransactionDTO ToTransactionDTO(TransactionEntity entity)
        {
            return new TransactionDTO
            {
                ShoppingList = entity.ShoppingList.Select(x => (x.Product.ProductName, x.Quantity)).ToList(),
                UserId = entity.UserId,
                TransactionDate = entity.TransactionDate,
                TotalValue = entity.TotalValue,
                TransactionStatus = entity.TransactionStatus
            };
        }


        public static TransactionInformationToEmailDTO ToTransactionEmailDTO(TransactionEntity entity)
        {

            var userName = entity.User != null ? $"{entity.User.Name}" : "Nome desconhecido.";
            var userEmail = entity.User != null ? $"{entity.User.Email}" : "Email desconhecido.";

            var shoppingList = entity.ShoppingList.Select(x => (x.Product.ProductName, x.Quantity)).ToList();

            return new TransactionInformationToEmailDTO()
            {
                UserName = userName,
                UserEmail = userEmail,
                TransactionId = entity.Id,
                TransactionDate = entity.TransactionDate,
                TotalValue = entity.TotalValue,
                ShoppingList = shoppingList
            };
        }

        public static AdminTransactionDTO ToTransactionAdminDTO(TransactionEntity entity)
        {

            return new AdminTransactionDTO
            {
                ShoppingList= entity.ShoppingList.Select(x => (x.Product.ProductName, x.Quantity)).ToList(),
                UserId=entity.UserId,
                TransactionDate=entity.TransactionDate,
                TotalValue=entity.TotalValue,
                TransactionStatus=entity.TransactionStatus

                };
        }
    }
}
