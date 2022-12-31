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

namespace Library_Client
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

        public void MembersDataGridSelectionChanged(object sender, SelectionChangedEventArgs args) 
        {
            var selectedMember = membersGrid.SelectedItem as Member;

            if (selectedMember != null)
            {
                var window = new MemberDetailsWindow(selectedMember);
                if (window.ShowDialog() ?? false)
                {
                    UpdateMembersGrid();
                }

                membersGrid.UnselectAll();
            }
        }

        public void AddMemberClick(object sender, RoutedEventArgs args)
        {
            var window = new AddMemberWindow();
            if (window.ShowDialog() ?? false)
            {
                UpdateMembersGrid();
            }
        }

        public void BooksDataGridSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedBook = booksGrid.SelectedItem as Book;

            if (selectedBook != null)
            {
                var window = new BookDetailsWindow(selectedBook);
                if (window.ShowDialog() ?? false)
                {
                    UpdateBooksGrid();
                }

                booksGrid.UnselectAll();
            }
        }

        private void UpdateMembersGrid()
        {
            var members = LibraryClientMemberDataProvider.GetMembers().ToList();
            membersGrid.ItemsSource = members;
        }

        private void UpdateBooksGrid()
        {
            var books = LibraryClientBookDataProvider.GetBooks().ToList();
            booksGrid.ItemsSource = books;
        }

        public void ReloadButtonClick(object sender, RoutedEventArgs args)
        {
            UpdateMembersGrid();

            UpdateBooksGrid();
        }

    }
}
