using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Library_Common.Models;

namespace Library_Server.Repositories
{
    public static class MemberRepository
    {
        private static bool _testDataAdded = false;
        public static void AddTestData()
        {
            AddMember(new Member { Name = "Richard Flake", Address = "Louisville, KY 40018-1234", DateOfBirth = DateTime.Parse("2002-12-05T06:25:00", CultureInfo.InvariantCulture) });
            AddMember(new Member { Name = "Hann Gothe", Address = "Nashville, TN 37011-5678", DateOfBirth = DateTime.Parse("2002-11-05T07:15:00", CultureInfo.InvariantCulture) });
            AddMember(new Member { Name = "Jonh Anderson", Address = "APO, AA 33608-1234", DateOfBirth = DateTime.Parse("2008-10-05T07:25:00", CultureInfo.InvariantCulture) });
            AddMember(new Member { Name = "TestName1", Address = "TestAddress1", DateOfBirth = DateTime.Parse("2008-10-05T07:25:00", CultureInfo.InvariantCulture) });
            AddMember(new Member { Name = "TestName2", Address = "TestAddress2", DateOfBirth = DateTime.Parse("2009-10-05T07:25:00", CultureInfo.InvariantCulture) });
            AddMember(new Member { Name = "TestName3", Address = "TestAddress3", DateOfBirth = DateTime.Parse("2010-10-05T07:25:00", CultureInfo.InvariantCulture) });
            AddMember(new Member { Name = "TestName4", Address = "TestAddress4", DateOfBirth = DateTime.Parse("2011-10-05T07:25:00", CultureInfo.InvariantCulture) });
        }

        public static IList<Member> GetMembers()
        {
            if (!_testDataAdded)
            {
                var members = new List<Member>();

                using (var database = new LibraryContext())
                {
                    members = database.Members.ToList();
                }

                if (members.Count == 0)
                {
                    AddTestData();
                    _testDataAdded = true;
                }
            }

            using (var database = new LibraryContext())
            {
                var members = database.Members.ToList();

                return members;
            }
        }

        public static Member GetMember(long id)
        {
            using (var database = new LibraryContext())
            {
                var member = database.Members.Where(m => m.Id == id).FirstOrDefault();

                return member;
            }
        }

        public static void AddMember(Member member)
        {
            using (var database = new LibraryContext())
            {
                database.Members.Add(member);
                database.SaveChanges();
            }
        }

        public static void UpdateMember(Member member)
        {
            using (var database = new LibraryContext())
            {
                database.Members.Update(member);
                database.SaveChanges();
            }
        }

        public static void DeleteMember(Member member)
        {
            using (var database = new LibraryContext())
            {
                database.Members.Remove(member);
                database.SaveChanges();
            }
        }
    }
}
