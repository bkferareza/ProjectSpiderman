using Project.Library.Data.Enums;
using Project.Library.Data.Models;
using Project.Library.Logic.DTO;
using Project.Library.Logic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Logic.Extensions
{
    public static class DTOExtensions
    {
        public static BookDTO MapBookToDTO(this Book book)
        {
            return new BookDTO {
                Id = book.Id,
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre.ToString(),
                Quantity = book.Quantity,
                Title = book.Title,
                YearPublished = book.YearPublished
            };
        }

        public static Book MapDTOToBook(this BookDTO book)
        {
            return new Book {
                Id = book.Id,
                Author = book.Author,
                Description = book.Description,
                Genre = Utilities.ParseEnum<Genre>(book.Genre),
                Quantity = book.Quantity,
                Title = book.Title,
                YearPublished = book.YearPublished
            };
        }

        public static BorrowerDTO MapBorrowerToDTO(this Borrower borrower)
        {
            return new BorrowerDTO
            {
                Id = borrower.Id,
                Address = borrower.Address,
                Email = borrower.Email,
                Name = borrower.Name,
                Phone = borrower.Phone
            };
        }

        public static Borrower MapDTOToBorrower(this BorrowerDTO borrower)
        {
            return new Borrower
            {
                Id = borrower.Id,
                Address = borrower.Address,
                Email = borrower.Email,
                Name = borrower.Name,
                Phone = borrower.Phone
            };
        }

        public static Transaction MapDTOToTransaction(this TransactionDTO transaction)
        {
            return new Transaction
            {
                Book = transaction.Book.MapDTOToBook(),
                Borrower = transaction.Borrower.MapDTOToBorrower(),
                Time = transaction.Time,
                TransactionType = Utilities.ParseEnum <TransactionType>(transaction.TransactionType),
                Id = transaction.Id
            };
        }

        public static TransactionDTO MapTransactionToDTO(this Transaction transaction)
        {
            return new TransactionDTO
            {
                Book = transaction.Book.MapBookToDTO(),
                Borrower = transaction.Borrower.MapBorrowerToDTO(),
                TransactionType = transaction.TransactionType.ToString(),
                Time = transaction.Time,
                Id = transaction.Id
            };
        }
    }
}
