using Project.Library.Logic.DTO;
using Project.Library.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project.Library.Web.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BorrowersController : ApiController
    {
        private IBorrowerManager borrowerManager;
        public BorrowersController(IBorrowerManager borrowerManager)
        {
            this.borrowerManager = borrowerManager;
        }
        // GET api/<controller>
        public List<BorrowerDTO> Get()
        {
            return this.borrowerManager.Get();
        }

        // GET api/<controller>/5
        public BorrowerDTO Get(int id)
        {
            return this.borrowerManager.GetById(id);
        }

        // POST api/<controller>
        public BorrowerDTO Post([FromBody]BorrowerDTO borrower)
        {
            return this.borrowerManager.Create(borrower);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]BorrowerDTO borrower)
        {
            return this.borrowerManager.Update(borrower);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}