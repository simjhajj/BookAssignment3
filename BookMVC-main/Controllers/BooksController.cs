using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_Assignment3.Data;
using Book_Assignment3.Models;

namespace Book_Assignment3.Controllers
{
    // This controller manages actions related to the "Books" entity
    public class BooksController : Controller
    {
        private readonly BookMVCContext _context;

        // Constructor to initialize the controller with a database context
        public BooksController(BookMVCContext context)
        {
            _context = context;
        }

        // Action method to display a list of books
        public async Task<IActionResult> Index()
        {
            // Check if the Book entity set is not null, then retrieve and pass the list of books to the view
            // Otherwise, return a problem response
            return _context.Book != null ?
                        View(await _context.Book.ToListAsync()) :
                        Problem("Entity set 'BookMVCContext.Book' is null.");
        }

        // Action method to display details of a specific book
        public async Task<IActionResult> Details(int? id)
        {
            // Check if the provided book ID is null or the Book entity set is null
            if (id == null || _context.Book == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            // Retrieve the book with the specified ID
            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);

            // If the book is not found, return a 404 Not Found response
            if (book == null)
            {
                return NotFound();
            }

            // Pass the book details to the view
            return View(book);
        }

        // Action method to display the create book form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create - Action method to handle the creation of a new book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PublicationDate,Genre,Price")] Book book)
        {
            // If the book model is valid, add it to the context and save changes to the database
            // Then redirect to the index page
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book); // If the model is not valid, return the create book form with validation errors
        }

        // Action method to display the edit book form
        public async Task<IActionResult> Edit(int? id)
        {
            // Check if the provided book ID is null or the Book entity set is null
            if (id == null || _context.Book == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            // Retrieve the book with the specified ID
            var book = await _context.Book.FindAsync(id);
            // If the book is not found, return a 404 Not Found response
            if (book == null)
            {
                return NotFound();
            }
            // Pass the book details to the view for editing
            return View(book);
        }

        // POST: Books/Edit/5 - Action method to handle the editing of an existing book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PublicationDate,Genre,Price")] Book book)
        {
            // Check if the provided book ID matches the model's ID
            if (id != book.Id)
            {
                return NotFound(); // Return a 404 Not Found response if IDs do not match
            }

            // If the model state is valid, update the book in the context and save changes to the database
            // Then redirect to the index page
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book); // If the model state is not valid, return the edit book form with validation errors
        }

        // Action method to display the delete book confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            // Check if the provided book ID is null or the Book entity set is null
            if (id == null || _context.Book == null)
            {
                return NotFound(); // Return a 404 Not Found response
            }

            // Retrieve the book with the specified ID
            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            // If the book is not found, return a 404 Not Found response
            if (book == null)
            {
                return NotFound();
            }

            // Pass the book details to the view for confirmation of deletion
            return View(book);
        }

        // POST: Books/Delete/5 - Action method to handle the deletion of a book
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Check if the Book entity set is null
            if (_context.Book == null)
            {
                return Problem("Entity set 'BookMVCContext.Book' is null.");
            }
            // Find the book with the specified ID
            var book = await _context.Book.FindAsync(id);
            // If the book is found, remove it from the context and save changes to the database
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirect to the index page
        }

        // Helper method to check if a book with the specified ID exists
        private bool BookExists(int id)
        {
            return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
