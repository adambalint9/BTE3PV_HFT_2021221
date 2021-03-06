using BTE3PV_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Repository;


namespace BTE3PV_HFT_2021221.Logic
{
    public class AuthorLogic : IAuthorLogic

    {

        IAuthorRepository authorRepository;
        public AuthorLogic(IAuthorRepository authorRepo)
        {
            this.authorRepository = authorRepo;
        }

        public double AGVBirthYear()
        {
            return authorRepository.ReadAll().Average(t => t.BirthYear);
                    
        }

        public IEnumerable<KeyValuePair<string, int>> CountBookByAuthor()
        {
            return from x in authorRepository.ReadAll()                       
                   select new KeyValuePair<string, int>
                   (x.AuthoreName, x.Books.Count());
        }

        public IEnumerable<KeyValuePair<string, int>> CountBookByTopic()
        {
            return from x in authorRepository.ReadAll()
                   select new KeyValuePair<string, int>
                   (x.AuthoreName,x.Books.GroupBy(t=>t.Topic).Count());

        }


        public void Create(Author author)
        {
            if (author.AuthoreName.Length < 4)
            {
                throw new ArgumentException("Author name has to be longer then 4 character");
            }
             authorRepository.Create(author);
        }

        public void Delete(int id)
        {
            authorRepository.Delete(id);
        }

        public Author Read(int id)
        {
            return authorRepository.Read(id);
        }

        public IEnumerable<Author> ReadAll()
        {
            return authorRepository.ReadAll();
        }

        public void Update(Author author)
        {
            authorRepository.Update(author);
        }
    }
}
