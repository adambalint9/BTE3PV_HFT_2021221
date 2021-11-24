using BTE3PV_HFT_2021221.Logic;
using BTE3PV_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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


        public PublisherController(IPublisherLogic pl)
        {
            this.pl = pl;
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
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Publisher value)
        {
            pl.Update(value);
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
