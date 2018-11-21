using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Logic.Interfaces
{
    public interface IBaseManager<T>
    {
        T Create(T entity);
        bool Update(T entity);
        List<T> Get();
        T GetById(int id);
        void Delete(int id);
    }
}
