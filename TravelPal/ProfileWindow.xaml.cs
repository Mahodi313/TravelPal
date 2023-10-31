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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private User currentUser;

        public ProfileWindow(User user)
        {
            InitializeComponent();
            currentUser = user;

            txtName.Text = user.Fullname;
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtPassword.Text = user.Password;
            txtBirthday.Text = user.Birthday.ToString();

            cbCountry.Items.Add(user.Location);

            cbCountry.SelectedIndex = 0;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            TravelWindow travelWindow = new(currentUser);
            travelWindow.Show();
            Close();
        }
    }
}
