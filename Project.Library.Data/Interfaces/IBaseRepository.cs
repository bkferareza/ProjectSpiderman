using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Create(T entity);
        bool Update(T entity);
        List<T> Get();
        void Delete(int id);
    }
}
