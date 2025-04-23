using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers
{
    public class TransactionMapper 
    {

        //entity => dto

        //Model => entity

        public TransactionEntity FromTransactionModel(CreateTransactionModel model)
        {
            return new TransactionEntity
            (
                model.UserId,
                model.ShoppingList,
                model.TotalValue
            );
        }

        public TransactionDTO ToTransactionDTO(TransactionEntity entity)
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
    }
}
