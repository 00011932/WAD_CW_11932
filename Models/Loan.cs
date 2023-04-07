using BookLibrary.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static BookLibrary.Models.Book;

namespace BookLibrary.Models
{
    public class Loan
    {
        // loan class that represents book model in the database
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonConverter(typeof(StringToIntConverter))]
        public int ID { get; set; }

        [Required]
        [JsonConverter(typeof(StringToIntConverter))]
        public int UserId { get; set; }

        
        public User User { get; set; }
        [Required]
        [JsonConverter(typeof(StringToIntConverter))]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public DateTime DateTaken { get; set; }

        [Required]
        [JsonConverter(typeof(StringToIntConverter))]
        public int DurationPeriod { get; set; }
        


        public DateTime? ActualReturnDate { get; set; }

        public DateTime ExpectedReturnDate
        {
            get
            {
                return DateTaken.AddDays(DurationPeriod);
            }
        }

        
    }
}
