using BTE3PV_HFT_2021221.Logic;
using BTE3PV_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTE3PV_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBookLogic bl;
        IAuthorLogic al;
        IPublisherLogic pl;

        public StatController(IBookLogic bl, IAuthorLogic al,IPublisherLogic pl)
        {
            this.bl = bl;
            this.al = al;
            this.pl = pl;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGYeraPublished()
        {
            return bl.AVGYeraPublished();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountBookByTopic()
        {
            return al.CountBookByTopic();

        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, bool>> ISMothrtounge()
        {

            return bl.IsWritenOnTheWritersMothertounge();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountBookByPublisher()
        {
            return pl.CountBookByPublisher();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountBookByAuthor()
        {
            return al.CountBookByAuthor();
        }
        [HttpGet]
        public double AVGBirthyear()
        {
            return al.AGVBirthYear();
        
        }


    }
}
