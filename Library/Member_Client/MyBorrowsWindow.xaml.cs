using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library_Client.DataProviders;
using Library_Common.Models;
using Member_Client.MyBorrowsWindowBookWithReturnDateAndOverdue;

namespace Member_Client
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
            List<String> overdueList = new List<String>();

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
