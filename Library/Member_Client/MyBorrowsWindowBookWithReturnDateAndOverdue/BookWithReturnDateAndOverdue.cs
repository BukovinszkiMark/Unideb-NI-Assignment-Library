using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Common.Models;

namespace Member_Client.MyBorrowsWindowBookWithReturnDateAndOverdue
{
    class BookWithReturnDateAndOverdue
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public DateTime ReturnDate { get; set; }
        public String Overdue { get; set; }

        public BookWithReturnDateAndOverdue(Book book, DateTime returnDate, String overdue) 
        {
            Id = book.Id;
            Title = book.Title;
            Writer = book.Writer;
            Publisher = book.Publisher;
            PublishYear = book.PublishYear;
            ReturnDate = returnDate;
            Overdue = overdue;
        }

    }

}
