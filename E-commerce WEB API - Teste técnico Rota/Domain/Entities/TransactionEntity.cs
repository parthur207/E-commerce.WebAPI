using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class TransactionEntity : BaseEntity
    {
        public TransactionEntity(int userId)
        {
            UserId = userId;
            TransactionDate = DateTime.Now;
            TransactionStatus = TransactionStatusEnum.Pending;
            ShoppingList = new List<TransactionProductEntity>();
        }

        public int UserId { get; private set; }
        public UserEntity User { get; protected set; }

        public decimal TotalValue { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionStatusEnum TransactionStatus { get; private set; }

        public List<TransactionProductEntity> ShoppingList { get; private set; }

        public void CalculateTotalValue()
        {
            TotalValue = ShoppingList.Sum(x => x.Quantity * x.Product.Price);
        }

        public void SetTransactionStatusToPaid()
        {
            if (TransactionStatus == TransactionStatusEnum.Pending || TransactionStatus == TransactionStatusEnum.InProcessing)
            {
                TransactionStatus = TransactionStatusEnum.Paid;
            }
        }

        public void SetTransactionStatusToInProcessing()
        {
            if (TransactionStatus == TransactionStatusEnum.Pending || TransactionStatus == TransactionStatusEnum.Paid)
            {
                TransactionStatus = TransactionStatusEnum.InProcessing;
            }
        }

        public void SetTransactionStatusToCanceled()
        {
            if (TransactionStatus == TransactionStatusEnum.Pending || TransactionStatus == TransactionStatusEnum.Paid || TransactionStatus == TransactionStatusEnum.InProcessing)
            {
                TransactionStatus = TransactionStatusEnum.Canceled;
            }
        }
    }
}
