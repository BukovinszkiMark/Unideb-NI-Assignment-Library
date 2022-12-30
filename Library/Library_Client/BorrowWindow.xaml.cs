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

namespace Library_Client
{
    /// <summary>
    /// Interaction logic for BorrowWindow.xaml
    /// </summary>
    public partial class BorrowWindow : Window
    {
        private readonly Borrow _borrow;

        private Book currentBook;

        public BorrowWindow(Book book)
        {
            InitializeComponent();

            _borrow = new Borrow();

            currentBook = book;
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
                _borrow.BookId = currentBook.Id;
                _borrow.MemberId = MemberDataProvider.GetMembers().Where(m => m.Name == NameTextBox.Text).FirstOrDefault().Id;
                _borrow.BorrowDate = DateTime.Now;
                _borrow.ReturnDate = DateTime.Now.AddMonths(2);

                BorrowDataProvider.CreateBorrow(_borrow);

                DialogResult = true;
                Close();
            }
        }

        public bool ValidateBorrow() 
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty.");
                return false;
            }
            if (MemberDataProvider.GetMembers().Where(m => m.Name == NameTextBox.Text).FirstOrDefault() == null) 
            {
                MessageBox.Show("Member Not found.");
                return false;
            }
            return true;
        }
    }
}
