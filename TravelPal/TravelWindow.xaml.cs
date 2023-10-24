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
using TravelPal.Models;
using TravelPal.User_Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelWindow.xaml
    /// </summary>
    public partial class TravelWindow : Window
    {
        public TravelWindow(User user)
        {
            InitializeComponent();

            lblGreetUser.Content = $"Welcome {user.Username}!";

            foreach (Travel travels in user.Travels) 
            {
                ListViewItem travelItem = new ListViewItem();
                travelItem.Content = travels.GetInfo();
                travelItem.Tag = travels;

                lstTravels.Items.Add(travelItem);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
        private void tbkProfile_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tbkInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
