using BTE3PV_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Repository;

namespace BTE3PV_HFT_2021221.Logic
{
    class BookLogic : IBookLogic
    {
        IBookRepository bookRepository;
        public BookLogic(IBookRepository bookrepo)
        {

            this.bookRepository = bookrepo;
        
        }



        public IEnumerable<KeyValuePair<string, int>> CountBookByTopic()
        {
            return from x in bookRepository.ReadAll()
                   group x by x.Author.AuthoreName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.GroupBy(t=>t.Topic).Count());
                   
        }
        public IEnumerable<KeyValuePair<string, double>> AVGYeraPublished()
        {
            return from x in bookRepository.ReadAll()
                   group x by x.Publishers.PublisherName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.YearOfIssue));
        }

        public void Create(Book book)
        {
            if (book.Title.Length>0)
            {
                throw new ArgumentException("Book name canot be empty");
            }
            bookRepository.Create(book);
        }

        public void Delete(int id)
        {
            bookRepository.Delete(id);
        }

        public Book Read(int id)
        {
            return bookRepository.Read(id);
        }

        public IEnumerable<Book> ReadAll()
        {
            return bookRepository.ReadAll();
        }

        public void Update(Book book)
        {
            bookRepository.Update(book);
        }

        public IEnumerable<KeyValuePair<string,bool>> IsWritenOnTheWritersMothertounge()
        {
            return from x in bookRepository.ReadAll()
                   select new KeyValuePair<string, bool>
                   (x.Title, x.Language.Equals(x.Author.WritingLanguage));
        }
    }
}
