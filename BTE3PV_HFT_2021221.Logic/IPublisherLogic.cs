using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Models;

namespace BTE3PV_HFT_2021221.Logic
{
    interface IPublisherLogic
    {
        void Create(Publisher publisher);
        void Delete(int id);
        Publisher Read(int id);
        IEnumerable<Publisher> ReadAll();
        void Update(Publisher publisher);
        IEnumerable<KeyValuePair<string, int>> CountBookByPublisher();
        
    }
}
