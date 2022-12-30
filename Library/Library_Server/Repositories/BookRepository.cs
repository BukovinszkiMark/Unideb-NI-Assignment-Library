using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;

namespace Library_Server.Repositories
{
    public class BookRepository
    {

        public static bool testDataAdded = false;
        public static void AddTestData()
        {
            AddBook(new Book {Title = "A Song of Ice and Fire", Writer = "George R. R. Martin", Publisher = "Bantam Books", PublishYear = 1996 });
            AddBook(new Book {Title = "Thus Spoke Zarathustra", Writer = "Friedrich Nietzsche", Publisher = "Ernst Schmeitzner", PublishYear = 1892 });
            AddBook(new Book {Title = "12 Rules for Life", Writer = "Jordan Peterson", Publisher = "Random House Canada", PublishYear = 2018 });
            AddBook(new Book {Title = "Demokrácia Részvénytársaság", Writer = "Puzsér Róbert", Publisher = "Kossuth Kiadó Zrt.", PublishYear = 2020 });
        }

        public static IList<Book> GetBooks() 
        {
            if (!testDataAdded) 
            {
                var books = new List<Book>();

                using (var database = new LibraryContext())
                {
                    books = database.Books.ToList();
                }

                if (books.Count == 0) 
                {
                    AddTestData();
                    testDataAdded = true;
                }
            }

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
