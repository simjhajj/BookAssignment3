using System; // Importing necessary namespaces
using Microsoft.EntityFrameworkCore.Migrations; // Importing EF Core migrations namespace

#nullable disable // Disabling nullable reference types

namespace Book_Assignment3.Migrations // Namespace for migrations
{
    /// <inheritdoc /> // Inheriting from the base Migration class
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc /> // Overriding the Up method to define the migration
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creating a new table named "Book" with specified columns
            migrationBuilder.CreateTable(
                name: "Book", // Table name
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Auto-incrementing primary key
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true), // Title column
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false), // Publication date column
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true), // Genre column
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false) // Price column
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id); // Primary key constraint
                });
        }

        /// <inheritdoc /> // Overriding the Down method to define rollback logic
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable( // Dropping the "Book" table if it exists
                name: "Book");
        }
    }
}
