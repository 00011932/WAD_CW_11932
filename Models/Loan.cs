using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookLibrary.Models.Book;

namespace BookLibrary.Models
{
    public class Loan
    {
        public int ID { get; set; }

        public User Loanee { get; set; }

        public Book BorrowedBook { get; set; }

        public DateTime DateTaken { get; set; }

        public int DurationPeriod { get; set; }

        public bool IsReturned { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        public DateTime ExpectedReturnDate
        {
            get
            {
                return DateTaken.AddDays(DurationPeriod);
            }
        }

        //constructor for Loan Class
        public Loan(User user, Book book)
        {
            Loanee = user;
            BorrowedBook = book;
            book.Status = BookStatus.InLoan;
            DateTaken = DateTime.Now;
            DurationPeriod = 30;  // days 
            IsReturned = false;
            Loanee.BooksCurrentlyOnLoan.Add(BorrowedBook);
        }

        public Loan(User user, Book book, int duration)
        {
            Loanee = user;
            BorrowedBook = book;
            book.Status = BookStatus.InLoan;
            DateTaken = DateTime.Now;
            DurationPeriod = duration;
            IsReturned = false;
            Loanee.BooksCurrentlyOnLoan.Add(BorrowedBook);
        }

        public void ReturnLoan()
        {
            IsReturned = true;
            BorrowedBook.Status = BookStatus.Available;
            ActualReturnDate = DateTime.Now;
            Loanee.BooksCurrentlyOnLoan.Remove(BorrowedBook);
        }
    }
}
