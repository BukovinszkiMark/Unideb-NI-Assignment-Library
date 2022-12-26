using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Common.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
    }
}
