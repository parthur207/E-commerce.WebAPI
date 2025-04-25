using Ecommerce.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    internal class TransactionProductRepository : ITransactionProductRepository
    {

        private readonly DbContextInMemory _dbContextInMemory;
        public TransactionProductRepository(DbContextInMemory dbContextInMemory)
        {
            _dbContextInMemory = dbContextInMemory;
        }
    }
}
