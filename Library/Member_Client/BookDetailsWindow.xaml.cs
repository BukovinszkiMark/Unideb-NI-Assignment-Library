using System.Globalization;
using System.Linq;
using System.Windows;
using LibraryClient.DataProviders;
using LibraryCommon.Models;

namespace MemberClient
{
    /// <summary>
    /// Interaction logic for BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        private Book _currentBook;

        public BookDetailsWindow(Book book)
        {
            InitializeComponent();

            _currentBook = book;

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
                returnDateText.Content = borrow.ReturnDate.ToString(CultureInfo.InvariantCulture);
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
