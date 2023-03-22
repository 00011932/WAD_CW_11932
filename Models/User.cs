using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Type { get; set; }
        [Required]
        public string PassportNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserStatus Status { get; set; } = default;
        public List<Book> BooksCurrentlyOnLoan { get; set; }
    }

    public enum UserStatus
    {
        Pending = 0,
        Approved = 1,
        Regected = 2

    }

}
