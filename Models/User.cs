using BookLibrary.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class User
    {
        // user class that represents book model in the database
        [Key]
        public int ID { get; set; }
        [StringLength(120)]
        public string FirstName { get; set; }
        [StringLength(120)]
        public string LastName { get; set; }

 
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassportNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        
        public UserStatus Status { get; set; }= default ;
        public List<Book> BooksCurrentlyOnLoan { get; set; }
    }

    public enum UserStatus
    {
        Pending = 0,
        Approved = 1,
        Regected = 2

    } 

}
