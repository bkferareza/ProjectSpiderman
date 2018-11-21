using Project.Library.Data.Interfaces;
using Project.Library.Data.Repositories;
using Project.Library.Logic.DTO;
using Project.Library.Logic.Extensions;
using Project.Library.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Logic.Managers
{
    public class TransactionManager : ITransactionManager
    {
        private IBookRepository bookRepository;
        private IBorrowerRepository borrowerRepository;
        private ITransactionRepository transactionRepository;
        private IBookManager bookManager;

        public TransactionManager()
        {
            bookRepository = new BookRepository();
            borrowerRepository = new BorrowerRepository();
            transactionRepository = new TransactionRepository();
            bookManager = new BookManager();
        }

        public bool CheckBookAvailability(int BookId)
        {
            try {
                var book = this.bookRepository.Get().Find(i => i.Id == BookId);
                return (book.Quantity > 0);
            }
            catch 
            {
                return false;
            }
        }

        public bool CheckBorrowerEligibility(int borrowerId)
        {
            try
            {
                var borrowerItems = this.transactionRepository.GetTransactions()
                                    .Where(a => a.Borrower.Id == borrowerId).ToList();
                return (borrowerItems.Count <= 5);
            }
            catch
            {
                return false;
            }
        }

        public TransactionDTO CreateBorrowTransaction(TransactionDTO transaction)
        {
            var bookToUpdate = bookManager.GetById(transaction.Book.Id);
            transaction.Time = DateTime.Now;
            transaction.TransactionType = "Borrow";
            bookToUpdate.Quantity--;
            bookManager.Update(bookToUpdate);
            return this.transactionRepository.CreateTransaction(transaction.MapDTOToTransaction()).MapTransactionToDTO();
        }

        public TransactionDTO CreateReturnTransaction(TransactionDTO transaction)
        {
            var bookToUpdate = bookManager.GetById(transaction.Book.Id);
            transaction.Time = DateTime.Now;
            transaction.TransactionType = "Return";
            bookToUpdate.Quantity++;
            bookManager.Update(bookToUpdate);
            return this.transactionRepository.CreateTransaction(transaction.MapDTOToTransaction()).MapTransactionToDTO();
        }

        public TransactionDTO GetTransactionById(int id)
        {
            return this.GetTransactions().Find(i => i.Id == id);
        }

        public List<TransactionDTO> GetTransactions()
        {
            var list = transactionRepository.GetTransactions();
            var result = new List<TransactionDTO>();

            foreach (var t in list)
            {
                result.Add(t.MapTransactionToDTO());
            }

            return result;
        }
    }
}
