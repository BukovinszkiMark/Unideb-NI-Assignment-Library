using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Server.Repositories
{
    public class LibraryContext : DbContext
    {
        public LibraryContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}
