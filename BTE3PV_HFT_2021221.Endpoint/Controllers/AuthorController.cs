using BTE3PV_HFT_2021221.Logic;
using BTE3PV_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BTE3PV_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorLogic al;


        public AuthorController(IAuthorLogic al)
        {
            this.al = al;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return al.ReadAll();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return al.Read(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] Author value)
        {
            al.Create(value);

        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Author value)
        {
            al.Update(value);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            al.Delete(id);
        }
    }
}
