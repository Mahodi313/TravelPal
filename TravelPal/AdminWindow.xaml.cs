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
        public AdminWindow()
        {
            InitializeComponent();

            foreach (var user in UserManager.users) 
            {

                ComboBoxItem item = new ComboBoxItem();
                item.Content = user.Username;
                item.Tag = user;
                cbUsers.Items.Add(item);
            }
            cbUsers.Items.RemoveAt(0); // Removes Admin because nobody likes him :( (Don't need him for this) 


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
            // ADD LATER
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                ComboBoxItem? selectedUser = cbUsers.SelectedItem as ComboBoxItem;

                if (selectedUser == null) 
                {
                    throw new NullReferenceException("You need to select user before proceeding!");
                }
                else 
                {
                    User user = (User)selectedUser.Tag;

                    foreach(Travel travel in user.Travels) 
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
