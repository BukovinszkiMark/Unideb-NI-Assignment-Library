using System;
using LibraryCommon.Models;

namespace MemberClient.MyBorrowsWindowBookWithReturnDateAndOverdue
{
    public class BookWithReturnDateAndOverdue
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Overdue { get; set; }

        public BookWithReturnDateAndOverdue(Book book, DateTime returnDate, string overdue)
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
