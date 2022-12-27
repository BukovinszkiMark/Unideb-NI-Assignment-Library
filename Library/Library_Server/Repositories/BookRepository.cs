using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;

namespace Library_Server.Repositories
{
    public class BookRepository
    {
        public static IList<Book> GetBooks() 
        {
            using (var database = new LibraryContext())
            {
                var books = database.Books.ToList();
                return books;
            }
        }

        public static Book GetBook(long id)
        {
            using (var database = new LibraryContext())
            {
                var book = database.Books.Where(b => b.Id == id).FirstOrDefault();
                return book;
            }
        }

        public static void AddBook(Book book)
        {
            using (var database = new LibraryContext())
            {
                database.Books.Add(book);
                database.SaveChanges();
            }
        }

        public static void UpdateBook(Book book)
        {
            using (var database = new LibraryContext())
            {
                database.Books.Update(book);
                database.SaveChanges();
            }
        }

        public static void DeleteBook(Book book)
        {
            using (var database = new LibraryContext())
            {
                database.Books.Remove(book);
                database.SaveChanges();
            }
        }
    }
}
