using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly BookLibraryDbContext _dbContext;

        public LoanController(BookLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // getting all loans list 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetAllLoans()
        {
            var loans = await _dbContext.Loans.Include(l => l.User).Include(l => l.Book).ToListAsync();
            return Ok(loans);
        }


        // get loan by id

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoanById(int id)
        {
            var loan = await _dbContext.Loans.Include(l => l.User).Include(l => l.Book).FirstOrDefaultAsync(l => l.ID == id);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        // create loan

        [HttpPost]
        public async Task<ActionResult<Loan>> CreateLoan(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the user and book associated with the loan
            var user = await _dbContext.Users.FindAsync(loan.UserId);
            var book = await _dbContext.Books.FindAsync(loan.BookId);

            if (user == null || book == null)
            {
                return NotFound();
            }

            // Update the loan properties
            loan.DateTaken = DateTime.Now;
            

            // Set the book status to InLoan
            book.Status = Book.BookStatus.InLoan;

            // Add the loan to the database
            _dbContext.Loans.Add(loan);
            await _dbContext.SaveChangesAsync();

            // Update the user's BooksCurrentlyOnLoan list
            if (user.BooksCurrentlyOnLoan == null)
            {
                user.BooksCurrentlyOnLoan = new List<Book>();
            }
            user.BooksCurrentlyOnLoan.Add(book);

            return CreatedAtAction(nameof(GetLoanById), new { id = loan.ID }, loan);
        }

        // update loan

        [HttpPut("{id}")]
        public async Task<ActionResult<Loan>> UpdateLoan(int id, Loan loan)
        {
            // first finds the loan with given id then if it exists updates if not returns not found
            if (id != loan.ID)
            {
                return BadRequest();
            }

            _dbContext.Entry(loan).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(loan);
        }

        // delete loan

        [HttpDelete("{id}")]
        public async Task<ActionResult<Loan>> DeleteLoan(int id)
        {
            // action for deleting loan. First finds the book by its id. if it exists then delets it
            var loan = await _dbContext.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _dbContext.Loans.Remove(loan);
            await _dbContext.SaveChangesAsync();

            return Ok(loan);

        }

        private bool LoanExists(int id)
        {
            return _dbContext.Loans.Any(e => e.ID == id);
        }
    }
}
