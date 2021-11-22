using BTE3PV_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Repository;

namespace BTE3PV_HFT_2021221.Logic
{
   public class PublisherLogic : IPublisherLogic
    {

        IPublisherRepository publisherRepository;

       public PublisherLogic(IPublisherRepository publisherRepo)
        {
            this.publisherRepository = publisherRepo;
        }
       

        

        public IEnumerable<KeyValuePair<string, int>> CountBookByPublisher()
        {
            return from x in publisherRepository.ReadAll()
                   select new KeyValuePair<string, int>
                   (x.PublisherName, x.Books.Count());
        }

        public void Create(Publisher publisher)
        {
            if (publisher.PublisherName.Length<4)
            {
                throw new ArgumentException("Name must be longer than 4 character");
            }
            publisherRepository.Create(publisher);
        }

        public void Delete(int id)
        {
            publisherRepository.Delete(id);
        }

        public Publisher Read(int id)
        {
           return publisherRepository.Read(id);
        }

        public IEnumerable<Publisher> ReadAll()
        {
            return publisherRepository.ReadAll();
        }

        public void Update(Publisher publisher)
        {
            publisherRepository.Update(publisher);
        }
    }
}
