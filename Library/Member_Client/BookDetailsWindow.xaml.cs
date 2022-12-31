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

namespace Member_Client
{
    /// <summary>
    /// Interaction logic for BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        Book currentBook;

        public BookDetailsWindow(Book book)
        {
            InitializeComponent();

            currentBook = book;

            DisplayBookDetails(book);
        }

        public void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public void DisplayBookDetails(Book book)
        {
            Borrow borrow = MemberClientBorrowDataProvider.GetBorrows().Where(b => b.BookId == book.Id).FirstOrDefault();

            if (borrow != null)
            {
                borrowedText.Content = "Yes";
                borrowedByText.Content = MemberClientMemberDataProvider.GetMembers().Where(m => m.Id == borrow.MemberId).FirstOrDefault().Name;
                returnDateText.Content = borrow.ReturnDate.ToString();
            }
            else
            {
                borrowedText.Content = "No";
                borrowedByText.Content = "Not Borrowed";
                returnDateText.Content = "Not Borrowed";
            }
        }

   }
}
