using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;

namespace Library_Server.Repositories
{
    public class BorrowRepository
    {
        public static IList<Borrow> GetBorrows()
        {
            using (var database = new LibraryContext())
            {
                var borrows = database.Borrows.ToList();

                return borrows;
            }
        }

        public static Borrow GetBorrow(int id) 
        {
            using (var database = new LibraryContext())
            {
                var borrow = database.Borrows.Where(b => b.Id == id).FirstOrDefault();

                return borrow;
            }
        }

        public static void AddBorrow(Borrow borrow) 
        {
            using (var database = new LibraryContext())
            {
                database.Borrows.Add(borrow);
                database.SaveChanges();
            }
        }

        public static void UpdateBorrow(Borrow borrow)
        {
            using (var database = new LibraryContext())
            {
                database.Borrows.Update(borrow);
                database.SaveChanges();
            }
        }

        public static void DeleteBorrow(Borrow borrow)
        {
            using (var database = new LibraryContext())
            {
                database.Borrows.Remove(borrow);
                database.SaveChanges();
            }
        }
    }
}
