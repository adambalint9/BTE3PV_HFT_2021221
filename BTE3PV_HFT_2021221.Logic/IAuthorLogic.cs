using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3PV_HFT_2021221.Models;

namespace BTE3PV_HFT_2021221.Logic
{
    interface IAuthorLogic
    {
        void Create(Author author);
        void Delete(int id);
        Author Read(int id);
        IEnumerable<Author> ReadAll();
        void Update(Author author);
        IEnumerable<KeyValuePair<string, int>> CountBookByAuthor();
       
    }
}
