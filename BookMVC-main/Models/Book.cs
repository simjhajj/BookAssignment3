using System.ComponentModel.DataAnnotations; // Importing necessary namespace for data annotations

namespace Book_Assignment3.Models // Namespace for the Book class
{
    public class Book // Book class definition
    {
        public int Id { get; set; } // Property to store the book's ID

        public string? Title { get; set; } // Property to store the book's title (nullable string)

        [DataType(DataType.Date)] // Data type annotation for the PublicationDate property
        [Display(Name = "Publication Date")] // Display name annotation for the PublicationDate property
        public DateTime PublicationDate { get; set; } // Property to store the publication date of the book

        public string? Genre { get; set; } // Property to store the genre of the book (nullable string)

        public decimal Price { get; set; } // Property to store the price of the book
    }
}
