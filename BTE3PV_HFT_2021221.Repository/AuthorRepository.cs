using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Data;
using BTE3PV_HFT_2021221.Models;

namespace BTE3PV_HFT_2021221.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        LibraryDbContext db;

        AuthorRepository(LibraryDbContext db)
        {

            this.db = db;
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Author Read(int id)
        {
            return db.Authors.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Author> ReadAll()
        {
            return db.Authors;
        }

        public void Update(Author author)
        {
            var oldAuthor = Read(author.Id);
            oldAuthor.AuthoreName = author.AuthoreName;
            oldAuthor.Birthcountry = author.Birthcountry;
            oldAuthor.BirthYear = author.BirthYear;
            oldAuthor.Specialization = author.Specialization;
            oldAuthor.WritingLanguage = author.WritingLanguage;
            db.SaveChanges();


        }
    }
}
