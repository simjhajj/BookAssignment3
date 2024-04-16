using System; // Importing necessary namespaces
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core
using Book_Assignment3.Models; // Importing the Book model

namespace Book_Assignment3.Data
{
    public class BookMVCContext : DbContext // Defining a DbContext class named BookMVCContext
    {
        // Constructor to initialize the BookMVCContext with DbContextOptions
        public BookMVCContext(DbContextOptions<BookMVCContext> options)
            : base(options)
        {
        }

        // DbSet representing the Book entity in the database
        public DbSet<Book_Assignment3.Models.Book> Book { get; set; } = default!;

        // Overriding the OnModelCreating method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the Price property of the Book entity to use decimal(18,2) data type
            modelBuilder.Entity<Book_Assignment3.Models.Book>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");
        }

    }
}
