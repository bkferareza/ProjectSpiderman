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
    public class BookRepository : IBookRepository
    {
        public Book Create(Book entity)
        {
            return CrappyDatabase.Instance.CreateBook(entity);
        }

        public void Delete(int id)
        {
            CrappyDatabase.Instance.DeleteBook(id);
        }

        public List<Book> Get()
        {
            return CrappyDatabase.Instance.GetBookList();
        }

        public bool Update(Book entity)
        {
            return CrappyDatabase.Instance.UpdateBook(entity);
        }
    }
}
