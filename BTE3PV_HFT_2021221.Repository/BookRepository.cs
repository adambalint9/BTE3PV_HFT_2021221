using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Models;
using BTE3PV_HFT_2021221.Data;

namespace BTE3PV_HFT_2021221.Repository
{
    public class BookRepository : IBookRepository
    {
        LibraryDbContext db;

        public BookRepository(LibraryDbContext db)
        {
            this.db = db;
        
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();


        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Book Read(int id)
        {
            return db.Books.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Book> ReadAll()
        {
            return db.Books;
        }

        public void Update(Book book)
        {
            var oldBook = Read(book.Id);
            oldBook.Language = book.Language;
            oldBook.Lenght = book.Lenght;
            oldBook.PublisherID = book.PublisherID;
            oldBook.AuthorID = book.AuthorID;
            oldBook.Title = book.Title;
            oldBook.Topic = book.Topic;
            oldBook.YearOfIssue = book.YearOfIssue;
            db.SaveChanges();

        }
    }
}
