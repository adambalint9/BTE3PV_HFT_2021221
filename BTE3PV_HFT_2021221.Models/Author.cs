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
    [Table("Authors")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [MaxLength(100)]
        [Required]
        public string AuthoreName { get; set; }

        
        public int BirthYear { get; set; }

        [MaxLength(100)]
        public string Specialization { get; set; }

        [MaxLength(100)]
        public string Birthcountry { get; set; }

        [MaxLength(100)]
        public string WritingLanguage { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            this.Books = new HashSet<Book>();
        }
        public override string ToString()
        {
            String s = "Id: " +Id+ "\n AuthoreName:" + AuthoreName+ "\n Birthcountry:" + Birthcountry+ "\n BirthYear:" + BirthYear+ "\n Specialization:" + Specialization+ "\n WritingLanguage: " + WritingLanguage+ "\n";
            return s;
        }
    }
}
