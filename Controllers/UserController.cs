using BookLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookLibraryDbContext _dbContext;

        public UserController(BookLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            //gets all the users from database
            return await _dbContext.Users.ToListAsync();
        }

        // GET: api/user/id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // action for getting only specified user by id
            var user = await _dbContext.Users.Include(u => u.BooksCurrentlyOnLoan).FirstOrDefaultAsync(u => u.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            var userJson = new
            {
                id = user.ID,
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                passportNumber = user.PassportNumber,
                createdAt = user.CreatedAt,
                status = user.Status,
                booksCurrentlyOnLoan = user.BooksCurrentlyOnLoan.Select(b => b.Title)
            };

            return Ok(userJson);
        }
        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            // // creates user and saves changes
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }

        // PUT: api/user/id
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            // updates user data where id == given id
            if (id != user.ID)
            {
                return BadRequest();
            }

            _dbContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }

        // DELETE: api/user/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // First finds the user by its id. if it exists then delets it. if not returns not found
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            // check whether user exists or not
            return _dbContext.Users.Any(e => e.ID == id);
        }
    }
}