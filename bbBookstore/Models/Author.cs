using bbBookstore.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace bbBookstore.Models
{
    public class Author : IEntityBase
    {
        [Key]
        public int ? Id { get; set; } // The author's ID number (i.e., the primary key)

        [Display(Name = "Profile")]
        [Required(ErrorMessage ="Please provide an image for the author!")]
        public string ? ProfileImage { get; set; } // The profile picture for each author

        [Display(Name = "First")]
        [Required(ErrorMessage = "Please provide a first name for the author!")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "The first name must be between 2 and 15 letters!")]
        public string ? FirstName { get; set; } // The first name of each author
        
        [Display(Name = "Last")]
        [Required(ErrorMessage = "Please provide a last name for the author!")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "The last name must be between 2 and 15 letters!")]
        public string ? LastName { get; set; } // The last name of each author

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Please provide background information for the author!")]
        public string ? Background { get; set; } // The background (bio) description for each author

        // Cardinality
        public List<Book> ? Books { get; set; } // One author can have many books written
        int IEntityBase.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
