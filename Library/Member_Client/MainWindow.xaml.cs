using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Library_Common.Models;
using LibraryClient.DataProviders;
using LibraryCommon.Models;

namespace MemberClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BooksGridSelectionChanged(object sender, SelectionChangedEventArgs arguments)
        {
            var selectedBook = BooksGrid.SelectedItem as Book;

            if (selectedBook != null)
            {
                var window = new BookDetailsWindow(selectedBook);
                window.ShowDialog();

                BooksGrid.UnselectAll();
            }
        }

        public void MyBorrowsButtonClick(object sender, RoutedEventArgs arguments)
        {
            if (ValidateName())
            {
                Member member = MemberClientMemberDataProvider.GetMembers().Where(m => m.Name == NameTextBox.Text).FirstOrDefault();
                var window = new MyBorrowsWindow(member);
                window.ShowDialog();

                BooksGrid.UnselectAll();
            }
        }

        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty.");
                return false;
            }

            Member member = MemberClientMemberDataProvider.GetMembers().Where(m => m.Name == NameTextBox.Text).FirstOrDefault();

            if (member == null)
            {
                MessageBox.Show("Member does not exist.");
                return false;
            }

            return true;
        }

        private void UpdateBooksGrid()
        {
            var books = MemberClientBookDataProvider.GetBooks().ToList();
            BooksGrid.ItemsSource = books;
        }

        public void ReloadButtonClick(object sender, RoutedEventArgs arguments)
        {
            UpdateBooksGrid();
        }
    }
}
