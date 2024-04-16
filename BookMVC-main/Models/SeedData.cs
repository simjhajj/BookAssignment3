using Microsoft.EntityFrameworkCore; // Importing necessary namespaces
using Book_Assignment3.Data; // Importing the namespace for the context

namespace Book_Assignment3.Models // Namespace for the SeedData class
{
    public class SeedData // SeedData class definition
    {
        public static void Initialize(IServiceProvider serviceProvider) // Method to initialize seed data
        {
            using (var context = new BookMVCContext( // Creating a new context using the provided service provider
                serviceProvider.GetRequiredService<DbContextOptions<BookMVCContext>>())) // Getting DbContextOptions<BookMVCContext> from the service provider
            {
                if (context.Book.Any()) // Checking if there are any existing books in the database
                {
                    return; // If there are existing books, return and do nothing
                }

                // If there are no existing books, add some sample data
                context.Book.AddRange(
                    new Book // Adding a new book
                    {
                        Title = "The FairyTale", // Title of the book
                        PublicationDate = DateTime.Parse("1989-2-12"), // Publication date of the book
                        Genre = "Dark Fantasy", // Genre of the book
                        Price = 7.99M // Price of the book
                    },
                    // Adding more books with similar properties
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        PublicationDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },
                    new Book
                    {
                        Title = "The Great Gatsby",
                        PublicationDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },
                    new Book
                    {
                        Title = "The Power of Letting Go",
                        PublicationDate = DateTime.Parse("1959-4-15"),
                        Genre = "Psychological",
                        Price = 3.99M
                    }
                );

                context.SaveChanges(); // Saving changes to the database
            }
        }
    }
}
