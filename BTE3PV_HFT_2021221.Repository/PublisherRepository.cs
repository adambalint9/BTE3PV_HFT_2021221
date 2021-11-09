using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Data;
using BTE3PV_HFT_2021221.Models;

namespace BTE3PV_HFT_2021221.Repository
{
    public class PublisherRepository : IPublisherRepository
    {

        LibraryDbContext db;

        PublisherRepository(LibraryDbContext db)
        {

            this.db = db;
        }

        public void Create(Publisher publisher)
        {
            db.Publishers.Add(publisher);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Publisher Read(int id)
        {
            return db.Publishers.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return db.Publishers;
        }

        public void Update(Publisher publisher)
        {
            var oldPublisher = Read(publisher.Id);
            oldPublisher.PublisherName = publisher.PublisherName;
            oldPublisher.TelphoneNumber = publisher.TelphoneNumber;
            oldPublisher.Headquarters = publisher.Headquarters;
            oldPublisher.Email = publisher.Email;
            oldPublisher.YearOfFundation = publisher.YearOfFundation;

            db.SaveChanges();


        }
    }
}
