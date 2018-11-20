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

        private CrappyDatabase()
        {
            books = new List<Book>();
            borrowers = new List<Borrower>();
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

        public List<Book> GetBookList()
        {
            return this.books;
        }

        public List<Borrower> GetBorrowers()
        {
            return this.borrowers;
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
    }
}
