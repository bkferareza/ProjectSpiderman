﻿using Project.Library.Logic.DTO;
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
    public class BooksController : ApiController
    {
        private IBookManager bookManager;
        public BooksController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }
        // GET api/<controller>
        public List<BookDTO> Get()
        {
            return this.bookManager.Get();
        }

        // GET api/<controller>/5
        public BookDTO Get(int id)
        {
            return this.bookManager.GetById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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