using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTE3PV_HFT_2021221.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
       
        public string Title { get; set; }

        [MaxLength(100)]
       
        public string Topic { get; set; }

       
        public int YearOfIssue { get; set; }

        [MaxLength(100)]
        
        public string Language { get; set; }
    

        public int Lenght { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }

        [ForeignKey(nameof(Publishers))]
        public int PublisherID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Publisher Publishers { get; set; }

        public override string ToString()
        { 
            string s =" Id: "+ Id + "\n Title: " + Title +"\n Topic: "+Topic + "\n YearOfIssue: " + YearOfIssue + "\n Language: " + Language + "\n Lenght: "  +Lenght+"\n";
            return s;
        }

    }
}
