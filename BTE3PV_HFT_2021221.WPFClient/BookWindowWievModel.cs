using BTE3PV_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3PV_HFT_2021221.WPFClient
{
    public class BookWindowWievModel
    {
        public RestCollection<Book> Books { get; set; }


        public BookWindowWievModel()
        {
            Books = new RestCollection<Book>("http://localhost:4854/", "Book");
        
        }
    }
}
