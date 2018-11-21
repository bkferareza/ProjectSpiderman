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
    public class BorrowerRepository : IBorrowerRepository
    {
        public Borrower Create(Borrower entity)
        {
            return CrappyDatabase.Instance.CreateBorrower(entity);
        }

        public void Delete(int id)
        {
            CrappyDatabase.Instance.DeleteBorrower(id);
        }

        public List<Borrower> Get()
        {
            return CrappyDatabase.Instance.GetBorrowers();
        }

        public bool Update(Borrower entity)
        {
            return CrappyDatabase.Instance.UpdateBorrower(entity);
        }
    }
}
