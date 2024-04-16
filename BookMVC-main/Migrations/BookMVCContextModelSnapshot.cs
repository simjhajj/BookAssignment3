﻿// <auto-generated />: Indicates that this file is auto-generated by EF Core.

using System; // Importing necessary namespaces
using Book_Assignment3.Data; // Importing BookMVCContext namespace
using Microsoft.EntityFrameworkCore; // Importing EF Core namespace
using Microsoft.EntityFrameworkCore.Infrastructure; // Importing EF Core infrastructure namespace
using Microsoft.EntityFrameworkCore.Metadata; // Importing EF Core metadata namespace
using Microsoft.EntityFrameworkCore.Storage.ValueConversion; // Importing EF Core storage value conversion namespace

#nullable disable // Disabling nullable reference types

namespace Book_Assignment3.Migrations // Namespace for migrations
{
    [DbContext(typeof(BookMVCContext))] // Specifies the DbContext associated with this model snapshot
    partial class BookMVCContextModelSnapshot : ModelSnapshot // Inheriting from ModelSnapshot class
    {
        protected override void BuildModel(ModelBuilder modelBuilder) // Overriding the BuildModel method to build the model snapshot
        {
#pragma warning disable 612, 618 // Disabling warnings related to obsolete APIs
            modelBuilder // Configuring the model
                .HasAnnotation("ProductVersion", "7.0.9") // Setting the EF Core product version
                .HasAnnotation("Relational:MaxIdentifierLength", 128); // Setting the maximum identifier length

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder); // Configuring identity columns for SQL Server

            modelBuilder.Entity("Book_Assignment3.Models.Book", b => // Configuring the "Book" entity
            {
                b.Property<int>("Id") // Defining the "Id" property as an integer
                    .ValueGeneratedOnAdd() // Generating values for "Id" on add
                    .HasColumnType("int"); // Setting the data type for "Id"

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id")); // Configuring "Id" as an identity column for SQL Server

                b.Property<string>("Genre") // Defining the "Genre" property as a string
                    .HasColumnType("nvarchar(max)"); // Setting the data type for "Genre"

                b.Property<decimal>("Price") // Defining the "Price" property as a decimal
                    .HasColumnType("decimal(18,2)"); // Setting the data type for "Price"

                b.Property<DateTime>("PublicationDate") // Defining the "PublicationDate" property as a DateTime
                    .HasColumnType("datetime2"); // Setting the data type for "PublicationDate"

                b.Property<string>("Title") // Defining the "Title" property as a string
                    .HasColumnType("nvarchar(max)"); // Setting the data type for "Title"

                b.HasKey("Id"); // Defining the primary key for the "Book" entity

                b.ToTable("Book"); // Mapping the "Book" entity to the "Book" table
            });
#pragma warning restore 612, 618 // Restoring warnings related to obsolete APIs
        }
    }
}
