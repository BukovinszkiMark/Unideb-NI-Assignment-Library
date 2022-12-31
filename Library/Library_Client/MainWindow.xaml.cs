using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Library_Client.DataProviders;
using Library_Common.Models;
using LibraryClient.DataProviders;
using LibraryCommon.Models;

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

        public void MembersDataGridSelectionChanged(object sender, SelectionChangedEventArgs arguments)
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

        public void AddMemberClick(object sender, RoutedEventArgs arguments)
        {
            var window = new AddMemberWindow();
            if (window.ShowDialog() ?? false)
            {
                UpdateMembersGrid();
            }
        }

        public void BooksDataGridSelectionChanged(object sender, SelectionChangedEventArgs arguments)
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

        public void ReloadButtonClick(object sender, RoutedEventArgs arguments)
        {
            UpdateMembersGrid();

            UpdateBooksGrid();
        }
    }
}
