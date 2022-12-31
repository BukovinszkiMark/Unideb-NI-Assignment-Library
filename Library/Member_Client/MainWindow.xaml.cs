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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library_Client.DataProviders;
using Library_Common.Models;

namespace Member_Client
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

        public void BorrowableGridSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedBook = BorrowableGrid.SelectedItem as Book;

            if (selectedBook != null)
            {
                var window = new BookDetailsWindow(selectedBook);
                window.ShowDialog();

                BorrowableGrid.UnselectAll();
            }
        }

        public void MyBorrowsButtonClick(object sender, RoutedEventArgs args)
        {

            if (ValidateName()) 
            {
                Member member = MemberClientMemberDataProvider.GetMembers().Where(m => m.Name == NameTextBox.Text).FirstOrDefault();
                var window = new MyBorrowsWindow(member);
                window.ShowDialog();

                BorrowableGrid.UnselectAll();
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
            BorrowableGrid.ItemsSource = books;
        }

        public void ReloadButtonClick(object sender, RoutedEventArgs args)
        {
            UpdateBooksGrid();
        }

    }

}
