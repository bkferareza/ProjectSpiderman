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
    public class TransactionsController : ApiController
    {
        private ITransactionManager transactionManager;

        public TransactionsController(ITransactionManager transactionManager)
        {
            this.transactionManager = transactionManager;
        }

        // GET api/<controller>
        public List<TransactionDTO> Get()
        {
            return this.transactionManager.GetTransactions();
        }

        // GET api/<controller>/5
        public TransactionDTO Get(int id)
        {
            return this.transactionManager.GetTransactionById(id);
        }

        // POST api/<controller>
        public TransactionDTO Post([FromBody]TransactionDTO value)
        {
            if (value.TransactionType == "Borrow")
                return this.transactionManager.CreateBorrowTransaction(value);
            else
                return this.transactionManager.CreateReturnTransaction(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}