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
    public class BorrowerManager : IBorrowerManager
    {
        private IBorrowerRepository borrowerRepository;

        public BorrowerManager()
        {
            borrowerRepository = new BorrowerRepository();
        }

        public BorrowerDTO Create(BorrowerDTO entity)
        {
            return this.borrowerRepository.Create(entity.MapDTOToBorrower()).MapBorrowerToDTO();
        }

        public void Delete(int id)
        {
            try
            {
                this.borrowerRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<BorrowerDTO> Get()
        {
            var result = new List<BorrowerDTO>();
            var borrowerList = this.borrowerRepository.Get();
            foreach (var b in borrowerList)
            {
                result.Add(b.MapBorrowerToDTO());
            }

            return result;
        }

        public BorrowerDTO GetById(int id)
        {
            return this.Get().Find(i => i.Id == id);
        }

        public bool Update(BorrowerDTO entity)
        {
            return this.borrowerRepository.Update(entity.MapDTOToBorrower());
        }
    }
}
