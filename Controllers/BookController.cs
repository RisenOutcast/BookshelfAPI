// All endpoints for the database
// Author: Metso (@RisenOutcast)

using Microsoft.AspNetCore.Mvc;
using BookshelfAPI.Models;

namespace BookshelfAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private BooksContext booksContext;
        public BooksController(BooksContext _booksContext)
        {
            booksContext = _booksContext;
        }

        // Get all books or if there are parameters, filter some books.
        [HttpGet("")]
        public ActionResult<List<Book>> Getstrings(string? author, int? year, string? publisher)
        {
            // Get all books and check if there are parameters
            // Case-insensitive comparisons
            var books = booksContext.Books.AsQueryable();
            if (!string.IsNullOrEmpty(author))
            {
                books = books.Where(book => book.Author.ToLower() == author.ToLower());
            }

            if (year.HasValue)
            {
                books = books.Where(book => book.Year == year.Value);
            }

            if (!string.IsNullOrEmpty(publisher))
            {
                books = books.Where(book => book.Publisher.ToLower() == publisher.ToLower());
            }

            return books.ToList();
        }

        // Adding new books
        [HttpPost("")]
        public ActionResult<object> PostString(Book book)
        {
            // Check that the user gave a year
            if (!book.Year.HasValue)
                return BadRequest();

            // Check if a identical book already exists
            var oldBooks = booksContext.Books.Where(book => book.Title == book.Title);
            if (oldBooks != null)
            {
                foreach (var oldBook in oldBooks)
                {
                    if (oldBook.Title == book.Title && oldBook.Author == book.Author && oldBook.Year == book.Year)
                        return BadRequest();
                }
            }

            // Add the book to the database
            booksContext.Books.Add(book);
            booksContext.SaveChanges();

            // Return the generated id (primary key) to the user
            return new { id = book.Id };
        }

        // Getting book info with id number, if the id is invalid return 404
        [HttpGet("{id}")]
        public ActionResult<Book> GetStringById(long id)
        {
            var book = booksContext.Books.FirstOrDefault(book => book.Id == id);

            if (book != null)
                return book;
            else
                return NotFound();
        }

        // Delete book with id number, if the id is invalid return 404
        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteById(long id)
        {
            var book = booksContext.Books.FirstOrDefault(book => book.Id == id);
            if (book != null)
            {
                // Remove the book
                booksContext.Books.Remove(book);
                booksContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}