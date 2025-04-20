using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Transactions;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class TransactionEntity : BaseEntity
    {
        public TransactionEntity(UserEntity user)
        {
            User = user;
            TransactionDate = DateTime.Now;
            TransactionStatus = TransactionStatusEnum.Pending;
        }

        public int UserId { get; private set; }
        public UserEntity User { get; private set; }
        public decimal TotalValue { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionStatusEnum TransactionStatus { get; private set; }
        public List<TransactionProductEntity> ShoppingList { get; private set; }


        public void CalculateTotalValue()
        {
            TotalValue = ShoppingList.Sum(x => x.Quantity * x.Product.Price);
        }

        public void SetTransactionStatusToPaid()//Para torna-lo usual, é de necessidade o implemento de um serviço externo que reconheceria o valor e faria o apontamento para esse método
        {
            if(TransactionStatus == TransactionStatusEnum.Paid || TransactionStatus == TransactionStatusEnum.InProcessing)
            {
                TransactionStatus = TransactionStatusEnum.Paid;
            }
        }

        public void SetTransactionStatusToInProcessing()//Em teória, chamaria esse método cair o pagamento e de forma manual, pelo admin/vendedor após o envio do produto...
        {
            if (TransactionStatus == TransactionStatusEnum.Pending || TransactionStatus == TransactionStatusEnum.Paid)
            {
                TransactionStatus = TransactionStatusEnum.InProcessing;
            }

            //Método para debitar {quantity} do estoque do produto específico
        }

        public void SetTransactionStatusToCanceled()//Caso o cliente solicite o cancelamento
        {
            if (TransactionStatus == TransactionStatusEnum.Pending || TransactionStatus == TransactionStatusEnum.Paid || TransactionStatus == TransactionStatusEnum.InProcessing)
            {
                TransactionStatus = TransactionStatusEnum.Canceled;
            }

            //Método para incrementar {quantity} ao estoque do produto específico
        }
    }
}
