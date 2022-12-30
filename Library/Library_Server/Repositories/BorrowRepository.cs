using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;

namespace Library_Server.Repositories
{
    public class BorrowRepository
    {
        public static bool testDataAdded = false;
        public static void AddTestData()
        {
            AddBorrow(new Borrow { MemberId=1 , BookId=17 , BorrowDate= DateTime.Parse("2022-12-25T06:25:00"), ReturnDate= DateTime.Parse("2023-02-25T06:25:00") });
            AddBorrow(new Borrow { MemberId=2 , BookId=18 , BorrowDate= DateTime.Parse("2022-09-02T06:25:00"), ReturnDate= DateTime.Parse("2022-11-02T06:25:00") });
            AddBorrow(new Borrow { MemberId=2 , BookId=19 , BorrowDate= DateTime.Parse("2022-12-23T06:25:00"), ReturnDate= DateTime.Parse("2023-02-23T06:25:00") });
        }

        public static IList<Borrow> GetBorrows()
        {
            if (!testDataAdded)
            {
                var borrows = new List<Borrow>();

                using (var database = new LibraryContext())
                {
                    borrows = database.Borrows.ToList();
                }

                if (borrows.Count == 0)
                {
                    AddTestData();
                    testDataAdded = true;
                }
            }

            using (var database = new LibraryContext())
            {
                var borrows = database.Borrows.ToList();

                return borrows;
            }
        }

        public static Borrow GetBorrow(long id) 
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
