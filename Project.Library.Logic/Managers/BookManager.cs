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
    public class BookManager : IBookManager
    {
        private IBookRepository bookRepository;
        public BookManager()
        {
            bookRepository = new BookRepository();
        }

        public BookDTO Create(BookDTO entity)
        {
            return bookRepository.Create(entity.MapDTOToBook()).MapBookToDTO();
        }

        public void Delete(int id)
        {
            try
            {
                bookRepository.Delete(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<BookDTO> Get()
        {
            var list = bookRepository.Get();
            var result = new List<BookDTO>();

            foreach (var b in list)
            {
                result.Add(b.MapBookToDTO());
            }

            return result;
        }

        public BookDTO GetById(int id)
        {
            return this.Get().Find(a => a.Id == id);
        }

        public bool Update(BookDTO entity)
        {
            return this.bookRepository.Update(entity.MapDTOToBook());
        }
    }
}
