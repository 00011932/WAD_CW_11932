using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List <User> ListUsers { get; set; }
        public User user { get; set; }

        public List<Book> ListBooks { get; set; }
        public Book book { get; set; }

        public List<Loan> LoanList { get; set; }
        public Loan loan { get; set; }

    }
}
