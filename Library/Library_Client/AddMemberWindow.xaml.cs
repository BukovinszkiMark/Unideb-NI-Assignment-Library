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
    /// Interaction logic for AddMemberWindow.xaml
    /// </summary>
    public partial class AddMemberWindow : Window
    {

        private readonly Member _member;

        public AddMemberWindow()
        {
            InitializeComponent();

            _member = new Member();

            NameTextBox.Text = _member.Name;
            NameTextBox.Text = _member.Address;
            DateOfBirthDatePicker.SelectedDate = _member.DateOfBirth;
        }

        public void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            if (ValidateMember())
            {
                _member.Name = NameTextBox.Text;
                _member.Address = AddressTextBox.Text;
                _member.DateOfBirth = DateOfBirthDatePicker.SelectedDate.Value;

                LibraryClientMemberDataProvider.CreateMember(_member);

                DialogResult = true;
                Close();
            }
        }

        public void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }


        private bool ValidateMember()
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                MessageBox.Show("Address should not be empty.");
                return false;
            }

            if (!DateOfBirthDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a date of birth date.");
                return false;
            }

            return true;
        }
    }
}
