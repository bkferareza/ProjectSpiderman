using Project.Library.Data.Database;
using Project.Library.Data.Interfaces;
using Project.Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Transaction CreateTransaction(Transaction transaction)
        {
            return CrappyDatabase.Instance.CreateTransaction(transaction);
        }

        public List<Transaction> GetTransactions()
        {
            return CrappyDatabase.Instance.GetTransactions();
        }
    }
}
