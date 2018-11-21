using Project.Library.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Logic.Interfaces
{
    public interface ITransactionManager
    {
        bool CheckBookAvailability(int BookId);
        bool CheckBorrowerEligibility(int BorrowerId);
        TransactionDTO CreateBorrowTransaction(TransactionDTO transaction);
        TransactionDTO CreateReturnTransaction(TransactionDTO transaction);
        List<TransactionDTO> GetTransactions();
        TransactionDTO GetTransactionById(int id);
    }
}
