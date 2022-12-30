using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Common.Models;

namespace Library_Client.MemberDetailsWindowBookWithOverdue
{
    class BookWithOverdue
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public String Overdue { get; set; }

        public BookWithOverdue(Book book, String overdueText) 
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
