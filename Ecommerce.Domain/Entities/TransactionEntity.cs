using Ecommerce.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Domain.Entities
{
    public class TransactionEntity 
    {
        protected TransactionEntity()
        {

        }

        public TransactionEntity(int userId, List<TransactionProductEntity> transactionProductsList)
        {
            UserId = userId;
            TransactionDate = DateTime.Now;
            TransactionStatus = TransactionStatusEnum.PendingPayment;
            TransactionProductsList = transactionProductsList;
        }
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public UserEntity User { get; protected set; }
        public decimal TotalValue { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionStatusEnum TransactionStatus { get; private set; }
        public List<TransactionProductEntity> TransactionProductsList { get; private set; }

        
        public void CalculateTotalValue()
        {
            TotalValue = TransactionProductsList
            .Where(x => x.Product != null)
            .Sum(x => (decimal)x.Quantity * (decimal)x.Product.Price);
        }

        public void SetTransactionStatusToPaid()
        {
            TransactionStatus = TransactionStatusEnum.Paid;
        }

        public void SetTransactionStatusToCanceled()
        {
                TransactionStatus = TransactionStatusEnum.Canceled;
        }

        public void SetTransactionStatusToSent()
        {
            TransactionStatus = TransactionStatusEnum.Sent;
        }
    }
}
