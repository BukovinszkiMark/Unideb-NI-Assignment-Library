using System;
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
    /// Interaction logic for BorrowWindow.xaml
    /// </summary>
    public partial class BorrowWindow : Window
    {
        private readonly Borrow _borrow;

        private Book _currentBook;

        public BorrowWindow(Book book)
        {
            InitializeComponent();

            _borrow = new Borrow();

            _currentBook = book;
        }

        public void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public void BorrowButtonClick(object sender, RoutedEventArgs e)
        {
            if (ValidateBorrow())
            {
                _borrow.BookId = _currentBook.Id;
                _borrow.MemberId = int.Parse(MemberIdTextBox.Text, CultureInfo.InvariantCulture);
                _borrow.BorrowDate = DateTime.Now;
                _borrow.ReturnDate = DateTime.Now.AddMonths(2);

                LibraryClientBorrowDataProvider.CreateBorrow(_borrow);

                DialogResult = true;
                Close();
            }
        }

        public bool ValidateBorrow()
        {
            if (string.IsNullOrEmpty(MemberIdTextBox.Text))
            {
                MessageBox.Show("Member ID should not be empty.");
                return false;
            }
            if (LibraryClientMemberDataProvider.GetMembers().Where(m => m.Id == int.Parse(MemberIdTextBox.Text, CultureInfo.InvariantCulture)).FirstOrDefault() == null)
            {
                MessageBox.Show("Member Not found.");
                return false;
            }
            return true;
        }
    }
}
