using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers
{
    public class TransactionMapper
    {

        //entity => dto

        //Model => entity

        public void TransactionEntity (TransactionModel model)
        {
            return new TransactionEntity
            {
                model.User,
                model
            }
        }
    }
}
