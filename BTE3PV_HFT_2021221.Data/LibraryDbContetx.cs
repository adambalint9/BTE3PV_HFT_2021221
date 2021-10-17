using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Models;




namespace BTE3PV_HFT_2021221.Data
{
    public partial class LibraryDbContetx : DbContext
    {
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public LibraryDbContetx()
        {
            this.Database.EnsureCreated();
        }

        public LibraryDbContetx(DbContextOptions<LibraryDbContetx> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");


            }
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Book b0 = new Book { Id = 16, Title = "Gravity", Topic = "physics", YearOfIssue = 1687, Language = "English", Lenght = 918 };
            Book b1 = new Book { Id = 1, Title = "Concept of Zero", Topic = "Math", YearOfIssue = 1921, Language = "Italian", Lenght = 542 };
            Book b2 = new Book { Id = 2, Title = "Why you shoud  Leran Math", Topic = "Math", YearOfIssue = 1821, Language = "English", Lenght = 456 };
            Book b3 = new Book { Id = 3, Title = "Why you shoudn not  Leran Math", Topic = "Math", YearOfIssue = 1822, Language = "French", Lenght = 457 };
            Book b4 = new Book { Id = 4, Title = "Money and Credit", Topic = "Economy", YearOfIssue = 2008, Language = "English", Lenght = 231 };
            Book b5 = new Book { Id = 5, Title = "The story behind our bone structures ", Topic = "Biology", YearOfIssue = 2003, Language = "English", Lenght = 153 };
            Book b6 = new Book { Id = 6, Title = "Mind and reality", Topic = "Psychology", YearOfIssue = 1980, Language = "German", Lenght = 1200 };
            Book b7 = new Book { Id = 7, Title = "The Future of the AI", Topic = "Computer Science", YearOfIssue = 2018, Language = "English", Lenght = 720 };
            Book b8 = new Book { Id = 8, Title = "Psychology Of The Modern Man", Topic = "Psychology", YearOfIssue = 1973, Language = "German", Lenght = 582 };
            Book b9 = new Book { Id = 9, Title = "Wonders Of Imanigary Numbers", Topic = "Math", YearOfIssue = 1926, Language = "Italian", Lenght = 356 };
            Book b10 = new Book { Id = 10, Title = "Heart And Cloning ", Topic = "Biology", YearOfIssue = 2006, Language = "English", Lenght = 350 };
            Book b11 = new Book { Id = 11, Title = "Simple Computers", Topic = "Computer Science", YearOfIssue = 2011, Language = "English", Lenght = 266 };
            Book b12 = new Book { Id = 12, Title = "Child and Parents", Topic = "Psychology", YearOfIssue = 2003, Language = "Hungarian", Lenght = 450 };
            Book b13 = new Book { Id = 13, Title = "Children and Schools", Topic = "Psychology", YearOfIssue = 2010, Language = "Hungarian", Lenght = 381 };
            Book b14 = new Book { Id = 14, Title = "Basic Programming Principle", Topic = "Computer Science", YearOfIssue = 2005, Language = "English", Lenght = 302 };
            Book b15 = new Book { Id = 15, Title = "How  Get To Anoher Star System", Topic = "physics", YearOfIssue = 1998, Language = "English", Lenght = 680 };

            Author a0 = new Author { Id = 1, AuthoreName = "Isaac Newton", BirthYear = 1642, Birthcountry = "England", WritingLanguage = "English", Specialization = "physics" };
            Author a1 = new Author { Id = 2, AuthoreName = "Will Gabriel", BirthYear = 1790, Birthcountry = "England", WritingLanguage = "English", Specialization = "Math" };
            Author a2 = new Author { Id = 3, AuthoreName = "Gavino Samuele", BirthYear = 1885, Birthcountry = "Italy", WritingLanguage = "Italian", Specialization = "Math" };
            Author a3 = new Author { Id = 4, AuthoreName = "Jonathan Noa", BirthYear = 1786, Birthcountry = "France", WritingLanguage = "French", Specialization = "Math" };
            Author a4 = new Author { Id = 5, AuthoreName = "Frankie Waldo", BirthYear = 1961, Birthcountry = "England", WritingLanguage = "English", Specialization = "Economy" };
            Author a5 = new Author { Id = 6, AuthoreName = "Red Roosevelt", BirthYear = 1975, Birthcountry = "England", WritingLanguage = "English", Specialization = "Biology" };
            Author a6 = new Author { Id = 7, AuthoreName = "Sigmund Karl Dieter", BirthYear = 1935, Birthcountry = "Germany", WritingLanguage = "German", Specialization = "Psychology" };
            Author a7 = new Author { Id = 8, AuthoreName = "Dannie Loyd", BirthYear = 1980, Birthcountry = "England", WritingLanguage = "English", Specialization = "Computer Science" };
            Author a8 = new Author { Id = 9, AuthoreName = "Anna Gyöngyösi", BirthYear = 1986, Birthcountry = "Hungary", WritingLanguage = "Hungarian", Specialization = "Psychology" };
            Author a9 = new Author { Id = 10, AuthoreName = "Lambert Stanley", BirthYear = 1965, Birthcountry = "England", WritingLanguage = "English", Specialization = "physics" };

            Publisher p0 = new Publisher { Id = 1, PublisherName = "London Free Press", TelphoneNumber = 07563545, Email = "freepress@london.co", Headquarters = "London", YearOfFundation = 1610 };
            Publisher p1 = new Publisher { Id = 2, PublisherName = "Giorno Brothers", TelphoneNumber = 01256568, Email = "giorno.brothers@pressroyal.it", Headquarters = "Bologna", YearOfFundation = 1766 };
            Publisher p2 = new Publisher { Id = 3, PublisherName = "Magyar Nemzeti Nyomda", TelphoneNumber = 06305558, Email = "magyar.nyomnda@nemzeti.hu", Headquarters = "Budapest", YearOfFundation = 1820 };
            Publisher p4 = new Publisher { Id = 4, PublisherName = "La Guyane ", TelphoneNumber = 0355462545, Email = "guyane@imprimerie.fr", Headquarters = "Cayanne", YearOfFundation = 1789 };
            Publisher p5 = new Publisher { Id = 5, PublisherName = "Luther Martin Press", TelphoneNumber = 08266565, Email = "luthermartin@perss.de", Headquarters = "Nürnberg", YearOfFundation = 1762 };

            b0.PublisherID = p0.Id;
            b0.AuthorID = a0.Id;

            b1.PublisherID = p1.Id;
            b1.AuthorID = a2.Id;

            b2.PublisherID = p1.Id;
            b2.AuthorID = a1.Id;

            b3.PublisherID = p4.Id;
            b3.AuthorID = a3.Id;

            b4.PublisherID = p0.Id;
            b4.AuthorID = a4.Id;

            b5.PublisherID = p0.Id;
            b5.AuthorID = a5.Id;

            b6.PublisherID = p5.Id;
            b6.AuthorID = a6.Id;

            b7.AuthorID = a7.Id;
            b7.PublisherID = p0.Id;

            b8.AuthorID = a6.Id;
            b8.PublisherID = p5.Id;

            b9.AuthorID = a2.Id;
            b9.PublisherID = p1.Id;

            b10.AuthorID = a5.Id;
            b10.PublisherID = p0.Id;

            b11.AuthorID = a7.Id;
            b11.PublisherID = p0.Id;

            b12.AuthorID = a8.Id;
            b12.PublisherID = p2.Id;

            b13.AuthorID = a8.Id;
            b13.PublisherID = p2.Id;

            b14.AuthorID = a7.Id;
            b14.PublisherID = p0.Id;

            b15.AuthorID = a9.Id;
            b15.PublisherID = p0.Id;

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(book => book.Publishers)
                .WithMany(publishers => publishers.Books)
                .HasForeignKey(book => book.PublisherID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Book>().HasData(b0, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15);
            modelBuilder.Entity<Author>().HasData(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9);
            modelBuilder.Entity<Publisher>().HasData(p0, p1, p2, p4, p5);
        }
    }
}
