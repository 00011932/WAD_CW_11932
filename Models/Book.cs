using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }

        public string Description { get; set; }
        [Required]
        public BookStatus Status { get; set; }

        public List <string> Authors { get; set; }

        public int PageCount { get; set; }


        public enum BookStatus
        {
            Reserved = 0,
            InLoan = 1,
            Available = 2
        }
    }
}
