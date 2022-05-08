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
    public class PublisherController : ControllerBase
    {
        IPublisherLogic pl;
        IHubContext<SignalRHub> hub;


        public PublisherController(IPublisherLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
        }

        // GET: api/<PublisherController>
        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return pl.ReadAll();
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public Publisher Get(int id)
        {
            return pl.Read(id);
        }

        // POST api/<PublisherController>
        [HttpPost]
        public void Post([FromBody] Publisher value)
        {
            pl.Create(value);
            this.hub.Clients.All.SendAsync("PublisherCreated", value);
        }

        // PUT api/<PublisherController>/5
        [HttpPut]
        public void Put( [FromBody] Publisher value)
        {
            pl.Update(value);
            this.hub.Clients.All.SendAsync("PublisherUpdated", value);
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var p=pl.Read(id);
            pl.Delete(id);
            this.hub.Clients.All.SendAsync("PublisherDeleted", p);
        }
    }
}
