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
    }
}
