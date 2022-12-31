using System;
using Library_Common.Models;
using LibraryCommon.Models;

namespace Library_Client.MemberDetailsWindowBookWithOverdue
{
    public class BookWithOverdue
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public string Overdue { get; set; }

        public BookWithOverdue(Book book, string overdueText)
        {
            Id = book.Id;
            Title = book.Title;
            Writer = book.Writer;
            Publisher = book.Publisher;
            PublishYear = book.PublishYear;
            Overdue = overdueText;
        }
    }
}
