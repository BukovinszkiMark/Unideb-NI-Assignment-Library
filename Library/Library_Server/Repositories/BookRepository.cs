using System.Collections.Generic;
using System.Linq;
using Library_Common.Models;
using LibraryCommon.Models;

namespace Library_Server.Repositories
{
    public static class BookRepository
    {
        private static bool _testDataAdded = false;
        public static void AddTestData()
        {
            AddBook(new Book { Title = "A Song of Ice and Fire", Writer = "George R. R. Martin", Publisher = "Bantam Books", PublishYear = 1996 });
            AddBook(new Book { Title = "Thus Spoke Zarathustra", Writer = "Friedrich Nietzsche", Publisher = "Ernst Schmeitzner", PublishYear = 1892 });
            AddBook(new Book { Title = "12 Rules for Life", Writer = "Jordan Peterson", Publisher = "Random House Canada", PublishYear = 2018 });
            AddBook(new Book { Title = "Demokrácia Részvénytársaság", Writer = "Puzsér Róbert", Publisher = "Kossuth Kiadó Zrt.", PublishYear = 2020 });
            AddBook(new Book { Title = "Állatfarm", Writer = "George Orwell", Publisher = "Secker and Warburg", PublishYear = 1945 });
            AddBook(new Book { Title = "Beyond Good and Evil", Writer = "Friedrich Nietzsche", Publisher = "Simon & Schuster", PublishYear = 1866 });
            AddBook(new Book { Title = "ExampleTitle1", Writer = "ExampleWriter1", Publisher = "ExamplePublisher1", PublishYear = 1866 });
            AddBook(new Book { Title = "ExampleTitle2", Writer = "ExampleWriter2", Publisher = "ExamplePublisher2", PublishYear = 1867 });
            AddBook(new Book { Title = "ExampleTitle3", Writer = "ExampleWriter3", Publisher = "ExamplePublisher3", PublishYear = 1868 });
            AddBook(new Book { Title = "ExampleTitle4", Writer = "ExampleWriter4", Publisher = "ExamplePublisher4", PublishYear = 1869 });
            AddBook(new Book { Title = "ExampleTitle5", Writer = "ExampleWriter5", Publisher = "ExamplePublisher5", PublishYear = 1870 });
            AddBook(new Book { Title = "ExampleTitle6", Writer = "ExampleWriter6", Publisher = "ExamplePublisher6", PublishYear = 1886 });
            AddBook(new Book { Title = "ExampleTitle7", Writer = "ExampleWriter7", Publisher = "ExamplePublisher7", PublishYear = 1896 });
            AddBook(new Book { Title = "ExampleTitle8", Writer = "ExampleWriter8", Publisher = "ExamplePublisher8", PublishYear = 1966 });
        }

        public static IList<Book> GetBooks()
        {
            if (!_testDataAdded)
            {
                var books = new List<Book>();

                using (var database = new LibraryContext())
                {
                    books = database.Books.ToList();
                }

                if (books.Count == 0)
                {
                    AddTestData();
                    _testDataAdded = true;
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
