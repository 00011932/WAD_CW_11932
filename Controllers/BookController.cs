using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Constructor injecting database context for BookController.
        private readonly BookLibraryDbContext _dbContext;

        public BookController(BookLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _dbContext.Books.ToListAsync();
            return Ok(books);
        }

        // GET: api/book/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            // creates book and saves changes
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.ID }, book);
        }

        // PUT: api/book/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            // first finds the book with given id then if it exists updates if not returns not found

            var existingBook = await _dbContext.Books.FindAsync(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.ISBN = book.ISBN;
            existingBook.Description = book.Description;
            existingBook.Status = book.Status;
            existingBook.Authors = book.Authors;
            existingBook.PageCount = book.PageCount;

            await _dbContext.SaveChangesAsync();

            return Ok(existingBook);
        }

        // DELETE: api/book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            // action for deleting book. First finds the book by its id. if it exists then delets it
            var existingBook = await _dbContext.Books.FindAsync(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(existingBook);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

