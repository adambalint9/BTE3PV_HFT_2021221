using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Models;

namespace BTE3PV_HFT_2021221.Logic
{
    interface IBookLogic
    {
        void Create(Book book);
        void Delete(int id);
        Book Read(int id);
        IEnumerable<Book> ReadAll();
        void Update(Book book);       
        IEnumerable<KeyValuePair<string, bool>> IsWritenOnTheWritersMothertounge();
        IEnumerable<KeyValuePair<string, int>> CountBookByTopic();
        IEnumerable<KeyValuePair<string, double>> AVGYeraPublished();
    }
}
