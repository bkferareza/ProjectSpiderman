using Project.Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Data.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction CreateTransaction(Transaction transaction);
        List<Transaction> GetTransactions();
    }
}
