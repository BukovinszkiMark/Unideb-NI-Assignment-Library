using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Library_Common.Models;
using LibraryClient.DataProviders;
using LibraryCommon.Models;
using MemberClient.MyBorrowsWindowBookWithReturnDateAndOverdue;

namespace MemberClient
{
    /// <summary>
    /// Interaction logic for MyBorrowsWindow.xaml
    /// </summary>
    public partial class MyBorrowsWindow : Window
    {
        public MyBorrowsWindow(Member member)
        {
            InitializeComponent();

            UpdateBooksGrid(member);
        }

        public void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void UpdateBooksGrid(Member member)
        {
            var borrows = MemberClientBorrowDataProvider.GetBorrows().Where(b => b.MemberId == member.Id);

            List<long> bookIds = new List<long>();
            List<DateTime> returnDates = new List<DateTime>();
            List<string> overdueList = new List<string>();

            foreach (Borrow borrow in borrows)
            {
                bookIds.Add(borrow.BookId);

                returnDates.Add(borrow.ReturnDate);

                if (borrow.ReturnDate < DateTime.Now)
                {
                    overdueList.Add("Yes");
                }
                else
                {
                    overdueList.Add("No");
                }
            }

            List<BookWithReturnDateAndOverdue> books = new List<BookWithReturnDateAndOverdue>();

            int counterForList = 0;

            foreach (long id in bookIds)
            {
                Book book = MemberClientBookDataProvider.GetBooks().Where(b => b.Id == id).FirstOrDefault();

                books.Add(new BookWithReturnDateAndOverdue(book, returnDates[counterForList], overdueList[counterForList]));
                counterForList++;
            }

            books.Sort((p, q) => p.ReturnDate.CompareTo(q.ReturnDate));

            booksGrid.ItemsSource = books;
        }
    }
}
