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
using Library_Client.MemberDetailsWindowBookWithOverdue;
using Library_Common.Models;

namespace Library_Client
{
    /// <summary>
    /// Interaction logic for MemberDetailsWindow.xaml
    /// </summary>
    public partial class MemberDetailsWindow : Window
    {
        public MemberDetailsWindow(Member member)
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
            var borrows = LibraryClientBorrowDataProvider.GetBorrows().Where(b => b.MemberId == member.Id);

            List<long> bookIds = new List<long>();
            List<String> overdueList = new List<string>();

            foreach (Borrow borrow in borrows) 
            {
                bookIds.Add(borrow.BookId);

                if (borrow.ReturnDate < DateTime.Now)
                {
                    overdueList.Add("Yes");
                }
                else {
                    overdueList.Add("No");
                }
            }

            List<BookWithOverdue> books = new List<BookWithOverdue>();

            int counterForList = 0;

            foreach (long id in bookIds) 
            {
                Book book = LibraryClientBookDataProvider.GetBooks().Where(b => b.Id == id).FirstOrDefault();

                books.Add(new BookWithOverdue(book, overdueList[counterForList]));
                counterForList++;
            }

            booksGrid.ItemsSource = books;

        }

    }
}
