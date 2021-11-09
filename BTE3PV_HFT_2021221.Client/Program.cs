using System;
using BTE3PV_HFT_2021221.Models;
using BTE3PV_HFT_2021221.Data;
using System.Linq;
using BTE3PV_HFT_2021221.Repository;

namespace BTE3PV_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext db = new LibraryDbContext();

            AuthorRepository AR = new AuthorRepository(db);

            var test = db.Books.ToList();

            Console.ReadLine();  
        }
    }
}
