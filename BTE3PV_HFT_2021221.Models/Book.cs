using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTE3PV_HFT_2021221.Models
{
    [Table("Book")]
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
        public virtual Author Author { get; set; }

        [ForeignKey(nameof(Publishers))]
        public int PublisherID { get; set; }

        [NotMapped]
        public virtual Publisher Publishers { get; set; }

        
    }
}
