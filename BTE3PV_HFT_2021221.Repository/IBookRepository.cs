using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Models;

namespace BTE3PV_HFT_2021221.Repository
{
    public interface IBookRepository
    {
        void Create(Book car);
        void Delete(int id);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book car);
    }
}
