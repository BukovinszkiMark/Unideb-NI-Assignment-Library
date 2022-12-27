using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;

namespace Library_Server.Repositories
{
    public class MemberRepository
    {
        public static IList<Member> GetMembers() 
        {
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
