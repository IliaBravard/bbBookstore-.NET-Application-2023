using bbBookstore.Data.Base;
using bbBookstore.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbBookstore.Models
{
    public class NewBookVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a book title!")]
        [Display(Name="Book Title")]
        public string BookTitle { get; set; } // The book's title

        [Required(ErrorMessage = "Please enter a book description!")]
        [Display(Name = "Book Description")]
        public string Description { get; set; } // The book's Name

        [Required(ErrorMessage = "Please enter a book price!")]
        [Display(Name = "Book Price ($)")]
        public double Price { get; set; } // The book's price

        [Required(ErrorMessage = "Please include a URL for the book image!")]
        [Display(Name = "Book Image")]
        public string BookImage { get; set; } // The book's image

        [Required(ErrorMessage = "Please select a book genre!")]
        [Display(Name = "Book Genre")]
        public Genre BookGenre { get; set; } // The book's genre

        [Required(ErrorMessage = "Please enter the total number of pages for the book!")]
        [Display(Name = "Book Total Pages")]
        public int NumOfPages { get; set; } // The book's total number of pages

        [Required(ErrorMessage = "Please enter the ISBN for the book!")]
        [Display(Name = "Book ISBN")]
        public string ISBN { get; set; } // The book's ISBN number

        [Required(ErrorMessage = "Please enter the review for the book!")]
        [Display(Name = "Book Review")]
        public string Review { get; set; } // The review given for a particular book

        // Defining the foreign keys for the created relationships between the entities
        [Required(ErrorMessage = "Please select an publisher!")]
        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Please select an author!")]
        [Display(Name = "Book Author")]
        public int AuthorId { get; set; }
    }
}
