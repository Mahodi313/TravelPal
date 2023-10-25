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
using TravelPal.User_Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private User _user;
        public AddTravelWindow(IUser user)
        {
            InitializeComponent();
            _user = (User)user;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            TravelWindow travelWindow = new(_user);
            travelWindow.Show();
            Close();
        }
    }
}
