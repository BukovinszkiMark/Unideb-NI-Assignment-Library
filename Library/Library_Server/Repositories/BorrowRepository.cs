using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Library_Common.Models;
using Library_Server.Repositories;
using LibraryCommon.Models;

namespace LibraryServer.Repositories
{
    public static class BorrowRepository
    {
        private static bool _testDataAdded = false;
        public static void AddTestData()
        {
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[0].Id, BookId = BookRepository.GetBooks()[0].Id, BorrowDate = DateTime.Parse("2022-12-25T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2023-02-25T06:25:00", CultureInfo.InvariantCulture) });
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[1].Id, BookId = BookRepository.GetBooks()[1].Id, BorrowDate = DateTime.Parse("2022-09-02T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2022-11-02T06:25:00", CultureInfo.InvariantCulture) });
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[1].Id, BookId = BookRepository.GetBooks()[2].Id, BorrowDate = DateTime.Parse("2022-11-23T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2023-01-23T06:25:00", CultureInfo.InvariantCulture) });
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[1].Id, BookId = BookRepository.GetBooks()[3].Id, BorrowDate = DateTime.Parse("2021-12-23T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2022-02-23T06:25:00", CultureInfo.InvariantCulture) });
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[1].Id, BookId = BookRepository.GetBooks()[4].Id, BorrowDate = DateTime.Parse("2000-12-23T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2001-02-23T06:25:00", CultureInfo.InvariantCulture) });
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[1].Id, BookId = BookRepository.GetBooks()[5].Id, BorrowDate = DateTime.Parse("2022-12-23T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2023-02-23T06:25:00", CultureInfo.InvariantCulture) });
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[2].Id, BookId = BookRepository.GetBooks()[6].Id, BorrowDate = DateTime.Parse("2022-12-23T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2023-02-23T06:25:00", CultureInfo.InvariantCulture) });
            AddBorrow(new Borrow { MemberId = MemberRepository.GetMembers()[3].Id, BookId = BookRepository.GetBooks()[7].Id, BorrowDate = DateTime.Parse("2022-12-23T06:25:00", CultureInfo.InvariantCulture), ReturnDate = DateTime.Parse("2023-02-23T06:25:00", CultureInfo.InvariantCulture) });
        }

        public static IList<Borrow> GetBorrows()
        {
            if (!_testDataAdded)
            {
                var borrows = new List<Borrow>();

                using (var database = new LibraryContext())
                {
                    borrows = database.Borrows.ToList();
                }

                if (borrows.Count == 0)
                {
                    AddTestData();
                    _testDataAdded = true;
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
