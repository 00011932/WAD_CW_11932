using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class Book
    {
        // book class that represents book model in the database
        public int ID { get; set; }
        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string ISBN { get; set; }

        public string Description { get; set; }

        [Required]
        public BookStatus Status { get; set; }

        public string Authors { get; set; }

        public int PageCount { get; set; }

        public enum BookStatus
        {
            Available = 0,
            Reserved = 1,
            InLoan = 2,

        }
    }
}
