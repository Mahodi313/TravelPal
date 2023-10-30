using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private User _user;

        public AdminWindow()
        {
            InitializeComponent();

            foreach (var user in UserManager.users)
            {

                if (user is User costumer)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = costumer.Username;
                    item.Tag = costumer;
                    cbUsers.Items.Add(item);
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser = null;

            MainWindow main = new();
            main.Show();

            Close();
        }

        private void btnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            // ADD LATER - NICE TO HAVE.
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListViewItem? selectedTravel = lstUserTravels.SelectedItem as ListViewItem;

                if (selectedTravel == null)
                {
                    throw new NullReferenceException("You need to select a travel before proceeding!");
                }
                else
                {

                    Travel travelToRemove = (Travel)selectedTravel.Tag;

                    TravelManager.RemoveTravel(travelToRemove, _user);

                    //REFRESH UI

                    lstUserTravels.Items.Clear();

                    foreach (Travel travel in _user.Travels)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Content = travel.GetInfo();
                        item.Tag = travel;

                        lstUserTravels.Items.Add(item);
                    }

                    MessageBox.Show("Travel removed successfully!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem? selectedUser = cbUsers.SelectedItem as ComboBoxItem;

                if (selectedUser == null)
                {
                    throw new NullReferenceException("Selection Error!");
                }
                else
                {
                    User user = (User)selectedUser.Tag;
                    _user = user;

                    lstUserTravels.Items.Clear();

                    foreach (Travel travel in user.Travels)
                    {



                        ListViewItem item = new ListViewItem();
                        item.Content = travel.GetInfo();
                        item.Tag = travel;

                        lstUserTravels.Items.Add(item);

                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
