using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Common.Models
{
    public class Borrow
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public long MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
