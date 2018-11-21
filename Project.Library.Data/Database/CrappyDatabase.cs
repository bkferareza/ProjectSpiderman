using Bogus;
using Project.Library.Data.Enums;
using Project.Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Data.Database
{
    public sealed class CrappyDatabase
    {
        private static CrappyDatabase instance = null;
        private static readonly object padlock = new object();
        private List<Book> books;
        private List<Borrower> borrowers;
        private List<Transaction> transactions;

        private CrappyDatabase()
        {
            books = new List<Book>();
            borrowers = new List<Borrower>();
            transactions = new List<Transaction>();
            Seed();
        }

        public static CrappyDatabase Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new CrappyDatabase();
                }
                return instance;
            }
        }

        private void Seed()
        {
            //Used library bogus just for fun. do not use as real data;
            Randomizer.Seed = new Random(8675309);
            var bookId = 0;
            var borrowerId = 0;
            for (var i = 0; i < 10; i++)
            {
                var testBook = new Faker<Book>()
                                        .StrictMode(true)
                                        .RuleFor(o => o.Id, f => bookId++)
                                        .RuleFor(o => o.Genre, f => f.PickRandom<Genre>())
                                        .RuleFor(o => o.Author, f => f.Person.LastName)
                                        .RuleFor(o => o.Title, f => f.Lorem.Sentence())
                                        .RuleFor(o => o.YearPublished, f => f.Date.Past())
                                        .RuleFor(o => o.Description, f => f.Lorem.Sentences())
                                        .RuleFor(o => o.Quantity, f => f.Random.Int(5,10))
                                        .RuleFor(o => o.Created, f => f.Date.Recent())
                                        .RuleFor(o => o.Modified, f => f.Date.Recent());

                var generatedBook = testBook.Generate();
                books.Add(generatedBook);

                var testBorrower = new Faker<Borrower>()
                                    .StrictMode(true)
                                    .RuleFor(o => o.Id, f => borrowerId++)
                                    .RuleFor(o => o.Name, f => f.Person.FullName)
                                    .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
                                    .RuleFor(o => o.Email, f => f.Person.Email)
                                    .RuleFor(o => o.Address, f => f.Address.FullAddress())
                                    .RuleFor(o => o.Created, f => f.Date.Recent())
                                    .RuleFor(o => o.Modified, f => f.Date.Recent());

                var generatedBorrower = testBorrower.Generate();
                borrowers.Add(generatedBorrower);
            }
        }

        //CRUD For Database Entities

        public List<Book> GetBookList()
        {
            return this.books;
        }

        public List<Borrower> GetBorrowers()
        {
            return this.borrowers;
        }

        public List<Transaction> GetTransactions()
        {
            return this.transactions;
        }

        public Book CreateBook(Book book)
        {
            var id = books.Count;
            book.Id = id;
            book.Created = DateTime.Now;
            book.Modified = book.Created;

            this.books.Add(book);

            return book;
        }

        public Borrower CreateBorrower(Borrower borrower)
        {
            var id = borrowers.Count;
            borrower.Id = id;
            borrower.Created = DateTime.Now;
            borrower.Modified = borrower.Created;

            this.borrowers.Add(borrower);

            return borrower;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            var id = transactions.Count;
            transaction.Id = id;
            transaction.Created = DateTime.Now;
            transaction.Modified = DateTime.Now;

            this.transactions.Add(transaction);

            return transaction;
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                var index = books.FindIndex(c => c.Id == book.Id);
                books[index].Modified = DateTime.Now;
                books[index].Title = book.Title;
                books[index].Author = book.Author;
                books[index].Description = book.Description;
                books[index].YearPublished = book.YearPublished;
                books[index].Genre = book.Genre;
                books[index].Quantity = book.Quantity;

                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public bool UpdateBorrower(Borrower borrower)
        {
            try {
                var index = borrowers.FindIndex(c => c.Id == borrower.Id);
                borrowers[index].Modified = DateTime.Now;
                borrowers[index].Name = borrower.Name;
                borrowers[index].Phone = borrower.Phone;
                borrowers[index].Email = borrower.Email;
                borrowers[index].Address = borrower.Address;

                return true;
            }
            catch {
                return false;
            }
        }

        public void DeleteBook(int id)
        {
            var bookToRemove = books.Single(r => r.Id == id);
            if (bookToRemove != null)
                books.Remove(bookToRemove);
        }

        public void DeleteBorrower(int id)
        {
            var borrowerToDelete = borrowers.Single(r => r.Id == id);
            if (borrowerToDelete != null)
                borrowers.Remove(borrowerToDelete);
        }
    }
}
