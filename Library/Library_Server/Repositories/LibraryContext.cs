using Library_Common.Models;
using LibraryCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Server.Repositories
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=LibraryDb;Integrated Security=True;");
        }
    }
}
