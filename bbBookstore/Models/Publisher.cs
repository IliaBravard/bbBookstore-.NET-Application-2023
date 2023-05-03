using bbBookstore.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace bbBookstore.Models
{
    public class Publisher : IEntityBase
    {
        [Key]
        public int ? Id { get; set; } // The publishing company's ID number (i.e., the primary key)

        [Display(Name = "Publisher")]
        [Required(ErrorMessage ="Please provide the publisher's name!")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "The first name must be between 5 and 15 letters!")]
        public string ? Name { get; set; } // The name of the publishing company

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please provide the country location of the company!")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "The country name must be between 5 and 15 letters!")]
        public string ? Country { get; set; } // The country from which each publishing company is from
        
        [Display(Name = "Year")]
        [Required(ErrorMessage = "Please provide the year the company was established!")]
        [Range(1900, 2023, ErrorMessage = "The year must be between 1900 and 2023!")]
        public int ? Year { get; set; } // The year a particular book was published

        // Cardinality
        public List<Book> ? Books { get; set; } // One publisher may publish multiple books
        int IEntityBase.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
