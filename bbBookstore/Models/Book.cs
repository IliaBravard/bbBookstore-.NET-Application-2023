using bbBookstore.Data.Base;
using bbBookstore.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bbBookstore.Models
{
    public class Book : IEntityBase
    {
        [Key]
        public int Id { get; set; } // The book's ID number (i.e. the primary key)
        public string BookTitle { get; set; } // The book's title
        public string Description { get; set; } // The book's description
        public double Price { get; set; } // The book's price
        public string BookImage { get; set; } // The book's image
        public Genre BookGenre { get; set; } // The book's genre
        public int NumOfPages { get; set; } // The book's total number of pages
        public string ISBN { get; set; } // The book's ISBN number
        public string Review { get; set; } // The review given for a particular book

        // Defining the foreign keys for the created relationships between the entities
        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }


        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
