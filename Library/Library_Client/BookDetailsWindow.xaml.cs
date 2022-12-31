using System.Globalization;
using System.Linq;
using System.Windows;
using Library_Client.DataProviders;
using Library_Common.Models;
using LibraryClient.DataProviders;
using LibraryCommon.Models;

namespace Library_Client
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
            Borrow borrow = LibraryClientBorrowDataProvider.GetBorrows().Where(b => b.BookId == book.Id).FirstOrDefault();

            if (borrow != null)
            {
                borrowedText.Content = "Yes";
                borrowedByText.Content = LibraryClientMemberDataProvider.GetMembers().Where(m => m.Id == borrow.MemberId).FirstOrDefault().Name;
                returnDateText.Content = borrow.ReturnDate.ToString(CultureInfo.InvariantCulture);

                BorrowButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                borrowedText.Content = "No";
                borrowedByText.Content = "Not Borrowed";
                returnDateText.Content = "Not Borrowed";

                ReturnButton.Visibility = Visibility.Collapsed;
            }
        }

        public void BorrowButtonClick(object sender, RoutedEventArgs e)
        {
            var window = new BorrowWindow(_currentBook);
            if (window.ShowDialog() ?? false)
            {
                DisplayBookDetails(_currentBook);
            }
        }

        public void ReturnButtonClick(object sender, RoutedEventArgs e)
        {
            LibraryClientBorrowDataProvider.DeleteBorrow(LibraryClientBorrowDataProvider.GetBorrows().Where(b => b.BookId == _currentBook.Id).FirstOrDefault().Id);
            DisplayBookDetails(_currentBook);
        }
    }
}
