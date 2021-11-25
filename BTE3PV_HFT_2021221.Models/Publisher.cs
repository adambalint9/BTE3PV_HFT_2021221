using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTE3PV_HFT_2021221.Models
{
    
    
        [Table("Publishers")]
        public class Publisher
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string PublisherName { get; set; }

            public int TelphoneNumber { get; set; }

            [MaxLength(100)]
            public string Email { get; set; }

            [MaxLength(100)]
            public string Headquarters { get; set; }

            public int YearOfFundation { get; set; }

            [NotMapped]
            [JsonIgnore]
             public virtual ICollection<Book> Books { get; set; }

            public Publisher()
            {
                Books = new HashSet<Book>();
            }

            public override string ToString()
            {

                string s ="Id: "+ Id+ "\n PublisherName: " + PublisherName + "\n TelphoneNumber: " + TelphoneNumber + "\n Email: " + Email + "\n Headquarters: " + Headquarters + "\n YearOfFundation:" + YearOfFundation;
                return s;
            }

    }
}
