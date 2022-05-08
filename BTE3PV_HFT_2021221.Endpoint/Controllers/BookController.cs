using BTE3PV_HFT_2021221.Endpoint.Services;
using BTE3PV_HFT_2021221.Logic;
using BTE3PV_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BTE3PV_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic bl;
        IHubContext<SignalRHub> hub;

        public BookController(IBookLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub; 
        
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bl.ReadAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            Book b = bl.Read(id);
            return b;
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bl.Create(value);
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public void Put([FromBody] Book Value)
        {
            bl.Update(Value);
            this.hub.Clients.All.SendAsync("BookUpdated", Value);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var b = bl.Read(id);
            bl.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", b);
        }
    }
}
