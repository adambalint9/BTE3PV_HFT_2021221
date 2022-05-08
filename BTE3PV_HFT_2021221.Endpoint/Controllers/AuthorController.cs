using BTE3PV_HFT_2021221.Endpoint.Services;
using BTE3PV_HFT_2021221.Logic;
using BTE3PV_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public AuthorController(IAuthorLogic al, IHubContext<SignalRHub> hub)
        {
            this.al = al;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("AuthorCreated", value);
        }

        // PUT api/<AuthorController>/5
        [HttpPut]
        public void Put([FromBody] Author value)
        {
            al.Update(value);
            this.hub.Clients.All.SendAsync("AuthorUpdate", value);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var a = al.Read(id);    
            al.Delete(id);
            this.hub.Clients.All.SendAsync("AuthorDeleted", a);
        }
    }
}
