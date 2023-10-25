using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelWindow.xaml
    /// </summary>
    public partial class TravelWindow : Window
    {
        private User User { get; set; }

        public TravelWindow(User user)
        {
            InitializeComponent();

            User = user;

            UpdateUI();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser = null;

            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
        private void tbkProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        /* When tbkInfo_Click method is clicked,
         * It will show a tutorial on
         * how to use the application
         * in the travelwindow section
         * with a Messagebox
         */
        private void tbkInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Check your travels in the list below\n" +
                            "2. Press Add Travels to book a new travel\n" +
                            "3. Press Details to show travel info or edit a travel\n" +
                            "4. Press Remove to delete a choosen travel\n" +
                            "5. To Check your profile, Press My Profile\n" +
                            "6. Press Logout to return to the start-section",
                            "Tutorial", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnRemoveTravels_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListViewItem? selectedItem = lstTravels.SelectedItem as ListViewItem;

                if (selectedItem == null)
                {
                    throw new NullReferenceException("You need to select a travel before proceeding!");
                }
                else
                {
                    Travel travelToRemove = (Travel)selectedItem.Tag;

                    TravelManager.RemoveTravel(travelToRemove, User);

                    UpdateUI();
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUI()
        {
            lblGreetUser.Content = $"Welcome {User.Username}!";

            lstTravels.Items.Clear();

            foreach (Travel travels in User.Travels)
            {
                ListViewItem travelItem = new ListViewItem();
                travelItem.Content = travels.GetInfo();
                travelItem.Tag = travels;

                lstTravels.Items.Add(travelItem);
            }
        }
    }
}
